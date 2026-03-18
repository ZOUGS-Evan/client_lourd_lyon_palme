using System.Windows.Forms;
using LyonPalme.DataAccess;

namespace LyonPalme.Forms
{
    public partial class MaterielDetailsForm : Form
    {
        private readonly MaterielDTO _dto;

        public MaterielDetailsForm(MaterielDTO dto)
        {
            InitializeComponent();
            _dto = dto;
        }
    }
}