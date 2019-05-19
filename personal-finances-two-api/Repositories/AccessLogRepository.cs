using personal_finances_two_api.Models;

namespace personal_finances_two_api.Repositories
{
    public class AccessLogRepository
    {
        public void Insert (AccessLog accessLog)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.AccessLogs.Add(accessLog);
                context.SaveChanges();
            }
        }
    }
}