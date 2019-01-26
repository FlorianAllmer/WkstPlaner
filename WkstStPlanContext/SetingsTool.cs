using System;

namespace HtlWeiz.WkstPlaner.WkstPlanContext
{
    internal class SetingsTool
    {

        internal void StoreConnectionString(string connectionString)
        {
            var storage = GetSettingStorage();
            var setings = GetSettingsObject(storage);
            setings.ConnectionString = connectionString;
            storage.WriteSettings(setings);

        }

        internal string GetConnectionString()
        {
            var storage = GetSettingStorage();
            var setings = GetSettingsObject(storage);
            if (string.IsNullOrEmpty(setings.ConnectionString))
            {
                throw new Exception("No valid data stored to configuration file");
            }
            return setings.ConnectionString;
        }

        private ISetingsStorage<PocoSetings> GetSettingStorage()
        {
            return new JsonSetingsStorage<PocoSetings>(AppDomain.CurrentDomain.BaseDirectory, "settings");
        }

        private PocoSetings GetSettingsObject(ISetingsStorage<PocoSetings> storage)
        {
            var setings = new PocoSetings();
            storage.ReadSettingsTo(ref setings);
            return setings;
        }

    }

}

