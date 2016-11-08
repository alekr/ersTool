using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.IO;
using System.Net.Mime;
using System.Windows.Forms;

namespace erstool
{
    public class ErsToolConfiguration
    {
        //private string puttyPath = String.Empty;
        //private string sshUser = String.Empty;

        private String SHARED_SECRET = "ers";

        public String MainWindowSize
        {
            get { return erstool.Properties.Settings.Default.MainWindowSize; }
            set
            {
                erstool.Properties.Settings.Default.Upgrade();
                erstool.Properties.Settings.Default.MainWindowSize = value;
                erstool.Properties.Settings.Default.Save();
            }
        }

        public Int32 Site
        {
            get
            {
                String appPath = Path.GetDirectoryName(Application.ExecutablePath);
                if (appPath.EndsWith("\\") == false)
                    appPath += "\\";

                if (File.Exists("site.Harrogate"))
                    return 0;
                else
                    return 1;
            }
        }

        public String HostParamColumnWidths
        {
            get { return erstool.Properties.Settings.Default.HostParamColumnWidths; }
            set
            {
                erstool.Properties.Settings.Default.Upgrade();
                erstool.Properties.Settings.Default.HostParamColumnWidths = value;
                erstool.Properties.Settings.Default.Save();
            }
        }

        public String VirtServParamColumnWidths
        {
            get { return erstool.Properties.Settings.Default.VirtServParamColumnWidths; }
            set
            {
                erstool.Properties.Settings.Default.Upgrade();
                erstool.Properties.Settings.Default.VirtServParamColumnWidths = value;
                erstool.Properties.Settings.Default.Save();
            }
        }

        public String PuttyPath 
        {
            get { return erstool.Properties.Settings.Default.PuttyPath; }
            set
            {
                erstool.Properties.Settings.Default.Upgrade();
                erstool.Properties.Settings.Default.PuttyPath = value;
                erstool.Properties.Settings.Default.Save();
            }
        }

        public String SSHUser 
        {
            get { return erstool.Properties.Settings.Default.SSHUser; }
            set
            {
                erstool.Properties.Settings.Default.Upgrade();
                erstool.Properties.Settings.Default.SSHUser = value;
                erstool.Properties.Settings.Default.Save();
            }
        }

        public String SSHPassword
        {
            get
            {
#if false
                return erstool.Properties.Settings.Default.SSHPassword;
#else
                String temp = erstool.Properties.Settings.Default.SSHPassword.Trim();
                if (String.IsNullOrEmpty(temp))
                    return String.Empty;
                else
                    //return Crypto.DecryptStringAES(temp, SHARED_SECRET);
                    return Crypto.DecryptStringAES(temp);
#endif
            }
            set
            {
                String encryptedValue = String.Empty;
                value = value.Trim();

                if (String.IsNullOrEmpty(value) == false)
                    //encryptedValue = Crypto.EncryptStringAES(value, SHARED_SECRET);
                    encryptedValue = Crypto.EncryptStringAES(value);

                erstool.Properties.Settings.Default.Upgrade();
                erstool.Properties.Settings.Default.SSHPassword = encryptedValue;
                erstool.Properties.Settings.Default.Save();
            }
        }

#if false
        public String DefaultBrowser
        {
            get { return erstool.Properties.Settings.Default.HostParamColumnWidths; }
            set
            {
                erstool.Properties.Settings.Default.Upgrade();
                erstool.Properties.Settings.Default.HostParamColumnWidths = value;
                erstool.Properties.Settings.Default.Save();
            }
        }
#endif
    }
}
