namespace OutlookAddIn_Test
{
    partial class MessageRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MessageRibbon()
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
            this.messageTab = this.Factory.CreateRibbonTab();
            this.Bijlagen = this.Factory.CreateRibbonGroup();
            this.btnBijlage = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.tab1 = this.Factory.CreateRibbonTab();
            this.messageTab.SuspendLayout();
            this.Bijlagen.SuspendLayout();
            this.tab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // messageTab
            // 
            this.messageTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.messageTab.ControlId.OfficeId = "TabReadMessage";
            this.messageTab.Groups.Add(this.Bijlagen);
            this.messageTab.Label = "TabReadMessage";
            this.messageTab.Name = "messageTab";
            // 
            // Bijlagen
            // 
            this.Bijlagen.Items.Add(this.btnBijlage);
            this.Bijlagen.Label = "Bijlagen";
            this.Bijlagen.Name = "Bijlagen";
            // 
            // btnBijlage
            // 
            this.btnBijlage.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnBijlage.Image = global::OutlookAddIn_Test.Properties.Resources.Logo_MFC_St_Jozef_transparant_zonder_tekst_klein_grijs;
            this.btnBijlage.Label = "Platform";
            this.btnBijlage.Name = "btnBijlage";
            this.btnBijlage.ShowImage = true;
            // 
            // group1
            // 
            this.group1.Label = "group1";
            this.group1.Name = "group1";
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabReadMessage";
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabReadMessage";
            this.tab1.Name = "tab1";
            // 
            // MessageRibbon
            // 
            this.Name = "MessageRibbon";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.messageTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.MessageRibbon_Load);
            this.messageTab.ResumeLayout(false);
            this.messageTab.PerformLayout();
            this.Bijlagen.ResumeLayout(false);
            this.Bijlagen.PerformLayout();
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        public Microsoft.Office.Tools.Ribbon.RibbonTab messageTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup Bijlagen;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnBijlage;
    }

    partial class ThisRibbonCollection
    {
        internal MessageRibbon MessageRibbon
        {
            get { return this.GetRibbon<MessageRibbon>(); }
        }
    }
}
