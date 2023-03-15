namespace Minecraft_Bedrock_Launcher
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.GradientPanel = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.Minimize_Button = new Bunifu.Framework.UI.BunifuImageButton();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.Close_Button = new Bunifu.Framework.UI.BunifuImageButton();
            this.Country_Icon = new System.Windows.Forms.PictureBox();
            this.ElipseControl = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.DragControl = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.Main_Button = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.Flag = new System.Windows.Forms.Timer(this.components);
            this.RefreshControl = new System.Windows.Forms.Timer(this.components);
            this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.GradientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Minimize_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Country_Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // GradientPanel
            // 
            this.GradientPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GradientPanel.BackgroundImage")));
            this.GradientPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GradientPanel.Controls.Add(this.Minimize_Button);
            this.GradientPanel.Controls.Add(this.Logo);
            this.GradientPanel.Controls.Add(this.Close_Button);
            this.GradientPanel.Controls.Add(this.Country_Icon);
            this.GradientPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.GradientPanel.GradientBottomLeft = System.Drawing.Color.LightGray;
            this.GradientPanel.GradientBottomRight = System.Drawing.Color.LightYellow;
            this.GradientPanel.GradientTopLeft = System.Drawing.Color.DarkOrange;
            this.GradientPanel.GradientTopRight = System.Drawing.Color.Goldenrod;
            this.GradientPanel.Location = new System.Drawing.Point(0, 0);
            this.GradientPanel.Name = "GradientPanel";
            this.GradientPanel.Quality = 10;
            this.GradientPanel.Size = new System.Drawing.Size(800, 28);
            this.GradientPanel.TabIndex = 0;
            // 
            // Minimize_Button
            // 
            this.Minimize_Button.BackColor = System.Drawing.Color.Transparent;
            this.Minimize_Button.Image = global::Minecraft_Bedrock_Launcher.Properties.Resources.minimize_icon;
            this.Minimize_Button.ImageActive = null;
            this.Minimize_Button.Location = new System.Drawing.Point(749, 3);
            this.Minimize_Button.Name = "Minimize_Button";
            this.Minimize_Button.Size = new System.Drawing.Size(22, 22);
            this.Minimize_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Minimize_Button.TabIndex = 3;
            this.Minimize_Button.TabStop = false;
            this.Minimize_Button.Zoom = 10;
            this.Minimize_Button.Click += new System.EventHandler(this.Minimize_Button_Click);
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Logo.Image = global::Minecraft_Bedrock_Launcher.Properties.Resources.minecraft_text;
            this.Logo.Location = new System.Drawing.Point(10, 4);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(100, 20);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 1;
            this.Logo.TabStop = false;
            this.Logo.Click += new System.EventHandler(this.Logo_Click);
            // 
            // Close_Button
            // 
            this.Close_Button.BackColor = System.Drawing.Color.Transparent;
            this.Close_Button.Image = global::Minecraft_Bedrock_Launcher.Properties.Resources.close_icon;
            this.Close_Button.ImageActive = null;
            this.Close_Button.Location = new System.Drawing.Point(774, 3);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(22, 22);
            this.Close_Button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Close_Button.TabIndex = 2;
            this.Close_Button.TabStop = false;
            this.Close_Button.Zoom = 10;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // Country_Icon
            // 
            this.Country_Icon.BackColor = System.Drawing.Color.Transparent;
            this.Country_Icon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Country_Icon.Image = global::Minecraft_Bedrock_Launcher.Properties.Resources.vietnam_480px;
            this.Country_Icon.Location = new System.Drawing.Point(125, 6);
            this.Country_Icon.Name = "Country_Icon";
            this.Country_Icon.Size = new System.Drawing.Size(24, 16);
            this.Country_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Country_Icon.TabIndex = 2;
            this.Country_Icon.TabStop = false;
            this.Country_Icon.Click += new System.EventHandler(this.Country_Icon_Click);
            // 
            // ElipseControl
            // 
            this.ElipseControl.ElipseRadius = 10;
            this.ElipseControl.TargetControl = this;
            // 
            // DragControl
            // 
            this.DragControl.Fixed = true;
            this.DragControl.Horizontal = true;
            this.DragControl.TargetControl = this.GradientPanel;
            this.DragControl.Vertical = true;
            // 
            // Main_Button
            // 
            this.Main_Button.AllowToggling = false;
            this.Main_Button.AnimationSpeed = 200;
            this.Main_Button.AutoGenerateColors = false;
            this.Main_Button.BackColor = System.Drawing.Color.Transparent;
            this.Main_Button.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(170)))), ((int)(((byte)(65)))));
            this.Main_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Main_Button.BackgroundImage")));
            this.Main_Button.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Main_Button.ButtonText = "Active";
            this.Main_Button.ButtonTextMarginLeft = 0;
            this.Main_Button.ColorContrastOnClick = 45;
            this.Main_Button.ColorContrastOnHover = 45;
            this.Main_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.Main_Button.CustomizableEdges = borderEdges2;
            this.Main_Button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Main_Button.DisabledBorderColor = System.Drawing.Color.Empty;
            this.Main_Button.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Main_Button.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.Main_Button.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.Main_Button.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.Main_Button.ForeColor = System.Drawing.Color.White;
            this.Main_Button.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.Main_Button.IconMarginLeft = 11;
            this.Main_Button.IconPadding = 10;
            this.Main_Button.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.Main_Button.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(170)))), ((int)(((byte)(65)))));
            this.Main_Button.IdleBorderRadius = 10;
            this.Main_Button.IdleBorderThickness = 1;
            this.Main_Button.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(170)))), ((int)(((byte)(65)))));
            this.Main_Button.IdleIconLeftImage = null;
            this.Main_Button.IdleIconRightImage = null;
            this.Main_Button.IndicateFocus = false;
            this.Main_Button.Location = new System.Drawing.Point(295, 360);
            this.Main_Button.Name = "Main_Button";
            this.Main_Button.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(150)))), ((int)(((byte)(65)))));
            this.Main_Button.onHoverState.BorderRadius = 10;
            this.Main_Button.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Main_Button.onHoverState.BorderThickness = 1;
            this.Main_Button.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(150)))), ((int)(((byte)(65)))));
            this.Main_Button.onHoverState.ForeColor = System.Drawing.Color.White;
            this.Main_Button.onHoverState.IconLeftImage = null;
            this.Main_Button.onHoverState.IconRightImage = null;
            this.Main_Button.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(170)))), ((int)(((byte)(65)))));
            this.Main_Button.OnIdleState.BorderRadius = 10;
            this.Main_Button.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Main_Button.OnIdleState.BorderThickness = 1;
            this.Main_Button.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(170)))), ((int)(((byte)(65)))));
            this.Main_Button.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.Main_Button.OnIdleState.IconLeftImage = null;
            this.Main_Button.OnIdleState.IconRightImage = null;
            this.Main_Button.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(170)))), ((int)(((byte)(65)))));
            this.Main_Button.OnPressedState.BorderRadius = 10;
            this.Main_Button.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.Main_Button.OnPressedState.BorderThickness = 1;
            this.Main_Button.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(170)))), ((int)(((byte)(65)))));
            this.Main_Button.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.Main_Button.OnPressedState.IconLeftImage = null;
            this.Main_Button.OnPressedState.IconRightImage = null;
            this.Main_Button.Size = new System.Drawing.Size(210, 45);
            this.Main_Button.TabIndex = 1;
            this.Main_Button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Main_Button.TextMarginLeft = 0;
            this.Main_Button.UseDefaultRadiusAndThickness = true;
            this.Main_Button.Click += new System.EventHandler(this.Main_Button_Click);
            // 
            // Flag
            // 
            this.Flag.Enabled = true;
            this.Flag.Interval = 1000;
            this.Flag.Tick += new System.EventHandler(this.Flag_Tick);
            // 
            // RefreshControl
            // 
            this.RefreshControl.Enabled = true;
            this.RefreshControl.Tick += new System.EventHandler(this.RefreshControl_Tick);
            // 
            // axWindowsMediaPlayer
            // 
            this.axWindowsMediaPlayer.Enabled = true;
            this.axWindowsMediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            this.axWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
            this.axWindowsMediaPlayer.Size = new System.Drawing.Size(0, 0);
            this.axWindowsMediaPlayer.TabIndex = 2;
            this.axWindowsMediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer_PlayStateChange);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Minecraft_Bedrock_Launcher.Properties.Resources.minecraft_bee;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axWindowsMediaPlayer);
            this.Controls.Add(this.Main_Button);
            this.Controls.Add(this.GradientPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft Bedrock Launcher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.GradientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Minimize_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Country_Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuGradientPanel GradientPanel;
        private Bunifu.Framework.UI.BunifuElipse ElipseControl;
        private System.Windows.Forms.PictureBox Logo;
        private Bunifu.Framework.UI.BunifuDragControl DragControl;
        private System.Windows.Forms.PictureBox Country_Icon;
        private Bunifu.Framework.UI.BunifuImageButton Close_Button;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton Main_Button;
        private Bunifu.Framework.UI.BunifuImageButton Minimize_Button;
        private System.Windows.Forms.Timer Flag;
        private System.Windows.Forms.Timer RefreshControl;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
    }
}

