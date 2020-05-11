using Accounting_for_finance.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Accounting_for_finance
{
    public class GlobalEvents
    {
        public static event EventHandler<SMSEventArgs> OnSMSReceived;

        public static void OnSMSReceived_Event(object sender, SMSEventArgs sms)
        {
            OnSMSReceived?.Invoke(sender, sms);
            var bill = DbService.LoadAllBills();
            Operation op = new Operation();
            foreach(var b in bill)
            if((sms.Message.IndexOf(b.Number)!=-1)&&(b.Type==true))
                {
                    op.bill = b;
                }
            if (op.bill != null)
            {
                if (sms.Message.IndexOf("Покупка") != -1)
                {
                    var text = sms.Message.Substring(sms.Message.IndexOf("Покупка") + 9);
                    var pos = text.IndexOf(" ");
                    op.amount = Convert.ToUInt32(text.Substring(0, pos));
                    op.category = DbService.FindCategory(1);
                }
                if (sms.Message.IndexOf("Oplata") != -1)
                {
                    var text = sms.Message.Substring(sms.Message.IndexOf("Oplata") + 7);
                    var pos = text.IndexOf(".");
                    op.amount = Convert.ToUInt32(text.Substring(0, pos));
                    op.category = DbService.FindCategory(1);
                }
                if (sms.Message.IndexOf("Перевод") != -1)
                {
                    var text = sms.Message.Substring(sms.Message.IndexOf("Перевод") + 8);
                    var pos = text.IndexOf(" ");
                    op.amount = Convert.ToUInt32(text.Substring(0, pos));
                    op.category = DbService.FindCategory(9);
                }
                if (sms.Message.IndexOf("зачисление") != -1)
                {
                    var text = sms.Message.Substring(sms.Message.IndexOf("зачисление") + 11);
                    var pos = text.IndexOf(" ");
                    op.amount = Convert.ToUInt32(text.Substring(0, pos));
                    op.category = DbService.FindCategory(8);
                }
                op.Comments = sms.Message;
                op.date = sms.Date;
                DbService.AddOperation(op);
            }

        }
    }

    public class SMSEventArgs : EventArgs
    {
        public string PhoneNumber { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; }
    }
}
