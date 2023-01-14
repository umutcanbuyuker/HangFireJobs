namespace hangfapi.Services
{
    public class ServiceManagement : IServiceManagement 
    {
        public void GenerateMerchandise()
        {
            Console.WriteLine($" Generate Merchandise: Long running task {DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss")}");
        }

        public void SendEmail()
        {
            Console.WriteLine($" SendEmail: Long running task {DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss")}");

        }

        public void SyncData()
        {
            Console.WriteLine($" SyncData: Long running task {DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss")}");

        }

        public void UpdateDatabase()
        {
            Console.WriteLine($" Update Database: Long running task {DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss")}");
        }
    }
}
