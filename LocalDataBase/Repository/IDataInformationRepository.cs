using LocalDataBase.Model;

namespace LocalDataBase.Repository
{
    /// <summary>
    /// Interface do Repositórios de Informação de dados persistidos
    /// </summary>
    public interface IDataInformationRepository : IBaseRepository<DataInformation>
    {
        Task<DataInformation> GetFirst();
    }
}