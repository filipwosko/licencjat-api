using licencjatFrontend.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace licencjatFrontend.ViewModels
{
    public class ProgramParameterViewModel : BaseViewModel
    {
        private readonly ProgramParametersApiService _programParametersApiService;

        private string _selectedAlgorithm;
        public string SelectedAlgorithm
        {
            get => _selectedAlgorithm;
            set => SetProperty(ref _selectedAlgorithm, value, nameof(SelectedAlgorithm));
        }

        private List<string> _availableMethods;
        public List<string> AvailableMethods
        {
            get => _availableMethods;
            set => SetProperty(ref _availableMethods, value, nameof(AvailableMethods));
        }

        public ICommand LoadMethodsCommand { get; }

        public ProgramParameterViewModel()
        {
            _programParametersApiService = new ProgramParametersApiService();
        }

        public ICommand UpdateMethodCommand => new RelayCommand(async () => await UpdateProgramParameterAsync());

        private async Task UpdateProgramParameterAsync()
        {
            try
            {
                var parameterDto = new ProgramParametersApiService.ProgramParameterDto
                {
                    Value = SelectedAlgorithm
                };

                await _programParametersApiService.UpdateProgramParameterAsync(parameterDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
        }
    }
}
