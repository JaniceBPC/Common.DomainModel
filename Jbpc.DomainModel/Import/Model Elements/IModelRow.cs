using System.Data;
using Jbpc.Repository;

namespace Jbpc.Common.DomainModel.ImportModel
{
    public interface IModelRow<out TRepositoryObject> : IAbstractModelRow
        where TRepositoryObject : IRepositoryObject
    {
        TRepositoryObject ImportedObject { get; }
        DataRow DataRow { get; }
    }
}