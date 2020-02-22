using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;

namespace YTPPlusPlus.YTPPlus
{
    public class EffectsFactory
    {
        private readonly Utilities _toolBox;
        private readonly Random _rnd = new Random();

        public EffectsFactory(Utilities utilities)
        {
            _toolBox = utilities;
        }

        private string PickSound()
        {
            var d = Directory.GetFiles(_toolBox.Sounds, "*.mp3");
            var file = new FileInfo(d[RandomInt(0, d.Length - 1)]);
            return file.Name;
        }
        public string PickSource()
        {
            var d = Directory.GetFiles(_toolBox.Sources, "*.mp4");
            Console.WriteLine(d.Length);
            var file = new FileInfo(d[RandomInt(0, d.Length - 1)]);
            return file.Name;
        }

        private string PickMusic()
        {
            var d = Directory.GetFiles(_toolBox.Music, "*.mp3");
            var file = new FileInfo(d[RandomInt(0, d.Length - 1)]);
            return file.Name;
        }
        /* EFFECTS */
        public void effect_RandomSound(string video, int width, int height)
        {
            Console.WriteLine(@"effect_RandomSound initiated");
            try
            {
                var inVid = new FileInfo(video);
                var temp = $"{_toolBox.Temp}temp.mp4";
                if (File.Exists(video))
                {
                    File.Delete(temp);
                    inVid.MoveTo(temp);
                }

                var randomSound = PickSound();

                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = _toolBox.Ffmpeg,
                    Arguments =
                        $"-i {_toolBox.Temp}temp.mp4 -i {_toolBox.Sounds}{randomSound} -filter_complex \"[1:a]volume=1,apad[A];[0:a][A]amerge[out]\" -ac 2 -ar 44100 -vf scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1,fps=fps=30 -map 0:v -map [out] -y {video}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };
                process.StartInfo = startInfo;
                process.Start();
                // Read stderr synchronously (on another thread)

                var stderrThread = new Thread(() => { process.StandardOutput.ReadToEnd(); });
                stderrThread.Start();

                // Read stdout synchronously (on this thread)

                while (true)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (line == null)
                        break;

                    Console.WriteLine(line);
                }

                process.WaitForExit();
                stderrThread.Join(); 
                File.Delete(temp);
            }
            catch (Exception ex) { Console.WriteLine($@"effect
{ex}"); }
        }

        public void effect_RandomSoundMute(string video, int width, int height)
        {
            Console.WriteLine(@"effect_RandomSoundMute initiated");
            try
            {
                var randomSound = PickSound();
                var soundLength = _toolBox.GetLength(_toolBox.Sounds + randomSound);
                Console.WriteLine($@"Doing a mute now. {randomSound} length: {soundLength}.");
                var inVid = new FileInfo(video);

                var temp = $"{_toolBox.Temp}temp.mp4";
                var temp2 = $"{_toolBox.Temp}temp2.mp4";
                if (File.Exists(video))
                {
                    File.Delete(temp);
                    inVid.MoveTo(temp);
                }
                if (File.Exists(temp2))
                {
                    File.Delete(temp2);
                }
                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = _toolBox.Ffmpeg,
                    Arguments =
                        $"-i {_toolBox.Temp}temp.mp4 -ar 44100 -vf scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1,fps=fps=30 -af \"volume=0\" -y {_toolBox.Temp}temp2.mp4",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };

                process.StartInfo = startInfo;
                process.Start();
                // Read stderr synchronously (on another thread)

                var process1 = process;
                var stderrThread = new Thread(() => { process1.StandardOutput.ReadToEnd(); });
                stderrThread.Start();

                // Read stdout synchronously (on this thread)

                while (true)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (line == null)
                        break;

                    Console.WriteLine(line);
                }

                process.WaitForExit();
                stderrThread.Join();

                process = new Process();
                startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = _toolBox.Ffmpeg,
                    Arguments =
                        $"-i {_toolBox.Temp}temp2.mp4 -i \"{_toolBox.Sounds}{randomSound}\" -to {soundLength} -ar 44100 -vf scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1,fps=fps=30 -filter_complex \"[1:a]volume=1,apad[A]; [0:a][A]amerge[out]\" -ac 2 -map 0:v -map [out] -y {video}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };

                process.StartInfo = startInfo;
                process.Start();
                // Read stderr synchronously (on another thread)

                stderrThread = new Thread(() => { process.StandardOutput.ReadToEnd(); });
                stderrThread.Start();

                // Read stdout synchronously (on this thread)

                while (true)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (line == null)
                        break;

                    Console.WriteLine(line);
                }

