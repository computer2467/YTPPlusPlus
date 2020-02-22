using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DiscordRPC;
using DiscordRPC.Logging;
using Microsoft.WindowsAPICodePack.Taskbar;
using Vlc.DotNet.Forms;
using YTPPlusPlus.YTPPlus;

namespace YTPPlusPlus
{
    public partial class YTPPlusPlus : Form
    {
        //vlc check
        private VlcControl _player;

        private bool _renderComplete = true;
        //tool variables
        private string _ffmpeg = "ffmpeg.exe";
        private string _ffprobe = "ffprobe.exe";
        private string _magick = "magick";
        private string _temp = "temp\\";
        private string _sounds = "sounds\\";
        private string _music = "music\\";
        private string _resources = "resources\\";

        private string[] _sources = new string[0];
        //default variables
        private const bool TransitionsDef = true;
        private const bool Effect1Def = true;
        private const bool Effect2Def = true;
        private const bool Effect3Def = true;
        private const bool Effect4Def = true;
        private const bool Effect5Def = true;
        private const bool Effect6Def = true;
        private const bool Effect7Def = true;
        private const bool Effect8Def = true;
        private const bool Effect9Def = true;
        private const bool Effect10Def = true;
        private const bool Effect11Def = true;
        private const bool IntroBoolDef = false;
        private const bool OutroBoolDef = true;
        private const bool PluginTestDef = false;
        private const int ClipCountDef = 20;
        private const int WidthDef = 640;
        private const int HeightDef = 480;
        private const decimal MinStreamDef = 0.2M;
        private const decimal MaxStreamDef = 0.4M;
        private const string IntroDef = "resources\\intro.mp4";
        private const string OutroDef = "resources\\outro.mp4";
        private const string FfmpegDef = "ffmpeg.exe";
        private const string FfprobeDef = "ffprobe.exe";
        private const string MagickDef = "magick";
        private const string SourcesDef = "sources\\";
        private const string TempDef = "temp\\";
        private const string SoundsDef = "sounds\\";
        private const string MusicDef = "music\\";
        private const string ResourcesDef = "resources\\";
        private YTPGenerator _globalGen;
        private int _pluginCount;
        private readonly List<string> _enabledPlugins = new List<string>();
        private TaskbarManager _taskbarInstance;
        private SoundPlayer _renderCompleteSnd;
        private SoundPlayer _renderFailedSnd;
        private readonly DiscordRpcClient _client;
        private readonly Timestamps _timestamps = new Timestamps(DateTime.UtcNow);

        private void ResetVars()
        {
            InsertTransitions.Checked = TransitionsDef;
            effect_RandomSound.Checked = Effect1Def;
            effect_RandomSoundMute.Checked = Effect2Def;
            effect_Reverse.Checked = Effect3Def;
            effect_SpeedUp.Checked = Effect4Def;
            effect_SlowDown.Checked = Effect5Def;
            effect_Chorus.Checked = Effect6Def;
            effect_Vibrato.Checked = Effect7Def;
            effect_HighPitch.Checked = Effect8Def;
            effect_SlowDown.Checked = Effect9Def;
            effect_Dance.Checked = Effect10Def;
            effect_Squidward.Checked = Effect11Def;
            pluginTest.Checked = PluginTestDef;
            InsertIntro.Checked = IntroBoolDef;
            InsertOutro.Checked = OutroBoolDef;
            Clips.Value = ClipCountDef;
            WidthSet.Value = WidthDef;
            HeightSet.Value = HeightDef;
            MinStreamDur.Value = MinStreamDef;
            MaxStreamDur.Value = MaxStreamDef;
            Intro.Text = $@"{Directory.GetCurrentDirectory()}\{IntroDef}";
            Outro.Text = $@"{Directory.GetCurrentDirectory()}\{OutroDef}";
            _ffmpeg = $"{Directory.GetCurrentDirectory()}\\{FfmpegDef}";
            _ffprobe = $"{Directory.GetCurrentDirectory()}\\{FfprobeDef}";
            _magick = MagickDef;
            TransitionDir.Text = $@"{Directory.GetCurrentDirectory()}\{SourcesDef}";
            _temp = $"{Directory.GetCurrentDirectory()}\\{TempDef}";
            _sounds = $"{Directory.GetCurrentDirectory()}\\{SoundsDef}";
            _music = $"{Directory.GetCurrentDirectory()}\\{MusicDef}";
            _resources = $"{Directory.GetCurrentDirectory()}\\{ResourcesDef}";
            _pluginCount = 0;
            _enabledPlugins.Clear();
            plugins.MenuItems.Clear();
            _renderCompleteSnd = new SoundPlayer($"{_resources}\\rendercomplete.wav");
            _renderFailedSnd = new SoundPlayer($"{_resources}\\renderfailed.wav");
            if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\plugins")) {
                var d = Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\plugins", "*.bat");
                foreach (var s in d)
                {
                    void F(object sender, EventArgs args)
                    {
                        var ss = (MenuItem)sender;
                        ss.Checked = !ss.Checked;
                        if (ss.Checked)
                        {
                            _pluginCount++;
                            _enabledPlugins.Add(s);
                        }
                        else
                        {
                            _pluginCount--;
                            _enabledPlugins.Remove(s);
                        }
                    }
                    plugins.MenuItems.Remove(noPlugins);
                    var newstring = s.Replace($"{Directory.GetCurrentDirectory()}\\plugins\\", "");
                    plugins.MenuItems.Add(new MenuItem(newstring, F));
                }
            }

        }
        //end default variables

