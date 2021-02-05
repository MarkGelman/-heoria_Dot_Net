using BankEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsDelegates
{
    class Program
    {
       ClassWork event1 = new ClassWork();
        static void Main(string[] args)
        {
            ClassWork even = new ClassWork();

            /* ---- CW_1 ----*/
            //from main call EncodeVideo

            even.invocationMethodsList += even.SendEmailAfterEncoding;
            even.invocationMethodsList += even.SendSmsAfterEncoding;
            even.VideoEncoding("Batman movie...");

            even.invocationMethodsList -= even.SendEmailAfterEncoding;
            even.VideoEncoding("Superman movie...");

            /* ---- CW_2 ---- */

            even.toPrint += even.PrintToScreen;
            even.toPrint += even.PrintToScreenx2;

            even.RunFrom1to10();

            even.toPrint -= even.PrintToScreenx2;

            Real_Event real_event = new Real_Event();

            // +=

            real_event.invocationMethodsList += real_event.SendEmailAfterEncoding;
            real_event.invocationMethodsList += real_event.SendSmsAfterEncoding;
            real_event.invocationMethodsList += real_event.UploadInCloud;
            real_event.Mp4VideoEncoding("Batman movie...");
            real_event.SlimEncoder("Spiderman movie...");
           
            real_event.invocationMethodsList -= real_event.SendEmailAfterEncoding;
            real_event.MpgVideoEncoding("Superman movie...");

            /*------------------------------------------------------ 27-01-21 ------------------------------------------------------*/

                                                                /* Проэкт BankEvents*/
             
            Bank igud = new Bank();
            Fatal fatal = new Fatal();
            Ariela a = new Ariela();
            BuyHouseCommercial buy_house = new BuyHouseCommercial();
            buy_house.Register1MWithBank(igud);
            fatal.RegisterBankWithFreeWeekend(igud);
            fatal.RegisterBankWithFreeWeekend(a);

            Customer c = new Customer
            {
                Name = "Moshe",
                Balance = 50000,
                MobileNumber = "055-555555555"
            };
            igud.AddCustomer(c);
            igud.Deposite(c, 999_999);

            a.PlayLotto();

        }
    }
}
