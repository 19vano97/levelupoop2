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
            grdActions = new Panel();
            grdResult = new Panel();
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
            // grdActions
            // 
            grdActions.Dock = DockStyle.Left;
            grdActions.Location = new Point(0, 103);
            grdActions.Name = "grdActions";
            grdActions.Size = new Size(642, 532);
            grdActions.TabIndex = 2;
            grdActions.Paint += panel3_Paint;
            // 
            // grdResult
            // 
            grdResult.Dock = DockStyle.Right;
            grdResult.Location = new Point(833, 103);
            grdResult.Name = "grdResult";
            grdResult.Size = new Size(594, 532);
            grdResult.TabIndex = 3;
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1427, 733);
            Controls.Add(grdResult);
            Controls.Add(grdActions);
            Controls.Add(Footer);
            Controls.Add(Header);
            Name = "ResultForm";
            Text = "Result";
            Load += ResultForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel Header;
        private Panel Footer;
        private Panel grdActions;
        private Panel grdResult;
    }
}