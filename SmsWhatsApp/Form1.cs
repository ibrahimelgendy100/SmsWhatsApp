using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsAppApi;

namespace SmsWhatsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            WhatsApp wa = new WhatsApp(txtPhone.Text,txtPassword.Text,txtName.Text,true);
            wa.OnConnectSuccess += () =>
            {
                txtStatus.Text = "Connected....";
                wa.OnLoginSuccess += (phone, data) =>
                {
                    txtStatus.Text += "\r\nConnection success !";
                    wa.SendMessage(txtTo.Text, txtMessage.Text);
                    txtStatus.Text += "\r\nMessage sent !";
                };
                wa.OnLoginFailed += (data) =>
                {
                    txtStatus.Text += string.Format("\r\nLogin failed {0}", data);
                };
                wa.Login();
            };
            wa.OnConnectFailed += (ex) =>
            {
                txtStatus.Text += string.Format("\r\nConnect failed{0}", ex.StackTrace);
            };
            wa.Connect();
        }
    }
}
