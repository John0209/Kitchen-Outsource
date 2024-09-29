using System.Net;
using System.Net.Mail;
using Kitchen.Application.ErrorHandlers;
using Kitchen.Infrastructure.Entities;
using RecipeCategoryEnum.Entities;

namespace Kitchen.Application.Utils;

public static class EmailUtils
{
    public static void SendEmail(string toEmail, string toSubject, string toContent)
    {
        // set up send email
        string sendto = toEmail;
        string subject = toSubject;
        string content = toContent;
        // this is sender email
        string fromEmail = "long88ka@gmail.com";
        string fromPasswordEmail = "fbkseabpvtwrmigo";
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            //set property for email you want to send
            mail.From = new MailAddress(fromEmail);
            mail.To.Add(sendto);
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = content;
            mail.Priority = MailPriority.High;
            //set smtp port
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            //set gmail pass sender
            smtp.Credentials = new NetworkCredential(fromEmail, fromPasswordEmail);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        catch (Exception ex)
        {
            throw new BadRequestException($"Send to {toEmail} failed");
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
                      "Kitchen Buddy xin gửi bạn mật khẩu mới để đăng nhập vào website của chúng tôi: " + "<strong>" + user.Password + "</strong><br><br>" +
                      "Bạn vui lòng thay đổi mật khẩu của mình sau khi đăng nhập để bảo mật tài khoản " + "<br><br>" +
                      "Chúc bạn thành công với món ăn của mình!" + "<br>" + "<br>" + "Đội Ngũ Kỹ Thuật Kitchen Buddy.";
        SendEmail(user.Email, title, content);
    }
}