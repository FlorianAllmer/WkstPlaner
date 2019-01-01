using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace HtlWeiz.WkstPlaner.Contracts.DataAccess
{

    public enum EnumContextFabricateBy
    {
        ConnectionString
       ,ConfigFile
    }
    public interface IContextFactory
    {

        /// <summary>
        /// Retruns Db - Context
        /// </summary>
        DbContext Context { get;  }
        /// <summary>
        /// Saving actual connection Parameter to config file
        /// </summary>
        void StoreSettingsToConfigFile();
    }
}
