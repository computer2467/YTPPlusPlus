using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;

namespace YTPPlusPlus.YTPPlus
{
    public class Utilities
    {
        public string Ffprobe;
        public string Ffmpeg;
        public string Magick;

        public string Temp = "";
        public string Sources = "";
        public string Sounds = "";
        public string Music = "";
        public string Resources = "";

        public string Intro = "";
        public string Outro = "";

        /**
         * Return the length of a video (in seconds)
         *
         * @param video input video filename to work with
         * @return Video length as a string (output from ffprobe)
         */
        public string GetVideoLength(string video)
        {
            try
            {
                var process = new Process();
                var startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = Ffprobe;
                startInfo.Arguments =
                    $"-v error -sexagesimal -show_entries format=duration -of default=noprint_wrappers=1:nokey=1 \"{video}\"";
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
                return errorText;
            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); return ""; }
        }

        public string GetLength(string file)
        {
            try
            {
                var process = new Process();
                var startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = Ffprobe;
                startInfo.Arguments = $"-i \"{file}\" -show_entries format=duration -v quiet -of csv=\"p=0\"";
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                process.StartInfo = startInfo;
                process.Start();
                var s = "";
                // Read stdout synchronously (on this thread)

                while (true)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (line == null)
                        break;
                    Console.WriteLine(line);
                    s = line;
                }

                process.WaitForExit();
                Console.WriteLine(s);
                return s;

            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); return ""; }
        }

        /**
         * Snip a video file between the start and end time, and save it to an output file.
         *
         * @param video input video filename to work with
         * @param startTime start time (in TimeStamp format, e.g. new TimeStamp(seconds);)
         * @param endTime start time (in TimeStamp format, e.g. new TimeStamp(seconds);)
         * @param output output video filename to save the snipped clip to
         */
        public void SnipVideo(string video, double startTime, double endTime, string output, int width, int height)
        {
            try
            {
                var process = new Process();
                var startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = Ffmpeg;
                startInfo.Arguments =
                    $"-i \"{video}\" -ss {startTime.ToString("0.#########################", new CultureInfo("en-US"))} -to {endTime.ToString("0.#########################", new CultureInfo("en-US"))} -ac 1 -ar 44100 -vf scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1,fps=fps=30 -y {output}.mp4";
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

                if (process.HasExited && process.ExitCode == 1)
                {
                    Console.WriteLine(@"ERROR");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
        }

        /**
         * Copies a video and encodes it in the proper format without changes.
         *
         * @param video input video filename to work with
         * @param output output video filename to save the snipped clip to
         */
        public void CopyVideo(string video, string output, int width, int height)
        {
            try
            {
                var process = new Process();
                var startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = Ffmpeg;
                startInfo.Arguments =
                    $"-i \"{video}\" -ar 44100 -ac 1 -vf scale={width.ToString("0.#########################", new CultureInfo("en-US"))}x{height.ToString("0.#########################", new CultureInfo("en-US"))},setsar=1:1,fps=fps=30 -y {output}.mp4";
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


                if (process.HasExited && process.ExitCode == 1)
                {
                    Console.WriteLine(@"ERROR");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
        }

        /**
         * Concatenate videos by count
         *
         * @param count number of input videos to concatenate
         * @param out output video filename
         */
        public void ConcatenateVideo(int count, string ou)
        {
            try
            {
                if (File.Exists(ou))
                    File.Delete(ou);

                var command1 = "";

                for (var i = 0; i < count; i++)
                {
                    if (File.Exists($"{Temp}video{i}.mp4"))
                    {
                        command1 += (" -i " + Temp + "video" + i + ".mp4");
                    }
                }
                command1 += (" -filter_complex \"");

                var realcount = 0;
                for (var i = 0; i < count; i++)
                {
                    if (File.Exists($"{Temp}video{i}.mp4"))
                    {
                        realcount += 1;
                    }
                }
                for (var i = 0; i < realcount; i++)
                {
                    command1 += ("[" + i + ":v:0][" + i + ":a:0]");
                }

                //realcount +=1;
                command1 += ("concat=n=" + realcount + ":v=1:a=1[outv][outa]\" -map \"[outv]\" -map \"[outa]\" -y " + ou);
                Console.WriteLine(command1);

                var process = new Process();
                var startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = Ffmpeg;
                startInfo.Arguments = command1;
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


                //cmdLine = CommandLine.parse(command2);
                //executor = new DefaultExecutor();
                //exitValue = executor.execute(cmdLine);

                //temp.delete();

            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
        }
    }
}
