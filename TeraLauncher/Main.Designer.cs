namespace TeraLauncher
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this._m = new System.Windows.Forms.Label();
            this._x = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _m
            // 
            this._m.BackColor = System.Drawing.Color.Transparent;
            this._m.ForeColor = System.Drawing.Color.White;
            this._m.Location = new System.Drawing.Point(12, 273);
            this._m.Name = "_m";
            this._m.Size = new System.Drawing.Size(184, 13);
            this._m.TabIndex = 0;
            this._m.Text = "...";
            // 
            // _x
            // 
            this._x.BackColor = System.Drawing.Color.Transparent;
            this._x.ForeColor = System.Drawing.Color.White;
            this._x.Location = new System.Drawing.Point(221, 273);
            this._x.Name = "_x";
            this._x.Size = new System.Drawing.Size(165, 13);
            this._x.TabIndex = 1;
            this._x.Text = "Patch Version : 0";
            this._x.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(395, 295);
            this.ControlBox = false;
            this.Controls.Add(this._x);
            this.Controls.Add(this._m);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aera Tera Online Launcher";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _m;
        private System.Windows.Forms.Label _x;

    }
}

