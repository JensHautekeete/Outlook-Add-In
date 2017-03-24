using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.VisualBasic;


namespace PlatformAddIn_Test
{
    public partial class FileSearchForm : Form
    {
        // Kijken wat de parent folder is //
        public int Parent;


        public List<CheckBox> checkList = new List<CheckBox>();


        // afmetingen
        //private int _RTot = 660, _RSize = 20, _CCheck = 20, _CPic = 40, _CSize = 100; //sint - jozef
        private int _RTot = 800, _RSize = 25, _CCheck = 25, _CPic = 60, _CSize = 100; //sint - jozef

        // knop bovenliggende map toegankelijk maken //
        public Button ButtonOmhoog { get { return btnParent; } set { btnParent = value; } }
        public FileSearchForm() { InitializeComponent(); }

        // form load //
        private void FileSearchForm_Load(object sender, EventArgs e)
        {
            //layout van form
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ForeColor = System.Drawing.Color.Black;
            this.Size = new System.Drawing.Size(850, 550);

            //data opvragen
            Verzoeken v = new Verzoeken();
            v.Bladeren(0);
        }

        // titelbalk aanmaken //
        public void StartForm()
        {
            checkList.Clear();

            #region layout tabel
            Init.panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single; // moet weg
            Init.panel.ColumnCount = 4;
            Init.panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _CCheck));
            Init.panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _CPic));
            Init.panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, _RTot - (_CCheck + _CPic + _CSize)));
            Init.panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            Init.panel.Location = new System.Drawing.Point(13, 13);
            Init.panel.Name = "SearchTable";
            Init.panel.RowCount = 0;
            Init.panel.RowStyles.Add(new RowStyle(SizeType.Absolute, _RSize));
            Init.panel.Size = new System.Drawing.Size(_RTot, _RSize);
            Init.panel.TabIndex = 0;
            Init.panel.MinimumSize = new System.Drawing.Size(_RTot, _RSize + 1);
            Init.panel.MaximumSize = new System.Drawing.Size(_RTot, 420);
            Init.panel.AutoScroll = false;
            #endregion

            #region Header invullen
            Init.panel.Controls.Add(new Label() { Text = ((char)0x2713).ToString(), Anchor = AnchorStyles.Left, AutoSize = true, Name = "lblHead_Check"}, 0, 0);
            Init.panel.Controls.Add(new Label() { Text = "Soort", Anchor = AnchorStyles.Top, AutoSize = true, Name = "lblHead_Title", Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))) }, 1, 0);
            Init.panel.Controls.Add(new Label() { Text = "Naam", Anchor = AnchorStyles.Left, AutoSize = true, Name = "lblHead_Title", Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))) }, 2, 0);
            Init.panel.Controls.Add(new Label() { Text = "Size", Anchor = AnchorStyles.Left, AutoSize = true, Name = "lblHead_Size", Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))) }, 3, 0);
            #endregion

            Controls.Add(Init.panel);
        }


        // nieuwe rij aanmaken //
        public void AddRow(int _Rijen, string _Naam, bool _SFile, decimal _Size, string _extentie, int _Id)
        {
            Init.panel.RowStyles.Add(new RowStyle(SizeType.Absolute, _RSize));
            Init.panel.RowCount = _Rijen;

            #region checkbox check + bestandsgrootte
            //checken of checkbox nodig is
            if (_SFile == true)
            {
                string _Grootte = "";

                //grootte van bestand berekenen + benaming
                if (_Size <= 1024 * 1024) {  _Grootte = Convert.ToString(Math.Round(_Size / 1024, 0)) + " KB"; }
                else { _Grootte = Convert.ToString(Math.Round(_Size / (1024 * 1024),3)) + " MB"; }

                CheckBox cb = new CheckBox() { Text = "", Anchor = AnchorStyles.None, AutoSize = true, Name = Convert.ToString(_Naam), Tag = _extentie};//checkbox toevoegen
                Init.panel.Controls.Add(cb, 0, _Rijen);
                checkList.Add(cb);

                Init.panel.Controls.Add(new Label() { Text = _Grootte, Anchor = AnchorStyles.Left, AutoSize = true, Name = "lblGrootte_" + Convert.ToString(_Rijen) }, 3, _Rijen); //label met grootte 
            }
            #endregion

            Init.panel.Controls.Add(new Label() { Text = _extentie , Anchor = AnchorStyles.Top ,AutoSize = true, Name = "lblExt_" + Convert.ToString(_Rijen) }, 1, _Rijen);//Extentie toevoegen

            var lbl = new Label() { Text = _Naam, Anchor = AnchorStyles.Left, AutoSize = true, Name = "lblNaam_" + Convert.ToString(_Rijen), Tag = Convert.ToString(_Id) };
            if (_SFile == false) { lbl.Click += lbl_Click; } // klikinstructie                 
            Init.panel.Controls.Add(lbl, 2, _Rijen );//Titel documenten toevoegen
        }         
          

        // Tabel aanpassingen //
        public void AutoCheck(int _Rijen)
        {
            Init.panel.Size = new System.Drawing.Size(_RTot, (_RSize + 1) * (_Rijen + 1)); //tabelgrootte veranderen
            if (Init.panel.Size.Height >= 340) { Init.panel.AutoScroll = true; } // scrolbar toevoegen als er te veel files zijn
        }

        // label klik referentie //
        private void lbl_Click(object sender, EventArgs e) 
        {
            var lbl = sender as Label;
            Init.panel.Controls.Clear(); // tabel leegmaken

            Verzoeken v = new Verzoeken(); // nieuwe files laden
            v.Bladeren(Convert.ToInt16(lbl.Tag));
        }
    

        // upload knop //
        private void btnAdd_Click(object sender, EventArgs e) //knop upload
        {
            Outlook.Attachments att = null;
            string test = "";
            foreach (CheckBox cbx in checkList)
            {
                if (cbx.Checked == true)
                {
                    test += cbx.Name + "." + cbx.Tag+ Environment.NewLine;
                }              
            }
            MessageBox.Show(test);

 

            Init.f.Close();       
        }

        // knop bovenliggende map //
        private void btnParent_Click(object sender, EventArgs e) 
        {
            Init.panel.Controls.Clear(); //tabel leegmaken

            Verzoeken v = new Verzoeken(); // nieuwe files laden
            v.Bladeren(Parent);
        }

        
    }
} 