        public void SetVars()
        {
            InsertTransitions.Checked = Properties.Settings.Default.InsertTransitions;
            effect_RandomSound.Checked = Properties.Settings.Default.effect_RandomSound;
            effect_RandomSoundMute.Checked = Properties.Settings.Default.effect_RandomSoundMute;
            effect_Reverse.Checked = Properties.Settings.Default.effect_Reverse;
            effect_SpeedUp.Checked = Properties.Settings.Default.effect_SpeedUp;
            effect_SlowDown.Checked = Properties.Settings.Default.effect_SlowDown;
            effect_Chorus.Checked = Properties.Settings.Default.effect_Chorus;
            effect_Vibrato.Checked = Properties.Settings.Default.effect_Vibrato;
            effect_HighPitch.Checked = Properties.Settings.Default.effect_HighPitch;
            effect_SlowDown.Checked = Properties.Settings.Default.effect_SlowDown;
            effect_Dance.Checked = Properties.Settings.Default.effect_Dance;
            effect_Squidward.Checked = Properties.Settings.Default.effect_Squidward;
            pluginTest.Checked = Properties.Settings.Default.PluginTest;
            InsertIntro.Checked = Properties.Settings.Default.InsertIntro;
            InsertOutro.Checked = Properties.Settings.Default.InsertOutro;
            Clips.Value = Properties.Settings.Default.Clips;
            WidthSet.Value = Properties.Settings.Default.Width;
            HeightSet.Value = Properties.Settings.Default.Height;
            MinStreamDur.Value = Properties.Settings.Default.MinStreamDur;
            MaxStreamDur.Value = Properties.Settings.Default.MaxStreamDur;
            Intro.Text = Properties.Settings.Default.Intro;
            Outro.Text = Properties.Settings.Default.Outro;
            _ffmpeg = Properties.Settings.Default.FFmpeg;
            _ffprobe = Properties.Settings.Default.FFprobe;
            _magick = MagickDef;
            TransitionDir.Text = Properties.Settings.Default.TransitionDir;
            _temp = Properties.Settings.Default.Temp;
            _sounds = Properties.Settings.Default.Sounds;
            _music = Properties.Settings.Default.Music;
            _resources = Properties.Settings.Default.Resources;
            if (Properties.Settings.Default.Theme == "Dark")
            {
                theme_light.Checked = false;
                theme_dark.Checked = true;
                theme_custom.Checked = false;
                SwitchTheme(Color.FromName("ControlDarkDark"), Color.FromName("ControlDark"), Color.FromName("Control"), Color.FromName("ControlText"));
            }
            else if (Properties.Settings.Default.Theme == "Light")
            {
                theme_light.Checked = true;
                theme_dark.Checked = false;
                theme_custom.Checked = false;
                SwitchTheme(Color.FromName("ControlLightLight"), Color.FromName("ControlLight"), Color.FromName("Control"), Color.FromName("ControlText"));
            }
            else if (Properties.Settings.Default.Theme == "Custom") {
                theme_custom.Checked = true;
                theme_dark.Checked = false;
                theme_light.Checked = false;
                Alert("CUSTOM THEME NOT IMPLEMENTED");
            } else
            {
                Properties.Settings.Default.Theme = "Dark";
                theme_light.Checked = false;
                theme_dark.Checked = true;
                theme_custom.Checked = false;
                SwitchTheme(Color.FromName("ControlDarkDark"), Color.FromName("ControlDark"), Color.FromName("Control"), Color.FromName("ControlText"));
                Alert("THEME NOT SUPPORTED");
            }
            _pluginCount = 0;
            _enabledPlugins.Clear();
            plugins.MenuItems.Clear();
            _renderCompleteSnd = new SoundPlayer($"{_resources}\\rendercomplete.wav");
            _renderFailedSnd = new SoundPlayer($"{_resources}\\renderfailed.wav");
            if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\plugins"))
            {
                var d = Directory.GetFiles($"{Directory.GetCurrentDirectory()}\\plugins", "*.bat");
                foreach (var s in d)
                {
                    void F(object sender, EventArgs args)
                    {
                        var ss = (MenuItem)sender;
                        ss.Checked = !ss.Checked;
                        if (ss.Checked)
                        {
                            _pluginCount++;
                            _enabledPlugins.Add(s);
                        }
                        else
                        {
                            _pluginCount--;
                            _enabledPlugins.Remove(s);
                        }
                    }
                    plugins.MenuItems.Remove(noPlugins);
                    var newstring = s.Replace($"{Directory.GetCurrentDirectory()}\\plugins\\", "");
                    plugins.MenuItems.Add(new MenuItem(newstring, F));
                }
            }

        }


