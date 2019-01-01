namespace HtlWeiz.WkstPlaner.Model.context
{
    public interface ISetingsStorage<T>
    {
        void WriteSettings( T settings);
        void ReadSettingsTo(ref T settings);
    }
}