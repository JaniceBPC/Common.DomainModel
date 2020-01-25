
using System;
using System.Threading.Tasks;
using Jbpc.Common.DomainModel;

namespace Jbpc.Common.DomainModel
{
    public abstract class AbstractBuildEditSession
    {
        public abstract Task Build(IEditSession editSession);
        //{
        //    await Task.Delay(1);

        //    return new Task<IEditSession>(() => editSession);
        //}
    }
}
