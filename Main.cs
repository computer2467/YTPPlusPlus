using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using YTPPlus;

namespace YTPPlusPlus
{
    public partial class YTPPlusPlus : Form
    {
        //vlc check
        Vlc.DotNet.Forms.VlcControl Player;
        bool renderComplete = true;
        //tool variables
        string ffmpeg = "ffmpeg.exe";
        string ffprobe = "ffprobe.exe";
        string magick = "magick";
        string temp = "temp\\";
        string sounds = "sounds\\";
        string music = "music\\";
        string resources = "resources\\";
        string[] sources = new string[0];
        //default variables
        bool transitionsDef = true;
        bool effect1Def = true;
        bool effect2Def = true;
        bool effect3Def = true;
        bool effect4Def = true;
        bool effect5Def = true;
        bool effect6Def = true;
        bool effect7Def = true;
        bool effect8Def = true;
        bool effect9Def = true;
        bool effect10Def = true;
        bool effect11Def = true;
        bool introBoolDef = false;
        bool outroBoolDef = true;
        int clipCountDef = 20;
        int widthDef = 640;
        int heightDef = 480;
        decimal minStreamDef = 0.2M;
        decimal maxStreamDef = 0.4M;
        string introDef = "resources\\intro.mp4";
        string outroDef = "resources\\outro.mp4";
        string ffmpegDef = "ffmpeg.exe";
        string ffprobeDef = "ffprobe.exe";
        string magickDef = "magick";
        string sourcesDef = "sources\\";
        string tempDef = "temp\\";
        string soundsDef = "sounds\\";
        string musicDef = "music\\";
        string resourcesDef = "resources\\";
        YTPGenerator globalGen;
        public void ResetVars()
        {
            this.InsertTransitions.Checked = transitionsDef;
            this.checkBox1.Checked = effect1Def;
            this.checkBox2.Checked = effect2Def;
            this.checkBox3.Checked = effect3Def;
            this.checkBox4.Checked = effect4Def;
            this.checkBox5.Checked = effect5Def;
            this.checkBox6.Checked = effect6Def;
            this.checkBox7.Checked = effect7Def;
            this.checkBox8.Checked = effect8Def;
            this.checkBox9.Checked = effect9Def;
            this.checkBox10.Checked = effect10Def;
            this.checkBox11.Checked = effect11Def;
            this.InsertIntro.Checked = introBoolDef;
            this.InsertOutro.Checked = outroBoolDef;
            this.Clips.Value = clipCountDef;
            this.WidthSet.Value = widthDef;
            this.HeightSet.Value = heightDef;
            this.MinStreamDur.Value = minStreamDef;
            this.MaxStreamDur.Value = maxStreamDef;
            this.Intro.Text = Directory.GetCurrentDirectory() + "\\" + introDef;
            this.Outro.Text = Directory.GetCurrentDirectory() + "\\" + outroDef;
            this.ffmpeg = Directory.GetCurrentDirectory() + "\\" + ffmpegDef;
            this.ffprobe = Directory.GetCurrentDirectory() + "\\" + ffprobeDef;
            this.magick = magickDef;
            this.TransitionDir.Text = Directory.GetCurrentDirectory() + "\\" + sourcesDef;
            this.temp = Directory.GetCurrentDirectory() + "\\" + tempDef;
            this.sounds = Directory.GetCurrentDirectory() + "\\" + soundsDef;
            this.music = Directory.GetCurrentDirectory() + "\\" + musicDef;
            this.resources = Directory.GetCurrentDirectory() + "\\" + resourcesDef;
        }
        //end default variables

        //console import
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        bool ConsoleShowing = false;

        public static void ShowConsoleWindow()
        {
            var handle = GetConsoleWindow();

            if (handle == IntPtr.Zero)
            {
                AllocConsole();
            }
            else
            {
                ShowWindow(handle, SW_SHOW);
            }
        }

        public static void HideConsoleWindow()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
        }
        //end console import


