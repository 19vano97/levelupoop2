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
            Header.Name = "Header";
            Header.Size = new Size(1427, 103);
            Header.TabIndex = 0;
            Header.Paint += panel1_Paint;
            // 
            // Footer
            // 
            Footer.Dock = DockStyle.Bottom;
            Footer.Location = new Point(0, 635);
            Footer.Name = "Footer";
            Footer.Size = new Size(1427, 98);
            Footer.TabIndex = 1;
            // 
            // grdEmailShow
            // 
            grdEmailShow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdEmailShow.Dock = DockStyle.Left;
            grdEmailShow.Location = new Point(0, 103);
            grdEmailShow.Name = "grdEmailShow";
            grdEmailShow.RowHeadersWidth = 82;
            grdEmailShow.Size = new Size(592, 532);
            grdEmailShow.TabIndex = 4;
            grdEmailShow.CellContentClick += dataGridView1_CellContentClick;
            // 
            // grdEmailDetails
            // 
            grdEmailDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdEmailDetails.Dock = DockStyle.Right;
            grdEmailDetails.Location = new Point(592, 103);
            grdEmailDetails.Name = "grdEmailDetails";
            grdEmailDetails.RowHeadersWidth = 82;
            grdEmailDetails.Size = new Size(835, 532);
            grdEmailDetails.TabIndex = 5;
            grdEmailDetails.CellContentClick += grdEmailDetails_CellContentClick;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(592, 103);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(6, 532);
            splitter1.TabIndex = 6;
            splitter1.TabStop = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(598, 103);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            splitContainer1.Size = new Size(0, 532);
            splitContainer1.SplitterDistance = 25;
            splitContainer1.TabIndex = 7;
            // 
            // ResultForm
            // 
            AccessibleRole = AccessibleRole.OutlineButton;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1427, 733);
            Controls.Add(splitContainer1);
            Controls.Add(splitter1);
            Controls.Add(grdEmailDetails);
            Controls.Add(grdEmailShow);
            Controls.Add(Footer);
            Controls.Add(Header);
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