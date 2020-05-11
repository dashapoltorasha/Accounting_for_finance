using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Accounting_for_finance.Views;
using System.IO;
using Xamarin.Forms;
using Accounting_for_finance.Models;
using Plugin.Messaging;

namespace Accounting_for_finance
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DbService.RefrashDb();

              DbService.LoadAll();    

           // DbService.LoadTestSample();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            //GlobalEvents.OnSMSReceived_Event(this, new SMSEventArgs() { PhoneNumber = "900", Message = "Oplata 17.00 RUB Karta * 5484 KURLTRANS_OPLATA Balans 2202.65 RUB 21:44 vtb.ru / app", Date = DateTime.Now });
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}