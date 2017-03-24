using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace OutlookAddIn_Test
{
    public partial class ThisAddIn
    {
        private Office.CommandBar _objMenuBar;
        private Office.CommandBarPopup _objNewMenuBar;
        private Outlook.Inspectors Inspectors;
        private Office.CommandBarButton _objButton;
        private string menuTag = "MyMenu";

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.MyMenuBar();
            Inspectors = this.Application.Inspectors;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see http://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region "Outlook07 Menu"
        private void MyMenuBar()
        {
            this.ErsMyMenuBar();

            try
            {
                _objMenuBar = this.Application.ActiveExplorer().CommandBars.ActiveMenuBar;
                _objNewMenuBar = (Office.CommandBarPopup)
                _objMenuBar.Controls.Add(Office.MsoControlType.msoControlPopup, missing, missing, missing, false);

                if (_objNewMenuBar != null)
                {
                    _objNewMenuBar.Caption = "My Plugin";
                    _objNewMenuBar.Tag = menuTag;
                    _objButton = (Office.CommandBarButton)_objNewMenuBar.Controls.
                    Add(Office.MsoControlType.msoControlButton, missing,
                        missing, 1, true);
                    _objButton.Style = Office.MsoButtonStyle.
                        msoButtonIconAndCaption;
                    _objButton.Caption = "Hello World";
                    //Icon 
                    _objButton.FaceId = 500;
                    _objButton.Tag = "ItemTag";
                    //EventHandler
                    _objButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(_objButton_Click);
                    _objNewMenuBar.Visible = true;
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message.ToString(), "Error Message");
            }
        }
        #endregion

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion

        #region "Event Handler"
        #region "Menu Button"

        private void _objButton_Click(Office.CommandBarButton ctrl, ref bool cancel)
        {
            try
            {
                System.Windows.Forms.MessageBox.Show("Hello World");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message.ToString());
            }
        }

        #endregion

        #region "Remove Existing"

        private void ErsMyMenuBar()
        {
            // If the menu already exists, remove it.
            try
            {
                Office.CommandBarPopup _objIsMenueExist = (Office.CommandBarPopup)
                this.Application.ActiveExplorer().CommandBars.ActiveMenuBar.FindControl(Office.MsoControlType.msoControlPopup, missing, menuTag, true, true);

                if (_objIsMenueExist != null)
                {
                    _objIsMenueExist.Delete(true);
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message.ToString(), "Error Message");
            }
        }

        #endregion
        #endregion
    }
}