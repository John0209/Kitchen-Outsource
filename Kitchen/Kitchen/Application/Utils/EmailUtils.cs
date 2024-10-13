using System.Net;
using System.Net.Mail;
using HtmlAgilityPack;
using Kitchen.Application.ErrorHandlers;
using Kitchen.Infrastructure.Entities;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;

namespace Kitchen.Application.Utils;

public static class EmailUtils
{
    public static bool IsReadMail = false;
    const string SenderEmail = "long88ka@gmail.com";
    const string SenderPassword = "fbkseabpvtwrmigo";
    const string Label = "Cake";


    private static void SendEmail(string toEmail, string toSubject, string toContent)
    {
        // set up send email
        string sendto = toEmail;
        string subject = toSubject;
        string content = toContent;

        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            //set property for email you want to send
            mail.From = new MailAddress(SenderEmail);
            mail.To.Add(sendto);
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = content;
            mail.Priority = MailPriority.High;
            //set smtp port
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            //set gmail pass sender
            smtp.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        catch (Exception ex)
        {
            throw new BadRequestException($"Send to {toEmail} failed, error: "+ex);
        }
    }

    public static void SendVerifyCodeToEmail(User user)
    {
        var title = "[KITCHEN BUDDY] - Xác Minh Tài Khoản";
        var content = "Xin chào " + user.UserName + "<br>" + "<br>" +
                      "Kitchen Buddy cảm ơn bạn đã đăng ký tài khoản tại website của chúng tôi." + "<br>" + "<br>" +
                      "Bạn vui lòng nhập mã xác mình này vào ô xác nhận ở website để hoàn thành việc đăng ký tài khoản mới: "
                      + "<strong>" + user.VerifyCode + "</strong><br><br>" +
                      "Chúc bạn thành công với món ăn của mình!" + "<br>" + "<br>" + "Đội Ngũ Kỹ Thuật Kitchen Buddy.";
        SendEmail(user.Email, title, content);
    }

    public static void SendNewPasswordToEmail(User user)
    {
        var title = "[KITCHEN BUDDY] - Gửi Mật Khẩu Mới";
        var content = "Xin chào " + user.UserName + "<br>" + "<br>" +
                      "Kitchen Buddy xin gửi bạn mật khẩu mới để đăng nhập vào website của chúng tôi: " + "<strong>" +
                      user.Password + "</strong><br><br>" +
                      "Bạn vui lòng thay đổi mật khẩu của mình sau khi đăng nhập để bảo mật tài khoản " + "<br><br>" +
                      "Chúc bạn thành công với món ăn của mình!" + "<br>" + "<br>" + "Đội Ngũ Kỹ Thuật Kitchen Buddy.";
        SendEmail(user.Email, title, content);
    }

    public static async Task<string?> ReadEmailAsync(string transactionCode)
    {
        try
        {
            using (var client = new ImapClient())
            {
                // Kết nối đến máy chủ IMAP
                await client.ConnectAsync("imap.gmail.com", 993, true);
                await client.AuthenticateAsync(SenderEmail, SenderPassword);

                // Mở thư mục cụ thể, ví dụ "Important"
                var inbox = client.GetFolder(Label);
                await inbox.OpenAsync(FolderAccess.ReadOnly);

                DateTime today = DateTime.Now;
                // Tìm kiếm email theo tiêu đề
                var searchResults = await inbox.SearchAsync(SearchQuery.All);
                foreach (var uid in searchResults)
                {
                    var message = await inbox.GetMessageAsync(uid);
                    var sendDate = message.Date;
                    if (sendDate.Date == today.Date)
                    {
                        // Lấy email vừa gửi, thời gian trong 5p
                        var timeSpan = today.TimeOfDay - sendDate.LocalDateTime.TimeOfDay;
                        if ((int)timeSpan.TotalMinutes <= 5)
                        {
                            var doc = new HtmlDocument();
                            doc.LoadHtml(message.HtmlBody);

                            var contentNode = doc.DocumentNode.SelectSingleNode(
                                "//td[contains(text(), 'Nội dung giao dịch')]/following-sibling::td[4]");
                            
                            var content = contentNode.InnerText?.Trim();
                            var contentSplit = content!.Split('-');
                            var code = contentSplit[1].Trim();
                            if (String.Compare(transactionCode.Trim(), code, StringComparison.Ordinal) == 0)
                            {
                                return code;
                            }
                        }
                    }
                }

                // Ngắt kết nối
                await client.DisconnectAsync(true);
            }
        }
        catch (Exception e)
        {
            LogUtils.LogWarning("ReadEmailAsync", e.Message, null);
        }

        return String.Empty;
    }

    public static async Task<EmailTest> ReadEmailAsyncTest()
    {
        var result = new EmailTest();
        using (var client = new ImapClient())
        {
            // Kết nối đến máy chủ IMAP
            await client.ConnectAsync("imap.gmail.com", 993, true);
            await client.AuthenticateAsync(SenderEmail, SenderPassword);

            // Mở thư mục cụ thể, ví dụ "Important"
            var inbox = client.GetFolder(Label);
            await inbox.OpenAsync(FolderAccess.ReadOnly);
            DateTime today = DateTime.Now;
            // Tìm kiếm email theo tiêu đề
            var searchResults = await inbox.SearchAsync(SearchQuery.All);
            foreach (var uid in searchResults)
            {
                var message = await inbox.GetMessageAsync(uid);
                var sendDate = message.Date;
                if (sendDate.Date == today.Date)
                {
                    var timeSpan = today.TimeOfDay - sendDate.LocalDateTime.TimeOfDay;
                    if ((int)timeSpan.TotalMinutes <= 15)
                    {
                        result.Title = sendDate.Date;
                        result.TimeSpan = timeSpan;
                        result.ToDay = today.TimeOfDay;
                        result.EmailTime = sendDate.LocalDateTime.TimeOfDay;
                        return result;
                    }
                }
            }

            return result;
        }
    }
}