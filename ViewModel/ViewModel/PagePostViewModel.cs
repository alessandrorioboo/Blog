using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (String.IsNullOrEmpty(Status))
                    return "Obtendo postagens...";
                else
                    return $"Total de Postagens: {Total}";
            }
        }
        public string? Status { get; set; }
        public IList<PostViewModel>? Posts { get; set; }

        
    }
}
