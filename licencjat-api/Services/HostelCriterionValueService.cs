using licencjat_api.Models;
using licencjat_api.Repository;

namespace licencjat_api.Services
{
    public class HostelCriterionValueService : IHostelCriterionValueService
    {
        private readonly IHostelCriterionValueRepository _hostelCriterionValueRepository;
        public HostelCriterionValueService(IHostelCriterionValueRepository hostelCriterionValueRepository)
        {
            _hostelCriterionValueRepository = hostelCriterionValueRepository;
        }


        //TODO





        public void Add(HostelCriterionValue hostel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HostelCriterionValue> GetByCriterionId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HostelCriterionValue> GetByHostelId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(HostelCriterionValue HostelCriterionValue)
        {
            throw new NotImplementedException();
        }
    }
}
