using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BloodBank
{
    /// <summary>
    /// Interaction logic for BB_ReqViewPage.xaml
    /// </summary>
    public partial class BB_ReqViewPage : Page
    {
        string id;
        public BB_ReqViewPage(string id)
        {
            InitializeComponent();
            this.id = id;
        }
    }
}
