using System;
using System.Collections.Generic;
using System.Linq;
using Jbpc.Repository;

namespace Jbpc.Common.DomainModel
{
    public static class ObjectStatesMessage
    {
        public static string Generate(List<IRepositoryObject> objects, string title)
        {
            var @new = objects.Count(x => x.IsChangesPending);
            var modified = objects.Count(x => x.IsDirty);
            var unchanged = objects.Count(x => x.IsPersistent & !x.IsChangesPending);
            var toDelete = objects.Count(x => x.IsMarkedForDeletion);

            var msg = title;
            msg = $"{msg}{Environment.NewLine}..new={@new:#,0}";
            msg = $"{msg}{Environment.NewLine}..modified={modified:#,0}";
            msg = $"{msg}{Environment.NewLine}..unchanged={unchanged:#,0}";
            msg = $"{msg}{Environment.NewLine}..toDelete={toDelete:#,0}";
            msg = $"{msg}{Environment.NewLine}..total={@new+modified+unchanged+toDelete:#,0}";

            return msg;
        }
    }
}
