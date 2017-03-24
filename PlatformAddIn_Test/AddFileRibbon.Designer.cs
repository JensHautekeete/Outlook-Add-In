namespace PlatformAddIn_Test
{
    partial class AddFileRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public AddFileRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tab = this.Factory.CreateRibbonTab();
            this.Bestanden = this.Factory.CreateRibbonGroup();
            this.btnFiles = this.Factory.CreateRibbonButton();
            this.Tab.SuspendLayout();
            this.Bestanden.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tab
            // 
            this.Tab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.Tab.ControlId.OfficeId = "TabNewMailMessage";
            this.Tab.Groups.Add(this.Bestanden);
            this.Tab.Label = "TabNewMailMessage";
            this.Tab.Name = "Tab";
            // 
            // Bestanden
            // 
            this.Bestanden.Items.Add(this.btnFiles);
            this.Bestanden.Label = "Bestanden";
            this.Bestanden.Name = "Bestanden";
            // 
            // btnFiles
            // 
            this.btnFiles.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnFiles.Image = global::PlatformAddIn_Test.Properties.Resources.Logo_MFC_St_Jozef_transparant_zonder_tekst_klein_grijs;
            this.btnFiles.Label = "Toevoegen van Platform";
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.ScreenTip = "Haal bestanden op van het platform.";
            this.btnFiles.ShowImage = true;
            this.btnFiles.SuperTip = "Haal bestanden uit het platform en voeg ze in je mail toe.";
            this.btnFiles.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnFiles_Click);
            // 
            // AddFileRibbon
            // 
            this.Name = "AddFileRibbon";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose";
            this.Tabs.Add(this.Tab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.AddFileRibbon_Load);
            this.Tab.ResumeLayout(false);
            this.Tab.PerformLayout();
            this.Bestanden.ResumeLayout(false);
            this.Bestanden.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Bestanden;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnFiles;
        public Microsoft.Office.Tools.Ribbon.RibbonTab Tab;
    }

    partial class ThisRibbonCollection
    {
        internal AddFileRibbon AddFileRibbon
        {
            get { return this.GetRibbon<AddFileRibbon>(); }
        }
    }
}
