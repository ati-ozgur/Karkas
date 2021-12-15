using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Deployment.Application;

namespace Karkas.CodeGeneration.WinApp
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                var version = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                string strVersion = string.Format("Karkas Code Generation Version : v{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
                labelVersion.Text = strVersion;
            }
        }
    }
}
