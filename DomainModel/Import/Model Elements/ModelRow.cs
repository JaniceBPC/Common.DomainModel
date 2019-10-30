
using System.Collections.Generic;
using System.Data;
using Jbpc.Repository;

namespace Jbpc.Common.DomainModel.ImportModel
{
    public class ModelRow<T> : AbstractModelRow 
        where T : IRepositoryObject 
    {
        public T ImportedObject { get; set; }
        public override List<IRepositoryObject> RepositoryObjectsToUpdate() => RepositoryObjectsToUpdate(ImportedObject);
    }
}
