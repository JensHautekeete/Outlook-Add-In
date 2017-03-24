namespace PlatformAddIn_Test
{
    partial class FileSearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnParent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 369);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 26);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Upload";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnParent
            // 
            this.btnParent.Visible = false;
            this.btnParent.Location = new System.Drawing.Point(142, 369);
            this.btnParent.Name = "btnParent";
            this.btnParent.Size = new System.Drawing.Size(120, 26);
            this.btnParent.TabIndex = 2;
            this.btnParent.Text = "Bovenliggende map";
            this.btnParent.UseVisualStyleBackColor = true;
            ButtonOmhoog.Click += new System.EventHandler(this.btnParent_Click);
            // 
            // FileSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 404);
            this.Controls.Add(this.btnParent);
            this.Controls.Add(this.btnAdd);
            this.Name = "FileSearchForm";
            this.Text = "Browse";
            this.Load += new System.EventHandler(this.FileSearchForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnParent;
    }
}