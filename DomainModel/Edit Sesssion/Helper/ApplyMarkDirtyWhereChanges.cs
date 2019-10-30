using System;
using Jbpc.Repository;

namespace Jbpc.Common.DomainModel
{
    public static class ApplyMarkDirtyWhereChanges
    {
        public static void Apply<T>(T lineItem, bool changes, Action<T> mutate) where T : IRepositoryObject
        {
            Apply(lineItem, x => changes, mutate);
        }
        public static void Apply<T>(T lineItem, Func<T, bool> predicate, Action<T> mutate) where T : IRepositoryObject
        {
            if (predicate(lineItem))
            {
                lineItem.IsDirty = lineItem.IsDirty || lineItem.IsPersistent;

                mutate(lineItem);
            }
        }
    }
}
