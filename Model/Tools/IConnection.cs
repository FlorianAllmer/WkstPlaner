
namespace HtlWeiz.WkstPlaner.Model.Tools
{
    interface IConnection
    {
        string Server { set; }
        string Catalog { set; }
        bool UseWindowsAuthentication { set; }
        string User { set; }
        string Password { set; }
        int Timeout { get; set; }
        string State { get; }

        /// <summary>
        /// Connection Data spezified
        /// </summary>
        bool CanConnect { get; }

        /// <summary>
        /// Conection Data and Catalog spezified
        /// </summary>
        bool CanAccessData { get; }

        string ConnectionString { get; }
        string ToString();

    }
}

 
