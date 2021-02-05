using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsDelegates
{
    class ClassWork
    {
        /* ---- CW_1 ---- */

        // define delegate which is void and accepts string -- or just use Action
        public Action<string> invocationMethodsList;
        
        // create function called SendEmailAfterEncoding (string videoName)
        //    in this function cw (email notification video name was successfully encoded!)

        public void SendEmailAfterEncoding(string videoName)
        {
            Console.WriteLine($"Email Header: Video Body: {videoName} successfully encoded");
        }

        // create function called SendSmsAfterEncoding (string videoName)
        //    in this function cw (SMS notification video name was successfully encoded!)

        public void SendSmsAfterEncoding(string videoName)
        {
            Console.WriteLine($"SMS: -- Body: {videoName} successfully encoded --");
        }

        // create delegate and insert both functions inside it as static member

        // create function EncodeVideo which recieves video name as argument
        //     Thread.Sleep(3000);
        //     now invoke the delegate!
        // from main call EncodeVideo

        public void VideoEncoding (string videoName )
        {
            Console.WriteLine($"Encoding video {videoName}");
            Thread.Sleep(3000);

            if (invocationMethodsList != null)
            {
                invocationMethodsList.Invoke(videoName); // "выстреливает" все зарегистрированые в нём функции
            }
        }

        /* ---- СW_2 ---- */

        //define delegate which is void and accepts int --or just use Action

        public Action<int> toPrint;

        //create function called PrintToScreen(int number)
        //in this function cw(current number = number)
        public void PrintToScreen (int number)
        {
            Console.WriteLine($"number={number}");
        }

        //create function called PrintToScreenNumberx2(int number)
        //in this function cw(numberx2 = number * 2)

        public void PrintToScreenx2(int number)
        {
            Console.WriteLine($"number x 2={number*2}");
        }

        //create delegate and insert both functions inside it as static member(in Program.Main)

        //create function RunFrom1to10 which
        //Thread.Sleep(1000);
        //now invoke the delegate!
        public void RunFrom1to10()
        {
            for (int i=1; i<=10;i++)
            {
                toPrint.Invoke(i);
                Thread.Sleep(1000);
            }
            
        }

        //from main call RunFrom1to10

        //part 2:
        //now remove the PrintToScreenNumberx2 using -=
        //now call RunFrom1to10 again


    }
}
