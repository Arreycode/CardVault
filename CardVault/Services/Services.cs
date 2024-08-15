using CardVault.Models;

namespace CardVault.Services
{
    public class Services
    {
        private readonly MyDBContext dbContext;

        public Services()
        {
            dbContext = new MyDBContext();
        }
    }

}
