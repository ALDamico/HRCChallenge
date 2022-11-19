using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCChallenge.ViewModels
{
    internal class MatrixSizeViewModel : ViewModelBase
    {
        private int side;
        private string caption;

        public int Side
        {
            get => side;
            set
            {
                side = value;
                OnPropertyChanged(nameof(Side));
            }
        }

        public string Caption
        {
            get => caption;
            set
            {
                caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
    }
}
