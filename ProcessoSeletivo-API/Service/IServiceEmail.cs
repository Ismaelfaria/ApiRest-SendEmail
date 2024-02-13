namespace ProcessoSeletivo_API.Service
{
    public interface IServiceEmail
    {
        void SendEmail(string ?email, string subject, string body);
    }
}
