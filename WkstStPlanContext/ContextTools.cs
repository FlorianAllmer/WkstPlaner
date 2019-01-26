namespace HtlWeiz.WkstPlaner.WkstPlanContext
{
    internal static class ContextTools
    {
        internal static bool IsPropperContext(Microsoft.EntityFrameworkCore.DbContext context)
        {
            return context.GetType() == typeof(WkstStPlanContext);
        }

    }
}
