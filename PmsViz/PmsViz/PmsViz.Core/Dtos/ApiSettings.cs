using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmsViz.Core.Dtos
{
    public class ApiSettings
    {
        public string WebServicePorts { get; set; }
        public int HttpPort { get { return int.Parse(WebServicePorts.Split(',')[0]); } }
        public int HttpsPort { get { return int.Parse(WebServicePorts.Split(',')[1]); } }

        public string DatabaseConnection { get; set; }
        public string DatabaseHost { get { return DatabaseConnection.Split(',')[0]; } }
        public string DatabaseUser { get { return DatabaseConnection.Split(',')[1]; } }

        public string ProductionDatabaseConnection { get; set; }
        public string ProductionDatabaseHost { get { return ProductionDatabaseConnection.Split(',')[0]; } }
        public string ProductionDatabaseUser { get { return ProductionDatabaseConnection.Split(',')[1]; } }
    }
}
