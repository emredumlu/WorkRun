using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using WorkRun.Client.BL;

namespace WorkRun.Wpf
{
    /// <summary>
    /// Interaction logic for PersonView.xaml
    /// </summary>
    public partial class PersonView : UserControl
    {
        PersonViewModel _vm;
        public PersonView()
        {
            InitializeComponent();
            SetVm();
            LayoutRoot.KeyDown += UIHelper.KeyDown;
            Loaded += PersonView_Loaded;
        }

        #region event
        private void PersonView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            SetFocus();

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _ = Save();
        }
        #endregion

        #region method
        private void SetFocus()
        {
            Dispatcher.BeginInvoke((Action)delegate
            {
                txtName.Focus();
            }, DispatcherPriority.Render);
        }
        private void SetVm()
        {
            _vm = new();
            DataContext = _vm;
        }
        private async Task Save()
        {
            var result = await _vm.Save();
            string message = string.Empty;
            if (result.IsOk)
            {
                message = "Kayıt Başarılı";
            }
            else
            {
                message = "Kayıt Başarılı Değil";
            }

            MessageBox.Show(message);
        }
        #endregion
    }
}
