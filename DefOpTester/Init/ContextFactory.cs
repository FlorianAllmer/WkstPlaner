using System;
using HtlWeiz.WkstPlaner.Contracts.DataAccess;
using HtlWeiz.WkstPlaner.DataBaseHelper.Connect;
using HtlWeiz.WkstPlaner.WkstPlanContext;

namespace HtlWeiz.WkstPlaner.DefOpTester.Init
{
    internal class ContextFactory
    {
        internal IConnectionDefinition ConnectionDefinition { get; private set; }

        internal IContextFactory Context { get; }

        internal ContextFactory()
        {
            InitConnectionPropertys();
            Context = new MsSqlContextSingleton(EnumContextFabricateBy.ConfigFile);
            
        }
        internal ContextFactory(string connectionString)
        {
            InitConnectionPropertys();
            Context = new MsSqlContextSingleton(EnumContextFabricateBy.ConnectionString, connectionString);
        }

        internal ContextFactory(EnumUser dataset)
        {
            ConnectionDefinition = InitConnection.GetConnectionParameter(dataset);
            Context = new MsSqlContextSingleton(EnumContextFabricateBy.ConnectionString, ConnectionDefinition.ConnectionString);
        }

        private void InitConnectionPropertys()
        {
            ConnectionDefinition = new MsSqlConnection();
            const string defaultText = "Set elsewhere";
            ConnectionDefinition.Server = defaultText;
            ConnectionDefinition.Catalog= defaultText;
            ConnectionDefinition.User = defaultText;
            ConnectionDefinition.Password= defaultText;
            ConnectionDefinition.UseWindowsAuthentication = false;
        }



    }
}
