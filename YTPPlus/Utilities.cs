using System;
using System.IO;
using System.Threading;

/**
 * FFMPEG utilities toolbox for YTP+
 *
 * @author benb
 * @author LimeQuartz
 */
namespace YTPPlus
{
    public class Utilities
    {
        public string FFPROBE;
        public string FFMPEG;
        public string MAGICK;

        public string TEMP = "";
        public string SOURCES = "";
        public string SOUNDS = "";
        public string MUSIC = "";
        public string RESOURCES = "";

        public string intro = "";
        public string outro = "";

        /**
         * Return the length of a video (in seconds)
         *
         * @param video input video filename to work with
         * @return Video length as a string (output from ffprobe)
         */
        public string getVideoLength(string video)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = FFPROBE;
                startInfo.Arguments = "-v error"
                        + " -sexagesimal"
                        + " -show_entries format=duration"
                        + " -of default=noprint_wrappers=1:nokey=1"
                        + " \"" + video + "\"";
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                process.StartInfo = startInfo;
                process.Start();
                // Read stderr synchronously (on another thread)
                string s;
                string errorText = null;
                var stderrThread = new Thread(() => { errorText = process.StandardOutput.ReadToEnd(); });
                stderrThread.Start();

                // Read stdout synchronously (on this thread)

                while (true)
                {
                    var line = process.StandardOutput.ReadLine();
                    if (line == null)
                        break;
                    s = line;
                    Console.WriteLine(line);
                }

                process.WaitForExit();
                stderrThread.Join();
                return errorText;
            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); return ""; }
        }

        public string getLength(string file)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = FFPROBE;
                startInfo.Arguments = "-i \"" + file
                        + "\" -show_entries format=duration"
                        + " -v quiet"
                        + " -of csv=\"p=0\"";
                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                process.StartInfo = startInfo;
                process.Start();
                string s = "";
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
        public void snipVideo(string video, double startTime, double endTime, string output, int width, int height)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = FFMPEG;
                startInfo.Arguments = "-i \"" + video
                        + "\" -ss " + startTime
                        + " -to " + endTime
                        + " -ac 1"
                        + " -ar 44100"
                        + " -vf scale=" + width + "x" + height + ",setsar=1:1,fps=fps=30"
                        + " -y"
                        + " " + output + ".mp4";
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

                if (process.HasExited && process.ExitCode == 1)
                {
                    Console.WriteLine("ERROR");
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
        public void copyVideo(String video, String output, int width, int height)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = FFMPEG;
                startInfo.Arguments = "-i \"" + video
                        + "\" -ar 44100"
                        + " -ac 1"
                        //+ " -filter:v fps=fps=30,setsar=1:1"
                        + " -vf scale=" + width + "x" + height + ",setsar=1:1,fps=fps=30"
                        + " -y"
                        + " " + output + ".mp4";
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


                if (process.HasExited && process.ExitCode == 1)
                {
                    Console.WriteLine("ERROR");
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
        public void concatenateVideo(int count, string ou)
        {
            try
            {
                if (File.Exists(ou))
                    File.Delete(ou);

                string command1 = "";

                for (int i = 0; i < count; i++)
                {
                    if (File.Exists(TEMP + "video" + i + ".mp4"))
                    {
                        command1 += (" -i " + TEMP + "video" + i + ".mp4");
                    }
                }
                command1 += (" -filter_complex \"");

                int realcount = 0;
                for (int i = 0; i < count; i++)
                {
                    if (File.Exists(TEMP + "video" + i + ".mp4"))
                    {
                        realcount += 1;
                    }
                }
                for (int i = 0; i < realcount; i++)
                {
                    command1 += ("[" + i + ":v:0][" + i + ":a:0]");
                }

                //realcount +=1;
                command1 += ("concat=n=" + realcount + ":v=1:a=1[outv][outa]\" -map \"[outv]\" -map \"[outa]\" -y " + ou);
                Console.WriteLine(command1);

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = FFMPEG;
                startInfo.Arguments = command1;
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


                //cmdLine = CommandLine.parse(command2);
                //executor = new DefaultExecutor();
                //exitValue = executor.execute(cmdLine);

                //temp.delete();

            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
        }
    }
}
