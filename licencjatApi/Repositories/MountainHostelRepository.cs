using licencjatApi.Data;
using licencjatApi.Models;
using Microsoft.EntityFrameworkCore;

namespace licencjatApi.Repository
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
                mountainHostelToEdit.Name = mountainHostel.Name;
                _dataContext.Entry(mountainHostelToEdit).State = EntityState.Modified;
                _dataContext.SaveChanges();
            }
        }
    }
}
