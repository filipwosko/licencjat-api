using GalaSoft.MvvmLight.Command;
using licencjatFrontend.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace licencjatFrontend.ViewModels
{
    public class CriterionViewModel : BaseViewModel
    {
        private readonly CriterionApiService _criterionApiService;
        public ObservableCollection<Criterion> Criteria { get; set; }
        public List<decimal> Values { get; set; }
        public ICommand LoadCriteriaCommand { get; set; }

        public CriterionViewModel()
        {
            _criterionApiService = new CriterionApiService();
            Criteria = new ObservableCollection<Criterion>();
            Values = new List<decimal> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            LoadCriteriaCommand = new RelayCommand(async () => await LoadCriteriaAsync());
        }

        private async Task LoadCriteriaAsync()
        {
            var criteria = await _criterionApiService.GetAllCriteriaAsync();
            Criteria.Clear();
            foreach (var criterion in criteria)
            {
                Criteria.Add(new Criterion
                {
                    Id = criterion.Id,
                    Name = criterion.Name,
                    Value = 0
                });
            }
        }

        public class Criterion : INotifyPropertyChanged
        {
            public int Id { get; set; }
            public string Name { get; set; }

            private decimal _value;
            public decimal Value
            {
                get => _value;
                set
                {
                    if (_value != value)
                    {
                        _value = value;
                        OnPropertyChanged(nameof(Value));
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}