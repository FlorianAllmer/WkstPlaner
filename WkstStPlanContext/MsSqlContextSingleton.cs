using System;
using HtlWeiz.WkstPlaner.Contracts.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace HtlWeiz.WkstPlaner.WkstPlanContext
{
    public class MsSqlContextSingleton : IContextFactory

    {
        private readonly WkstStPlanContext _context;

        public DbContext Context => _context;
        public Type SettingsType => typeof(PocoSetings);

        public MsSqlContextSingleton(EnumContextFabricateBy fabricateBy, string parameter = "")
        {
            _context = GetContext(fabricateBy, parameter);
        }

        private WkstStPlanContext GetContext(EnumContextFabricateBy fabricateBy, string parameter)
        {
            switch (fabricateBy)
            {
                case EnumContextFabricateBy.ConnectionString:
                    return new WkstStPlanContext(parameter);
                case EnumContextFabricateBy.ConfigFile:
                    return new WkstStPlanContext(GetConnectionStringFromSettings());
            }
            return null;
        }

        public void StoreSettingsToConfigFile()
        {
            var setingTool = new SetingsTool();
            setingTool.StoreConnectionString(_context.Database.GetDbConnection().ConnectionString);
        }

        private string GetConnectionStringFromSettings()
        {
            var setingTool = new SetingsTool();
            return setingTool.GetConnectionString();
        }

    }
}
