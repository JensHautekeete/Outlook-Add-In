using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.VisualBasic;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;

namespace PlatformAddIn_Test
{

    public class Init
    {
        public static FileSearchForm f = new FileSearchForm();
        public static TableLayoutPanel panel = new TableLayoutPanel();
    }

    public partial class AddFileRibbon
    {
        private void AddFileRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            
        }

        private void btnFiles_Click(object sender, RibbonControlEventArgs e)
        {
            Init.f.Show(); //form laden       
        }
    }
}