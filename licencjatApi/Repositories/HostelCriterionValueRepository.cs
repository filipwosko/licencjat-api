using licencjatApi.Data;
using licencjatApi.Models;
using Microsoft.EntityFrameworkCore;

namespace licencjatApi.Repository
{
    public class HostelCriterionValueRepository : IHostelCriterionValueRepository
    {
        private readonly DataContext _dataContext;

        public HostelCriterionValueRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<HostelCriterionValue> GetByHostelIdAndCriterionId(int hostelId, int criterionId)
        {
            return _dataContext.HostelCriterionValues
                .Where(h => h.MountainHostelId == hostelId && h.CriterionId == criterionId);
        }

        public IEnumerable<HostelCriterionValue> GetByHostelId(int hostelId)
        {
            return _dataContext.HostelCriterionValues.Where(x => x.MountainHostelId == hostelId);
        }

        public IEnumerable<HostelCriterionValue> GetByCriterionId(int criterionId)
        {
            return _dataContext.HostelCriterionValues.Where(x => x.CriterionId == criterionId);
        }

        public void AddHostelCriterionValue(HostelCriterionValue hostelCriterionValue)
        {
            _dataContext.HostelCriterionValues.Add(hostelCriterionValue);
            _dataContext.SaveChanges();
        }

        public void UpdateHostelCriterionValue(HostelCriterionValue hostelCriterionValue)
        {
            var hostelCriterionValueToEdit = _dataContext.HostelCriterionValues.FirstOrDefault(n => n.Id == hostelCriterionValue.Id);
            if (hostelCriterionValueToEdit != null)
            {
                hostelCriterionValueToEdit.Value = hostelCriterionValue.Value;
                _dataContext.Entry(hostelCriterionValueToEdit).State = EntityState.Modified;
                _dataContext.SaveChanges();
            }
        }

        public void DeleteHostelCriterionValue(int id)
        {
            _dataContext.HostelCriterionValues.Where(n => n.Id == id).ExecuteDelete();
        }

        public void DeleteHostelCriterionValueByHostelId(int hostelId)
        {
            _dataContext.HostelCriterionValues.Where(n => n.MountainHostelId == hostelId).ExecuteDelete();
        }

        public void DeleteHostelCriterionValueByCriterionId(int criterionId)
        {
            _dataContext.HostelCriterionValues.Where(n => n.CriterionId == criterionId).ExecuteDelete();
        }
    }
}
