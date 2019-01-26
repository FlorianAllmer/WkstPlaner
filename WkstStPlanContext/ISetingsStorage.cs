namespace HtlWeiz.WkstPlaner.WkstPlanContext
{
    public interface ISetingsStorage<T>
    {
        void WriteSettings( T settings);
        void ReadSettingsTo(ref T settings);
    }
}