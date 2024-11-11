using licencjat_api.Data;
using licencjat_api.Models;
using Microsoft.EntityFrameworkCore;

namespace licencjat_api.Repository
{
    public class MountainHostelRepository : IMountainHostelRepository
    {
        private readonly DataContext _dataContext;
        public MountainHostelRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddMountainHostel(MountainHostel mountainHostel)
        {
            mountainHostel.Id = 0;
            _dataContext.MountainHostels.Add(mountainHostel);
            _dataContext.SaveChanges();
        }

        public void DeleteMountainHostel(int id)
        {
            var mountainHostel = _dataContext.MountainHostels.FirstOrDefault(n => n.Id.Equals(id));
            if (mountainHostel != null)
            {
                _dataContext.MountainHostels.Remove(mountainHostel);
                _dataContext.SaveChanges();
            }
        }

        public MountainHostel GetMountainHostel(int id)
        {
            return _dataContext.MountainHostels.FirstOrDefault(n => n.Id.Equals(id));
        }
        
        public IEnumerable<MountainHostel> GetMountainHostels()
        {
            return _dataContext.MountainHostels.ToList();
        }

        public void UpdateMountainHostel(MountainHostel mountainHostel)
        {
            var mountainHostelToEdit = _dataContext.MountainHostels.FirstOrDefault(n => n.Id.Equals(mountainHostel.Id));
            if (mountainHostelToEdit != null)
            {
                _dataContext.Entry(mountainHostel).State = EntityState.Modified;
                _dataContext.SaveChanges();
            }
        }
    }
}
