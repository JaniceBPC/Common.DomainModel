using System.Threading.Tasks;

namespace Jbpc.Common.DomainModel
{
    public interface IEditSessionBuilder<T> 
        where T : IEditSession
    {
        Task<T> Build();
    }
}
