using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace erstool
{
    public partial class FormSettings : Form
    {
        private ErsToolConfiguration config = null;

        public FormSettings()
        {
            InitializeComponent();
        }

        public ErsToolConfiguration Configuration 
        {
            get { return config; }
            set { config = value; }
        }

        private void LoadSettings()
        {
            textBoxPuttyPath.Text = config.PuttyPath;
            textBoxSSHUser.Text = config.SSHUser;
            textBoxSSHPassword.Text = config.SSHPassword;
        }

        private void SaveSettings()
        {
            if (String.IsNullOrEmpty(textBoxPuttyPath.Text) == false)
            {
                if (File.Exists(textBoxPuttyPath.Text))
                    config.PuttyPath = textBoxPuttyPath.Text;
            }
            if (String.IsNullOrEmpty(textBoxSSHUser.Text) == false)
                config.SSHUser = textBoxSSHUser.Text;
            else
                config.SSHUser = String.Empty;

            if (String.IsNullOrEmpty(textBoxSSHPassword.Text) == false)
                config.SSHPassword = textBoxSSHPassword.Text;
            else
                config.SSHPassword = String.Empty;

#if false
            byte[] data = System.Text.Encoding.ASCII.GetBytes(textBoxSSHPassword.Text);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            config.SSHPassword = hash;
#endif
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);

            LoadSettings();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult r = openFileDialog1.ShowDialog();
            if (r == DialogResult.OK)
            {
                textBoxPuttyPath.Text = openFileDialog1.FileName;
            }
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
                textBoxSSHPassword.PasswordChar = '\0';
            else
                textBoxSSHPassword.PasswordChar = '*';
        }
    }
}
