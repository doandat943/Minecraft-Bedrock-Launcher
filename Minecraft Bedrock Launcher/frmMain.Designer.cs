namespace Minecraft_Bedrock_Launcher
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.ToggleSwitch.ToggleState toggleState1 = new Bunifu.ToggleSwitch.ToggleState();
            Bunifu.ToggleSwitch.ToggleState toggleState2 = new Bunifu.ToggleSwitch.ToggleState();
            Bunifu.ToggleSwitch.ToggleState toggleState3 = new Bunifu.ToggleSwitch.ToggleState();
            this.pnGradient = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnMinimize = new Bunifu.Framework.UI.BunifuImageButton();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.pbFlag = new System.Windows.Forms.PictureBox();
            this.ctrElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.ctrDrag = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.ctrTimer = new System.Windows.Forms.Timer(this.components);
            this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMain = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnSwitch = new Bunifu.ToggleSwitch.BunifuToggleSwitch();
            this.pnGradient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnGradient
            // 
            this.pnGradient.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnGradient.BackgroundImage")));
            this.pnGradient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnGradient.Controls.Add(this.btnMinimize);
            this.pnGradient.Controls.Add(this.pbLogo);
            this.pnGradient.Controls.Add(this.btnClose);
            this.pnGradient.Controls.Add(this.pbFlag);
            this.pnGradient.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnGradient.GradientBottomLeft = System.Drawing.Color.LightGray;
            this.pnGradient.GradientBottomRight = System.Drawing.Color.LightYellow;
            this.pnGradient.GradientTopLeft = System.Drawing.Color.DarkOrange;
            this.pnGradient.GradientTopRight = System.Drawing.Color.Goldenrod;
            this.pnGradient.Location = new System.Drawing.Point(0, 0);
            this.pnGradient.Name = "pnGradient";
            this.pnGradient.Quality = 10;
            this.pnGradient.Size = new System.Drawing.Size(800, 28);
            this.pnGradient.TabIndex = 0;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Image = global::Minecraft_Bedrock_Launcher.Properties.Resources.minimize_icon;
            this.btnMinimize.ImageActive = null;
            this.btnMinimize.Location = new System.Drawing.Point(749, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(22, 22);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Zoom = 10;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLogo.Image = global::Minecraft_Bedrock_Launcher.Properties.Resources.minecraft_text;
            this.pbLogo.Location = new System.Drawing.Point(10, 4);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(100, 20);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;
            this.pbLogo.Click += new System.EventHandler(this.pbLogo_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = global::Minecraft_Bedrock_Launcher.Properties.Resources.close_icon;
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(774, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(22, 22);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 2;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbFlag
            // 
            this.pbFlag.BackColor = System.Drawing.Color.Transparent;
            this.pbFlag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbFlag.Image = global::Minecraft_Bedrock_Launcher.Properties.Resources.vietnam_480px;
            this.pbFlag.Location = new System.Drawing.Point(125, 6);
            this.pbFlag.Name = "pbFlag";
            this.pbFlag.Size = new System.Drawing.Size(24, 16);
            this.pbFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFlag.TabIndex = 2;
            this.pbFlag.TabStop = false;
            this.pbFlag.Click += new System.EventHandler(this.pbFlag_Click);
            // 
            // ctrElipse
            // 
            this.ctrElipse.ElipseRadius = 10;
            this.ctrElipse.TargetControl = this;
            // 
            // ctrDrag
            // 
            this.ctrDrag.Fixed = true;
            this.ctrDrag.Horizontal = true;
            this.ctrDrag.TargetControl = this.pnGradient;
            this.ctrDrag.Vertical = true;
            // 
            // ctrTimer
            // 
            this.ctrTimer.Enabled = true;
            this.ctrTimer.Interval = 1000;
            this.ctrTimer.Tick += new System.EventHandler(this.timer_Tick);
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
            // panel1
            // 
            this.panel1.BackgroundImage = global::Minecraft_Bedrock_Launcher.Properties.Resources.minecraft_bee;
            this.panel1.Controls.Add(this.btnMain);
            this.panel1.Controls.Add(this.axWindowsMediaPlayer);
            this.panel1.Controls.Add(this.btnSwitch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 3;
            // 
            // btnMain
            // 
            this.btnMain.AllowToggling = false;
            this.btnMain.AnimationSpeed = 200;
            this.btnMain.AutoGenerateColors = false;
            this.btnMain.BackColor = System.Drawing.Color.Transparent;
            this.btnMain.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(170)))), ((int)(((byte)(65)))));
            this.btnMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMain.BackgroundImage")));
            this.btnMain.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnMain.ButtonText = "Active";
            this.btnMain.ButtonTextMarginLeft = 0;
            this.btnMain.ColorContrastOnClick = 45;
            this.btnMain.ColorContrastOnHover = 45;
            this.btnMain.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnMain.CustomizableEdges = borderEdges1;
            this.btnMain.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMain.DisabledBorderColor = System.Drawing.Color.Empty;
            this.btnMain.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnMain.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnMain.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnMain.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.btnMain.ForeColor = System.Drawing.Color.White;
            this.btnMain.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.btnMain.IconMarginLeft = 11;
            this.btnMain.IconPadding = 10;
            this.btnMain.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.btnMain.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(170)))), ((int)(((byte)(65)))));
            this.btnMain.IdleBorderRadius = 10;
            this.btnMain.IdleBorderThickness = 1;
            this.btnMain.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(170)))), ((int)(((byte)(65)))));
            this.btnMain.IdleIconLeftImage = null;
            this.btnMain.IdleIconRightImage = null;
            this.btnMain.IndicateFocus = false;
            this.btnMain.Location = new System.Drawing.Point(295, 334);
            this.btnMain.Name = "btnMain";
            this.btnMain.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(150)))), ((int)(((byte)(65)))));
            this.btnMain.onHoverState.BorderRadius = 10;
            this.btnMain.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnMain.onHoverState.BorderThickness = 1;
            this.btnMain.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(150)))), ((int)(((byte)(65)))));
            this.btnMain.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnMain.onHoverState.IconLeftImage = null;
            this.btnMain.onHoverState.IconRightImage = null;
            this.btnMain.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(170)))), ((int)(((byte)(65)))));
            this.btnMain.OnIdleState.BorderRadius = 10;
            this.btnMain.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnMain.OnIdleState.BorderThickness = 1;
            this.btnMain.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(170)))), ((int)(((byte)(65)))));
            this.btnMain.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnMain.OnIdleState.IconLeftImage = null;
            this.btnMain.OnIdleState.IconRightImage = null;
            this.btnMain.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(170)))), ((int)(((byte)(65)))));
            this.btnMain.OnPressedState.BorderRadius = 10;
            this.btnMain.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnMain.OnPressedState.BorderThickness = 1;
            this.btnMain.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(170)))), ((int)(((byte)(65)))));
            this.btnMain.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnMain.OnPressedState.IconLeftImage = null;
            this.btnMain.OnPressedState.IconRightImage = null;
            this.btnMain.Size = new System.Drawing.Size(210, 45);
            this.btnMain.TabIndex = 4;
            this.btnMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMain.TextMarginLeft = 0;
            this.btnMain.UseDefaultRadiusAndThickness = true;
            // 
            // btnSwitch
            // 
            this.btnSwitch.Animation = 5;
            this.btnSwitch.BackColor = System.Drawing.Color.Transparent;
            this.btnSwitch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSwitch.BackgroundImage")));
            this.btnSwitch.Checked = true;
            this.btnSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSwitch.InnerCirclePadding = 3;
            this.btnSwitch.Location = new System.Drawing.Point(383, 394);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(35, 18);
            this.btnSwitch.TabIndex = 5;
            toggleState1.BackColor = System.Drawing.Color.Empty;
            toggleState1.BackColorInner = System.Drawing.Color.Empty;
            toggleState1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(0)))), ((int)(((byte)(140)))));
            toggleState1.BorderColorInner = System.Drawing.Color.Empty;
            toggleState1.BorderRadius = 1;
            toggleState1.BorderRadiusInner = 1;
            toggleState1.BorderThickness = 1;
            toggleState1.BorderThicknessInner = 1;
            this.btnSwitch.ToggleStateDisabled = toggleState1;
            toggleState2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(179)))), ((int)(((byte)(46)))));
            toggleState2.BackColorInner = System.Drawing.Color.White;
            toggleState2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(179)))), ((int)(((byte)(46)))));
            toggleState2.BorderColorInner = System.Drawing.Color.White;
            toggleState2.BorderRadius = 17;
            toggleState2.BorderRadiusInner = 11;
            toggleState2.BorderThickness = 1;
            toggleState2.BorderThicknessInner = 1;
            this.btnSwitch.ToggleStateOff = toggleState2;
            toggleState3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(134)))), ((int)(((byte)(46)))));
            toggleState3.BackColorInner = System.Drawing.Color.White;
            toggleState3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(134)))), ((int)(((byte)(46)))));
            toggleState3.BorderColorInner = System.Drawing.Color.White;
            toggleState3.BorderRadius = 17;
            toggleState3.BorderRadiusInner = 11;
            toggleState3.BorderThickness = 1;
            toggleState3.BorderThicknessInner = 1;
            this.btnSwitch.ToggleStateOn = toggleState3;
            this.btnSwitch.Value = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 478);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnGradient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft Bedrock Launcher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.pnGradient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuGradientPanel pnGradient;
        private Bunifu.Framework.UI.BunifuElipse ctrElipse;
        private System.Windows.Forms.PictureBox pbLogo;
        private Bunifu.Framework.UI.BunifuDragControl ctrDrag;
        private System.Windows.Forms.PictureBox pbFlag;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimize;
        private System.Windows.Forms.Timer ctrTimer;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnMain;
        private Bunifu.ToggleSwitch.BunifuToggleSwitch btnSwitch;
    }
}

