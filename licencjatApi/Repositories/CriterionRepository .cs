using licencjatApi.Data;
using licencjatApi.Models;
using Microsoft.EntityFrameworkCore;

namespace licencjatApi.Repository
{
    public class CriterionRepository : ICriterionRepository
    {
        private readonly DataContext _dataContext;
        public CriterionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<Criterion> GetCriteria()
        {
            return _dataContext.Criteria;
        }

        public void AddCriterion(Criterion criterion)
        {
            _dataContext.Criteria.Add(criterion);
            _dataContext.SaveChanges();
        }

        public void UpdateCriterion(Criterion criterion)
        {
            var criterionToEdit = _dataContext.Criteria.FirstOrDefault(n => n.Id.Equals(criterion.Id));
            if (criterionToEdit != null)
            {
                criterionToEdit.Name = criterion.Name;
                criterionToEdit.Type = criterion.Type;
                criterionToEdit.IsStimulant = criterion.IsStimulant;
                _dataContext.Entry(criterionToEdit).State = EntityState.Modified;
                _dataContext.SaveChanges();
            }
        }

        public void DeleteCriterion(int id)
        {
            var criterion = _dataContext.Criteria.FirstOrDefault(n => n.Id.Equals(id));
            if (criterion != null)
            {
                _dataContext.Criteria.Remove(criterion);
                _dataContext.SaveChanges();
            }
        }
    }
}
