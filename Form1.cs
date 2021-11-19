using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireWallSwitcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (FireWall.IsAdministrator())
            {
                if (FireWall.Firewall_Is_Open())
                {
                    checkBox4.Checked = true;
                    //FireWall.useCommand("allprofile", "on");
                }
                else
                {
                    checkBox4.Checked = false;
                    //FireWall.useCommand("allprofile", "off");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkAll();
            if (checkBox1.Checked)
            {
                FireWall.useCommand("domainprofile", "on");
            }
            else
            {
                FireWall.useCommand("domainprofile", "off");
                checkBox4.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkAll();
            if (checkBox2.Checked)
            {
                FireWall.useCommand("privateprofile", "on");
            }
            else
            {
                FireWall.useCommand("privateprofile", "off");
                checkBox4.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkAll();
            if (checkBox3.Checked)
            {
                FireWall.useCommand("publicprofile", "on");
            }
            else
            {
                FireWall.useCommand("publicprofile", "off");
                checkBox4.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox1.Checked = checkBox2.Checked = checkBox3.Checked = true;
                //FireWall.useCommand("allprofile", "on");
            }
            else
            {
                if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
                    checkBox1.Checked = checkBox2.Checked = checkBox3.Checked = false;
                //FireWall.useCommand("allprofile", "off");
            }
        }

        private void checkAll()
        {
            if(checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
            {
                checkBox4.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FireWall.Firewall_Is_Open())
            {
                MessageBox.Show($"防火牆狀態：已啟用", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show($"防火牆狀態：未啟用", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