                process.WaitForExit();
                stderrThread.Join();

                File.Delete(temp);
                File.Delete(temp2);
            }
            catch (Exception ex) { Console.WriteLine($@"effect
{ex}"); }
        }

        public void effect_Reverse(string video, int width, int height)
        {
            Console.WriteLine(@"effect_Reverse initiated");
            try
            {
                var randomSound = PickSound();
                var soundLength = _toolBox.GetLength(_toolBox.Sounds + randomSound);
                Console.WriteLine($@"Doing a mute now. {randomSound} length: {soundLength}.");
                var inVid = new FileInfo(video);

                var temp = $"{_toolBox.Temp}temp.mp4";
                var temp2 = $"{_toolBox.Temp}temp2.mp4";
                if (File.Exists(video))
                {
                    File.Delete(temp);
                    inVid.MoveTo(temp);
                }
                if (File.Exists(temp2))
                {
                    File.Delete(temp2);
                }
                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = _toolBox.Ffmpeg,
                    Arguments =
                        $"-i {_toolBox.Temp}temp.mp4 -map 0 -ar 44100 -vf scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1,fps=fps=30 -af \"areverse\" -y {_toolBox.Temp}temp2.mp4",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };

                process.StartInfo = startInfo;
                process.Start();
                // Read stderr synchronously (on another thread)

                var process1 = process;
                var stderrThread = new Thread(() => { process1.StandardOutput.ReadToEnd(); });
                stderrThread.Start();

                // Read stdout synchronously (on this thread)

                while (true)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (line == null)
                        break;

                    Console.WriteLine(line);
                }

                process.WaitForExit();
                stderrThread.Join();

                process = new Process();
                startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = _toolBox.Ffmpeg,
                    Arguments =
                        $"-i {_toolBox.Temp}temp2.mp4 -ar 44100 -vf scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1,fps=fps=30 -vf reverse -y {video}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };

                process.StartInfo = startInfo;
                process.Start();
                // Read stderr synchronously (on another thread)

                stderrThread = new Thread(() => { process.StandardOutput.ReadToEnd(); });
                stderrThread.Start();

                // Read stdout synchronously (on this thread)

                while (true)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (line == null)
                        break;

                    Console.WriteLine(line);
                }

                process.WaitForExit();
                stderrThread.Join();

