using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Garage.Model;
using Garage.Util;
using Microsoft.Win32;
using Services;

namespace Garage.Viewmodel
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private readonly IQueryService _queryService;
        private readonly IFileExporterFactory _fileExporterFactory;

        public MainWindowViewModel(IQueryService queryService, IFileExporterFactory fileExporterFactory)
        {
            _queryService = queryService;
            _fileExporterFactory = fileExporterFactory;
            SearchCommand = new RelayCommand(SearchLog, CanExecuteSearchCommand);
            ExportCommand = new RelayCommand(ExportLog, CanExecuteExportCommand);
        }

        private void SearchLog(object parameter)
        {
            if (!FromDate.HasValue || !ToDate.HasValue || string.IsNullOrWhiteSpace(Search))
                return;

            var logs = IsByCard
                ? _queryService.ReportByCardId(int.TryParse(Search, out int cardId) ? cardId : 0, FromDate.Value, ToDate.Value)
                : _queryService.ReportByLicensePlate(Search, FromDate.Value, ToDate.Value);

            var report = logs.Select(o => new GatekeeperReport
                {
                    LicensePlate = o.LicensePlate,
                    Begin = o.Begin,
                    End = o.End,
                    Partner = o.Partner,
                    Discount = o.Discount * 100.0m,
                });

            GatekeeperReports = new ObservableCollection<GatekeeperReport>(report);
        }

        private void ExportLog(object parameter)
        {
            var param = (FileFormat) parameter;
            string tipus = IsByCard ? "kártya" : "rendszám";
            var dialog = new SaveFileDialog
            {
                Filter = $"{param} Documents (.{param})|*.{param}",
                DefaultExt = $".{param}",
                FileName = $"Garázs forgalom - {tipus} - {Search}"
            };

            if (dialog.ShowDialog() ?? false)
            {
                var exporter = _fileExporterFactory.Create((FileFormat)parameter);
                exporter.Export(GatekeeperReports, dialog.FileName);
            }
        }

        private bool CanExecuteSearchCommand(object parameter) => !string.IsNullOrWhiteSpace(Search) && FromDate.HasValue && ToDate.HasValue;

        private bool CanExecuteExportCommand(object parameter) => GatekeeperReports != null && GatekeeperReports.Count > 0;

        public ICommand SearchCommand { get; }
        public ICommand ExportCommand { get; }

        private ObservableCollection<GatekeeperReport> _gatekeeperReports;

        public ObservableCollection<GatekeeperReport> GatekeeperReports
        {
            get => _gatekeeperReports;
            set => SetProperty(ref _gatekeeperReports, value);
        }

        private DateTime? _fromDate;
        public DateTime? FromDate
        {
            get => _fromDate;
            set => SetProperty(ref _fromDate, value);
        }

        private DateTime? _toDate;
        public DateTime? ToDate
        {
            get => _toDate;
            set => SetProperty(ref _toDate, value);
        }

        private string _search;
        public string Search
        {
            get => _search; 
            set => SetProperty(ref _search, value);
        }

        private bool _isByCard;
        public bool IsByCard
        {
            get => _isByCard;
            set => SetProperty(ref _isByCard, value, nameof(SearchGroupHeader));
        }

        public string SearchGroupHeader => IsByCard ? "Keresés Belépőkártya alapján" : "Keresés rendszám alapján";
    }
}