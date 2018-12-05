using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Carlos_Palindrome.Models
{
    public class Value
    {
        [Required (ErrorMessage = "Required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a positive number! ")]
        public int _Number { get; set; }

        public Value()
        {
            _Number = 0;
        }

        public string Check_Palindrome(int number)
        {
            try
            {
                string aux = Convert.ToString(number);
                int i = 0;
                int j = aux.Length - 1;
                while (i < j)
                {
                    string front = aux[i].ToString();
                    string back = aux[j].ToString();
                    if (front != back)
                        return "The number isn't Palindrome";
                    i++;
                    j--;
                }
                return "The number is Palindrome";
            }
            catch (Exception ex)
            {
                MailMessage m = new MailMessage();
                m.Subject = "Palindrome Error";
                m.Body = "Error description : " + ex;
                m.IsBodyHtml = true;
                m.From = new MailAddress("ing.cfabregas@gmail.com");
                m.To.Add(new MailAddress("ing.cfabregas@gmail.com"));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                NetworkCredential authinfo = new NetworkCredential("ing.cfabregas@gmail.com", "my pass");
                smtp.EnableSsl = true;
                smtp.Credentials = authinfo;
                smtp.Send(m);
                return "An error occurred while processing your request. Please, try again.";                
            }            
        }

        
    }
}