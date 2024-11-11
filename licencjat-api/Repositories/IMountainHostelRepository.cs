using licencjat_api.Models;

namespace licencjat_api.Repository
{
    public interface IMountainHostelRepository
    {
        IEnumerable<MountainHostel> GetMountainHostels();
        MountainHostel GetMountainHostel(int id);
        void AddMountainHostel(MountainHostel mountainHostel);
        void UpdateMountainHostel(MountainHostel mountainHostel);
        void DeleteMountainHostel(int id);

    }
}
