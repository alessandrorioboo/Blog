using LocalDataBase.Model;
using Microsoft.EntityFrameworkCore;

namespace LocalDataBase.Repository
{
    
    public class DataInformationRepository : BaseRepository<DataInformation>
    {
        public virtual async Task<DataInformation> GetFirst()
        {
            var dataInformation = await context.DataInformation.FirstAsync();
            return dataInformation ?? new DataInformation { Id = 1, LastUpdate = DateTime.MinValue };
        }

    }
}
