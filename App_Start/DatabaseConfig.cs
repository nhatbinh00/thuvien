using LiteLibrary.BusinessLayers;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LiteLibrary.App_Start
{
    /// <summary>
    /// 
    /// </summary>
    public class DatabaseConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Initialize()
        {
            string connectionString = @"server=DESKTOP-6GHLID0\SQLEXPRESS;user id=sa;password=123;database=LiteLibrary";

            UserAccountBLL.Initialize(DatabaseType.SqlServer, connectionString);
        }
    }
}