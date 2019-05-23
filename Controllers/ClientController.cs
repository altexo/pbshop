namespace pbshop_web.Controllers
{
    public class ClientController
    {
         public bool validateEmail(string email){
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch {
                return false;
            }
        }
    }
}