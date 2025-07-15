using ApplicationBlog.Helper;
using LocalDataBase.Model;
using LocalDataBase.Repository;
using System.Text.Json;

namespace ApplicationBlog.AppService
{
    public class AppServiceDataInformation: AppServiceBase
    {
        private DataInformationRepository _dataInformationRepository = new DataInformationRepository();

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
