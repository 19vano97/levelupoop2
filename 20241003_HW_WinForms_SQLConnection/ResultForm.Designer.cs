namespace _20241003_HW_WinForms_SQLConnection
{
    partial class ResultForm
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
            Header = new Panel();
            Footer = new Panel();
            grdEmailShow = new DataGridView();
            grdEmailDetails = new DataGridView();
            splitter1 = new Splitter();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)grdEmailShow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdEmailDetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // Header
            // 
            Header.BorderStyle = BorderStyle.Fixed3D;
            Header.Dock = DockStyle.Top;
            Header.Location = new Point(0, 0);
            Header.Margin = new Padding(2, 1, 2, 1);
            Header.Name = "Header";
            Header.Size = new Size(738, 50);
            Header.TabIndex = 0;
            Header.Paint += panel1_Paint;
            // 
            // Footer
            // 
            Footer.Dock = DockStyle.Bottom;
            Footer.Location = new Point(0, 298);
            Footer.Margin = new Padding(2, 1, 2, 1);
            Footer.Name = "Footer";
            Footer.Size = new Size(738, 46);
            Footer.TabIndex = 1;
            // 
            // grdEmailShow
            // 
            grdEmailShow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdEmailShow.Dock = DockStyle.Left;
            grdEmailShow.Location = new Point(0, 50);
            grdEmailShow.Margin = new Padding(2, 1, 2, 1);
            grdEmailShow.Name = "grdEmailShow";
            grdEmailShow.RowHeadersWidth = 82;
            grdEmailShow.Size = new Size(319, 248);
            grdEmailShow.TabIndex = 4;
            grdEmailShow.CellContentClick += dataGridView1_CellContentClick;
            // 
            // grdEmailDetails
            // 
            grdEmailDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdEmailDetails.Dock = DockStyle.Right;
            grdEmailDetails.Location = new Point(288, 50);
            grdEmailDetails.Margin = new Padding(2, 1, 2, 1);
            grdEmailDetails.Name = "grdEmailDetails";
            grdEmailDetails.RowHeadersWidth = 82;
            grdEmailDetails.Size = new Size(450, 248);
            grdEmailDetails.TabIndex = 5;
            grdEmailDetails.CellContentClick += grdEmailDetails_CellContentClick;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(319, 50);
            splitter1.Margin = new Padding(2, 1, 2, 1);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 248);
            splitter1.TabIndex = 6;
            splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(322, 50);
            splitContainer1.Margin = new Padding(2, 1, 2, 1);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            splitContainer1.Size = new Size(0, 248);
            splitContainer1.SplitterDistance = 13;
            splitContainer1.SplitterWidth = 2;
            splitContainer1.TabIndex = 7;
            // 
            // ResultForm
            // 
            AccessibleRole = AccessibleRole.OutlineButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 344);
            Controls.Add(splitContainer1);
            Controls.Add(splitter1);
            Controls.Add(grdEmailDetails);
            Controls.Add(grdEmailShow);
            Controls.Add(Footer);
            Controls.Add(Header);
            Margin = new Padding(2, 1, 2, 1);
            Name = "ResultForm";
            Text = "Control Panel";
            Load += ResultForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdEmailShow).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdEmailDetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel Header;
        private Panel Footer;
        private DataGridView grdEmailShow;
        private DataGridView grdEmailDetails;
        private Splitter splitter1;
        private SplitContainer splitContainer1;
    }
}