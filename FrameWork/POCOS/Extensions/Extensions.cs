using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace POCOS.Models
{
  
        public static class DbContextExtensions
        {
            public static EntityKey GetEntityKey(this DbContext context, object entity)
            {
                var adapter = context as IObjectContextAdapter;
                var entry = adapter.ObjectContext.ObjectStateManager.GetObjectStateEntry(entity);
               // var entry = adapter.ObjectContext.ObjectStateManager.TryGetObjectStateEntry(entity);
                return entry.EntityKey;
            }

        }

   
}
