
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Jbpc.Repository;

namespace Jbpc.Common.DomainModel
{
    public abstract class AbstractModelRow : IAbstractModelRow
    {
        public event EventHandler<EditChangesEventArgs> ModelRowChanged;
        public int NthRow { get; set; }
        public bool IsInvalid { get; set; }
        public int NthImportRow { get; set; }
        public DataRow DataRow { get; set; }
        public IAbstractEditSession EditSession { get; set; }

        public void RaiseModelRowChangedEvent(IAbstractModelRow modelRow)
        {
            ModelRowChanged?.Invoke(this, new EditChangesEventArgs() { ModelRow = modelRow });
        }
        public virtual void RaiseModelRowChangedEvent()
        {

        }

        public virtual List<IRepositoryObject> RepositoryObjectsToUpdate()
        {
            return new List<IRepositoryObject>();
        }

        public List<IRepositoryObject> RepositoryObjectsToUpdate(List<IRepositoryObject> objects)
        {
            return objects.Where(x => x.IsChangesPending).ToList();
        }

        public List<IRepositoryObject> EmptyList => new List<IRepositoryObject>();
        public List<IRepositoryObject> RepositoryObjectsToUpdate(IRepositoryObject obj)
        {
            return RepositoryObjectsToUpdate(new List<IRepositoryObject>() {obj});
        }

        public override string ToString() => $"{GetType().Name}, row={NthRow}";
    }
}
