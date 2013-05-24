namespace TransformerGenerator
{
    partial class Form1
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
			this.components = new System.ComponentModel.Container();
			this.button1 = new System.Windows.Forms.Button();
			this.txtOriginalCode = new System.Windows.Forms.TextBox();
			this.txtExampleCode = new System.Windows.Forms.TextBox();
			this.txtOriginalXml = new System.Windows.Forms.TextBox();
			this.txtExampleXml = new System.Windows.Forms.TextBox();
			this.tabOriginal = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.tvOriginal = new System.Windows.Forms.TreeView();
			this.tabExample = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.tvExample = new System.Windows.Forms.TreeView();
			this.tabResult = new System.Windows.Forms.TabControl();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.txtResultCode = new System.Windows.Forms.TextBox();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.txtResultXml = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuLanguage = new System.Windows.Forms.ToolStripMenuItem();
			this.lvResult = new System.Windows.Forms.ListView();
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.lvSuggestion = new System.Windows.Forms.ListView();
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lvAccepted = new System.Windows.Forms.ListView();
			this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.tabOriginal.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.tabExample.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.tabResult.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 568);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(404, 31);
			this.button1.TabIndex = 0;
			this.button1.Text = "Analyze Inserted Example";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtOriginalCode
			// 
			this.txtOriginalCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOriginalCode.Location = new System.Drawing.Point(3, 3);
			this.txtOriginalCode.Multiline = true;
			this.txtOriginalCode.Name = "txtOriginalCode";
			this.txtOriginalCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtOriginalCode.Size = new System.Drawing.Size(394, 391);
			this.txtOriginalCode.TabIndex = 1;
			this.txtOriginalCode.WordWrap = false;
			// 
			// txtExampleCode
			// 
			this.txtExampleCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtExampleCode.Location = new System.Drawing.Point(3, 3);
			this.txtExampleCode.Multiline = true;
			this.txtExampleCode.Name = "txtExampleCode";
			this.txtExampleCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtExampleCode.Size = new System.Drawing.Size(390, 391);
			this.txtExampleCode.TabIndex = 2;
			this.txtExampleCode.WordWrap = false;
			// 
			// txtOriginalXml
			// 
			this.txtOriginalXml.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOriginalXml.Location = new System.Drawing.Point(3, 3);
			this.txtOriginalXml.Multiline = true;
			this.txtOriginalXml.Name = "txtOriginalXml";
			this.txtOriginalXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtOriginalXml.Size = new System.Drawing.Size(394, 214);
			this.txtOriginalXml.TabIndex = 3;
			this.txtOriginalXml.WordWrap = false;
			// 
			// txtExampleXml
			// 
			this.txtExampleXml.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtExampleXml.Location = new System.Drawing.Point(3, 3);
			this.txtExampleXml.Multiline = true;
			this.txtExampleXml.Name = "txtExampleXml";
			this.txtExampleXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtExampleXml.Size = new System.Drawing.Size(390, 214);
			this.txtExampleXml.TabIndex = 4;
			this.txtExampleXml.WordWrap = false;
			// 
			// tabOriginal
			// 
			this.tabOriginal.Controls.Add(this.tabPage1);
			this.tabOriginal.Controls.Add(this.tabPage2);
			this.tabOriginal.Controls.Add(this.tabPage7);
			this.tabOriginal.Location = new System.Drawing.Point(12, 31);
			this.tabOriginal.Name = "tabOriginal";
			this.tabOriginal.SelectedIndex = 0;
			this.tabOriginal.Size = new System.Drawing.Size(408, 423);
			this.tabOriginal.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtOriginalCode);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(400, 397);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Code";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.txtOriginalXml);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(400, 220);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Xml";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage7
			// 
			this.tabPage7.Controls.Add(this.tvOriginal);
			this.tabPage7.Location = new System.Drawing.Point(4, 22);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage7.Size = new System.Drawing.Size(400, 220);
			this.tabPage7.TabIndex = 2;
			this.tabPage7.Text = "TreeView";
			this.tabPage7.UseVisualStyleBackColor = true;
			// 
			// tvOriginal
			// 
			this.tvOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvOriginal.Location = new System.Drawing.Point(3, 3);
			this.tvOriginal.Name = "tvOriginal";
			this.tvOriginal.Size = new System.Drawing.Size(394, 214);
			this.tvOriginal.TabIndex = 10;
			this.tvOriginal.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOriginal_AfterSelect);
			// 
			// tabExample
			// 
			this.tabExample.Controls.Add(this.tabPage3);
			this.tabExample.Controls.Add(this.tabPage4);
			this.tabExample.Controls.Add(this.tabPage8);
			this.tabExample.Location = new System.Drawing.Point(433, 31);
			this.tabExample.Name = "tabExample";
			this.tabExample.SelectedIndex = 0;
			this.tabExample.Size = new System.Drawing.Size(404, 423);
			this.tabExample.TabIndex = 7;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.txtExampleCode);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(396, 397);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "Code";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.txtExampleXml);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(396, 220);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "Xml";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// tabPage8
			// 
			this.tabPage8.Controls.Add(this.tvExample);
			this.tabPage8.Location = new System.Drawing.Point(4, 22);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage8.Size = new System.Drawing.Size(396, 220);
			this.tabPage8.TabIndex = 2;
			this.tabPage8.Text = "TreeView";
			this.tabPage8.UseVisualStyleBackColor = true;
			// 
			// tvExample
			// 
			this.tvExample.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvExample.Location = new System.Drawing.Point(3, 3);
			this.tvExample.Name = "tvExample";
			this.tvExample.Size = new System.Drawing.Size(390, 214);
			this.tvExample.TabIndex = 11;
			this.tvExample.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tvExample_MouseMove);
			// 
			// tabResult
			// 
			this.tabResult.Controls.Add(this.tabPage5);
			this.tabResult.Controls.Add(this.tabPage6);
			this.tabResult.Location = new System.Drawing.Point(843, 31);
			this.tabResult.Name = "tabResult";
			this.tabResult.SelectedIndex = 0;
			this.tabResult.Size = new System.Drawing.Size(404, 423);
			this.tabResult.TabIndex = 8;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.txtResultCode);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(396, 397);
			this.tabPage5.TabIndex = 0;
			this.tabPage5.Text = "Code";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// txtResultCode
			// 
			this.txtResultCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtResultCode.Location = new System.Drawing.Point(3, 3);
			this.txtResultCode.Multiline = true;
			this.txtResultCode.Name = "txtResultCode";
			this.txtResultCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtResultCode.Size = new System.Drawing.Size(390, 391);
			this.txtResultCode.TabIndex = 2;
			this.txtResultCode.WordWrap = false;
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.txtResultXml);
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new System.Drawing.Size(396, 220);
			this.tabPage6.TabIndex = 1;
			this.tabPage6.Text = "Xml";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// txtResultXml
			// 
			this.txtResultXml.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtResultXml.Location = new System.Drawing.Point(3, 3);
			this.txtResultXml.Multiline = true;
			this.txtResultXml.Name = "txtResultXml";
			this.txtResultXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtResultXml.Size = new System.Drawing.Size(390, 214);
			this.txtResultXml.TabIndex = 4;
			this.txtResultXml.WordWrap = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLanguage});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1275, 26);
			this.menuStrip1.TabIndex = 9;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuLanguage
			// 
			this.menuLanguage.Name = "menuLanguage";
			this.menuLanguage.Size = new System.Drawing.Size(76, 22);
			this.menuLanguage.Text = "Language";
			// 
			// lvResult
			// 
			this.lvResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
			this.lvResult.Location = new System.Drawing.Point(12, 460);
			this.lvResult.MultiSelect = false;
			this.lvResult.Name = "lvResult";
			this.lvResult.Size = new System.Drawing.Size(404, 102);
			this.lvResult.TabIndex = 10;
			this.lvResult.UseCompatibleStateImageBehavior = false;
			this.lvResult.View = System.Windows.Forms.View.Details;
			this.lvResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvResult_MouseDoubleClick);
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Text";
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Element";
			this.columnHeader1.Width = 69;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Parent";
			this.columnHeader3.Width = 76;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Previous";
			this.columnHeader4.Width = 68;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Next";
			this.columnHeader5.Width = 75;
			// 
			// lvSuggestion
			// 
			this.lvSuggestion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
			this.lvSuggestion.Location = new System.Drawing.Point(433, 460);
			this.lvSuggestion.MultiSelect = false;
			this.lvSuggestion.Name = "lvSuggestion";
			this.lvSuggestion.Size = new System.Drawing.Size(404, 102);
			this.lvSuggestion.TabIndex = 11;
			this.lvSuggestion.UseCompatibleStateImageBehavior = false;
			this.lvSuggestion.View = System.Windows.Forms.View.Details;
			this.lvSuggestion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvSuggestion_MouseDoubleClick);
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Direction";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Element";
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "#Insertions";
			this.columnHeader8.Width = 79;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "#Examples";
			this.columnHeader9.Width = 87;
			// 
			// lvAccepted
			// 
			this.lvAccepted.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
			this.lvAccepted.Location = new System.Drawing.Point(843, 460);
			this.lvAccepted.MultiSelect = false;
			this.lvAccepted.Name = "lvAccepted";
			this.lvAccepted.Size = new System.Drawing.Size(397, 102);
			this.lvAccepted.TabIndex = 12;
			this.lvAccepted.UseCompatibleStateImageBehavior = false;
			this.lvAccepted.View = System.Windows.Forms.View.Details;
			this.lvAccepted.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvAccepted_MouseDoubleClick);
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Direction";
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "Element";
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "#Insertions";
			this.columnHeader12.Width = 79;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "#Examples";
			this.columnHeader13.Width = 87;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(843, 568);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(404, 31);
			this.button2.TabIndex = 13;
			this.button2.Text = "Apply Insertion";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(433, 568);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(404, 31);
			this.button3.TabIndex = 17;
			this.button3.Text = "Analyze Deleted Example";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1275, 603);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.lvAccepted);
			this.Controls.Add(this.lvSuggestion);
			this.Controls.Add(this.lvResult);
			this.Controls.Add(this.tabResult);
			this.Controls.Add(this.tabExample);
			this.Controls.Add(this.tabOriginal);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tabOriginal.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage7.ResumeLayout(false);
			this.tabExample.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.tabPage8.ResumeLayout(false);
			this.tabResult.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.tabPage6.ResumeLayout(false);
			this.tabPage6.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtOriginalCode;
        private System.Windows.Forms.TextBox txtExampleCode;
        private System.Windows.Forms.TextBox txtOriginalXml;
		private System.Windows.Forms.TextBox txtExampleXml;
		private System.Windows.Forms.TabControl tabOriginal;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabControl tabExample;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabControl tabResult;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TextBox txtResultCode;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.TextBox txtResultXml;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuLanguage;
		private System.Windows.Forms.TreeView tvOriginal;
		private System.Windows.Forms.TabPage tabPage7;
		private System.Windows.Forms.ListView lvResult;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.TabPage tabPage8;
		private System.Windows.Forms.TreeView tvExample;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ListView lvSuggestion;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ListView lvAccepted;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
    }
}

