using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Reportes
{
    public class Print<S, T, U> where S : EntityObject where T : EntityObject where U : PrintItem<S,T>, new()
    {
        #region Properties
        public List<U> Items { get; set; }
        #endregion Properties

        #region Constructors
        public Print(S entity, List<T> entities)
        {
            Items = new List<U>();
            if (entities != null) entities.ForEach(item => Items.Add(new U { Entity = item }));

            if (Items.Count == 0)
                Items.Add(new U());

            PrintItem<S, T>.EntityParent = entity;
        }
        #endregion Constructors
    }

    public class PrintItem<S, T>
    {
        #region Private Members
        internal static S EntityParent { get; set; }
        internal T Entity { get; set; }
        #endregion Private Members
     }
}
