namespace Minecraft_Bedrock_Launcher
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ElipseControl = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Main_Button = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::Minecraft_Bedrock_Launcher.Properties.Resources.Artworks;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 220);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ElipseControl
            // 
            this.ElipseControl.ElipseRadius = 10;
            this.ElipseControl.TargetControl = this;
            // 
            // Main_Button
            // 
            this.Main_Button.AllowToggling = false;
            this.Main_Button.AnimationSpeed = 200;
            this.Main_Button.AutoGenerateColors = false;
            this.Main_Button.BackColor = System.Drawing.Color.Transparent;
            this.Main_Button.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.Main_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Main_Button.BackgroundImage")));
            this.Main_Button.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Main_Button.ButtonText = "Close";
            this.Main_Button.ButtonTextMarginLeft = 0;
            this.Main_Button.ColorContrastOnClick = 45;
            this.Main_Button.ColorContrastOnHover = 45;
            this.Main_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.Main_Button.CustomizableEdges = borderEdges1;
            this.Main_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Main_Button.DisabledBorderColor = System.Drawing.Color.Empty;
            this.Main_Button.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Main_Button.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.Main_Button.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.Main_Button.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.Main_Button.ForeColor = System.Drawing.Color.Silver;
            this.Main_Button.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.Main_Button.IconMarginLeft = 11;
            this.Main_Button.IconPadding = 10;
            this.Main_Button.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.Main_Button.IdleBorderColor = System.Drawing.Color.Black;
            this.Main_Button.IdleBorderRadius = 5;
            this.Main_Button.IdleBorderThickness = 1;
            this.Main_Button.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.Main_Button.IdleIconLeftImage = null;
            this.Main_Button.IdleIconRightImage = null;
            this.Main_Button.IndicateFocus = false;
            this.Main_Button.Location = new System.Drawing.Point(60, 175);
            this.Main_Button.Name = "Main_Button";
            this.Main_Button.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(232)))), ((int)(((byte)(133)))));
            this.Main_Button.onHoverState.BorderRadius = 5;
            this.Main_Button.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Main_Button.onHoverState.BorderThickness = 1;
            this.Main_Button.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Main_Button.onHoverState.ForeColor = System.Drawing.Color.Silver;
            this.Main_Button.onHoverState.IconLeftImage = null;
            this.Main_Button.onHoverState.IconRightImage = null;
            this.Main_Button.OnIdleState.BorderColor = System.Drawing.Color.Black;
            this.Main_Button.OnIdleState.BorderRadius = 5;
            this.Main_Button.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Main_Button.OnIdleState.BorderThickness = 1;
            this.Main_Button.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.Main_Button.OnIdleState.ForeColor = System.Drawing.Color.Silver;
            this.Main_Button.OnIdleState.IconLeftImage = null;
            this.Main_Button.OnIdleState.IconRightImage = null;
            this.Main_Button.OnPressedState.BorderColor = System.Drawing.Color.Black;
            this.Main_Button.OnPressedState.BorderRadius = 5;
            this.Main_Button.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Main_Button.OnPressedState.BorderThickness = 1;
            this.Main_Button.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.Main_Button.OnPressedState.ForeColor = System.Drawing.Color.Silver;
            this.Main_Button.OnPressedState.IconLeftImage = null;
            this.Main_Button.OnPressedState.IconRightImage = null;
            this.Main_Button.Size = new System.Drawing.Size(100, 30);
            this.Main_Button.TabIndex = 1;
            this.Main_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Main_Button.TextMarginLeft = 0;
            this.Main_Button.UseDefaultRadiusAndThickness = true;
            this.Main_Button.Click += new System.EventHandler(this.Main_Button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(230, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(258, 196);
            this.textBox1.TabIndex = 2;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(500, 220);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Main_Button);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.Text = "AboutForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuElipse ElipseControl;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton Main_Button;
        private System.Windows.Forms.TextBox textBox1;
    }
}