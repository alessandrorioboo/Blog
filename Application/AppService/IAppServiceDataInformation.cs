using LocalDataBase.Model;

namespace Application.AppService
{
    /// <summary>
    /// Interface de Serviços de Informação de dados persistidos
    /// </summary>
    public interface IAppServiceDataInformation
    {
        Task AddOrUpdate(DataInformation dataInformation);
        Task<DataInformation> GetFirst();
    }
}