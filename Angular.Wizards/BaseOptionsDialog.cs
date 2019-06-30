using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Angular.Wizards
{
    public partial class BaseOptionsDialog : Form
    {
        public BaseOptionsDialog()
        {
            InitializeComponent();
        }

        public ICollection<string> ApiServices { get; set; } = new List<string>();
        public ICollection<string> SelectedApiServices { get; set; } = new List<string>();

        public ICollection<string> Services { get; set; } = new List<string>();
        public ICollection<string> SelectedServices { get; set; } = new List<string>();

        public ICollection<string> Models { get; set; } = new List<string>();
        public ICollection<string> SelectedModels { get; set; } = new List<string>();

        public ICollection<string> Dialogs { get; set; } = new List<string>();
        public ICollection<string> SelectedDialogs { get; set; } = new List<string>();

    }
}
