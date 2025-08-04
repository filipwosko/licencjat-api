using GalaSoft.MvvmLight.Command;
using licencjatFrontend.Services;
using licencjatFrontend.ViewModels;
using licencjatFrontend.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using static licencjatFrontend.Services.RankingApiService;

public class RankingViewModel : BaseViewModel
{
    private readonly RankingApiService _rankingApiService;
    private readonly CriterionViewModel _criterionViewModel;

    public ICommand GetRankingCommand { get; set; }

    public ObservableCollection<HostelWithResult> RankingResults { get; set; } = new ObservableCollection<HostelWithResult>();

    public RankingViewModel(CriterionViewModel criterionViewModel)
    {
        _rankingApiService = new RankingApiService();
        _criterionViewModel = criterionViewModel;

        GetRankingCommand = new RelayCommand(async () => await GetRankingAsync());
    }

    public async Task GetRankingAsync()
    {
        var criteria = _criterionViewModel.Criteria;

        var criterionWeights = criteria.Select(c => new CriterionWeight
        {
            CriterionId = c.Id,
            Weight = c.Value == 0 ? 0 : c.Value
        }).ToList();


        var ranking = await _rankingApiService.GetRankingAsync(criterionWeights);

        RankingResults.Clear();

        if (ranking != null && ranking.HostelsWithResult != null && ranking.HostelsWithResult.Any())
        {
            foreach (var hostel in ranking.HostelsWithResult)
            {
                RankingResults.Add(hostel);
            }

            var rankingWindow = new RankingWindow
            {
                DataContext = this
            };
            rankingWindow.Show();
        }

        OnPropertyChanged(nameof(RankingResults));
    }
}
