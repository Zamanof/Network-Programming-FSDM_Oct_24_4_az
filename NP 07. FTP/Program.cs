using System.Net;
//UploadFTP();
GetFTP();
List<string> fileNames = [
    "Akif.txt",
    "Huseyn.txt",
    "Sufiye.txt",
    "Gulcin.txt",
    "Firidun.txt"
];

fileNames.ForEach(DownloadFTP);
void GetFTP() {
    var request = WebRequest.Create("ftp://eu-central-1.sftpcloud.io:21") as FtpWebRequest;
    request!.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
    request.Credentials = 
        new NetworkCredential("e8218b59b8f348c89ca1c95fa5b46a07", "Uunjg2F4X6OPSjCA7xLfo210AtzbjfzM");

    var response = request.GetResponse() as FtpWebResponse;

    var stream = response.GetResponseStream();
    var reader = new StreamReader(stream);

    var data = reader.ReadToEnd();
    Console.WriteLine(data);

}
void UploadFTP() {
    var request = 
        WebRequest.Create("ftp://eu-central-1.sftpcloud.io:21/statusCodeList.png") as FtpWebRequest;
    
    request!.Method = WebRequestMethods.Ftp.UploadFile;
    request.Credentials =
        new NetworkCredential("e8218b59b8f348c89ca1c95fa5b46a07", "Uunjg2F4X6OPSjCA7xLfo210AtzbjfzM");

    var fileStream =
        new FileStream(@"C:\Users\zamanov\Downloads\1619338681039.png", FileMode.Open);

    var stream = request.GetRequestStream();
    fileStream.CopyTo(stream);

    stream.Close();
    fileStream.Close();
}
void DownloadFTP(string fileName) {
    var request = WebRequest.Create($"ftp://eu-central-1.sftpcloud.io:21/{fileName}") as FtpWebRequest;
    request!.Method = WebRequestMethods.Ftp.DownloadFile;
    request.Credentials =
        new NetworkCredential("e8218b59b8f348c89ca1c95fa5b46a07", "Uunjg2F4X6OPSjCA7xLfo210AtzbjfzM");

    var response = request.GetResponse() as FtpWebResponse;

    var stream = response.GetResponseStream();
    var fileStream = new FileStream(@$"C:\Users\zamanov\Downloads\fromStudents\{fileName}", FileMode.Create);
    
    stream.CopyTo(fileStream);
    stream.Close();
    fileStream.Close();


}
