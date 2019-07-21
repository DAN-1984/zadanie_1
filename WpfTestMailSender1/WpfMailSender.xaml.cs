using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;
//
// C# Уровень 3 
// Урок 1
// Дашкин Д.Ф.
//
namespace WpfTestMailSender1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Класс с переменными
        /// </summary>
        public static class WpfTestMailSender
        {
            public static string from = "dashkin.1984@inbox.ru";
            public static string subject = "Привет из c#";
            public static string body = "Hello, world!";
            public static string smtp = "smtp.mail.ru";
            public static int port = 25;
            public static string mail = "dashkin.1984@inbox.ru";
        }
        /// <summary>
        /// Класс для отправки письма
        /// </summary>
        public class EmailSendServiceClass
        {
            private List<string> listStrMails = new List<string>();
            public EmailSendServiceClass(List<string> list)
            {
                listStrMails = list;
            }
            /// <summary>
            /// Метод для отправки письма
            /// </summary>

            public void SendMail(string strUser, string strPass, string Name, string Text)
            {
                foreach (string mail in listStrMails)
                {
                    // Используем using, чтобы гарантированно удалить объект MailMessage после использования
                    using (MailMessage mm = new MailMessage(WpfTestMailSender.from, mail))
                    {
                        // Формируем письмо
                        mm.Subject = Name/*WpfTestMailSender.subject*/; // Заголовок письма
                        mm.Body = Text/*WpfTestMailSender.body*/;       // Тело письма
                        mm.IsBodyHtml = false;           // Не используем html в теле письма
                                                         // Авторизуемся на smtp-сервере и отправляем письмо
                                                         // Оператор using гарантирует вызов метода Dispose, даже если при вызове 
                                                         // методов в объекте происходит исключение.
                        using (SmtpClient sc = new SmtpClient(WpfTestMailSender.smtp, WpfTestMailSender.port))
                        {
                            sc.EnableSsl = true;
                            sc.Credentials = new NetworkCredential(WpfTestMailSender.mail, strPass);
                            try
                            {
                                sc.Send(mm);
                            }
                            catch (Exception ex)
                            {
                                SendExeption sew_1 = new SendExeption();
                                sew_1.TexBlockExeption.Text = "Невозможно отправить письмо " + ex.ToString();
                                sew_1.ShowDialog();
                                //MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                            }
                        }
                    } //using (MailMessage mm = new MailMessage("sender@yandex.ru", mail))
                }
                //MessageBox.Show("Работа завершена.");
                SendEndWindow sew = new SendEndWindow();
                sew.ShowDialog();
            }
        }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            List<string> listStrMails = new List<string> { "dashkin.1984@inbox.ru", "dashkin.1984@inbox.ru" };  // Список email'ов //кому мы отправляем письмо
            string strPassword = passwordBox.Password;  // для WinForms - string strPassword = passwordBox.Text;
            EmailSendServiceClass emailSend = new EmailSendServiceClass(listStrMails);
            emailSend.SendMail(WpfTestMailSender.mail, strPassword, TexBox_Name.Text, TexBox_Text.Text);
            //foreach (string mail in listStrMails)
            //{
            //    // Используем using, чтобы гарантированно удалить объект MailMessage после использования
            //    using (MailMessage mm = new MailMessage(WpfTestMailSender.from, mail))
            //    {
            //        // Формируем письмо
            //        mm.Subject = WpfTestMailSender.subject; // Заголовок письма
            //        mm.Body = WpfTestMailSender.body;       // Тело письма
            //        mm.IsBodyHtml = false;           // Не используем html в теле письма
            //                                         // Авторизуемся на smtp-сервере и отправляем письмо
            //                                         // Оператор using гарантирует вызов метода Dispose, даже если при вызове 
            //                                         // методов в объекте происходит исключение.
            //        using (SmtpClient sc = new SmtpClient(WpfTestMailSender.smtp, WpfTestMailSender.port))
            //        {
            //            sc.EnableSsl = true;
            //            sc.Credentials = new NetworkCredential(WpfTestMailSender.mail, strPassword);
            //            try
            //            {
            //                sc.Send(mm);
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
            //            }
            //        }
            //    } //using (MailMessage mm = new MailMessage("sender@yandex.ru", mail))
            //}
            ////MessageBox.Show("Работа завершена.");
            //SendEndWindow sew = new SendEndWindow();
            //sew.ShowDialog();
        }
    }
}
