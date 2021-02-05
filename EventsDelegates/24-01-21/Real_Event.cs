using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsDelegates
{
    class Real_Event
    {
        public class VideoEncoderEventArgs : EventArgs
        {
            public string VideoName { get; set; }
            public int Time { get; set; }
            public int Size { get; set; }
        }

        //public delegate void Func_Void_Arg_String(string s);

        public void SendEmailAfterEncoding(object sender, VideoEncoderEventArgs e)
        {
            Console.WriteLine($"Email: encoded by {sender}...");
            Console.WriteLine($"Email Header: Video Body: {e.VideoName} successfully encoded.Size of {e.VideoName} is {e.Size} G");
        }

        public void SendSmsAfterEncoding(object sender, VideoEncoderEventArgs e)
        {
            Console.WriteLine($"SMS: encoded by {sender}...");
            Console.WriteLine($"SMS: -- Body: {e.VideoName} successfully encoded --Size of {e.VideoName} is {e.Size} G");
        }

        //public Action<object, VideoEncoderEventArgs> invocationMethodsList;
        public event EventHandler<VideoEncoderEventArgs> invocationMethodsList;

        public void MpgVideoEncoding(string videoName)
        {
            Console.WriteLine($"Encoding video {videoName}");
            Thread.Sleep(3000);

            if (invocationMethodsList != null)
            {
                invocationMethodsList("Mpeg encoder",
                    new VideoEncoderEventArgs { VideoName = videoName,Time = 23,Size = 5 }); // fire all registered methods
            }
        }
        
        
        public void Mp4VideoEncoding(string videoName)
        {
            Console.WriteLine($"Encoding video {videoName}");
            Thread.Sleep(3000);

            if (invocationMethodsList != null)
            {
                invocationMethodsList("Mp4 encoder",
                    new VideoEncoderEventArgs { VideoName = videoName,Time = 16,Size = 1 });// fire all registered methods
            }

        }



        /* ---- CW_1 ---- */

        //1.
        //take the code of real_event(chat)
        //add SlimEncoder
        //fire the SlimEncoder
        public void SlimEncoder(string videoName)
        {
            Console.WriteLine($"Encoding video {videoName}");
            Thread.Sleep(3000);

            if (invocationMethodsList != null)
            {
                invocationMethodsList("Slim encoder",
                    new VideoEncoderEventArgs { VideoName = videoName, Time = 19,Size = 2 });// fire all registered methods
            }

        }

        //add inside VideoEncoderEventArgs time of video as int, add it to each event you fire

        //also print the video size in the functions of SMS and Email
        //add new function which upload the video into the cloud(same like email and sms function)
        //now += this function and try to see if it works
        public void UploadInCloud(object sender, VideoEncoderEventArgs e)
        {
            Console.WriteLine($"Upload by {sender}...");
            Console.WriteLine($"Upload: -- Body: {e.VideoName} successfully upload --Size of {e.VideoName} is {e.Size} G");
        }
    //2.
        //create new class
        public class DividedBy_5or3
        {
            //create 2 events : DividedBy3 and Divided by 5
            public event EventHandler dividedBy3;
            public event EventHandler dividedBy5;

            //add corresponsing methods(event args + event handler) which prints:
            //if dividded by 3 - Fizz
            //if devided by 5- Buzz
            public void DividedBy3(object sender, EventArgs e)
            {
                Console.WriteLine($"{sender}");
            }

            public void DividedBy5(object sender, EventArgs e)
            {
                Console.WriteLine($"{sender}");
            }

            //create a function which runs from 1 to 20 and print number to screen
                //if the number can be divided by 3 without reminder - invoke the DividedBy3
                //if the number can be divided by 5 without reminder - invoke the DividedBy5

            public void PrintNumber()
            {
                for (int i=1; i<=20;i++)
                {
                    if (i % 3 == 0)
                        DividedBy3("Fizz", EventArgs.Empty);
                    if (i % 5 == 0)
                        DividedBy5("Buzz", EventArgs.Empty);
                }
            }

        }
        
        
        
        
           

    }
}    

