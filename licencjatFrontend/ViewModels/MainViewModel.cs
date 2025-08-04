using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using static licencjatFrontend.Services.RankingApiService;

namespace licencjatFrontend.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public CriterionViewModel CriterionVM { get; set; }
        public RankingViewModel RankingVM { get; set; }
        public SelectedMethodViewModel MethodViewModel { get; } = new SelectedMethodViewModel();

        public MainViewModel()
        {
            CriterionVM = new CriterionViewModel();
            RankingVM = new RankingViewModel(CriterionVM);
            CriterionVM.Criteria.CollectionChanged += OnCriteriaCollectionChanged;
        }

        private void OnCriteriaCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(DataGridHeight));
        }

        public double DataGridHeight => Criteria.Count == 0 ? 0 : Criteria.Count * 35 + 35;

        public ICommand LoadCriteriaCommand => CriterionVM.LoadCriteriaCommand;
        public ICommand GetRankingCommand => RankingVM.GetRankingCommand;

        public ObservableCollection<CriterionViewModel.Criterion> Criteria => CriterionVM.Criteria;
        public ObservableCollection<decimal> Values => new ObservableCollection<decimal>(CriterionVM.Values);
        public ObservableCollection<HostelWithResult> RankingResults => RankingVM.RankingResults;
    }
}
