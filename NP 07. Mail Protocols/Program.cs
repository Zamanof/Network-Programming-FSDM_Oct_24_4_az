using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Search;
using MimeKit;

//SMTP();
//SMTPMailKit();
IMAP();
void SMTP() // SmtpClient from using System.Net.Mail is obsolete
{
    //using System.Net;
    //using System.Net.Mail;
    //var client = new SmtpClient("smtp.gmail.com", 587);
    //client.EnableSsl = true;

    //client.Credentials = new NetworkCredential("fbms.1223@gmail.com", "adfiauzxfgbrhssx");

    //var message = new MailMessage
    //{
    //    Subject = "Test Mail Protocols",
    //    Body = "WINTER IS COMING!!! (WINTER = EXAM)" 
    //};

    //message.From = new MailAddress("fbms.1223@gmail.com", "Elon Musk");

    //message.To.Add(new MailAddress("abbashaciyev313@gmail.com"));
    //message.To.Add(new MailAddress("hsbziyev@gmail.com"));
    //message.To.Add(new MailAddress("h.ibad.3008@gmail.com"));
    //message.To.Add(new MailAddress("g.hebillayeva46@gmail.com"));
    //message.To.Add(new MailAddress("yusifligulay06@gmail.com"));
    //message.To.Add(new MailAddress("sufiye.huseynzade.20@gmail.com"));
    //message.To.Add(new MailAddress("zamanov@itstep.org"));

    //client.Send(message);
}

void SMTPMailKit()
{
    var client = new SmtpClient();
    client.Connect("smtp.gmail.com", 587);
    client.Authenticate("fbms.1223@gmail.com", "adfiauzxfgbrhssx");

    var message = new MimeKit.MimeMessage();
    message.From.Add(new MailboxAddress("Donald Trump", "fbms.1223@gmail.com"));

    message.To.AddRange(new[]
    {
        MailboxAddress.Parse("abbashaciyev313@gmail.com"),
        MailboxAddress.Parse("hsbziyev@gmail.com"),
        MailboxAddress.Parse("h.ibad.3008@gmail.com"),
        MailboxAddress.Parse("g.hebillayeva46@gmail.com"),
        MailboxAddress.Parse("yusifligulay06@gmail.com"),
        MailboxAddress.Parse("sufiye.huseynzade.20@gmail.com"),
        MailboxAddress.Parse("zamanov@itstep.org"),
    });

    message.Subject = "Exam";
    //message.Body = new TextPart("plain")
    //{
    //    Text = "WINTER IS COMING!!! (WINTER = EXAM)"
    //};

    message.Body = new TextPart("html")
    {
        Text = """
        <h1 style='color:red;'>WINTER IS COMING!!! (WINTER = EXAM)</h1>
        <a href='https://pranx.com/hacker/'>Dont click</a>
        <img src='https://insights.ibx.com/wp-content/uploads/2019/06/first-aid-kit-screenshot.png'/>
        """
    };

    client.Send(message);
    client.Disconnect(true);
}


void IMAP()
{
    var imapClient = new ImapClient();
    imapClient.Connect("imap.gmail.com", 993, true);

    imapClient.Authenticate("fbms.1223@gmail.com", "adfiauzxfgbrhssx");

    var inbox = imapClient.Inbox;
    inbox.Open(FolderAccess.ReadWrite);

    var ids = inbox.Search(SearchQuery.All);

    //foreach (var id in ids)
    //{
    //    Console.WriteLine($"{id}. {inbox.GetMessage(id).TextBody}");
    //}

    //inbox.SetFlags(new UniqueId(120), MessageFlags.Deleted, true);
    //inbox.AddFlags(ids, MessageFlags.Seen, true);
    inbox.AddFlags(ids, MessageFlags.Deleted, true);


    inbox.Expunge();
    inbox.Close();
}