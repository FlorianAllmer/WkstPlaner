using System.Data.SqlClient;


namespace HtlWeiz.WkstPlaner.Model.Tools

{

    public class MsSqlConnection : IConnection
    {
        #region connection Parameter

        public string Server { private get;  set; }
        public string Catalog { private get; set; }
        public bool UseWindowsAuthentication { private get; set; }
        public string User { private get; set; }
        public string Password { private get; set; }
        public int Timeout { get; set; } = 15;
        #endregion

        #region States

        public string State { get; private set; }
        /// <inheritdoc />
        /// <summary>
        /// Connection Data spezified
        /// </summary>
        public bool CanConnect => CheckServerParameter();
        /// <inheritdoc />
        /// <summary>
        /// Conection Data and Catalog spezified
        /// </summary>
        public bool CanAccessData => CheckAllParameter();
        #endregion

        public string ConnectionString => GenerateConnectionString();


        internal MsSqlConnection() {}


        private bool CheckServerParameter()
        {
            if (string.IsNullOrEmpty(Server))
            {
                State = "No Servername specified!";
                return false;
            }

            if (UseWindowsAuthentication)
            {
                State = "ready";
                return true;
            }

            if (string.IsNullOrEmpty(User))
            {
                State = "Need User to be specified! (Or Windows Authentificaton)";
                return false;

            }

            if (string.IsNullOrEmpty(Password))
            {
                State = "No Password specified!";
                return false;

            }

            State = "ready";
            return true;

        }

        private bool CheckAllParameter()
        {
            if (!string.IsNullOrEmpty(Catalog)) return CheckServerParameter();
            State = "Need Catalog to be specified!";
            return false;
        }


        private string GenerateConnectionString()
        {
            if (!CheckServerParameter()) return "";

            var builder = new SqlConnectionStringBuilder { DataSource = Server };

            if (UseWindowsAuthentication)
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.UserID = User;
                builder.Password = Password;
                builder.IntegratedSecurity = false;
            }

            builder.ConnectTimeout = Timeout;
            if (!string.IsNullOrEmpty(Catalog)) builder.InitialCatalog = Catalog;

            return builder.ConnectionString;
        }

        public override string ToString()
        {
            return GenerateConnectionString();
        }
    }



}

    
