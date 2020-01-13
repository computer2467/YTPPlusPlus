using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
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
        bool pluginTestDef = false;
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
        int pluginCount = 0;
        List<string> enabledPlugins = new List<string>();
        Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager taskbarInstance;
        System.Media.SoundPlayer renderCompleteSnd;
        System.Media.SoundPlayer renderFailedSnd;
        public DiscordRpcClient client;
        public DiscordRPC.Timestamps timestamps = new DiscordRPC.Timestamps(DateTime.UtcNow);
        public void ResetVars()
        {
            this.InsertTransitions.Checked = transitionsDef;
            this.effect_RandomSound.Checked = effect1Def;
            this.effect_RandomSoundMute.Checked = effect2Def;
            this.effect_Reverse.Checked = effect3Def;
            this.effect_SpeedUp.Checked = effect4Def;
            this.effect_SlowDown.Checked = effect5Def;
            this.effect_Chorus.Checked = effect6Def;
            this.effect_Vibrato.Checked = effect7Def;
            this.effect_HighPitch.Checked = effect8Def;
            this.effect_SlowDown.Checked = effect9Def;
            this.effect_Dance.Checked = effect10Def;
            this.effect_Squidward.Checked = effect11Def;
            this.pluginTest.Checked = pluginTestDef;
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
            pluginCount = 0;
            enabledPlugins.Clear();
            plugins.MenuItems.Clear();
            this.renderCompleteSnd = new System.Media.SoundPlayer(this.resources + "\\rendercomplete.wav");
            this.renderFailedSnd = new System.Media.SoundPlayer(this.resources + "\\renderfailed.wav");
            if (Directory.Exists(Directory.GetCurrentDirectory() + "\\plugins")) {
                string[] d = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\plugins", "*.bat");
                foreach (string s in d)
                {
                    void f(object sender, EventArgs args)
                    {
                        MenuItem ss = (MenuItem)sender;
                        ss.Checked = !ss.Checked;
                        if (ss.Checked == true)
                        {
                            pluginCount++;
                            enabledPlugins.Add(s);
                        }
                        else
                        {
                            pluginCount--;
                            enabledPlugins.Remove(s);
                        }
                    }
                    plugins.MenuItems.Remove(noPlugins);
                    string newstring = s.Replace(Directory.GetCurrentDirectory() + "\\plugins\\", "");
                    plugins.MenuItems.Add(new MenuItem(newstring, f));
                }
            }

        }
        //end default variables

        public void SetVars()
        {
            this.InsertTransitions.Checked = Properties.Settings.Default.InsertTransitions;
            this.effect_RandomSound.Checked = Properties.Settings.Default.effect_RandomSound;
            this.effect_RandomSoundMute.Checked = Properties.Settings.Default.effect_RandomSoundMute;
            this.effect_Reverse.Checked = Properties.Settings.Default.effect_Reverse;
            this.effect_SpeedUp.Checked = Properties.Settings.Default.effect_SpeedUp;
            this.effect_SlowDown.Checked = Properties.Settings.Default.effect_SlowDown;
            this.effect_Chorus.Checked = Properties.Settings.Default.effect_Chorus;
            this.effect_Vibrato.Checked = Properties.Settings.Default.effect_Vibrato;
            this.effect_HighPitch.Checked = Properties.Settings.Default.effect_HighPitch;
            this.effect_SlowDown.Checked = Properties.Settings.Default.effect_SlowDown;
            this.effect_Dance.Checked = Properties.Settings.Default.effect_Dance;
            this.effect_Squidward.Checked = Properties.Settings.Default.effect_Squidward;
            this.pluginTest.Checked = Properties.Settings.Default.PluginTest;
            this.InsertIntro.Checked = Properties.Settings.Default.InsertIntro;
            this.InsertOutro.Checked = Properties.Settings.Default.InsertOutro;
            this.Clips.Value = Properties.Settings.Default.Clips;
            this.WidthSet.Value = Properties.Settings.Default.Width;
            this.HeightSet.Value = Properties.Settings.Default.Height;
            this.MinStreamDur.Value = Properties.Settings.Default.MinStreamDur;
            this.MaxStreamDur.Value = Properties.Settings.Default.MaxStreamDur;
            this.Intro.Text = Properties.Settings.Default.Intro;
            this.Outro.Text = Properties.Settings.Default.Outro;
            this.ffmpeg = Properties.Settings.Default.FFmpeg;
            this.ffprobe = Properties.Settings.Default.FFprobe;
            this.magick = magickDef;
            this.TransitionDir.Text = Properties.Settings.Default.TransitionDir;
            this.temp = Properties.Settings.Default.Temp;
            this.sounds = Properties.Settings.Default.Sounds;
            this.music = Properties.Settings.Default.Music;
            this.resources = Properties.Settings.Default.Resources;
            if (Properties.Settings.Default.Theme == "Dark")
            {
                theme_light.Checked = false;
                theme_dark.Checked = true;
                theme_custom.Checked = false;
                switchTheme(Color.FromName("ControlDarkDark"), Color.FromName("ControlDark"), Color.FromName("Control"), Color.FromName("ControlText"));
            }
            else if (Properties.Settings.Default.Theme == "Light")
            {
                theme_light.Checked = true;
                theme_dark.Checked = false;
                theme_custom.Checked = false;
                switchTheme(Color.FromName("ControlLightLight"), Color.FromName("ControlLight"), Color.FromName("Control"), Color.FromName("ControlText"));
            }
            else if (Properties.Settings.Default.Theme == "Custom") {
                theme_custom.Checked = true;
                theme_dark.Checked = false;
                theme_light.Checked = false;
                alert("CUSTOM THEME NOT IMPLEMENTED");
            } else
            {
                Properties.Settings.Default.Theme = "Dark";
                theme_light.Checked = false;
                theme_dark.Checked = true;
                theme_custom.Checked = false;
                switchTheme(Color.FromName("ControlDarkDark"), Color.FromName("ControlDark"), Color.FromName("Control"), Color.FromName("ControlText"));
                alert("THEME NOT SUPPORTED");
            }
            pluginCount = 0;
            enabledPlugins.Clear();
            plugins.MenuItems.Clear();
            this.renderCompleteSnd = new System.Media.SoundPlayer(this.resources + "\\rendercomplete.wav");
            this.renderFailedSnd = new System.Media.SoundPlayer(this.resources + "\\renderfailed.wav");
            if (Directory.Exists(Directory.GetCurrentDirectory() + "\\plugins"))
            {
                string[] d = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\plugins", "*.bat");
                foreach (string s in d)
                {
                    void f(object sender, EventArgs args)
                    {
                        MenuItem ss = (MenuItem)sender;
                        ss.Checked = !ss.Checked;
                        if (ss.Checked == true)
                        {
                            pluginCount++;
                            enabledPlugins.Add(s);
                        }
                        else
                        {
                            pluginCount--;
                            enabledPlugins.Remove(s);
                        }
                    }
                    plugins.MenuItems.Remove(noPlugins);
                    string newstring = s.Replace(Directory.GetCurrentDirectory() + "\\plugins\\", "");
                    plugins.MenuItems.Add(new MenuItem(newstring, f));
                }
            }

        }


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
                    effect_Squidward.Enabled = false;
                    effect_Squidward.Checked = false;
                }
                else
                {
                    effect_Squidward.Enabled = true;
                    effect_Squidward.Checked = true;
                }
            }
            catch
            {
                alert("ImageMagick is not installed. The Squidward effect has been disabled.\nPlease install ImageMagick and add it to your system PATH, or select \"Set magick.exe\" in the Tools menu.");
                effect_Squidward.Enabled = false;
                effect_Squidward.Checked = false;
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
            if (Properties.Settings.Default.Intro == "resources\\intro.mp4")
                Properties.Settings.Default.Intro = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.Intro;
            if (Properties.Settings.Default.Outro == "resources\\outro.mp4")
                Properties.Settings.Default.Outro = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.Outro;
            if (Properties.Settings.Default.FFmpeg == "ffmpeg.exe")
                Properties.Settings.Default.FFmpeg = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.FFmpeg;
            if (Properties.Settings.Default.FFprobe == "ffprobe.exe")
                Properties.Settings.Default.FFprobe = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.FFprobe;
            if (Properties.Settings.Default.TransitionDir == "sources\\")
                Properties.Settings.Default.TransitionDir = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.TransitionDir;
            if (Properties.Settings.Default.Temp == "temp\\")
                Properties.Settings.Default.Temp = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.Temp;
            if (Properties.Settings.Default.Sounds == "sounds\\")
                Properties.Settings.Default.Sounds = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.Sounds;
            if (Properties.Settings.Default.Music == "music\\")
                Properties.Settings.Default.Music = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.Music;
            if (Properties.Settings.Default.Resources == "resources\\")
                Properties.Settings.Default.Resources = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.Resources;
            SetVars();
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
            if (Directory.Exists(Properties.Settings.Default.VLC))
            {
                vlcC(new DirectoryInfo(Properties.Settings.Default.VLC));
            }
            else
            {
                DialogResult result = folderBrowserVLC.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Properties.Settings.Default.VLC = folderBrowserVLC.SelectedPath;
                    vlcC(new DirectoryInfo(folderBrowserVLC.SelectedPath));
                }
                else
                {
                    PausePlay.Enabled = false;
                    Start.Enabled = false;
                    End.Enabled = false;
                    if (Properties.Settings.Default.Intro == "resources\\intro.mp4")
                        Properties.Settings.Default.Intro = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.Intro;
                    if (Properties.Settings.Default.Outro == "resources\\outro.mp4")
                        Properties.Settings.Default.Outro = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.Outro;
                    if (Properties.Settings.Default.FFmpeg == "ffmpeg.exe")
                        Properties.Settings.Default.FFmpeg = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.FFmpeg;
                    if (Properties.Settings.Default.FFprobe == "ffprobe.exe")
                        Properties.Settings.Default.FFprobe = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.FFprobe;
                    if (Properties.Settings.Default.TransitionDir == "sources\\")
                        Properties.Settings.Default.TransitionDir = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.TransitionDir;
                    if (Properties.Settings.Default.Temp == "temp\\")
                        Properties.Settings.Default.Temp = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.Temp;
                    if (Properties.Settings.Default.Sounds == "sounds\\")
                        Properties.Settings.Default.Sounds = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.Sounds;
                    if (Properties.Settings.Default.Music == "music\\")
                        Properties.Settings.Default.Music = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.Music;
                    if (Properties.Settings.Default.Resources == "resources\\")
                        Properties.Settings.Default.Resources = Directory.GetCurrentDirectory() + "\\" + Properties.Settings.Default.Resources;
                    SetVars();
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

            //DISCORD RPC
            /*
	        Create a discord client
	        NOTE: 	If you are using Unity3D, you must use the full constructor and define
			         the pipe connection.
	        */
            client = new DiscordRpcClient("655125577669410829");

            //Set the logger
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            //Subscribe to events
            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };
            //Connect to the RPC
            client.Initialize();

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(new RichPresence()
            {
                Details = titles[new Random().Next(0, titles.Length)],
                Assets = new Assets()
                {
                    LargeImageKey = "icon",
                    LargeImageText = "YTP++, made with ❤ in C#."
                },
                State = "Idle",
                Timestamps = timestamps
            });
        }
        private void YTPPlusPlus_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
        public void PlayVideo(FileInfo fil)
        {
            fi = fil;
            
            this.Player.SetMedia(fi);
            this.Player.Play();
        }
        private void PausePlay_Click(object sender, EventArgs e)
        {
            if (Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.IsPlatformSupported)
            {
                taskbarInstance.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.NoProgress);
            }
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
            client.SetPresence(new RichPresence()
            {
                Details = titles[new Random().Next(0, titles.Length)],
                Assets = new Assets()
                {
                    LargeImageKey = "icon",
                    LargeImageText = "YTP++, made with ❤ in C#."
                },
                State = "Idle",
                Timestamps = timestamps
            });
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.IsPlatformSupported)
            {
                taskbarInstance.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.NoProgress);
            }
            if (fi != null)
            {
                
                this.Player.SetMedia(fi);
                this.Player.Position = 0;
                this.Player.Play();
                this.PausePlay.Text = "| |";
            }
            client.SetPresence(new RichPresence()
            {
                Details = titles[new Random().Next(0, titles.Length)],
                Assets = new Assets()
                {
                    LargeImageKey = "icon",
                    LargeImageText = "YTP++, made with ❤ in C#."
                },
                State = "Idle",
                Timestamps = timestamps
            });
        }

        private void End_Click(object sender, EventArgs e)
        {
            if (Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.IsPlatformSupported)
            {
                taskbarInstance.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.NoProgress);
            }
            this.Player.Position += 0.1f;
            if (this.Player.Position > 1f)
                this.Player.Position = 0.999f;
            client.SetPresence(new RichPresence()
            {
                Details = titles[new Random().Next(0, titles.Length)],
                Assets = new Assets()
                {
                    LargeImageKey = "icon",
                    LargeImageText = "YTP++, made with ❤ in C#."
                },
                State = "Idle",
                Timestamps = timestamps
            });
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
            if (Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.IsPlatformSupported)
            {
                taskbarInstance.SetProgressValue(e.ProgressPercentage,100);
            }
            client.SetPresence(new RichPresence()
            {
                Details = titles[new Random().Next(0, titles.Length)],
                Assets = new Assets()
                {
                    LargeImageKey = "icon",
                    LargeImageText = "YTP++, made with ❤ in C#."
                },
                State = "Rendering... ("+ e.ProgressPercentage+"%)",
                Timestamps = timestamps
            });
        }
        public void complete(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 100;
            if (Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.IsPlatformSupported)
            {
                taskbarInstance.SetProgressValue(100, 100);
            }
            if (this.Player != null)
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
                if (Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.IsPlatformSupported)
                {
                    taskbarInstance.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.Error);
                }
                client.SetPresence(new RichPresence()
                {
                    Details = titles[new Random().Next(0, titles.Length)],
                    Assets = new Assets()
                    {
                        LargeImageKey = "icon",
                        LargeImageText = "YTP++, made with ❤ in C#."
                    },
                    State = "Render failed",
                    Timestamps = timestamps
                });
                renderFailedSnd.Play();
                alert("An exception has occured during rendering. Rendering may have not produced a result.\n\nThe last exception to occur was:\n" + globalGen.exc.Message);
            } else
            {
                renderCompleteSnd.Play();
                client.SetPresence(new RichPresence()
                {
                    Details = titles[new Random().Next(0, titles.Length)],
                    Assets = new Assets()
                    {
                        LargeImageKey = "icon",
                        LargeImageText = "YTP++, made with ❤ in C#."
                    },
                    State = "Render complete",
                    Timestamps = timestamps
                });
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
                    client.SetPresence(new RichPresence()
                    {
                        Details = titles[new Random().Next(0, titles.Length)],
                        Assets = new Assets()
                        {
                            LargeImageKey = "icon",
                            LargeImageText = "YTP++, made with ❤ in C#."
                        },
                        State = "Rendering...",
                        Timestamps = timestamps
                    });
                    if (Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.IsPlatformSupported)
                    {
                        taskbarInstance = Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.Instance;
                    }
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
                    string jobDir = temp + "job_" + DateTimeOffset.Now.ToUnixTimeMilliseconds() + "\\";
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
                    generator.effect1 = this.effect_RandomSound.Checked;
                    generator.effect2 = this.effect_RandomSoundMute.Checked;
                    generator.effect3 = this.effect_Reverse.Checked;
                    generator.effect4 = this.effect_SpeedUp.Checked;
                    generator.effect5 = this.effect_SlowDown.Checked;
                    generator.effect6 = this.effect_Chorus.Checked;
                    generator.effect7 = this.effect_Vibrato.Checked;
                    generator.effect8 = this.effect_HighPitch.Checked;
                    generator.effect9 = this.effect_LowPitch.Checked;
                    generator.effect10 = this.effect_Dance.Checked;
                    generator.effect11 = this.effect_Squidward.Checked;
                    generator.pluginCount = pluginCount;
                    generator.plugins = enabledPlugins;
                    generator.insertTransitionClips = InsertTransitions.Checked;
                    generator.width = Convert.ToInt32(this.WidthSet.Value, new CultureInfo("en-US"));
                    generator.height = Convert.ToInt32(this.HeightSet.Value, new CultureInfo("en-US"));
                    generator.intro = this.InsertIntro.Checked;
                    generator.outro = this.InsertOutro.Checked;
                    generator.pluginTest = pluginTest.Checked;
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

                    if (Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.IsPlatformSupported)
                    {
                        taskbarInstance.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.Normal);
                    }
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
            if (Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.IsPlatformSupported)
            {
                taskbarInstance.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.NoProgress);
            }
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
            client.SetPresence(new RichPresence()
            {
                Details = titles[new Random().Next(0, titles.Length)],
                Assets = new Assets()
                {
                    LargeImageKey = "icon",
                    LargeImageText = "YTP++, made with ❤ in C#."
                },
                State = "Idle",
                Timestamps = timestamps
            });
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
                + "\n\n" + "My RESOURCES is: " + resources
                + "\n\n" + "My VLC is: " + Properties.Settings.Default.VLC);
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

        private void effect_Reverse_Click(object sender, EventArgs e)
        {
            effect_Reverse.Checked = !effect_Reverse.Checked;
            Properties.Settings.Default.effect_Reverse = effect_Reverse.Checked;
        }

        private void effect_HighPitch_Click(object sender, EventArgs e)
        {
            effect_HighPitch.Checked = !effect_HighPitch.Checked;
            Properties.Settings.Default.effect_HighPitch = effect_HighPitch.Checked;
        }

        private void effect_SpeedUp_Click(object sender, EventArgs e)
        {
            effect_SpeedUp.Checked = !effect_SpeedUp.Checked;
            Properties.Settings.Default.effect_SpeedUp = effect_SpeedUp.Checked;
        }

        private void effect_LowPitch_Click(object sender, EventArgs e)
        {
            effect_LowPitch.Checked = !effect_LowPitch.Checked;
            Properties.Settings.Default.effect_LowPitch = effect_LowPitch.Checked;
        }

        private void effect_SlowDown_Click(object sender, EventArgs e)
        {
            effect_SlowDown.Checked = !effect_SlowDown.Checked;
            Properties.Settings.Default.effect_SlowDown = effect_SlowDown.Checked;
        }

        private void effect_Dance_Click(object sender, EventArgs e)
        {
            effect_Dance.Checked = !effect_Dance.Checked;
            Properties.Settings.Default.effect_Dance = effect_Dance.Checked;
        }

        private void effect_Squidward_Click(object sender, EventArgs e)
        {
            effect_Squidward.Checked = !effect_Squidward.Checked;
            Properties.Settings.Default.effect_Squidward = effect_Squidward.Checked;
        }

        private void effect_RandomSound_Click(object sender, EventArgs e)
        {
            effect_RandomSound.Checked = !effect_RandomSound.Checked;
            Properties.Settings.Default.effect_RandomSound = effect_RandomSound.Checked;
        }
        private void effect_RandomSoundMute_Click(object sender, EventArgs e)
        {
            effect_RandomSoundMute.Checked = !effect_RandomSoundMute.Checked;
            Properties.Settings.Default.effect_RandomSoundMute = effect_RandomSoundMute.Checked;
        }

        private void effect_Chorus_Click(object sender, EventArgs e)
        {
            effect_Chorus.Checked = !effect_Chorus.Checked;
            Properties.Settings.Default.effect_Chorus = effect_Chorus.Checked;
        }

        private void effect_Vibrato_Click(object sender, EventArgs e)
        {
            effect_Vibrato.Checked = !effect_Vibrato.Checked;
            Properties.Settings.Default.effect_Vibrato = effect_Vibrato.Checked;
        }

        private void pluginTest_Click(object sender, EventArgs e)
        {
            pluginTest.Checked = !pluginTest.Checked;
            Properties.Settings.Default.PluginTest = pluginTest.Checked;
            if (pluginTest.Checked)
            {
                alert("Enabling plugin testing will cause the effect switch to only select plugins and no other effects.");
            }
        }
        private void theme_dark_Click(object sender, EventArgs e)
        {
            theme_light.Checked = false;
            theme_dark.Checked = true;
            theme_custom.Checked = false;
            Properties.Settings.Default.Theme = "Dark";
            switchTheme(Color.FromName("ControlDarkDark"), Color.FromName("ControlDark"), Color.FromName("Control"),Color.FromName("ControlText"));
        }

        private void theme_light_Click(object sender, EventArgs e)
        {
            theme_light.Checked = true;
            theme_dark.Checked = false;
            theme_custom.Checked = false;
            Properties.Settings.Default.Theme = "Light";
            switchTheme(Color.FromName("ControlLightLight"), Color.FromName("ControlLight"), Color.FromName("Control"), Color.FromName("ControlText"));
        }

        public void switchTheme(Color backColor, Color foreColor, Color subColor, Color textColor)
        {
            this.BackColor = backColor;

            Video.BackColor = foreColor;
            Materials.BackColor = foreColor;
            Settings.BackColor = foreColor;
            RenderSettings.BackColor = foreColor;

            Material.BackColor = subColor;
            Render.BackColor = subColor;
            Start.BackColor = subColor;
            PausePlay.BackColor = subColor;
            End.BackColor = subColor;
            SaveAs.BackColor = subColor;
            AddMaterial.BackColor = subColor;
            ClearMaterial.BackColor = subColor;
            progressBar1.BackColor = subColor;

            Material.ForeColor = textColor;
            Render.ForeColor = textColor;
            Start.ForeColor = textColor;
            PausePlay.ForeColor = textColor;
            End.ForeColor = textColor;
            SaveAs.ForeColor = textColor;
            AddMaterial.ForeColor = textColor;
            ClearMaterial.ForeColor = textColor;
            progressBar1.ForeColor = textColor;
            MaterialLabel.ForeColor = textColor;
            RenderSettingsLabel.ForeColor = textColor;
        }

        private void YTPPlusPlus_Load(object sender, EventArgs e)
        {
            this.FormClosing += YTPPlusPlus_FormClosing;
        }
    }
}
