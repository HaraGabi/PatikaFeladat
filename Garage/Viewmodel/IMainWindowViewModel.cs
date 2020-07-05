using System;
using System.Windows.Input;

namespace Garage.Viewmodel
{
    public interface IMainWindowViewModel
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Search { get; set; }
        public bool IsByCard { get; set; }

        public ICommand SearchCommand { get; }
        public ICommand ExportCommand { get; }
    }
}