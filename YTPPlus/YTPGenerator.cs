using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;

namespace YTPPlusPlus.YTPPlus
{
    public class YTPGenerator
    {
        private double _maxStreamDuration = 0.4; //default: 2s
        private double _minStreamDuration = 0.2; //default: 0.2s
        private int _maxClips = 20; //default: 5 clips
        private readonly string _outputFile; //the video file that will be produced in the end

        public bool Failed; //if the application has failed
        public Exception Exc; //set when the application fails to give more information

        public bool Effect1;
        public bool Effect2;
        public bool Effect3;
        public bool Effect4;
        public bool Effect5;
        public bool Effect6;
        public bool Effect7;
        public bool Effect8;
        public bool Effect9;
        public bool Effect10;
        public bool Effect11;
        public bool Effect12;

        public bool PluginTest;
        public int PluginCount;
        public List<string> Plugins = new List<string>();

        public bool InsertTransitionClips;

        public int Width = 640;
        public int Height = 480;
        public bool Intro;
        public bool Outro = true;

        public readonly Utilities ToolBox = new Utilities();

        private EffectsFactory _effectsFactory;
        private readonly ArrayList _sourceList = new ArrayList();
        //private bool _done;
        
        public YTPGenerator(string output)
        {
            _outputFile = output;
            //configurate();
        }
        
        public void SetMaxClips(int clips)
        {
            _maxClips = clips;
        }
        public void SetMinDuration(double min)
        {
            _minStreamDuration = min;
        }
        public void SetMaxDuration(double max)
        {
            _maxStreamDuration = max;
        }

        public void AddSource(string sourceName)
        {
            _sourceList.Add(sourceName);
        }

        private readonly BackgroundWorker _vidThreadWorker = new BackgroundWorker();

