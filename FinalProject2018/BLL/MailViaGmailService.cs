using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Entities;

namespace BLL
{
    public class MailViaGmailService
    {
        MailAddress myemail = new MailAddress("ymnredeecs@gmail.com", "לא ידוע");  //used for authentication
        string password = "0533177904";  //used for authentication
        SmtpClient client_smtp = new SmtpClient("smtp.gmail.com", 587);   //address and port

        public MailViaGmailService()
        {
            client_smtp.EnableSsl = true;   //Gmail requires a ssl connection
            client_smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            client_smtp.UseDefaultCredentials = false;
            client_smtp.Credentials = new NetworkCredential(myemail.Address, password); //authentication data
        }


        public void  sendOrderMessenge(SaleOrder so) {
          
            MailAddress mail_to = new MailAddress(so.Customer.Email,
                                                  so.Customer.FirstName+" "+so.Customer.LastName);  //the email address of the receiver


            MailMessage message = new MailMessage(myemail, mail_to);
            message.Subject = "Test";  //subject
            message.IsBodyHtml = true;
            message.Body = "תודה שרכשת את המצרכים הבאים:";
           // message.Body += string.Join(", ", so.SaleOrderProducts[0].Product.Name);
            foreach (var sop in so.SaleOrderProducts)
            {
                message.Body += "<li> " + sop.Product.Name+"   "+sop.Amount + "</li>";
            }
            message.Body += "</ul>";
            send(message);
            
        }

        private void send(MailMessage m)
        {
            try { client_smtp.Send(m); }
            catch(Exception ex){ throw ex; }
        }
    }
   
}
