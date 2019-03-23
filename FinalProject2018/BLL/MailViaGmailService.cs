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
    public class MailViaGmailService : BaseService
    {
        MailAddress myemail = new MailAddress("ymnredeecs@gmail.com", "לא ידוע");  //used for authentication
        string password = "0533177904";  //used for authentication
        SmtpClient client_smtp = new SmtpClient("smtp.gmail.com", 587);   //address and port

        public MailViaGmailService()
        {
            client_smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            client_smtp.UseDefaultCredentials = false;
            client_smtp.EnableSsl = true;
            client_smtp.Credentials = new NetworkCredential("bechagecha@gmail.com", "bechagecha2019"); //authentication data
        }


        public void sendOrderMessenge(SaleOrder so)
        {
            MailAddress mail_from = new MailAddress("bechagecha@gmail.com", "מערכת בחגייך");  //the email address of the receiver
           
            MailAddress mail_to = new MailAddress(so.Customer.Email,
                                                  so.Customer.FirstName + " " + so.Customer.LastName);  //the email address of the receiver


            MailMessage message = new MailMessage(myemail, mail_to);
            message.Subject = "ביצעת קניה בתאריך" + DateTime.Now.ToString();  //subject
            message.IsBodyHtml = true;
            message.Body = "תודה שרכשת את המצרכים הבאים:";
            // message.Body += string.Join(", ", so.SaleOrderProducts[0].Product.Name);
            foreach (var sop in so.SaleOrderProducts)
            {
                message.Body += "<li> " + sop.Product.Name + "   " + sop.Amount + "</li>";
            }
            message.Body += "</ul>";
            send(message);

        }

        private void send(MailMessage m)
        {
            try { client_smtp.Send(m); }
            catch (Exception ex) { throw new Exception("ארעה תקלה! לא נשלח המייל המבוקש"); }
        }

        public MailboxMessage sendContactUs(MailboxMessage mess)
        {
            Admin admin = db.Admins.FirstOrDefault();
            if (admin == null)
                return null;
            MailAddress mail_to = new MailAddress(admin.Email, admin.FirstName + " " + admin.LastName);  //the email address of the receiver
            MailAddress mail_from = new MailAddress(mess.FromEmail, mess.FromName);  //the email address of the receiver
            
            MailMessage message = new MailMessage(mail_from, mail_to);
            message.Subject = mess.Topic; 
            message.Body = mess.Content;
            
            send(message);
            return mess;

        }

        public void sendPasswordToCustomer(string to_mail,string to_name)
        {
            MailAddress mail_from = new MailAddress("bechagecha@gmail.com", "מערכת בחגייך");  //the email address of the receiver
            MailAddress mail_to = new MailAddress(to_mail, to_name);  //the email address of the receiver
            MailMessage message = new MailMessage(myemail, mail_to);
            message.Subject = "איפוס סיסמא";  //subject
            message.Body ="הסיסמא שלך היא : " + "pass";
            send(message);
        }
    }

}