        public String[] titles = { "Yo", "Mmmmm!", "I'm the invisible man...", "Luigi, look!", "You want it?", "WTF Booooooooooom" };
        public FileInfo fi; //= new FileInfo("D:\\Users\\Kisu-Amare\\Downloads\\spongebob1.mp4");
        public void TestMagick()
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = magick;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                process.StartInfo = startInfo;

                process.Start();
                process.WaitForExit();
                if (process.ExitCode == 1)
                {
                    alert("ImageMagick is not installed. The Squidward effect has been disabled.\nPlease install ImageMagick and add it to your system PATH, or select \"Set magick.exe\" in the Tools menu.");
                    checkBox11.Enabled = false;
                    checkBox11.Checked = false;
                }
                else
                {
                    checkBox11.Enabled = true;
                    checkBox11.Checked = true;
                }
            }
            catch
            {
                alert("ImageMagick is not installed. The Squidward effect has been disabled.\nPlease install ImageMagick and add it to your system PATH, or select \"Set magick.exe\" in the Tools menu.");
                checkBox11.Enabled = false;
                checkBox11.Checked = false;
            }
        }
        public void TestFFMPEG()
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = ffmpeg;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                process.StartInfo = startInfo;

                process.Start();
                process.WaitForExit();
            }
            catch
            {
                alert("FFMPEG is not installed. It may have been misplaced, make sure it is in the same directory as YTP++!");
                System.Environment.Exit(1);
            }
        }
        public void TestFFPROBE()
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = ffprobe;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                process.StartInfo = startInfo;

                process.Start();
                process.WaitForExit();
            }
            catch
            {
                alert("FFPROBE is not installed. It may have been misplaced, make sure it is in the same directory as YTP++!");
                System.Environment.Exit(1);
            }
        }
        public void vlcC(DirectoryInfo dir)
        {
            this.Player = new Vlc.DotNet.Forms.VlcControl();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.Player.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Player.BackColor = System.Drawing.Color.Black;
            this.Player.Enabled = false;
            this.Player.Location = new System.Drawing.Point(-1, -1);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(320, 240);
            this.Player.Spu = -1;
            this.Player.TabIndex = 0;
            this.Player.VlcMediaplayerOptions = null;
            this.Player.VlcLibDirectory = dir;
            this.Video.Controls.Add(this.Player);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            //VLCCheck.global.Close();
            Player.Enabled = true;
            ResetVars();
            HideConsoleWindow();
            //this.Player.SetMedia(fi);
            //this.Player.Play();
            this.Player.Enabled = false;
            this.m_saveas.Enabled = false;
            this.SaveAs.Enabled = false;
            TestFFMPEG();
            TestFFPROBE();
            TestMagick();
        }
        public YTPPlusPlus()
        {
            InitializeComponent();
            if (Directory.Exists("C:/Program Files (x86)/VideoLAN/VLC"))
            {
                vlcC(new DirectoryInfo("C:/Program Files (x86)/VideoLAN/VLC"));
            }
            else
            {
                DialogResult result = folderBrowserVLC.ShowDialog();
                if (result == DialogResult.OK)
                {
                    vlcC(new DirectoryInfo(folderBrowserVLC.SelectedPath));
                }
                else
                {
                    PausePlay.Enabled = false;
                    Start.Enabled = false;
                    End.Enabled = false;
                    ResetVars();
                    HideConsoleWindow();
                    //this.Player.SetMedia(fi);
                    //this.Player.Play();
                    this.SaveAs.Enabled = false;
                    this.m_saveas.Enabled = false;
                    TestFFMPEG();
                    TestFFPROBE();
                    TestMagick();
                }
            }
            
        }
        public void PlayVideo(FileInfo fil)
        {
            fi = fil;
            
            this.Player.SetMedia(fi);
            this.Player.Play();
        }
        private void PausePlay_Click(object sender, EventArgs e)
        {
            if (this.Player.IsPlaying)
            {
                this.PausePlay.Text = "▶️";
                this.Player.Pause();
            }
            else
            {
                this.PausePlay.Text = "| |";
                this.Player.Play();
            }

        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (fi != null)
            {
                
                this.Player.SetMedia(fi);
                this.Player.Position = 0;
                this.Player.Play();
                this.PausePlay.Text = "| |";
            }
        }

        private void End_Click(object sender, EventArgs e)
        {
            this.Player.Position += 0.1f;
            if (this.Player.Position > 1f)
                this.Player.Position = 0.999f;
        }

        private void m_console_Click(object sender, EventArgs e)
        {
            var handle = GetConsoleWindow();
            if (ConsoleShowing)
            {
                // Hide console
                HideConsoleWindow();
            }
            else
            {
                // Show console
                ShowConsoleWindow();
            }
            ConsoleShowing = !ConsoleShowing;
            m_console.Checked = ConsoleShowing;
        }
        public void alert(string alertText)
        {
            MessageBox.Show(this, alertText, titles[new Random().Next(0, titles.Length)]);
        }
        private void m_helpeffects_Click(object sender, EventArgs e)
        {
            alert("From the YTP+ Documentation: \n\"Currently, these effects are based on a switch statement, and each effect has an equal chance of appearing, which means if you "
                + "turn one of them off, there will be more unedited clips. Additionally, there is a 1/2 chance of there even being an effect on a clip. "
                + "You do the math. There's 11 effects. 1/2 chance of each effect occuring. That means, regardless of being turned on or off, "
                + "each effect has a 1/22 chance of occuring. Pretty nasty, right? I'll add sliders for \"frequency\" in the future...\n\n"
                + "This might be beneficial to know also: There's a 1/15 chance of a \"transition\" clip being used in place of your sources, too. "
                + "So for every 15 clips you tell YTP+ to generate, one of them will be a transition clip from the folder you provide the program. "
                + "It's a big mess of numbers.\n\n"
                + "The reason there aren't frequency sliders now is because someone will probably break them somehow and I don't have the time to debug. "
                + "Give me a few weeks for an update...\"");
        }

        private void m_helpconfigure_Click(object sender, EventArgs e)
        {
            alert("Configuration can be done within the \"Tools\" menu.\n\n"
                + "You can set folders that will be used for things such "
                + "as temporary files, source clips, sound effects, and "
                + "music. Music and sound effect directories should contain "
                + "*.mp3 files only, while videos (source clips) should all be "
                + "*.mp4 files.\n\nAs for Magick and FFMPEG/FFPROBE configuration, Magick is only needed "
                + "for the \"Squidward\" effect as all other effects use the FFMPEG/FFPROBE "
                + "libraries within distributions of the applications. Licenses for FFMPEG and FFPROBE can be found in the \"Help\" menu.\n\n"
                + "By default, all settings should be correct unless you are on a 32 bit "
                + "system, in which case there may be a possibility where you have to set "
                + "the directory for Magick. If anything goes wrong, reset and check your settings."
                );
        }

        private void m_ytphubdiscord_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/bzhzRmg");
        }

        private void m_reset_Click(object sender, EventArgs e)
        {
            ResetVars();
        }

        private void m_magick_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialogMagick.ShowDialog();
            if (result == DialogResult.OK)
            {
                magick = openFileDialogMagick.FileName;
                TestMagick();
            }
        }

        private void m_temp_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = folderBrowserTemp.ShowDialog();
            if (result == DialogResult.OK)
            {
                temp = folderBrowserTemp.SelectedPath;
            }
        }

        private void m_sounds_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = folderBrowserSounds.ShowDialog();
            if (result == DialogResult.OK)
            {
                sounds = folderBrowserSounds.SelectedPath;
            }
        }

        private void m_music_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = folderBrowserMusic.ShowDialog();
            if (result == DialogResult.OK)
            {
                music = folderBrowserMusic.SelectedPath;
            }
        }

        private void m_resources_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = folderBrowserResources.ShowDialog();
            if (result == DialogResult.OK)
            {
                resources = folderBrowserResources.SelectedPath;
            }
        }
        public void addSource()
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialogSource.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (String file in openFileDialogSource.FileNames)
                {
                    Array.Resize(ref sources, sources.Length + 1);
                    sources[sources.GetUpperBound(0)] = file;
                    Material.Text += file + "\n";
                    //assuming these all don't work
                    if (file.Contains(" "))
                    {
                        alert("One or more materials added in this batch has a space in its path or file name. While YTP++ will still try to render with the material in question, be aware that this may cause a render failure.");
                    }
                    else if (file.Contains("+"))
                    {
                        alert("One or more materials added in this batch has a + symbol in its path or file name. While YTP++ will still try to render with the material in question, be aware that this may cause a render failure.");
                    }
                    else if (file.Contains("%"))
                    {
                        alert("One or more materials added in this batch has a % symbol in its path or file name. While YTP++ will still try to render with the material in question, be aware that this may cause a render failure.");
                    }
                    else if (file.Contains("&"))
                    {
                        alert("One or more materials added in this batch has an & symbol in its path or file name. While YTP++ will still try to render with the material in question, be aware that this may cause a render failure.");
                    }
                    else if (file.Contains("*"))
                    {
                        alert("One or more materials added in this batch has a * symbol in its path or file name. While YTP++ will still try to render with the material in question, be aware that this may cause a render failure.");
                    }
                    else if (file.Contains("="))
                    {
                        alert("One or more materials added in this batch has a = symbol in its path or file name. While YTP++ will still try to render with the material in question, be aware that this may cause a render failure.");
                    }
                    else if (file.Contains("~"))
                    {
                        alert("One or more materials added in this batch has a ~ symbol in its path or file name. While YTP++ will still try to render with the material in question, be aware that this may cause a render failure.");
                    }
                }
            }
        }
        public void clearSources()
        {
            sources = new string[0];
            Material.Text = "";
        }

        private void AddMaterial_Click(object sender, EventArgs e)
        {
            addSource();
        }

        private void m_addmaterial_Click(object sender, EventArgs e)
        {
            addSource();
        }

        private void ClearMaterial_Click(object sender, EventArgs e)
        {
            clearSources();
        }

        private void m_clearmaterials_Click(object sender, EventArgs e)
        {
            clearSources();
        }
        private static long nanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }
        public void progress(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        public void complete(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 100;
            if(this.Player != null)
                this.Player.Enabled = true;
            renderComplete = true;
            this.SaveAs.Enabled = true;
            this.m_saveas.Enabled = true;
            if (this.Player != null)
                this.Player.Stop();
            fi = new FileInfo(temp + "tempoutput.mp4");
            if (this.Player != null)
                this.Player.SetMedia(fi);
            this.PausePlay.Text = "▶️";
            Render.Enabled = true;
            m_render.Enabled = true;
            if (globalGen.failed)
            {
                alert("An exception has occured during rendering. Rendering may have not produced a result.\n\nThe last exception to occur was:\n" + globalGen.exc.Message);
            }
        }
        public void RenderVideo()
        {
            if (sources.Length == 0)
            {
                alert("You need some sources...");
            }
            else
            {
                try
                {
                    if (this.Player != null)
                        this.Player.Stop();
                    renderComplete = false;
                    if(this.Player != null)
                        this.Player.Enabled = false;
                    this.m_saveas.Enabled = false;
                    this.SaveAs.Enabled = false;
                    Render.Enabled = false;
                    m_render.Enabled = false;
                    Console.WriteLine("poop");
                    YTPGenerator generator = new YTPGenerator(temp + "tempoutput.mp4");
                    Console.WriteLine("poop2");
                    generator.toolBox.FFMPEG = "\"" + ffmpeg + "\"";
                    generator.toolBox.FFPROBE = "\"" + ffprobe + "\"";
                    generator.toolBox.MAGICK = "\"" + magick + "\"";
                    Console.WriteLine("poop3");
                    string jobDir = temp + "job_" + DateTimeOffset.Now.ToUnixTimeMilliseconds() + "/";
                    generator.toolBox.TEMP = jobDir;
                    Directory.CreateDirectory(jobDir);
                    Directory.CreateDirectory(generator.toolBox.TEMP);
                    generator.toolBox.SOUNDS = sounds;
                    generator.toolBox.MUSIC = music;
                    generator.toolBox.RESOURCES = resources;
                    generator.toolBox.SOURCES = this.TransitionDir.Text;
                    generator.toolBox.intro = this.Intro.Text;
                    generator.toolBox.outro = this.Outro.Text;
                    Console.WriteLine("poop4");
                    generator.effect1 = this.checkBox1.Checked;
                    generator.effect2 = this.checkBox2.Checked;
                    generator.effect3 = this.checkBox3.Checked;
                    generator.effect4 = this.checkBox4.Checked;
                    generator.effect5 = this.checkBox5.Checked;
                    generator.effect6 = this.checkBox6.Checked;
                    generator.effect7 = this.checkBox7.Checked;
                    generator.effect8 = this.checkBox8.Checked;
                    generator.effect9 = this.checkBox9.Checked;
                    generator.effect10 = this.checkBox10.Checked;
                    generator.effect11 = this.checkBox11.Checked;
                    generator.insertTransitionClips = InsertTransitions.Checked;
                    generator.width = Convert.ToInt32(this.WidthSet.Value, new CultureInfo("en-US"));
                    generator.height = Convert.ToInt32(this.HeightSet.Value, new CultureInfo("en-US"));
                    generator.intro = this.InsertIntro.Checked;
                    generator.outro = this.InsertOutro.Checked;
                    Console.WriteLine("poop5");
                    foreach (string sourcem in sources)
                    {
                        generator.addSource("\"" + sourcem + "\"");
                    }
                    Console.WriteLine("poop6");
                    int maxclips = Convert.ToInt32(Clips.Value, new CultureInfo("en-US"));
                    generator.setMaxClips(Convert.ToInt32(Clips.Value, new CultureInfo("en-US")));
                    generator.setMaxDuration(Convert.ToDouble(MaxStreamDur.Value, new CultureInfo("en-US")));
                    generator.setMinDuration(Convert.ToDouble(MinStreamDur.Value, new CultureInfo("en-US")));
                    Console.WriteLine("poop7");

                    double timeStarted = nanoTime();
                    double elapsedTime = nanoTime() - timeStarted;


                    globalGen = generator.go(new ProgressChangedEventHandler(progress), new RunWorkerCompletedEventHandler(complete));
                    Console.WriteLine("poop8");
                }
                catch (Exception ex)
                {
                    Render.Enabled = true;
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
        private void Render_Click(object sender, EventArgs e)
        {
            RenderVideo();
        }

        private void m_render_Click(object sender, EventArgs e)
        {
            RenderVideo();
        }

        private void m_ffmpeg_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialogFFmpeg.ShowDialog();
            if (result == DialogResult.OK)
            {
                ffmpeg = openFileDialogFFmpeg.FileName;
                TestFFMPEG();
            }
        }

        private void m_ffprobe_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialogFFProbe.ShowDialog();
            if (result == DialogResult.OK)
            {
                ffmpeg = openFileDialogFFProbe.FileName;
                TestFFPROBE();
            }
        }

        private void m_about_Click(object sender, EventArgs e)
        {
            AboutBox dialog = new AboutBox();
            dialog.ShowDialog();
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            if (renderComplete)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(temp + "tempoutput.mp4"))
                    {
                        FileInfo file = new FileInfo(temp + "tempoutput.mp4");
                        file.CopyTo(saveFileDialog.FileName);
                    }
                }
            }
        }

        private void m_printconfig_Click(object sender, EventArgs e)
        {
            alert("My FFMPEG is: " + ffmpeg
                + "\n\n" + "My FFPROBE is: " + ffprobe
                + "\n\n" + "My MAGICK is: " + magick
                + "\n\n" + "My TEMP is: " + temp
                + "\n\n" + "My SOUNDS is: " + sounds
                + "\n\n" + "My SOURCES is: " + TransitionDir.Text
                + "\n\n" + "My MUSIC is: " + music
                + "\n\n" + "My RESOURCES is: " + resources);
        }

        private void m_saveas_Click(object sender, EventArgs e)
        {
            if (renderComplete)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(temp + "tempoutput.mp4"))
                    {
                        FileInfo file = new FileInfo(temp + "tempoutput.mp4");
                        file.CopyTo(saveFileDialog.FileName);
                    }
                }
            }
        }
    }
}
