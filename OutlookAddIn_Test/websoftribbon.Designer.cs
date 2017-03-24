namespace OutlookAddIn_Test
{
    partial class websoftribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public websoftribbon()
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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.grDoc = this.Factory.CreateRibbonGroup();
            this.btnDoc = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.grDoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.grDoc);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // grDoc
            // 
            this.grDoc.Items.Add(this.btnDoc);
            this.grDoc.Label = "Document toevoegen";
            this.grDoc.Name = "grDoc";
            // 
            // btnDoc
            // 
            this.btnDoc.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnDoc.Image = global::OutlookAddIn_Test.Properties.Resources.Chrysanthemum;
            this.btnDoc.Label = "pdf";
            this.btnDoc.Name = "btnDoc";
            this.btnDoc.ShowImage = true;
            this.btnDoc.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDoc_Click);
            // 
            // websoftribbon
            // 
            this.Name = "websoftribbon";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.websoftribbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.grDoc.ResumeLayout(false);
            this.grDoc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grDoc;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDoc;
    }

    partial class ThisRibbonCollection
    {
        internal websoftribbon websoftribbon
        {
            get { return this.GetRibbon<websoftribbon>(); }
        }
    }
}
