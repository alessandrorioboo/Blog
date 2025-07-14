using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using static Common.Enumerators;

namespace ViewModel.ViewModels
{
    public partial class PagePostViewModel : ObservableObject
    {
        public PagePostViewModel()
        {
            Page = 1;
            Total = 0;
            Status = eStatus.Processando;
            Posts = new ObservableCollection<PostViewModel>();
        }

        [ObservableProperty]
        public int _page;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TotalStr))]
        public int _total;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TotalStr))]
        [NotifyPropertyChangedFor(nameof(VisibleGrid))]
        public eStatus _status;

        [ObservableProperty]
        ObservableCollection<PostViewModel>? _posts;

        [ObservableProperty]
        ObservableCollection<PagingViewModel>? _pages;

        [ObservableProperty]
        public int _rowsPages;

        public bool VisibleGrid
        {
            get
            {
                return this.Status != eStatus.Processando;
            }
        }

        public string TotalStr
        {
            get
            {
                switch (Status)
                {
                    case eStatus.Processando:
                        return "Obtendo postagens...";
                    case eStatus.Erro:
                        return "Houve um erro ao obter as postagens.";
                    default:
                        return $"Total de Postagens: {Total}.";
                }
            }
        }
    }
}