        private void VidThread(object sender, DoWorkEventArgs e)
        {
            if (_sourceList.Count == 0)
            {
                Console.WriteLine(@"No sources added...");
                return;
            }

            Console.WriteLine(@"poop_1");

            if (File.Exists(_outputFile))
                File.Delete(_outputFile);

            try
            {
                Directory.CreateDirectory(ToolBox.Temp);
                Failed = false;
                for (var i = 0; i < _maxClips; i++)
                {
                    if (i == 0 && Intro)
                    {
                        _maxClips++;
                        Console.WriteLine($@"Intro clip enabled, adding 1 to max clips. New max clips is {_maxClips}.");
                        Console.WriteLine($@"Done: {decimal.Divide(i, _maxClips)}");
                        _vidThreadWorker.ReportProgress(Convert.ToInt32(decimal.Divide(i, _maxClips) * 100, new CultureInfo("en-US")));
                        Console.WriteLine(ToolBox.Intro);
                        Console.WriteLine($@"STARTING CLIP video{i}");
                        ToolBox.CopyVideo(ToolBox.Intro, $"{ToolBox.Temp}video{i}", Width, Height);
                    }
                    else
                    {
                        Console.WriteLine($@"Done: {decimal.Divide(i, _maxClips)}");
                        _vidThreadWorker.ReportProgress(Convert.ToInt32(decimal.Divide(i, _maxClips) * 100, new CultureInfo("en-US")));
                        var sourceToPick = _sourceList[RandomInt(0, _sourceList.Count - 1)].ToString();
                        Console.WriteLine(sourceToPick);
                        
                        var source = decimal.Parse(ToolBox.GetLength(sourceToPick), NumberStyles.Any, new CultureInfo("en-US"));
                        var output = source.ToString("0.#########################", new CultureInfo("en-US"));
                        Console.WriteLine(
                            $@"{ToolBox.GetLength(sourceToPick)} -> {output} -> {double.Parse(output, NumberStyles.Any, new CultureInfo("en-US"))}");
                        var boy = double.Parse(output, NumberStyles.Any, new CultureInfo("en-US"));
                        Console.WriteLine(boy);
                        Console.WriteLine($@"STARTING CLIP video{i}");
                        var startOfClip = RandomDouble(0.0, boy - _maxStreamDuration);
                        //Console.WriteLine("boy seconds = "+  boy.getLengthSec());
                        var endOfClip = startOfClip + RandomDouble(_minStreamDuration, _maxStreamDuration);
                        Console.WriteLine(
                            $@"Beginning of clip {i}: {startOfClip.ToString("0.#########################", new CultureInfo("en-US"))}");
                        Console.WriteLine(
                            $@"Ending of clip {i}: {endOfClip.ToString("0.#########################", new CultureInfo("en-US"))}, in seconds: ");
                        if (RandomInt(0, 15 + PluginCount) == 15 && InsertTransitionClips)
                        {
                            Console.WriteLine(@"Tryina use a diff source");
                            ToolBox.CopyVideo(ToolBox.Sources + _effectsFactory.PickSource(), $"{ToolBox.Temp}video{i}", Width, Height);
                        }
                        else
                        {
                            ToolBox.SnipVideo(sourceToPick, startOfClip, endOfClip, $"{ToolBox.Temp}video{i}", Width, Height);
                        }
                        //Add a random effect to the video
                        var effect = GiveProbability(0, 15 + PluginCount);
                        if (PluginTest)
                            effect = 16;
                        Console.WriteLine($@"STARTING EFFECT ON CLIP {i} EFFECT{effect}");
                        var clipToWorkWith = $"{ToolBox.Temp}video{i}.mp4";
                        switch (effect)
                        {
                            case 1:
                                //random sound
                                if (Effect1)
                                    _effectsFactory.effect_RandomSound(clipToWorkWith, Width, Height);
                                break;
                            case 2:
                                if (Effect2)
                                    //random sound
                                    _effectsFactory.effect_RandomSoundMute(clipToWorkWith, Width, Height);
                                break;
                            case 3:
                                if (Effect3)
                                    _effectsFactory.effect_Reverse(clipToWorkWith, Width, Height);
                                break;
                            case 4:
                                if (Effect4)
                                    _effectsFactory.effect_SpeedUp(clipToWorkWith, Width, Height);
                                break;
                            case 5:
                                if (Effect5)
                                    _effectsFactory.effect_SlowDown(clipToWorkWith, Width, Height);
                                break;
                            case 6:
                                if (Effect6)
                                    _effectsFactory.effect_Chorus(clipToWorkWith, Width, Height);
                                break;
                            case 7:
                                if (Effect7)
                                    _effectsFactory.effect_Vibrato(clipToWorkWith, Width, Height);
                                break;
                            case 8:
                                if (Effect8)
                                    _effectsFactory.effect_HighPitch(clipToWorkWith, Width, Height);
                                break;
                            case 9:
                                if (Effect9)
                                    _effectsFactory.effect_LowPitch(clipToWorkWith, Width, Height);
                                break;
                            case 10:
                                if (Effect10)
                                    _effectsFactory.effect_Dance(clipToWorkWith, Width, Height);
                                break;
                            case 11:
                                if (Effect11)
                                    _effectsFactory.effect_Squidward(clipToWorkWith, Width, Height);
                                break;
                            /*case 12:
                                if (effect12 == true)
                                {
                                    effectsFactory.effect_RainbowTrail(clipToWorkWith, width, height, startOfClip, endOfClip);
                                }
                                break;*/
                            default:
                                if (effect > 15)
                                {
                                    if (effect <= 15+PluginCount)
                                    {
                                        _effectsFactory.effect_Plugin(clipToWorkWith, Width, Height, Plugins[Rnd.Next(Plugins.Count)], startOfClip, endOfClip);
                                    }
                                }
                                break;
                        }
                    }
                }
                if (Outro)
                {
                    _maxClips++;
                    Console.WriteLine(@"Outro clip enabled.");
                    Console.WriteLine($@"Done: {decimal.Divide(_maxClips - 1, _maxClips)}");
                    _vidThreadWorker.ReportProgress(Convert.ToInt32(decimal.Divide(_maxClips - 1, _maxClips) * 100, new CultureInfo("en-US")));
                    Console.WriteLine(ToolBox.Outro);
                    Console.WriteLine($@"STARTING CLIP video{_maxClips}");
                    ToolBox.CopyVideo(ToolBox.Outro, $"{ToolBox.Temp}video{_maxClips}", Width, Height);
                    _maxClips++;
                }
                /*for (int i = 0; i < MAX_CLIPS; i++)
                {
                    if (File.Exists(toolBox.TEMP + "video" + i + ".mp4"))
                    {
                        writer.WriteLineAsync("file 'video" + i + ".mp4'\n"); //writing to same folder
                    }
                }*/
                //Thread.sleep(10000);
                ToolBox.ConcatenateVideo(_maxClips, _outputFile);
                //Thread.sleep(4000);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Exc = ex;
                Failed = true;
            }
            //for (int i=0; i<100; i++) {
            CleanUp();
            RmDir(ToolBox.Temp);
        }

        public YTPGenerator Go(ProgressChangedEventHandler progressReporter, RunWorkerCompletedEventHandler completedReporter)
        {
            _effectsFactory = new EffectsFactory(ToolBox); //hacky but works
            Console.WriteLine($@"My FFMPEG is: {ToolBox.Ffmpeg}");
            Console.WriteLine($@"My FFPROBE is: {ToolBox.Ffprobe}");
            Console.WriteLine($@"My MAGICK is: {ToolBox.Magick}");
            Console.WriteLine($@"My TEMP is: {ToolBox.Temp}");
            Console.WriteLine($@"My SOUNDS is: {ToolBox.Sounds}");
            Console.WriteLine($@"My SOURCES is: {ToolBox.Sources}");
            Console.WriteLine($@"My MUSIC is: {ToolBox.Music}");
            Console.WriteLine($@"My RESOURCES is: {ToolBox.Resources}");
            _vidThreadWorker.DoWork += VidThread;
            _vidThreadWorker.WorkerReportsProgress = true;
            _vidThreadWorker.WorkerSupportsCancellation = true;
            _vidThreadWorker.ProgressChanged += progressReporter;
            _vidThreadWorker.RunWorkerCompleted += completedReporter;
            _vidThreadWorker.RunWorkerAsync();
            return this;
        }



        public static double GetUnixEpoch(DateTime dateTime)
        {
            var unixTime = dateTime.ToUniversalTime() -
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return unixTime.TotalSeconds;
        }
        public Random Rnd = new Random();



        public double RandomDouble(double min, double max)
        {
            double finalVal = -1;
            while (finalVal < 0)
            {
                var x = (Rnd.NextDouble() * ((max - min) + 0)) + min;
                finalVal = Math.Round(x * 100.0) / 100.0;
            }
            return finalVal;
        }
        public int RandomInt(int min, int max)
        {
            return Rnd.Next((max - min) + 1) + min;
            //return new Random((int)GetUnixEpoch(DateTime.UtcNow)).Next((max - min) + 1) + min;
        }
        public int GiveProbability(int min, int max) //still unfinished
        {
            /*
            int roll = rnd.Next(0,1);
            float[] array = new float[max];
            for (int i = min; i < max; i++)
            {
                array.SetValue(0.1666F, i);
            }
            float sum = 0;
            int completedRoll = 0;
            for (int i = 0; i < 6; i++)
            {
                sum += array[i];
                if (sum > roll) break;
                completedRoll = i;
            }
            Console.WriteLine(completedRoll);*/
            //return completedRoll;
            return Rnd.Next((max - min) + 1) + min;
            //return new Random((int)GetUnixEpoch(DateTime.UtcNow)).Next((max - min) + 1) + min;
        }


        public void CleanUp()
        {
            if (File.Exists($"{ToolBox.Temp}temp.mp4"))
                File.Delete($"{ToolBox.Temp}temp.mp4");
            for (var i = 0; i < _maxClips; i++)
            {
                if (File.Exists($"{ToolBox.Temp}video{i}.mp4"))
                {
                    Console.WriteLine($@"{i} Exists");
                    File.Delete($"{ToolBox.Temp}video{i}.mp4");
                }
            }

        }
        public void RmDir(string file)
        {
            foreach (var fi in Directory.GetFiles(file))
            {
                File.Delete(fi);
            }
            Directory.Delete(file);
        }

    }
}
