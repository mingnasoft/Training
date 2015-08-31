using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace POCOS.Models
{
    public class EntityBase<Tentity> where Tentity : class
    {

        public void save(Tentity  etity2)
        {

            Object entity = null;
            if (CurrContext.Entry<Tentity>(etity2).State == EntityState.Detached)
            {
                CurrContext.Entry<Tentity>(etity2).State = EntityState.Modified;
                var _EntityKey = CurrContext.GetEntityKey(this);
                var adapter = (new MyContext()) as IObjectContextAdapter;
                var isExsit = adapter.ObjectContext.TryGetObjectByKey(_EntityKey, out entity);
                if (isExsit)
                {
                    CurrContext.Entry<Tentity>(etity2).State = EntityState.Added;
                }
            }
        }
        public MyContext CurrContext
        {
            get
            {
                return MyContext.Current;
            }

        }

    }
}