                File.Delete(temp);
                File.Delete(temp2);
            }
            catch (Exception ex) { Console.WriteLine($@"effect
{ex}"); }
        }
        public void effect_SpeedUp(string video, int width, int height)
        {
            Console.WriteLine(@"effect_SpeedUp initiated");
            try
            {
                var inVid = new FileInfo(video);
                var temp = $"{_toolBox.Temp}temp.mp4";
                if (File.Exists(video))
                {
                    File.Delete(temp);
                    inVid.MoveTo(temp);
                }

                PickSound();

                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = _toolBox.Ffmpeg,
                    Arguments =
                        $"-i {_toolBox.Temp}temp.mp4 -ar 44100 -vf scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1,fps=fps=30 -filter:v setpts=0.5*PTS -filter:a atempo=2.0 -y {video}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };
                process.StartInfo = startInfo;
                process.Start();
                // Read stderr synchronously (on another thread)

                var stderrThread = new Thread(() => { process.StandardOutput.ReadToEnd(); });
                stderrThread.Start();

                // Read stdout synchronously (on this thread)

                while (true)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (line == null)
                        break;

                    Console.WriteLine(line);
                }

                process.WaitForExit();
                stderrThread.Join();

                File.Delete(temp);
            }
            catch (Exception ex) { Console.WriteLine($@"effect
{ex}"); }
        }

        public void effect_SlowDown(string video, int width, int height)
        {
            Console.WriteLine(@"effect_SlowDown initiated");
            try
            {
                var inVid = new FileInfo(video);
                var temp = $"{_toolBox.Temp}temp.mp4";
                if (File.Exists(video))
                {
                    File.Delete(temp);
                    inVid.MoveTo(temp);
                }

                PickSound();

                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = _toolBox.Ffmpeg,
                    Arguments =
                        $"-i {_toolBox.Temp}temp.mp4 -ar 44100 -vf scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1,fps=fps=30 -filter:v setpts=2*PTS -filter:a atempo=0.5 -y {video}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };
                process.StartInfo = startInfo;
                process.Start();
                // Read stderr synchronously (on another thread)

                var stderrThread = new Thread(() => { process.StandardOutput.ReadToEnd(); });
                stderrThread.Start();

                // Read stdout synchronously (on this thread)

                while (true)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (line == null)
                        break;

                    Console.WriteLine(line);
                }

                process.WaitForExit();
                stderrThread.Join();

                File.Delete(temp);
            }
            catch (Exception ex) { Console.WriteLine($@"effect
{ex}"); }
        }

        public void effect_Chorus(string video, int width, int height)
        {
            Console.WriteLine(@"effect_Chorus initiated");
            try
            {
                var inVid = new FileInfo(video);
                var temp = $"{_toolBox.Temp}temp.mp4";
                if (File.Exists(video))
                {
                    File.Delete(temp);
                    inVid.MoveTo(temp);
                }

                PickSound();

                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = _toolBox.Ffmpeg,
                    Arguments =
                        $"-i {_toolBox.Temp}temp.mp4 -ar 44100 -vf scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1,fps=fps=30 -af chorus=0.5:0.9:50|60|40:0.4|0.32|0.3:0.25|0.4|0.3:2|2.3|1.3 -y {video}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };
                process.StartInfo = startInfo;
                process.Start();
                // Read stderr synchronously (on another thread)

                var stderrThread = new Thread(() => { process.StandardOutput.ReadToEnd(); });
                stderrThread.Start();

                // Read stdout synchronously (on this thread)

                while (true)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (line == null)
                        break;

                    Console.WriteLine(line);
                }

                process.WaitForExit();
                stderrThread.Join();

                File.Delete(temp);
            }
            catch (Exception ex) { Console.WriteLine($@"effect
{ex}"); }
        }

        public void effect_Vibrato(string video, int width, int height)
        {
            Console.WriteLine(@"effect_Vibrato initiated");
            try
            {
                var inVid = new FileInfo(video);
                var temp = $"{_toolBox.Temp}temp.mp4";
                if (File.Exists(video))
                {
                    File.Delete(temp);
                    inVid.MoveTo(temp);
                }

                PickSound();

                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = _toolBox.Ffmpeg,
                    Arguments =
                        $"-i {_toolBox.Temp}temp.mp4 -ar 44100 -vf scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1,fps=fps=30 -af vibrato=f=7.0:d=0.5 -y {video}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };
                process.StartInfo = startInfo;
                process.Start();
                // Read stderr synchronously (on another thread)

                var stderrThread = new Thread(() => { process.StandardOutput.ReadToEnd(); });
                stderrThread.Start();

                // Read stdout synchronously (on this thread)

                while (true)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (line == null)
                        break;

                    Console.WriteLine(line);
                }

                process.WaitForExit();
                stderrThread.Join();

                File.Delete(temp);
            }
            catch (Exception ex) { Console.WriteLine($@"effect
{ex}"); }
        }

        public void effect_LowPitch(string video, int width, int height)
        {
            Console.WriteLine(@"effect_LowPitch initiated");
            try
            {
                var inVid = new FileInfo(video);
                var temp = $"{_toolBox.Temp}temp.mp4";
                if (File.Exists(video))
                {
                    File.Delete(temp);
                    inVid.MoveTo(temp);
                }

                PickSound();

                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = _toolBox.Ffmpeg,
                    Arguments =
                        $"-i {_toolBox.Temp}temp.mp4 -ar 44100 -vf scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1,fps=fps=30 -filter:v setpts=2*PTS -af asetrate=44100*0.5,aresample=44100 -y {video}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };
                process.StartInfo = startInfo;
                process.Start();
                // Read stderr synchronously (on another thread)

                var stderrThread = new Thread(() => { process.StandardOutput.ReadToEnd(); });
                stderrThread.Start();

                // Read stdout synchronously (on this thread)

                while (true)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (line == null)
                        break;

                    Console.WriteLine(line);
                }

                process.WaitForExit();
                stderrThread.Join();

                File.Delete(temp);
            }
            catch (Exception ex) { Console.WriteLine($@"effect
{ex}"); }
        }

        public void effect_HighPitch(string video, int width, int height)
        {
            Console.WriteLine(@"effect_HighPitch initiated");
            try
            {
                var inVid = new FileInfo(video);
                var temp = $"{_toolBox.Temp}temp.mp4";
                if (File.Exists(video))
                {
                    File.Delete(temp);
                    inVid.MoveTo(temp);
                }

                PickSound();

                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = _toolBox.Ffmpeg,
                    Arguments =
                        $"-i {_toolBox.Temp}temp.mp4 -ar 44100 -vf scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1,fps=fps=30 -filter:v setpts=0.5*PTS -af asetrate=44100*2,aresample=44100 -y {video}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };
                process.StartInfo = startInfo;
                process.Start();
                // Read stderr synchronously (on another thread)

                var stderrThread = new Thread(() => { process.StandardOutput.ReadToEnd(); });
                stderrThread.Start();

                // Read stdout synchronously (on this thread)

                while (true)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (line == null)
                        break;

                    Console.WriteLine(line);
                }

                process.WaitForExit();
                stderrThread.Join();

                File.Delete(temp);
            }
            catch (Exception ex) { Console.WriteLine($@"effect
{ex}"); }
        }

        public void effect_Dance(string video, int width, int height)
        {
            Console.WriteLine(@"effect_Dance initiated");
            try
            {
                var inVid = new FileInfo(video);
                var temp = $"{_toolBox.Temp}temp.mp4";   //og file
                var temp2 = $"{_toolBox.Temp}temp2.mp4"; //1st cut
                var temp3 = $"{_toolBox.Temp}temp3.mp4"; //backwards (silent)
                var temp4 = $"{_toolBox.Temp}temp4.mp4"; //forwards (silent)
                var temp5 = $"{_toolBox.Temp}temp5.mp4"; //backwards & forwards concatenated
                var temp6 = $"{_toolBox.Temp}temp6.mp4"; //backwards & forwards concatenated
                var temp7 = $"{_toolBox.Temp}temp7.mp4"; //backwards & forwards concatenated (unused?)

                if (File.Exists(video))
                {
                    File.Delete(temp);
                    inVid.MoveTo(temp);
                }
                if (File.Exists(temp2))
                {
                    File.Delete(temp2);
                }
                if (File.Exists(temp3))
                {
                    File.Delete(temp3);
                }
                if (File.Exists(temp4))
                {
                    File.Delete(temp4);
                }
                if (File.Exists(temp5))
                {
                    File.Delete(temp5);
                }
                if (File.Exists(temp6))
                {
                    File.Delete(temp6);
                }
                if (File.Exists(temp7))
                {
                    File.Delete(temp7);
                }

                var randomSound = PickMusic();

                var commands = new string[6];
                var randomTime = RandomInt(3, 9);
                var randomTime2 = RandomInt(0, 1);

                commands.SetValue(
                    $"-i {_toolBox.Temp}temp.mp4 -map 0 -ar 44100 -to 00:00:0{randomTime2}.{randomTime} -vf scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1 -an -y {_toolBox.Temp}temp2.mp4", 0);

                commands.SetValue(
                    $"-i {_toolBox.Temp}temp2.mp4 -map 0 -ar 44100 -vf reverse,scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1 -y {_toolBox.Temp}temp3.mp4", 1);

                commands.SetValue(
                    $"-i {_toolBox.Temp}temp3.mp4 -ar 44100 -vf reverse,scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1 -y {_toolBox.Temp}temp4.mp4", 2);

                commands.SetValue(
                    $"-i {_toolBox.Temp}temp3.mp4 -i {_toolBox.Temp}temp4.mp4 -filter_complex \"[0:v:0][1:v:0][0:v:0][1:v:0][0:v:0][1:v:0][0:v:0][1:v:0]concat=n=8:v=1[outv]\" -map \"[outv]\" -c:v libx264 -shortest -y {_toolBox.Temp}temp5.mp4", 3);

                commands.SetValue(
                    $"-i {_toolBox.Temp}temp5.mp4 -map 0 -ar 44100 -vf \"setpts=0.5*PTS,scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1\" -af \"atempo=2.0\" -shortest -y {_toolBox.Temp}temp6.mp4", 4);

                commands.SetValue(
                    $"-i {_toolBox.Temp}temp6.mp4 -i {_toolBox.Music}{randomSound} -c:v libx264 -map 0:v:0 -map 1:a:0 -vf \"scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1,fps=fps=30\" -shortest -y {video}", 5);

                foreach (var cmd in commands)
                {
                    var process = new Process();
                    var startInfo = new ProcessStartInfo
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = _toolBox.Ffmpeg,
                        Arguments = cmd,
                        UseShellExecute = false,
                        RedirectStandardOutput = true
                    };
                    process.StartInfo = startInfo;
                    process.Start();
                    // Read stderr synchronously (on another thread)

                    var stderrThread = new Thread(() => { process.StandardOutput.ReadToEnd(); });
                    stderrThread.Start();

                    // Read stdout synchronously (on this thread)

                    while (true)
                    {
                        var line = process.StandardOutput.ReadLine();
                        if (line == null)
                            break;

                        Console.WriteLine(line);
                    }

                    process.WaitForExit();
                    stderrThread.Join();
                }

                File.Delete(temp);
                File.Delete(temp2);
                File.Delete(temp3);
                File.Delete(temp4);
                File.Delete(temp5);
                File.Delete(temp6);
                File.Delete(temp7);
            }
            catch (Exception ex) { Console.WriteLine($@"effect
{ex}"); }
        }

        public void effect_Squidward(string video, int width, int height)
        {
            Console.WriteLine(@"effect_Squidward initiated");
            try
            {
                var inVid = new FileInfo(video);
                var temp = $"{_toolBox.Temp}temp.mp4";   //og file
                var temp2 = $"{_toolBox.Temp}temp2.mp4"; //1st cut
                var temp3 = $"{_toolBox.Temp}temp3.mp4"; //backwards (silent)
                var temp4 = $"{_toolBox.Temp}temp4.mp4"; //forwards (silent)
                var temp5 = $"{_toolBox.Temp}temp5.mp4"; //backwards & forwards concatenated
                var temp6 = $"{_toolBox.Temp}temp6.mp4"; //backwards & forwards concatenated
                var temp7 = $"{_toolBox.Temp}temp7.mp4"; //backwards & forwards concatenated (unused?)

                if (File.Exists(video))
                {
                    File.Delete(temp);
                    inVid.MoveTo(temp);
                }
                if (File.Exists(temp2))
                {
                    File.Delete(temp2);
                }
                if (File.Exists(temp3))
                {
                    File.Delete(temp3);
                }
                if (File.Exists(temp4))
                {
                    File.Delete(temp4);
                }
                if (File.Exists(temp5))
                {
                    File.Delete(temp5);
                }
                if (File.Exists(temp6))
                {
                    File.Delete(temp6);
                }
                if (File.Exists(temp7))
                {
                    File.Delete(temp7);
                }

                PickMusic();

                var commands = new string[8];
                var args = new string[8];
                commands.SetValue(_toolBox.Ffmpeg, 0);
                args.SetValue(
                    $"-i {_toolBox.Temp}temp.mp4 -vf \"select=gte(n\\,1)\" -vframes 1 -y {_toolBox.Temp}squidward0.png", 0);

                for (var i = 1; i < 6; i++)
                {
                    var effect = "";
                    var random = RandomInt(0, 6);
                    switch (random)
                    {
                        case 0:
                            effect = " -flop";
                            break;
                        case 1:
                            effect = " -flip";
                            break;
                        case 2:
                            effect = $" -implode -{RandomInt(1, 3)}";
                            break;
                        case 3:
                            effect = $" -implode {RandomInt(1, 3)}";
                            break;
                        case 4:
                            effect = $" -swirl {RandomInt(1, 180)}";
                            break;
                        case 5:
                            effect = $" -swirl -{RandomInt(1, 180)}";
                            break;
                        case 6:
                            effect = " -channel RGB -negate";
                            break;
                            //case 7:
                            //    effect = " -virtual-pixel Black +distort Cylinder2Plane " + randomInt(1,90);
                            //    break;
                    }
                    commands.SetValue(_toolBox.Magick, i);
                    args.SetValue($"convert {_toolBox.Temp}squidward0.png{effect} {_toolBox.Temp}squidward{i}.png", i
                    );
                }
                commands.SetValue(_toolBox.Magick, 6);
                args.SetValue(
                    $"convert -size {width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))} canvas:black {_toolBox.Temp}black.png", 6);

                if (File.Exists($"{_toolBox.Temp}concatsquidward.txt"))
                    File.Delete($"{_toolBox.Temp}concatsquidward.txt");
                var writer = new StreamWriter($"{_toolBox.Temp}concatsquidward.txt");
                writer.Write
                            ("file 'squidward0.png'\n" +
                            "duration 0.467\n" +
                            "file 'squidward1.png'\n" +
                            "duration 0.434\n" +
                            "file 'squidward2.png'\n" +
                            "duration 0.4\n" +
                            "file 'black.png'\n" +
                            "duration 0.834\n" +
                            "file 'squidward3.png'\n" +
                            "duration 0.467\n" +
                            "file 'squidward4.png'\n" +
                            "duration 0.4\n" +
                            "file 'squidward5.png'\n" +
                            "duration 0.467");
                writer.Close();
                commands.SetValue(_toolBox.Ffmpeg, 7);
                args.SetValue(
                    $"-f concat -i {_toolBox.Temp}concatsquidward.txt -i {_toolBox.Resources}squidward/music.wav -map 0:v:0 -map 1:a:0 -vf \"scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1\" -pix_fmt yuv420p -y {video}", 7);

                //string command = "lib/ffmpeg -i " + toolBox.TEMP + "temp.mp4 -i sounds/"+randomSound+" -c:v copy -map 0:v:0 -map 1:a:0 -shortest "+ video;
                for (var i = 0; i < commands.Length; i++)
                {
                    var process = new Process();
                    var startInfo = new ProcessStartInfo();
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.FileName = commands[i];
                    startInfo.Arguments = args[i];
                    startInfo.UseShellExecute = false;
                    startInfo.RedirectStandardOutput = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    // Read stderr synchronously (on another thread)

                    var stderrThread = new Thread(() => { process.StandardOutput.ReadToEnd(); });
                    stderrThread.Start();

                    // Read stdout synchronously (on this thread)

                    while (true)
                    {
                        var line = process.StandardOutput.ReadLine();
                        if (line == null)
                            break;

                        Console.WriteLine(line);
                    }

                    process.WaitForExit();
                    stderrThread.Join();
                }

                File.Delete(temp);
                for (var i = 0; i < 6; i++)
                {
                    File.Delete($"{_toolBox.Temp}squidward{i}.png");
                }
                File.Delete($"{_toolBox.Temp}black.png");
                File.Delete($"{_toolBox.Temp}concatsquidward.txt");
            }
            catch (Exception ex) { Console.WriteLine($@"effect
{ex}"); }
        }
        /*public void effect_RainbowTrail(string video, int width, int height, double startOfClip, double endOfClip)
        {
            //completely broken don't bother
            Console.WriteLine("effect_RainbowTrail initiated");
            try
            {
                FileInfo inVid = new FileInfo(video);
                string temp = toolBox.TEMP + "temp.mp4";
                if (File.Exists(video))
                {
                    File.Delete(temp);
                    inVid.MoveTo(temp);
                }
                string temp2 = toolBox.TEMP + "temp2.mp4";
                if (File.Exists(temp2))
                {
                    File.Delete(temp2);
                }
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = toolBox.FFMPEG;
                startInfo.Arguments = "-i " + temp
                        + " -vf "
                        + "scale=" + width.ToString("0.#########################", new CultureInfo("en-US")) + "x" + height.ToString("0.#########################", new CultureInfo("en-US")) + ",setsar=1:1,fps=fps=30"
                        + " -y " + temp2;
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                process.StartInfo = startInfo;
                process.Start();

                // Read stderr synchronously (on another thread)

                string errorText = null;
                var stderrThread = new Thread(() => { errorText = process.StandardOutput.ReadToEnd(); });
                stderrThread.Start();

                // Read stdout synchronously (on this thread)

                while (true)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (line == null)
                        break;

                    Console.WriteLine(line);
                }

                process.WaitForExit();
                stderrThread.Join();

                int exitValue = process.ExitCode;

                System.Diagnostics.Process process2 = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo2 = new System.Diagnostics.ProcessStartInfo();
                startInfo2.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo2.FileName = toolBox.FFMPEG;
                startInfo2.Arguments = "-i " + temp2
                        + " -ss " + startOfClip.ToString("0.#########################", new CultureInfo("en-US"))
                        + " -to " + endOfClip.ToString("0.#########################", new CultureInfo("en-US"))
                        + " -ac 1"
                        + " -ar 44100 -vf" //see https://oioiiooixiii.blogspot.com/2017/09/ffmpeg-rainbow-trail-chromakey-effect.html
                        + " split[a][b];[a]colorchannelmixer=2:2:2:2:0:0:0:0:0:0:0:0:0:0:0:0,smartblur,colorchannelmixer=2:0:0:0:0:0:0:0:2:0:0:0:0:0:0:0,setpts=PTS+0.1/TB,split[a][c];[b]colorkey=0x000000:0.1:0.4[b];[c][b]overlay[b];[a]colorchannelmixer=2:2:2:2:0:0:0:0:0:0:0:0:0:0:0:0,smartblur,colorchannelmixer=0.5:0:0:0:0:0:0:0:2:0:0:0:0:0:0:0,setpts=PTS+0.1/TB,split[a][c];[b]colorkey=0x000000:0.1:0.4[b];[c][b]overlay[b];[a]colorchannelmixer=2:2:2:2:0:0:0:0:0:0:0:0:0:0:0:0,smartblur,colorchannelmixer=0:0:0:0:0:0:0:0:2:0:0:0:0:0:0:0,setpts=PTS+0.1/TB,split[a][c];[b]colorkey=0x000000:0.1:0.4[b];[c][b]overlay[b];[a]colorchannelmixer=2:2:2:2:0:0:0:0:0:0:0:0:0:0:0:0,smartblur,colorchannelmixer=0:0:0:0:2:0:0:0:0:0:0:0:0:0:0:0,setpts=PTS+0.1/TB,split[a][c];[b]colorkey=0x000000:0.1:0.4[b];[c][b]overlay[b];[a]colorchannelmixer=2:2:2:2:0:0:0:0:0:0:0:0:0:0:0:0,smartblur,colorchannelmixer=2:0:0:0:2:0:0:0:0:0:0:0:0:0:0:0,setpts=PTS+0.1/TB,split[a][c];[b]colorkey=0x000000:0.1:0.4[b];[c][b]overlay[b];[a]colorchannelmixer=2:2:2:2:0:0:0:0:0:0:0:0:0:0:0:0,smartblur,colorchannelmixer=2:0:0:0:0.5:0:0:0:0:0:0:0:0:0:0:0,setpts=PTS+0.1/TB,split[a][c];[b]colorkey=0x000000:0.1:0.4[b];[c][b]overlay[b];[a]colorchannelmixer=2:2:2:2:0:0:0:0:0:0:0:0:0:0:0:0,smartblur,colorchannelmixer=2:0:0:0:0:0:0:0:0:0:0:0:0:0:0:0,setpts=PTS+0.1/TB,split[a][c];[b]colorkey=0x000000:0.1:0.4[b];[c][b]overlay[b];[a][b]overlay"
                        + " -y " + video;
                startInfo2.UseShellExecute = false;
                startInfo2.RedirectStandardOutput = true;
                process2.StartInfo = startInfo2;
                process2.Start();
                // Read stderr synchronously (on another thread)

                string errorText2 = null;
                var stderrThread2 = new Thread(() => { errorText2 = process2.StandardOutput.ReadToEnd(); });
                stderrThread2.Start();

                // Read stdout synchronously (on this thread)

                while (true)
                {
                    var line = process2.StandardOutput.ReadLine();
                    if (line == null)
                        break;

                    Console.WriteLine(line);
                }

                process2.WaitForExit();
                stderrThread2.Join();

                int exitValue2 = process.ExitCode;
                File.Delete(temp);
                File.Delete(temp2);
            }
            catch (Exception ex) { Console.WriteLine("effect" + "\n" + ex); }
        }*/

        public void effect_Plugin(string video, int width, int height, string plugin, double startOfClip, double endOfClip)
        {
            Console.WriteLine($@"{plugin} initiated");
            try
            {
                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = plugin,
                    Arguments =
                        $"{video} {width} {height} {_toolBox.Temp} {_toolBox.Ffmpeg} {_toolBox.Ffprobe} {_toolBox.Magick} {_toolBox.Resources} {_toolBox.Sounds} {_toolBox.Sources} {_toolBox.Music} {startOfClip.ToString("0.#########################", new CultureInfo("en-US"))} {endOfClip.ToString("0.#########################", new CultureInfo("en-US"))}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };
                process.StartInfo = startInfo;
                process.Start();
                // Read stderr synchronously (on another thread)

                var stderrThread = new Thread(() => { process.StandardOutput.ReadToEnd(); });
                stderrThread.Start();

                // Read stdout synchronously (on this thread)

                while (true)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (line == null)
                        break;

                    Console.WriteLine(line);
                }

                process.WaitForExit();
                stderrThread.Join();
            }
            catch (Exception ex) { Console.WriteLine($@"effect
{ex}"); }
        }

        private int RandomInt(int min, int max)
        {
            return _rnd.Next((max - min) + 1) + min;
            //return new Random((int)GetUnixEpoch(DateTime.UtcNow)).Next((max - min) + 1) + min;
        }
    }
}
