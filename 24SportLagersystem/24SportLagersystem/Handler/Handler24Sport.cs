using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24SportLagersystem.ViewModel;

namespace _24SportLagersystem.Handler
{
    class Handler24Sport
    {
        public ViewModel24Sport ViewModel24Sport { get; set; }

        public Handler24Sport(ViewModel24Sport viewModel24Sport)
        {
            ViewModel24Sport = viewModel24Sport;
        }
    }
}
