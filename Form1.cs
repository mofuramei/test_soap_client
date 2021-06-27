using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Web;
using System.Xml;
using System.ServiceModel;
using System.Net;
using System.ServiceModel.Channels;

namespace test_soap_client
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      textBox2.Text = "";

      //soapsvtest.WebService1SoapClient cl = new soapsvtest.WebService1SoapClient();

      //SSL無しの時
      //var bind = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
      
      //SSL有りの時
      var bind = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
      
      bind.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

      //ポートを8080で指定（モジュールはIIS指定先トップに直置き）
      var address = new EndpointAddress(new Uri("https://soap.testsv.jp:8080/SimpleWebService.asmx"));

      var cl = new soapsvtest.WebService1SoapClient(bind, address);
      
      //ローカルテストなのでbasic認証 ユーザーID/パスは直指定
      cl.ClientCredentials.UserName.UserName = "webtest";
      cl.ClientCredentials.UserName.Password = "aiueo";

      //AddQuote
      string value = cl.AddQuote(textBox1.Text);
      textBox2.Text = value;

      //HelloWorld
      //textBox2.Text = cl.HelloWorld();

    }

  }

}