        //console import
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SwHide = 0;
        private const int SwShow = 5;
        private bool _consoleShowing;

        public static void ShowConsoleWindow()
        {
            var handle = GetConsoleWindow();

            if (handle == IntPtr.Zero)
            {
                AllocConsole();
            }
            else
            {
                ShowWindow(handle, SwShow);
            }
        }

        public static void HideConsoleWindow()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SwHide);
        }
        //end console import


        public string[] Titles = { "Yo", "Mmmmm!", "I'm the invisible man...", "Luigi, look!", "You want it?", "WTF Booooooooooom" };
        public FileInfo Fi; //= new FileInfo("D:\\Users\\Kisu-Amare\\Downloads\\spongebob1.mp4");
        public void TestMagick()
        {
            try
            {
                var process = new Process();
                var startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = _magick;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                process.StartInfo = startInfo;

                process.Start();
                process.WaitForExit();
                if (process.ExitCode == 1)
                {
                    Alert("ImageMagick is not installed. The Squidward effect has been disabled.\nPlease install ImageMagick and add it to your system PATH, or select \"Set magick.exe\" in the Tools menu.");
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
                Alert("ImageMagick is not installed. The Squidward effect has been disabled.\nPlease install ImageMagick and add it to your system PATH, or select \"Set magick.exe\" in the Tools menu.");
                effect_Squidward.Enabled = false;
                effect_Squidward.Checked = false;
            }
        }
        public void TestFfmpeg()
        {
            try
            {
                var process = new Process();
                var startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = _ffmpeg;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                process.StartInfo = startInfo;

                process.Start();
                process.WaitForExit();
            }
            catch
            {
                Alert("FFMPEG is not installed. It may have been misplaced, make sure it is in the same directory as YTP++!");
                Environment.Exit(1);
            }
        }
        public void TestFfprobe()
        {
            try
            {
                var process = new Process();
                var startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = _ffprobe;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                process.StartInfo = startInfo;

                process.Start();
                process.WaitForExit();
            }
            catch
            {
                Alert("FFPROBE is not installed. It may have been misplaced, make sure it is in the same directory as YTP++!");
                Environment.Exit(1);
            }
        }
        public void VlcC(DirectoryInfo dir)
        {
            _player = new VlcControl();
            ((ISupportInitialize)(_player)).BeginInit();
            _player.Anchor = AnchorStyles.Top;
            _player.BackColor = Color.Black;
            _player.Enabled = false;
            _player.Location = new Point(-1, -1);
            _player.Name = "Player";
            _player.Size = new Size(320, 240);
            _player.Spu = -1;
            _player.TabIndex = 0;
            _player.VlcMediaplayerOptions = null;
            _player.VlcLibDirectory = dir;
            Video.Controls.Add(_player);
            ((ISupportInitialize)(_player)).EndInit();
            //VLCCheck.global.Close();
            _player.Enabled = true;
            if (Properties.Settings.Default.Intro == "resources\\intro.mp4")
                Properties.Settings.Default.Intro =
                    $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.Intro}";
            if (Properties.Settings.Default.Outro == "resources\\outro.mp4")
                Properties.Settings.Default.Outro =
                    $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.Outro}";
            if (Properties.Settings.Default.FFmpeg == "ffmpeg.exe")
                Properties.Settings.Default.FFmpeg =
                    $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.FFmpeg}";
            if (Properties.Settings.Default.FFprobe == "ffprobe.exe")
                Properties.Settings.Default.FFprobe =
                    $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.FFprobe}";
            if (Properties.Settings.Default.TransitionDir == "sources\\")
                Properties.Settings.Default.TransitionDir =
                    $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.TransitionDir}";
            if (Properties.Settings.Default.Temp == "temp\\")
                Properties.Settings.Default.Temp =
                    $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.Temp}";
            if (Properties.Settings.Default.Sounds == "sounds\\")
                Properties.Settings.Default.Sounds =
                    $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.Sounds}";
            if (Properties.Settings.Default.Music == "music\\")
                Properties.Settings.Default.Music =
                    $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.Music}";
            if (Properties.Settings.Default.Resources == "resources\\")
                Properties.Settings.Default.Resources =
                    $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.Resources}";
            SetVars();
            HideConsoleWindow();
            //this.Player.SetMedia(fi);
            //this.Player.Play();
            _player.Enabled = false;
            m_saveas.Enabled = false;
            SaveAs.Enabled = false;
            TestFfmpeg();
            TestFfprobe();
            TestMagick();
        }
        public YTPPlusPlus()
        {
            InitializeComponent();
            if (Directory.Exists(Properties.Settings.Default.VLC))
            {
                VlcC(new DirectoryInfo(Properties.Settings.Default.VLC));
            }
            else
            {
                var result = folderBrowserVLC.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Properties.Settings.Default.VLC = folderBrowserVLC.SelectedPath;
                    VlcC(new DirectoryInfo(folderBrowserVLC.SelectedPath));
                }
                else
                {
                    PausePlay.Enabled = false;
                    Start.Enabled = false;
                    End.Enabled = false;
                    if (Properties.Settings.Default.Intro == "resources\\intro.mp4")
                        Properties.Settings.Default.Intro =
                            $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.Intro}";
                    if (Properties.Settings.Default.Outro == "resources\\outro.mp4")
                        Properties.Settings.Default.Outro =
                            $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.Outro}";
                    if (Properties.Settings.Default.FFmpeg == "ffmpeg.exe")
                        Properties.Settings.Default.FFmpeg =
                            $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.FFmpeg}";
                    if (Properties.Settings.Default.FFprobe == "ffprobe.exe")
                        Properties.Settings.Default.FFprobe =
                            $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.FFprobe}";
                    if (Properties.Settings.Default.TransitionDir == "sources\\")
                        Properties.Settings.Default.TransitionDir =
                            $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.TransitionDir}";
                    if (Properties.Settings.Default.Temp == "temp\\")
                        Properties.Settings.Default.Temp =
                            $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.Temp}";
                    if (Properties.Settings.Default.Sounds == "sounds\\")
                        Properties.Settings.Default.Sounds =
                            $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.Sounds}";
                    if (Properties.Settings.Default.Music == "music\\")
                        Properties.Settings.Default.Music =
                            $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.Music}";
                    if (Properties.Settings.Default.Resources == "resources\\")
                        Properties.Settings.Default.Resources =
                            $"{Directory.GetCurrentDirectory()}\\{Properties.Settings.Default.Resources}";
                    SetVars();
                    HideConsoleWindow();
                    //this.Player.SetMedia(fi);
                    //this.Player.Play();
                    SaveAs.Enabled = false;
                    m_saveas.Enabled = false;
                    TestFfmpeg();
                    TestFfprobe();
                    TestMagick();
                }
            }

            //DISCORD RPC
            /*
	        Create a discord client
	        NOTE: 	If you are using Unity3D, you must use the full constructor and define
			         the pipe connection.
	        */
            _client = new DiscordRpcClient("655125577669410829")
            {
                //Set the logger
                Logger = new ConsoleLogger {Level = LogLevel.Warning}
            };

            //Subscribe to events
            _client.OnReady += (sender, e) =>
            {
                Console.WriteLine(@"Received Ready from user {0}", e.User.Username);
            };
            //Connect to the RPC
            _client.Initialize();

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            _client.SetPresence(new RichPresence
            {
                Details = Titles[new Random().Next(0, Titles.Length)],
                Assets = new Assets
                {
                    LargeImageKey = "icon",
                    LargeImageText = "YTP++, made with ❤ in C#."
                },
                State = "Idle",
                Timestamps = _timestamps
            });
        }
        private static void YTPPlusPlus_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void PausePlay_Click(object sender, EventArgs e)
        {
            if (TaskbarManager.IsPlatformSupported)
            {
                _taskbarInstance.SetProgressState(TaskbarProgressBarState.NoProgress);
            }
            if (_player.IsPlaying)
            {
                PausePlay.Text = @"▶️";
                _player.Pause();
            }
            else
            {
                PausePlay.Text = @"| |";
                _player.Play();
            }
            _client.SetPresence(new RichPresence
            {
                Details = Titles[new Random().Next(0, Titles.Length)],
                Assets = new Assets
                {
                    LargeImageKey = "icon",
                    LargeImageText = "YTP++, made with ❤ in C#."
                },
                State = "Idle",
                Timestamps = _timestamps
            });
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (TaskbarManager.IsPlatformSupported)
            {
                _taskbarInstance.SetProgressState(TaskbarProgressBarState.NoProgress);
            }
            if (Fi != null)
            {
                
                _player.SetMedia(Fi);
                _player.Position = 0;
                _player.Play();
                PausePlay.Text = @"| |";
            }
            _client.SetPresence(new RichPresence
            {
                Details = Titles[new Random().Next(0, Titles.Length)],
                Assets = new Assets
                {
                    LargeImageKey = "icon",
                    LargeImageText = "YTP++, made with ❤ in C#."
                },
                State = "Idle",
                Timestamps = _timestamps
            });
        }

        private void End_Click(object sender, EventArgs e)
        {
            if (TaskbarManager.IsPlatformSupported)
            {
                _taskbarInstance.SetProgressState(TaskbarProgressBarState.NoProgress);
            }
            _player.Position += 0.1f;
            if (_player.Position > 1f)
                _player.Position = 0.999f;
            _client.SetPresence(new RichPresence
            {
                Details = Titles[new Random().Next(0, Titles.Length)],
                Assets = new Assets
                {
                    LargeImageKey = "icon",
                    LargeImageText = "YTP++, made with ❤ in C#."
                },
                State = "Idle",
                Timestamps = _timestamps
            });
        }

        private void m_console_Click(object sender, EventArgs e)
        {
            GetConsoleWindow();
            if (_consoleShowing)
            {
                // Hide console
                HideConsoleWindow();
            }
            else
            {
                // Show console
                ShowConsoleWindow();
            }
            _consoleShowing = !_consoleShowing;
            m_console.Checked = _consoleShowing;
        }

        private void Alert(string alertText)
        {
            MessageBox.Show(this, alertText, Titles[new Random().Next(0, Titles.Length)]);
        }
        private void m_helpeffects_Click(object sender, EventArgs e)
        {
            Alert("From the YTP+ Documentation: \n\"Currently, these effects are based on a switch statement, and each effect has an equal chance of appearing, which means if you "
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
            Alert("Configuration can be done within the \"Tools\" menu.\n\n"
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
            Process.Start("https://discord.gg/bzhzRmg");
        }

        private void m_reset_Click(object sender, EventArgs e)
        {
            ResetVars();
        }

        private void m_magick_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            var result = openFileDialogMagick.ShowDialog();
            if (result != DialogResult.OK) return;
            _magick = openFileDialogMagick.FileName;
            TestMagick();
        }

        private void m_temp_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            var result = folderBrowserTemp.ShowDialog();
            if (result == DialogResult.OK)
            {
                _temp = folderBrowserTemp.SelectedPath;
            }
        }

        private void m_sounds_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            var result = folderBrowserSounds.ShowDialog();
            if (result == DialogResult.OK)
            {
                _sounds = folderBrowserSounds.SelectedPath;
            }
        }

        private void m_music_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            var result = folderBrowserMusic.ShowDialog();
            if (result == DialogResult.OK)
            {
                _music = folderBrowserMusic.SelectedPath;
            }
        }

        private void m_resources_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            var result = folderBrowserResources.ShowDialog();
            if (result == DialogResult.OK)
            {
                _resources = folderBrowserResources.SelectedPath;
            }
        }
        public void AddSource()
        {
            // Show the dialog and get result.
            var result = openFileDialogSource.ShowDialog();
            if (result != DialogResult.OK) return;
            foreach (var file in openFileDialogSource.FileNames)
            {
                Array.Resize(ref _sources, _sources.Length + 1);
                _sources[_sources.GetUpperBound(0)] = file;
                Material.Text += $@"{file}
";
                //assuming these all don't work
                if (file.Contains(" "))
                {
                    Alert("One or more materials added in this batch has a space in its path or file name. While YTP++ will still try to render with the material in question, be aware that this may cause a render failure.");
                }
                else if (file.Contains("+"))
                {
                    Alert("One or more materials added in this batch has a + symbol in its path or file name. While YTP++ will still try to render with the material in question, be aware that this may cause a render failure.");
                }
                else if (file.Contains("%"))
                {
                    Alert("One or more materials added in this batch has a % symbol in its path or file name. While YTP++ will still try to render with the material in question, be aware that this may cause a render failure.");
                }
                else if (file.Contains("&"))
                {
                    Alert("One or more materials added in this batch has an & symbol in its path or file name. While YTP++ will still try to render with the material in question, be aware that this may cause a render failure.");
                }
                else if (file.Contains("*"))
                {
                    Alert("One or more materials added in this batch has a * symbol in its path or file name. While YTP++ will still try to render with the material in question, be aware that this may cause a render failure.");
                }
                else if (file.Contains("="))
                {
                    Alert("One or more materials added in this batch has a = symbol in its path or file name. While YTP++ will still try to render with the material in question, be aware that this may cause a render failure.");
                }
                else if (file.Contains("~"))
                {
                    Alert("One or more materials added in this batch has a ~ symbol in its path or file name. While YTP++ will still try to render with the material in question, be aware that this may cause a render failure.");
                }
            }
        }
        public void ClearSources()
        {
            _sources = new string[0];
            Material.Text = "";
        }

        private void AddMaterial_Click(object sender, EventArgs e)
        {
            AddSource();
        }

        private void m_addmaterial_Click(object sender, EventArgs e)
        {
            AddSource();
        }

        private void ClearMaterial_Click(object sender, EventArgs e)
        {
            ClearSources();
        }

        private void m_clearmaterials_Click(object sender, EventArgs e)
        {
            ClearSources();
        }

        public void Progress(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if (TaskbarManager.IsPlatformSupported)
            {
                _taskbarInstance.SetProgressValue(e.ProgressPercentage,100);
            }
            _client.SetPresence(new RichPresence
            {
                Details = Titles[new Random().Next(0, Titles.Length)],
                Assets = new Assets
                {
                    LargeImageKey = "icon",
                    LargeImageText = "YTP++, made with ❤ in C#."
                },
                State = $"Rendering... ({e.ProgressPercentage}%)",
                Timestamps = _timestamps
            });
        }

        private void Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 100;
            if (TaskbarManager.IsPlatformSupported)
            {
                _taskbarInstance.SetProgressValue(100, 100);
            }
            if (_player != null)
                _player.Enabled = true;
            _renderComplete = true;
            SaveAs.Enabled = true;
            m_saveas.Enabled = true;
            _player?.Stop();
            Fi = new FileInfo($"{_temp}tempoutput.mp4");
            _player?.SetMedia(Fi);
            PausePlay.Text = @"▶️";
            Render.Enabled = true;
            m_render.Enabled = true;
            if (_globalGen.Failed)
            {
                if (TaskbarManager.IsPlatformSupported)
                {
                    _taskbarInstance.SetProgressState(TaskbarProgressBarState.Error);
                }
                _client.SetPresence(new RichPresence
                {
                    Details = Titles[new Random().Next(0, Titles.Length)],
                    Assets = new Assets
                    {
                        LargeImageKey = "icon",
                        LargeImageText = "YTP++, made with ❤ in C#."
                    },
                    State = "Render failed",
                    Timestamps = _timestamps
                });
                _renderFailedSnd.Play();
                Alert(
                    $"An exception has occured during rendering. Rendering may have not produced a result.\n\nThe last exception to occur was:\n{_globalGen.Exc.Message}");
            } else
            {
                _renderCompleteSnd.Play();
                _client.SetPresence(new RichPresence
                {
                    Details = Titles[new Random().Next(0, Titles.Length)],
                    Assets = new Assets
                    {
                        LargeImageKey = "icon",
                        LargeImageText = "YTP++, made with ❤ in C#."
                    },
                    State = "Render complete",
                    Timestamps = _timestamps
                });
            }
        }
        public void RenderVideo()
        {
            if (_sources.Length == 0)
            {
                Alert("You need some sources...");
            }
            else
            {
                try
                {
                    _client.SetPresence(new RichPresence
                    {
                        Details = Titles[new Random().Next(0, Titles.Length)],
                        Assets = new Assets
                        {
                            LargeImageKey = "icon",
                            LargeImageText = "YTP++, made with ❤ in C#."
                        },
                        State = "Rendering...",
                        Timestamps = _timestamps
                    });
                    if (TaskbarManager.IsPlatformSupported)
                    {
                        _taskbarInstance = TaskbarManager.Instance;
                    }

                    _player?.Stop();
                    _renderComplete = false;
                    if(_player != null)
                        _player.Enabled = false;
                    m_saveas.Enabled = false;
                    SaveAs.Enabled = false;
                    Render.Enabled = false;
                    m_render.Enabled = false;
                    Console.WriteLine(@"poop");
                    var generator = new YTPGenerator($"{_temp}tempoutput.mp4");
                    Console.WriteLine(@"poop2");
                    generator.ToolBox.Ffmpeg = $"\"{_ffmpeg}\"";
                    generator.ToolBox.Ffprobe = $"\"{_ffprobe}\"";
                    generator.ToolBox.Magick = $"\"{_magick}\"";
                    Console.WriteLine(@"poop3");
                    var jobDir = $"{_temp}job_{DateTimeOffset.Now.ToUnixTimeMilliseconds()}\\";
                    generator.ToolBox.Temp = jobDir;
                    Directory.CreateDirectory(jobDir);
                    Directory.CreateDirectory(generator.ToolBox.Temp);
                    generator.ToolBox.Sounds = _sounds;
                    generator.ToolBox.Music = _music;
                    generator.ToolBox.Resources = _resources;
                    generator.ToolBox.Sources = TransitionDir.Text;
                    generator.ToolBox.Intro = Intro.Text;
                    generator.ToolBox.Outro = Outro.Text;
                    Console.WriteLine(@"poop4");
                    generator.Effect1 = effect_RandomSound.Checked;
                    generator.Effect2 = effect_RandomSoundMute.Checked;
                    generator.Effect3 = effect_Reverse.Checked;
                    generator.Effect4 = effect_SpeedUp.Checked;
                    generator.Effect5 = effect_SlowDown.Checked;
                    generator.Effect6 = effect_Chorus.Checked;
                    generator.Effect7 = effect_Vibrato.Checked;
                    generator.Effect8 = effect_HighPitch.Checked;
                    generator.Effect9 = effect_LowPitch.Checked;
                    generator.Effect10 = effect_Dance.Checked;
                    generator.Effect11 = effect_Squidward.Checked;
                    generator.PluginCount = _pluginCount;
                    generator.Plugins = _enabledPlugins;
                    generator.InsertTransitionClips = InsertTransitions.Checked;
                    generator.Width = Convert.ToInt32(WidthSet.Value, new CultureInfo("en-US"));
                    generator.Height = Convert.ToInt32(HeightSet.Value, new CultureInfo("en-US"));
                    generator.Intro = InsertIntro.Checked;
                    generator.Outro = InsertOutro.Checked;
                    generator.PluginTest = pluginTest.Checked;
                    Console.WriteLine(@"poop5");
                    foreach (var sourcem in _sources)
                    {
                        generator.AddSource($"\"{sourcem}\"");
                    }
                    Console.WriteLine(@"poop6");
                    generator.SetMaxClips(Convert.ToInt32(Clips.Value, new CultureInfo("en-US")));
                    generator.SetMaxDuration(Convert.ToDouble(MaxStreamDur.Value, new CultureInfo("en-US")));
                    generator.SetMinDuration(Convert.ToDouble(MinStreamDur.Value, new CultureInfo("en-US")));
                    Console.WriteLine(@"poop7");

                    if (TaskbarManager.IsPlatformSupported)
                    {
                        _taskbarInstance.SetProgressState(TaskbarProgressBarState.Normal);
                    }
                    _globalGen = generator.Go(Progress, Complete);
                    Console.WriteLine(@"poop8");
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
            var result = openFileDialogFFmpeg.ShowDialog();
            if (result == DialogResult.OK)
            {
                _ffmpeg = openFileDialogFFmpeg.FileName;
                TestFfmpeg();
            }
        }

        private void m_ffprobe_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            var result = openFileDialogFFProbe.ShowDialog();
            if (result == DialogResult.OK)
            {
                _ffmpeg = openFileDialogFFProbe.FileName;
                TestFfprobe();
            }
        }

        private void m_about_Click(object sender, EventArgs e)
        {
            var dialog = new AboutBox();
            dialog.ShowDialog();
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            if (TaskbarManager.IsPlatformSupported)
            {
                _taskbarInstance.SetProgressState(TaskbarProgressBarState.NoProgress);
            }
            if (_renderComplete)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists($"{_temp}tempoutput.mp4"))
                    {
                        var file = new FileInfo($"{_temp}tempoutput.mp4");
                        file.CopyTo(saveFileDialog.FileName);
                    }
                }
            }
            _client.SetPresence(new RichPresence
            {
                Details = Titles[new Random().Next(0, Titles.Length)],
                Assets = new Assets
                {
                    LargeImageKey = "icon",
                    LargeImageText = "YTP++, made with ❤ in C#."
                },
                State = "Idle",
                Timestamps = _timestamps
            });
        }

        private void m_printconfig_Click(object sender, EventArgs e)
        {
            Alert(
                $"My FFMPEG is: {_ffmpeg}\n\nMy FFPROBE is: {_ffprobe}\n\nMy MAGICK is: {_magick}\n\nMy TEMP is: {_temp}\n\nMy SOUNDS is: {_sounds}\n\nMy SOURCES is: {TransitionDir.Text}\n\nMy MUSIC is: {_music}\n\nMy RESOURCES is: {_resources}\n\nMy VLC is: {Properties.Settings.Default.VLC}");
        }

        private void m_saveas_Click(object sender, EventArgs e)
        {
            if (_renderComplete)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists($"{_temp}tempoutput.mp4"))
                    {
                        var file = new FileInfo($"{_temp}tempoutput.mp4");
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
                Alert("Enabling plugin testing will cause the effect switch to only select plugins and no other effects.");
            }
        }
        private void theme_dark_Click(object sender, EventArgs e)
        {
            theme_light.Checked = false;
            theme_dark.Checked = true;
            theme_custom.Checked = false;
            Properties.Settings.Default.Theme = "Dark";
            SwitchTheme(Color.FromName("ControlDarkDark"), Color.FromName("ControlDark"), Color.FromName("Control"),Color.FromName("ControlText"));
        }

        private void theme_light_Click(object sender, EventArgs e)
        {
            theme_light.Checked = true;
            theme_dark.Checked = false;
            theme_custom.Checked = false;
            Properties.Settings.Default.Theme = "Light";
            SwitchTheme(Color.FromName("ControlLightLight"), Color.FromName("ControlLight"), Color.FromName("Control"), Color.FromName("ControlText"));
        }

        private void SwitchTheme(Color backColor, Color foreColor, Color subColor, Color textColor)
        {
            BackColor = backColor;

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
            FormClosing += YTPPlusPlus_FormClosing;
        }
    }
}
