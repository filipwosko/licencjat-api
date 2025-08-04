using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using licencjatFrontend.Services;

namespace licencjatFrontend.ViewModels
{
    public class SelectedMethodViewModel : INotifyPropertyChanged
    {
        private readonly ProgramParametersApiService _parametersService = new ProgramParametersApiService();

        public SelectedMethodViewModel()
        {
            AvailableMethods = new ObservableCollection<string>
            {
                "SAW",
                "TOPSIS"
            };

            SelectedMethod = AvailableMethods[0];
        }

        private ObservableCollection<string> _availableMethods;
        public ObservableCollection<string> AvailableMethods
        {
            get => _availableMethods;
            set
            {
                _availableMethods = value;
                OnPropertyChanged();
            }
        }

        private string _selectedMethod;
        public string SelectedMethod
        {
            get => _selectedMethod;
            set
            {
                if (_selectedMethod != value)
                {
                    _selectedMethod = value;
                    OnPropertyChanged();
                    _ = UpdateSelectedMethodAsync(_selectedMethod);
                }
            }
        }

        private async Task UpdateSelectedMethodAsync(string method)
        {
            try
            {
                var dto = new ProgramParametersApiService.ProgramParameterDto
                {
                    Value = method
                };

                await _parametersService.UpdateProgramParameterAsync(dto);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd aktualizacji metody: " + ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
