using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace HtlWeiz.WkstPlaner.Model.context
{
    internal static class ContextTools
    {
        internal static bool IsPropperContext(DbContext context)
        {
            return context.GetType() == typeof(WkstStPlanContext);
        }

    }
}
