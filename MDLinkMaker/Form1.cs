using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDLinkMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtLink_TextChanged(object sender, EventArgs e)
        {
            // Automatische Redmine Task erkennen
            if(txtLink.Text.Contains("redmine"))
            {
                string[] parts = txtLink.Text.Split('/');
                string tasknr = parts[parts.Length - 1].ToString();
                if(tasknr.Length > 0 && tasknr.Length < 5)
                {
                    txtText.Text = "#" + tasknr;
                }
            }
        }

        private void txtResult_Enter(object sender, EventArgs e)
        {
            txtResult.Text = this.buildLink();
            txtResult.SelectAll();
        }

        private string buildLink()
        {
            string str = "";
            str = "[" + txtText.Text + "](" + txtLink.Text + ")";
            return str;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = "https://github.com/xcy7e";
            myProcess.Start();
        }
    }
}
