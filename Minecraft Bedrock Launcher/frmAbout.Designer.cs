namespace Minecraft_Bedrock_Launcher
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.ElipseControl = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnMain = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.txtMain = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbMain.Image = global::Minecraft_Bedrock_Launcher.Properties.Resources.Artworks;
            this.pbMain.Location = new System.Drawing.Point(0, 0);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(220, 221);
            this.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            // 
            // ElipseControl
            // 
            this.ElipseControl.ElipseRadius = 10;
            this.ElipseControl.TargetControl = this;
            // 
            // btnMain
            // 
            this.btnMain.AllowToggling = false;
            this.btnMain.AnimationSpeed = 200;
            this.btnMain.AutoGenerateColors = false;
            this.btnMain.BackColor = System.Drawing.Color.Transparent;
            this.btnMain.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMain.BackgroundImage")));
            this.btnMain.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnMain.ButtonText = "Close";
            this.btnMain.ButtonTextMarginLeft = 0;
            this.btnMain.ColorContrastOnClick = 45;
            this.btnMain.ColorContrastOnHover = 45;
            this.btnMain.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.btnMain.CustomizableEdges = borderEdges4;
            this.btnMain.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMain.DisabledBorderColor = System.Drawing.Color.Empty;
            this.btnMain.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnMain.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnMain.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnMain.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.btnMain.ForeColor = System.Drawing.Color.Silver;
            this.btnMain.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.btnMain.IconMarginLeft = 11;
            this.btnMain.IconPadding = 10;
            this.btnMain.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.btnMain.IdleBorderColor = System.Drawing.Color.Black;
            this.btnMain.IdleBorderRadius = 5;
            this.btnMain.IdleBorderThickness = 1;
            this.btnMain.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnMain.IdleIconLeftImage = null;
            this.btnMain.IdleIconRightImage = null;
            this.btnMain.IndicateFocus = false;
            this.btnMain.Location = new System.Drawing.Point(60, 175);
            this.btnMain.Name = "btnMain";
            this.btnMain.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(232)))), ((int)(((byte)(133)))));
            this.btnMain.onHoverState.BorderRadius = 5;
            this.btnMain.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnMain.onHoverState.BorderThickness = 1;
            this.btnMain.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnMain.onHoverState.ForeColor = System.Drawing.Color.Silver;
            this.btnMain.onHoverState.IconLeftImage = null;
            this.btnMain.onHoverState.IconRightImage = null;
            this.btnMain.OnIdleState.BorderColor = System.Drawing.Color.Black;
            this.btnMain.OnIdleState.BorderRadius = 5;
            this.btnMain.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnMain.OnIdleState.BorderThickness = 1;
            this.btnMain.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnMain.OnIdleState.ForeColor = System.Drawing.Color.Silver;
            this.btnMain.OnIdleState.IconLeftImage = null;
            this.btnMain.OnIdleState.IconRightImage = null;
            this.btnMain.OnPressedState.BorderColor = System.Drawing.Color.Black;
            this.btnMain.OnPressedState.BorderRadius = 5;
            this.btnMain.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnMain.OnPressedState.BorderThickness = 1;
            this.btnMain.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnMain.OnPressedState.ForeColor = System.Drawing.Color.Silver;
            this.btnMain.OnPressedState.IconLeftImage = null;
            this.btnMain.OnPressedState.IconRightImage = null;
            this.btnMain.Size = new System.Drawing.Size(100, 30);
            this.btnMain.TabIndex = 1;
            this.btnMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMain.TextMarginLeft = 0;
            this.btnMain.UseDefaultRadiusAndThickness = true;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // txtMain
            // 
            this.txtMain.Location = new System.Drawing.Point(230, 11);
            this.txtMain.Multiline = true;
            this.txtMain.Name = "txtMain";
            this.txtMain.ReadOnly = true;
            this.txtMain.Size = new System.Drawing.Size(268, 198);
            this.txtMain.TabIndex = 2;
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(510, 221);
            this.Controls.Add(this.txtMain);
            this.Controls.Add(this.btnMain);
            this.Controls.Add(this.pbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAbout";
            this.ShowInTaskbar = false;
            this.Text = "AboutForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMain;
        private Bunifu.Framework.UI.BunifuElipse ElipseControl;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnMain;
        private System.Windows.Forms.TextBox txtMain;
    }
}