using System.IO;
using System.Threading.Tasks;

namespace Instagram.DataProvider
{
    public interface IDataProvider
    {
        Task<MemoryStream> GetData();
    }
}
