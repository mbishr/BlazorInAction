using System.Data;

namespace EBikeShop.Server
{
    public interface IDbSession
    {
        string GetConnectionString();

        IDbConnection GetConnection();
    }
}
