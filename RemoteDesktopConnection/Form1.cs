using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSTSCLib;

namespace RemoteDesktopConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                rdp.Server = tbServer.Text;
                rdp.UserName = tbUsername.Text;
                IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
                secured.ClearTextPassword = tbPassword.Text;
                rdp.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong" + ex.StackTrace,"Click on ok"+ MessageBoxButtons.OK);   
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdp.Connected.ToString() == "1")
                {
                    rdp.Disconnect();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("You are not connected" + ex.StackTrace, "Click on ok" + MessageBoxButtons.OK);   
            }
        }
    }
}
