using ManagmentStudio.Server.Factory.Connector;
using ManagmentStudio.Server.Factory.Interfice;

namespace ManagmentStudio.Server.Factory
{
    public class ConnectorFactory
    {
        public IConnector GetConnector(string connoctorType, string connectionString)
        {
            IConnector resault;
            
            switch (connoctorType)
            {
                case "MSSQL":
                    resault = new MSSQLConnector(connectionString);
                    break;
                case "MySQL":
                    resault = new MySQLConnector(connectionString);
                    break;
                case "NpgSQL":
                    resault = new NpgSqlConnector(connectionString);
                    break;
                default:
                    resault = null;
                    break;
            }

            return resault;
        }
    }
}
