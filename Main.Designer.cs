namespace YTPPlusPlus
{
    partial class YTPPlusPlus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YTPPlusPlus));
            this.Video = new System.Windows.Forms.Panel();
            this.Render = new System.Windows.Forms.Button();
            this.PausePlay = new System.Windows.Forms.Button();
            this.SaveAs = new System.Windows.Forms.Button();
            this.End = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.Effects = new System.Windows.Forms.Panel();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.EffectsLabel = new System.Windows.Forms.Label();
            this.Settings = new System.Windows.Forms.Panel();
            this.Clips = new System.Windows.Forms.NumericUpDown();
            this.MaxStreamDur = new System.Windows.Forms.NumericUpDown();
            this.MinStreamDur = new System.Windows.Forms.NumericUpDown();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ClipCountLabel = new System.Windows.Forms.Label();
            this.MaxStreamLabel = new System.Windows.Forms.Label();
            this.MinSteamLabel = new System.Windows.Forms.Label();
            this.TransitionDir = new System.Windows.Forms.TextBox();
            this.InsertTransitions = new System.Windows.Forms.CheckBox();
            this.RenderSettings = new System.Windows.Forms.Panel();
            this.HeightSet = new System.Windows.Forms.NumericUpDown();
            this.WidthSet = new System.Windows.Forms.NumericUpDown();
            this.Intro = new System.Windows.Forms.TextBox();
            this.InsertIntro = new System.Windows.Forms.CheckBox();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.Outro = new System.Windows.Forms.TextBox();
            this.InsertOutro = new System.Windows.Forms.CheckBox();
            this.RenderSettingsLabel = new System.Windows.Forms.Label();
            this.Materials = new System.Windows.Forms.Panel();
            this.Material = new System.Windows.Forms.RichTextBox();
            this.AddMaterial = new System.Windows.Forms.Button();
            this.ClearMaterial = new System.Windows.Forms.Button();
            this.MaterialLabel = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.m_file = new System.Windows.Forms.MenuItem();
            this.m_addmaterial = new System.Windows.Forms.MenuItem();
            this.m_clearmaterials = new System.Windows.Forms.MenuItem();
            this.m_edit = new System.Windows.Forms.MenuItem();
            this.m_render = new System.Windows.Forms.MenuItem();
            this.m_saveas = new System.Windows.Forms.MenuItem();
            this.m_view = new System.Windows.Forms.MenuItem();
            this.m_console = new System.Windows.Forms.MenuItem();
            this.m_tools = new System.Windows.Forms.MenuItem();
            this.m_ffmpeg = new System.Windows.Forms.MenuItem();
            this.m_ffprobe = new System.Windows.Forms.MenuItem();
            this.m_magick = new System.Windows.Forms.MenuItem();
            this.m_temp = new System.Windows.Forms.MenuItem();
            this.m_sounds = new System.Windows.Forms.MenuItem();
            this.m_music = new System.Windows.Forms.MenuItem();
            this.m_resources = new System.Windows.Forms.MenuItem();
            this.m_printconfig = new System.Windows.Forms.MenuItem();
            this.m_reset = new System.Windows.Forms.MenuItem();
            this.m_help = new System.Windows.Forms.MenuItem();
            this.m_helpeffects = new System.Windows.Forms.MenuItem();
            this.m_helpconfigure = new System.Windows.Forms.MenuItem();
            this.m_ytphubdiscord = new System.Windows.Forms.MenuItem();
            this.m_about = new System.Windows.Forms.MenuItem();
            this.folderBrowserTemp = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialogMagick = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserSounds = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserMusic = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserResources = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialogSource = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogFFmpeg = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogFFProbe = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserVLC = new System.Windows.Forms.FolderBrowserDialog();
            this.Video.SuspendLayout();
            this.Effects.SuspendLayout();
            this.Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Clips)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxStreamDur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinStreamDur)).BeginInit();
            this.RenderSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthSet)).BeginInit();
            this.Materials.SuspendLayout();
            this.SuspendLayout();
            // 
            // Video
            // 
            this.Video.AccessibleDescription = "Generated Video";
            this.Video.AccessibleName = "Video Container";
            this.Video.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Video.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Video.Controls.Add(this.Render);
            this.Video.Controls.Add(this.PausePlay);
            this.Video.Controls.Add(this.SaveAs);
            this.Video.Controls.Add(this.End);
            this.Video.Controls.Add(this.Start);
            this.Video.Location = new System.Drawing.Point(12, 12);
            this.Video.Name = "Video";
            this.Video.Size = new System.Drawing.Size(320, 288);
            this.Video.TabIndex = 0;
            // 
            // Render
            // 
            this.Render.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Render.BackColor = System.Drawing.SystemColors.Control;
            this.Render.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Render.Location = new System.Drawing.Point(3, 245);
            this.Render.Name = "Render";
            this.Render.Size = new System.Drawing.Size(88, 38);
            this.Render.TabIndex = 1;
            this.Render.Text = "Render";
            this.Render.UseVisualStyleBackColor = false;
            this.Render.Click += new System.EventHandler(this.Render_Click);
            // 
            // PausePlay
            // 
            this.PausePlay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PausePlay.BackColor = System.Drawing.SystemColors.Control;
            this.PausePlay.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PausePlay.Location = new System.Drawing.Point(141, 245);
            this.PausePlay.Name = "PausePlay";
            this.PausePlay.Size = new System.Drawing.Size(38, 38);
            this.PausePlay.TabIndex = 3;
            this.PausePlay.Text = "| |";
            this.PausePlay.UseVisualStyleBackColor = false;
            this.PausePlay.Click += new System.EventHandler(this.PausePlay_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SaveAs.BackColor = System.Drawing.SystemColors.Control;
            this.SaveAs.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveAs.Location = new System.Drawing.Point(227, 245);
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(88, 38);
            this.SaveAs.TabIndex = 5;
            this.SaveAs.Text = "Save As...";
            this.SaveAs.UseVisualStyleBackColor = false;
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // End
            // 
            this.End.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.End.BackColor = System.Drawing.SystemColors.Control;
            this.End.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.End.Location = new System.Drawing.Point(183, 245);
            this.End.Name = "End";
            this.End.Size = new System.Drawing.Size(38, 38);
            this.End.TabIndex = 4;
            this.End.Text = ">";
            this.End.UseVisualStyleBackColor = false;
            this.End.Click += new System.EventHandler(this.End_Click);
            // 
            // Start
            // 
            this.Start.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Start.BackColor = System.Drawing.SystemColors.Control;
            this.Start.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start.Location = new System.Drawing.Point(97, 245);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(38, 38);
            this.Start.TabIndex = 2;
            this.Start.Text = "|<";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Effects
            // 
            this.Effects.AccessibleDescription = "Generated Video";
            this.Effects.AccessibleName = "Video Container";
            this.Effects.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Effects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Effects.Controls.Add(this.checkBox11);
            this.Effects.Controls.Add(this.checkBox10);
            this.Effects.Controls.Add(this.checkBox5);
            this.Effects.Controls.Add(this.checkBox9);
            this.Effects.Controls.Add(this.checkBox8);
            this.Effects.Controls.Add(this.checkBox7);
            this.Effects.Controls.Add(this.checkBox6);
            this.Effects.Controls.Add(this.checkBox4);
            this.Effects.Controls.Add(this.checkBox3);
            this.Effects.Controls.Add(this.checkBox2);
            this.Effects.Controls.Add(this.checkBox1);
            this.Effects.Controls.Add(this.EffectsLabel);
            this.Effects.Location = new System.Drawing.Point(338, 12);
            this.Effects.Name = "Effects";
            this.Effects.Size = new System.Drawing.Size(211, 288);
            this.Effects.TabIndex = 6;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Checked = true;
            this.checkBox11.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox11.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox11.Location = new System.Drawing.Point(23, 257);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(82, 17);
            this.checkBox11.TabIndex = 21;
            this.checkBox11.Text = "Squidward";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Checked = true;
            this.checkBox10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox10.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox10.Location = new System.Drawing.Point(23, 234);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(58, 17);
            this.checkBox10.TabIndex = 20;
            this.checkBox10.Text = "Dance";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox5.Location = new System.Drawing.Point(23, 119);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(160, 17);
            this.checkBox5.TabIndex = 15;
            this.checkBox5.Text = "Slow Down Clip (No Pitch)";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Checked = true;
            this.checkBox9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox9.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox9.Location = new System.Drawing.Point(23, 211);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(142, 17);
            this.checkBox9.TabIndex = 19;
            this.checkBox9.Text = "Slow Down Clip (Pitch)";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Checked = true;
            this.checkBox8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox8.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox8.Location = new System.Drawing.Point(23, 188);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(133, 17);
            this.checkBox8.TabIndex = 18;
            this.checkBox8.Text = "Speed Up Clip (Pitch)";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Checked = true;
            this.checkBox7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox7.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox7.Location = new System.Drawing.Point(23, 165);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(98, 17);
            this.checkBox7.TabIndex = 17;
            this.checkBox7.Text = "Vibrato Audio";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox6.Location = new System.Drawing.Point(23, 142);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(97, 17);
            this.checkBox6.TabIndex = 16;
            this.checkBox6.Text = "Chorus Audio";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox4.Location = new System.Drawing.Point(23, 96);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(151, 17);
            this.checkBox4.TabIndex = 14;
            this.checkBox4.Text = "Speed Up Clip (No Pitch)";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(23, 73);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(88, 17);
            this.checkBox3.TabIndex = 13;
            this.checkBox3.Text = "Reverse Clip";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(23, 50);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(162, 17);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "Random Sound (Mute OG)";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(23, 27);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Random Sound";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // EffectsLabel
            // 
            this.EffectsLabel.AutoSize = true;
            this.EffectsLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EffectsLabel.Location = new System.Drawing.Point(39, -1);
            this.EffectsLabel.Name = "EffectsLabel";
            this.EffectsLabel.Size = new System.Drawing.Size(128, 25);
            this.EffectsLabel.TabIndex = 0;
            this.EffectsLabel.Text = "Effect Toggles";
            this.EffectsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Settings
            // 
            this.Settings.AccessibleDescription = "Generated Video";
            this.Settings.AccessibleName = "Video Container";
            this.Settings.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Settings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Settings.Controls.Add(this.Clips);
            this.Settings.Controls.Add(this.MaxStreamDur);
            this.Settings.Controls.Add(this.MinStreamDur);
            this.Settings.Controls.Add(this.progressBar1);
            this.Settings.Controls.Add(this.ClipCountLabel);
            this.Settings.Controls.Add(this.MaxStreamLabel);
            this.Settings.Controls.Add(this.MinSteamLabel);
            this.Settings.Controls.Add(this.TransitionDir);
            this.Settings.Controls.Add(this.InsertTransitions);
            this.Settings.Location = new System.Drawing.Point(13, 306);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(320, 145);
            this.Settings.TabIndex = 7;
            // 
            // Clips
            // 
            this.Clips.BackColor = System.Drawing.SystemColors.Control;
            this.Clips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Clips.Location = new System.Drawing.Point(226, 80);
            this.Clips.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Clips.Name = "Clips";
            this.Clips.Size = new System.Drawing.Size(88, 20);
            this.Clips.TabIndex = 10;
            this.Clips.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // MaxStreamDur
            // 
            this.MaxStreamDur.BackColor = System.Drawing.SystemColors.Control;
            this.MaxStreamDur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MaxStreamDur.DecimalPlaces = 1;
            this.MaxStreamDur.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.MaxStreamDur.Location = new System.Drawing.Point(226, 54);
            this.MaxStreamDur.Name = "MaxStreamDur";
            this.MaxStreamDur.Size = new System.Drawing.Size(88, 20);
            this.MaxStreamDur.TabIndex = 9;
            this.MaxStreamDur.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // MinStreamDur
            // 
            this.MinStreamDur.BackColor = System.Drawing.SystemColors.Control;
            this.MinStreamDur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MinStreamDur.DecimalPlaces = 1;
            this.MinStreamDur.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.MinStreamDur.Location = new System.Drawing.Point(227, 28);
            this.MinStreamDur.Name = "MinStreamDur";
            this.MinStreamDur.Size = new System.Drawing.Size(88, 20);
            this.MinStreamDur.TabIndex = 8;
            this.MinStreamDur.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 108);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(309, 32);
            this.progressBar1.TabIndex = 20;
            // 
            // ClipCountLabel
            // 
            this.ClipCountLabel.AutoSize = true;
            this.ClipCountLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClipCountLabel.Location = new System.Drawing.Point(3, 82);
            this.ClipCountLabel.Name = "ClipCountLabel";
            this.ClipCountLabel.Size = new System.Drawing.Size(62, 13);
            this.ClipCountLabel.TabIndex = 19;
            this.ClipCountLabel.Text = "Clip Count";
            // 
            // MaxStreamLabel
            // 
            this.MaxStreamLabel.AutoSize = true;
            this.MaxStreamLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxStreamLabel.Location = new System.Drawing.Point(3, 56);
            this.MaxStreamLabel.Name = "MaxStreamLabel";
            this.MaxStreamLabel.Size = new System.Drawing.Size(179, 13);
            this.MaxStreamLabel.TabIndex = 17;
            this.MaxStreamLabel.Text = "Max Stream Duration (in seconds)";
            // 
            // MinSteamLabel
            // 
            this.MinSteamLabel.AutoSize = true;
            this.MinSteamLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinSteamLabel.Location = new System.Drawing.Point(3, 30);
            this.MinSteamLabel.Name = "MinSteamLabel";
            this.MinSteamLabel.Size = new System.Drawing.Size(178, 13);
            this.MinSteamLabel.TabIndex = 15;
            this.MinSteamLabel.Text = "Min Stream Duration (in seconds)";
            // 
            // TransitionDir
            // 
            this.TransitionDir.BackColor = System.Drawing.SystemColors.Control;
            this.TransitionDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TransitionDir.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransitionDir.Location = new System.Drawing.Point(227, 2);
            this.TransitionDir.Name = "TransitionDir";
            this.TransitionDir.Size = new System.Drawing.Size(88, 22);
            this.TransitionDir.TabIndex = 7;
            this.TransitionDir.Text = "sources/";
            // 
            // InsertTransitions
            // 
            this.InsertTransitions.AutoSize = true;
            this.InsertTransitions.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.InsertTransitions.Checked = true;
            this.InsertTransitions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.InsertTransitions.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertTransitions.Location = new System.Drawing.Point(3, 3);
            this.InsertTransitions.Name = "InsertTransitions";
            this.InsertTransitions.Size = new System.Drawing.Size(186, 17);
            this.InsertTransitions.TabIndex = 6;
            this.InsertTransitions.Text = "Insert Transition Clips (Sources)";
            this.InsertTransitions.UseVisualStyleBackColor = true;
            // 
            // RenderSettings
            // 
            this.RenderSettings.BackColor = System.Drawing.SystemColors.ControlDark;
            this.RenderSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RenderSettings.Controls.Add(this.HeightSet);
            this.RenderSettings.Controls.Add(this.WidthSet);
            this.RenderSettings.Controls.Add(this.Intro);
            this.RenderSettings.Controls.Add(this.InsertIntro);
            this.RenderSettings.Controls.Add(this.HeightLabel);
            this.RenderSettings.Controls.Add(this.WidthLabel);
            this.RenderSettings.Controls.Add(this.Outro);
            this.RenderSettings.Controls.Add(this.InsertOutro);
            this.RenderSettings.Controls.Add(this.RenderSettingsLabel);
            this.RenderSettings.Location = new System.Drawing.Point(339, 305);
            this.RenderSettings.Name = "RenderSettings";
            this.RenderSettings.Size = new System.Drawing.Size(210, 145);
            this.RenderSettings.TabIndex = 8;
            // 
            // HeightSet
            // 
            this.HeightSet.BackColor = System.Drawing.SystemColors.Control;
            this.HeightSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HeightSet.Location = new System.Drawing.Point(117, 116);
            this.HeightSet.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.HeightSet.Name = "HeightSet";
            this.HeightSet.Size = new System.Drawing.Size(88, 20);
            this.HeightSet.TabIndex = 27;
            this.HeightSet.Value = new decimal(new int[] {
            480,
            0,
            0,
            0});
            // 
            // WidthSet
            // 
            this.WidthSet.BackColor = System.Drawing.SystemColors.Control;
            this.WidthSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WidthSet.Location = new System.Drawing.Point(117, 87);
            this.WidthSet.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.WidthSet.Name = "WidthSet";
            this.WidthSet.Size = new System.Drawing.Size(88, 20);
            this.WidthSet.TabIndex = 26;
            this.WidthSet.Value = new decimal(new int[] {
            640,
            0,
            0,
            0});
            // 
            // Intro
            // 
            this.Intro.BackColor = System.Drawing.SystemColors.Control;
            this.Intro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Intro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Intro.Location = new System.Drawing.Point(117, 31);
            this.Intro.Name = "Intro";
            this.Intro.Size = new System.Drawing.Size(88, 22);
            this.Intro.TabIndex = 23;
            this.Intro.Text = "intro.mp4";
            // 
            // InsertIntro
            // 
            this.InsertIntro.AutoSize = true;
            this.InsertIntro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.InsertIntro.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertIntro.Location = new System.Drawing.Point(3, 33);
            this.InsertIntro.Name = "InsertIntro";
            this.InsertIntro.Size = new System.Drawing.Size(83, 17);
            this.InsertIntro.TabIndex = 22;
            this.InsertIntro.Text = "Insert Intro";
            this.InsertIntro.UseVisualStyleBackColor = true;
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeightLabel.Location = new System.Drawing.Point(3, 118);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(82, 13);
            this.HeightLabel.TabIndex = 23;
            this.HeightLabel.Text = "Render Height";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WidthLabel.Location = new System.Drawing.Point(3, 89);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(79, 13);
            this.WidthLabel.TabIndex = 21;
            this.WidthLabel.Text = "Render Width";
            // 
            // Outro
            // 
            this.Outro.BackColor = System.Drawing.SystemColors.Control;
            this.Outro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Outro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Outro.Location = new System.Drawing.Point(117, 59);
            this.Outro.Name = "Outro";
            this.Outro.Size = new System.Drawing.Size(88, 22);
            this.Outro.TabIndex = 25;
            this.Outro.Text = "outro.mp4";
            // 
            // InsertOutro
            // 
            this.InsertOutro.AutoSize = true;
            this.InsertOutro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.InsertOutro.Checked = true;
            this.InsertOutro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.InsertOutro.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertOutro.Location = new System.Drawing.Point(3, 60);
            this.InsertOutro.Name = "InsertOutro";
            this.InsertOutro.Size = new System.Drawing.Size(89, 17);
            this.InsertOutro.TabIndex = 24;
            this.InsertOutro.Text = "Insert Outro";
            this.InsertOutro.UseVisualStyleBackColor = true;
            // 
            // RenderSettingsLabel
            // 
            this.RenderSettingsLabel.AutoSize = true;
            this.RenderSettingsLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RenderSettingsLabel.Location = new System.Drawing.Point(31, 1);
            this.RenderSettingsLabel.Name = "RenderSettingsLabel";
            this.RenderSettingsLabel.Size = new System.Drawing.Size(143, 25);
            this.RenderSettingsLabel.TabIndex = 12;
            this.RenderSettingsLabel.Text = "Render Settings";
            this.RenderSettingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Materials
            // 
            this.Materials.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Materials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Materials.Controls.Add(this.Material);
            this.Materials.Controls.Add(this.AddMaterial);
            this.Materials.Controls.Add(this.ClearMaterial);
            this.Materials.Controls.Add(this.MaterialLabel);
            this.Materials.Location = new System.Drawing.Point(555, 13);
            this.Materials.Name = "Materials";
            this.Materials.Size = new System.Drawing.Size(210, 438);
            this.Materials.TabIndex = 15;
            // 
            // Material
            // 
            this.Material.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Material.Location = new System.Drawing.Point(4, 26);
            this.Material.Name = "Material";
            this.Material.ReadOnly = true;
            this.Material.Size = new System.Drawing.Size(200, 368);
            this.Material.TabIndex = 28;
            this.Material.Text = "";
            // 
            // AddMaterial
            // 
            this.AddMaterial.Location = new System.Drawing.Point(3, 400);
            this.AddMaterial.Name = "AddMaterial";
            this.AddMaterial.Size = new System.Drawing.Size(100, 32);
            this.AddMaterial.TabIndex = 29;
            this.AddMaterial.Text = "Add (*.mp4)";
            this.AddMaterial.UseVisualStyleBackColor = true;
            this.AddMaterial.Click += new System.EventHandler(this.AddMaterial_Click);
            // 
            // ClearMaterial
            // 
            this.ClearMaterial.Location = new System.Drawing.Point(109, 400);
            this.ClearMaterial.Name = "ClearMaterial";
            this.ClearMaterial.Size = new System.Drawing.Size(95, 32);
            this.ClearMaterial.TabIndex = 30;
            this.ClearMaterial.Text = "Clear";
            this.ClearMaterial.UseVisualStyleBackColor = true;
            this.ClearMaterial.Click += new System.EventHandler(this.ClearMaterial_Click);
            // 
            // MaterialLabel
            // 
            this.MaterialLabel.AutoSize = true;
            this.MaterialLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaterialLabel.Location = new System.Drawing.Point(61, 0);
            this.MaterialLabel.Name = "MaterialLabel";
            this.MaterialLabel.Size = new System.Drawing.Size(82, 25);
            this.MaterialLabel.TabIndex = 12;
            this.MaterialLabel.Text = "Material";
            this.MaterialLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_file,
            this.m_edit,
            this.m_view,
            this.m_tools,
            this.m_help});
            // 
            // m_file
            // 
            this.m_file.Index = 0;
            this.m_file.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_addmaterial,
            this.m_clearmaterials});
            this.m_file.ShowShortcut = false;
            this.m_file.Text = "File";
            // 
            // m_addmaterial
            // 
            this.m_addmaterial.Index = 0;
            this.m_addmaterial.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.m_addmaterial.Text = "Add Material";
            this.m_addmaterial.Click += new System.EventHandler(this.m_addmaterial_Click);
            // 
            // m_clearmaterials
            // 
            this.m_clearmaterials.Index = 1;
            this.m_clearmaterials.Shortcut = System.Windows.Forms.Shortcut.F12;
            this.m_clearmaterials.Text = "Clear Materials";
            this.m_clearmaterials.Click += new System.EventHandler(this.m_clearmaterials_Click);
            // 
            // m_edit
            // 
            this.m_edit.Index = 1;
            this.m_edit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_render,
            this.m_saveas});
            this.m_edit.ShowShortcut = false;
            this.m_edit.Text = "Edit";
            // 
            // m_render
            // 
            this.m_render.Index = 0;
            this.m_render.Shortcut = System.Windows.Forms.Shortcut.F2;
            this.m_render.Text = "Render";
            this.m_render.Click += new System.EventHandler(this.m_render_Click);
            // 
            // m_saveas
            // 
            this.m_saveas.Index = 1;
            this.m_saveas.Shortcut = System.Windows.Forms.Shortcut.F3;
            this.m_saveas.Text = "Save As...";
            this.m_saveas.Click += new System.EventHandler(this.m_saveas_Click);
            // 
            // m_view
            // 
            this.m_view.Index = 2;
            this.m_view.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_console});
            this.m_view.ShowShortcut = false;
            this.m_view.Text = "View";
            // 
            // m_console
            // 
            this.m_console.Index = 0;
            this.m_console.Shortcut = System.Windows.Forms.Shortcut.F4;
            this.m_console.Text = "Show Console";
            this.m_console.Click += new System.EventHandler(this.m_console_Click);
            // 
            // m_tools
            // 
            this.m_tools.Index = 3;
            this.m_tools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_ffmpeg,
            this.m_ffprobe,
            this.m_magick,
            this.m_temp,
            this.m_sounds,
            this.m_music,
            this.m_resources,
            this.m_printconfig,
            this.m_reset});
            this.m_tools.ShowShortcut = false;
            this.m_tools.Text = "Tools";
            // 
            // m_ffmpeg
            // 
            this.m_ffmpeg.Index = 0;
            this.m_ffmpeg.Text = "Set ffmpeg.exe";
            this.m_ffmpeg.Click += new System.EventHandler(this.m_ffmpeg_Click);
            // 
            // m_ffprobe
            // 
            this.m_ffprobe.Index = 1;
            this.m_ffprobe.Text = "Set ffprobe.exe";
            this.m_ffprobe.Click += new System.EventHandler(this.m_ffprobe_Click);
            // 
            // m_magick
            // 
            this.m_magick.Index = 2;
            this.m_magick.Text = "Set magick.exe";
            this.m_magick.Click += new System.EventHandler(this.m_magick_Click);
            // 
            // m_temp
            // 
            this.m_temp.Index = 3;
            this.m_temp.Text = "Set temp/ folder";
            this.m_temp.Click += new System.EventHandler(this.m_temp_Click);
            // 
            // m_sounds
            // 
            this.m_sounds.Index = 4;
            this.m_sounds.Text = "Set sounds/ folder";
            this.m_sounds.Click += new System.EventHandler(this.m_sounds_Click);
            // 
            // m_music
            // 
            this.m_music.Index = 5;
            this.m_music.Text = "Set music/ folder";
            this.m_music.Click += new System.EventHandler(this.m_music_Click);
            // 
            // m_resources
            // 
            this.m_resources.Index = 6;
            this.m_resources.Text = "Set resources/ folder";
            this.m_resources.Click += new System.EventHandler(this.m_resources_Click);
            // 
            // m_printconfig
            // 
            this.m_printconfig.Index = 7;
            this.m_printconfig.Text = "Print current config";
            this.m_printconfig.Click += new System.EventHandler(this.m_printconfig_Click);
            // 
            // m_reset
            // 
            this.m_reset.Index = 8;
            this.m_reset.Shortcut = System.Windows.Forms.Shortcut.F10;
            this.m_reset.Text = "Reset all";
            this.m_reset.Click += new System.EventHandler(this.m_reset_Click);
            // 
            // m_help
            // 
            this.m_help.Index = 4;
            this.m_help.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_helpeffects,
            this.m_helpconfigure,
            this.m_ytphubdiscord,
            this.m_about});
            this.m_help.ShowShortcut = false;
            this.m_help.Text = "Help";
            // 
            // m_helpeffects
            // 
            this.m_helpeffects.Index = 0;
            this.m_helpeffects.Text = "What do the effects do?";
            this.m_helpeffects.Click += new System.EventHandler(this.m_helpeffects_Click);
            // 
            // m_helpconfigure
            // 
            this.m_helpconfigure.Index = 1;
            this.m_helpconfigure.Text = "How do I configure YTP++?";
            this.m_helpconfigure.Click += new System.EventHandler(this.m_helpconfigure_Click);
            // 
            // m_ytphubdiscord
            // 
            this.m_ytphubdiscord.Index = 2;
            this.m_ytphubdiscord.Text = "YTP+ Hub";
            this.m_ytphubdiscord.Click += new System.EventHandler(this.m_ytphubdiscord_Click);
            // 
            // m_about
            // 
            this.m_about.Index = 3;
            this.m_about.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.m_about.Text = "About YTP++";
            this.m_about.Click += new System.EventHandler(this.m_about_Click);
            // 
            // folderBrowserTemp
            // 
            this.folderBrowserTemp.SelectedPath = "temp/";
            // 
            // openFileDialogMagick
            // 
            this.openFileDialogMagick.FileName = "magick.exe";
            this.openFileDialogMagick.Filter = "ImageMagick|magick.exe";
            this.openFileDialogMagick.Title = "Select ImageMagick";
            // 
            // folderBrowserSounds
            // 
            this.folderBrowserSounds.SelectedPath = "sounds/";
            // 
            // folderBrowserMusic
            // 
            this.folderBrowserMusic.SelectedPath = "music/";
            // 
            // folderBrowserResources
            // 
            this.folderBrowserResources.SelectedPath = "resources/";
            // 
            // openFileDialogSource
            // 
            this.openFileDialogSource.Multiselect = true;
            this.openFileDialogSource.Title = "Select a material clip (Only videos!)";
            // 
            // openFileDialogFFmpeg
            // 
            this.openFileDialogFFmpeg.FileName = "ffmpeg.exe";
            this.openFileDialogFFmpeg.Filter = "FFMpeg|ffmpeg.exe";
            this.openFileDialogFFmpeg.Title = "Select FFMpeg";
            // 
            // openFileDialogFFProbe
            // 
            this.openFileDialogFFProbe.FileName = "ffprobe.exe";
            this.openFileDialogFFProbe.Filter = "FFProbe|ffprobe.exe";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "MPEG-4 Video|*.mp4";
            // 
            // folderBrowserVLC
            // 
            this.folderBrowserVLC.Description = "Please locate your VLC directory. (VideoLAN/VLC)";
            this.folderBrowserVLC.RootFolder = System.Environment.SpecialFolder.ProgramFilesX86;
            // 
            // YTPPlusPlus
            // 
            this.AccessibleDescription = "Youtube Poop Generator";
            this.AccessibleName = "Y T P Plus Plus";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(777, 466);
            this.Controls.Add(this.Materials);
            this.Controls.Add(this.RenderSettings);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.Effects);
            this.Controls.Add(this.Video);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(793, 526);
            this.Menu = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(793, 526);
            this.Name = "YTPPlusPlus";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YTP++";
            this.Video.ResumeLayout(false);
            this.Effects.ResumeLayout(false);
            this.Effects.PerformLayout();
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Clips)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxStreamDur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinStreamDur)).EndInit();
            this.RenderSettings.ResumeLayout(false);
            this.RenderSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthSet)).EndInit();
            this.Materials.ResumeLayout(false);
            this.Materials.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Video;
        private System.Windows.Forms.Button PausePlay;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button End;
        private System.Windows.Forms.Button Render;
        private System.Windows.Forms.Button SaveAs;
        private System.Windows.Forms.Panel Effects;
        private System.Windows.Forms.Panel Settings;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label EffectsLabel;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label ClipCountLabel;
        private System.Windows.Forms.Label MaxStreamLabel;
        private System.Windows.Forms.Label MinSteamLabel;
        private System.Windows.Forms.TextBox TransitionDir;
        private System.Windows.Forms.CheckBox InsertTransitions;
        private System.Windows.Forms.Panel RenderSettings;
        private System.Windows.Forms.Label RenderSettingsLabel;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.TextBox Outro;
        private System.Windows.Forms.CheckBox InsertOutro;
        private System.Windows.Forms.Panel Materials;
        private System.Windows.Forms.RichTextBox Material;
        private System.Windows.Forms.Button AddMaterial;
        private System.Windows.Forms.Button ClearMaterial;
        private System.Windows.Forms.Label MaterialLabel;
        private System.Windows.Forms.TextBox Intro;
        private System.Windows.Forms.CheckBox InsertIntro;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem m_file;
        private System.Windows.Forms.MenuItem m_addmaterial;
        private System.Windows.Forms.MenuItem m_clearmaterials;
        private System.Windows.Forms.MenuItem m_edit;
        private System.Windows.Forms.MenuItem m_render;
        private System.Windows.Forms.MenuItem m_saveas;
        private System.Windows.Forms.MenuItem m_view;
        private System.Windows.Forms.MenuItem m_console;
        private System.Windows.Forms.MenuItem m_tools;
        private System.Windows.Forms.MenuItem m_magick;
        private System.Windows.Forms.MenuItem m_temp;
        private System.Windows.Forms.MenuItem m_sounds;
        private System.Windows.Forms.MenuItem m_music;
        private System.Windows.Forms.MenuItem m_resources;
        private System.Windows.Forms.MenuItem m_reset;
        private System.Windows.Forms.MenuItem m_help;
        private System.Windows.Forms.MenuItem m_helpeffects;
        private System.Windows.Forms.MenuItem m_helpconfigure;
        private System.Windows.Forms.MenuItem m_ytphubdiscord;
        private System.Windows.Forms.NumericUpDown MinStreamDur;
        private System.Windows.Forms.NumericUpDown Clips;
        private System.Windows.Forms.NumericUpDown MaxStreamDur;
        private System.Windows.Forms.NumericUpDown HeightSet;
        private System.Windows.Forms.NumericUpDown WidthSet;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserTemp;
        private System.Windows.Forms.OpenFileDialog openFileDialogMagick;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserSounds;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserMusic;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserResources;
        private System.Windows.Forms.OpenFileDialog openFileDialogSource;
        private System.Windows.Forms.MenuItem m_ffmpeg;
        private System.Windows.Forms.OpenFileDialog openFileDialogFFmpeg;
        private System.Windows.Forms.MenuItem m_ffprobe;
        private System.Windows.Forms.OpenFileDialog openFileDialogFFProbe;
        private System.Windows.Forms.MenuItem m_about;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.MenuItem m_printconfig;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserVLC;
    }
}

