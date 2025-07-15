using LocalDataBase.Model;
using LocalDataBase.Repository;

namespace ApplicationBlog.AppService
{
    /// <summary>
    /// Classe de Serviços de Informação de dados persistidos
    /// </summary>
    public class AppServiceDataInformation : AppServiceBase, IAppServiceDataInformation
    {
        private IDataInformationRepository _dataInformationRepository;

        public AppServiceDataInformation(IDataInformationRepository dataInformationRepository)
        {
            _dataInformationRepository = dataInformationRepository;
        }

        public async Task<DataInformation> GetFirst()
        {
            return await _dataInformationRepository.GetFirst();
        }

        public async Task AddOrUpdate(DataInformation dataInformation)
        {
            await _dataInformationRepository.AddOrUpdate(dataInformation);
        }

    }
}
