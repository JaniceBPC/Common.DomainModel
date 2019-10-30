using System.Threading.Tasks;

namespace Jbpc.Common.DomainModel
{
    public interface IEditSession
    {
        Task<IEditSession> Build();
    }
}
