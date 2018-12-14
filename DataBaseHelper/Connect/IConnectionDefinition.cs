
namespace HtlWeiz.WkstPlaner.DataBaseHelper.Connect
{
    public interface IConnectionDefinition
    {
        string Server { get; set; }
        string Catalog { get; set; }
        bool UseWindowsAuthentication { get; set; }
        string User { get; set; }
        string Password { get; set; }
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

 
