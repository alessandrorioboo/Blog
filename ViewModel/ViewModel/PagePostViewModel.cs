using static Common.Enumerators;

namespace ViewModel.ViewModels
{
    public class PagePostViewModel
    {
        public int Page { get; set; }
        public int Total { get; set; }
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

        private eStatus _status = eStatus.Processando;
        public eStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        public IList<PostViewModel>? Posts { get; set; }
    }
}
