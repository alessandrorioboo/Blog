using LocalDataBase.Model;
using Microsoft.EntityFrameworkCore;

namespace LocalDataBase.Repository
{
    /// <summary>
    /// Classe de Repositórios de Dados de Informação de dados persistidos
    /// </summary>
    public class DataInformationRepository : BaseRepository<DataInformation>, IDataInformationRepository
    {
        public virtual async Task<DataInformation> GetFirst()
        {
            var dataInformation = await context.DataInformation.FirstAsync();
            return dataInformation ?? new DataInformation { Id = 1, LastUpdate = DateTime.MinValue };
        }

    }
}
