using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WorkRun.Wpf
{
    /// <summary>
    /// Interaction logic for PersonView.xaml
    /// </summary>
    public partial class PersonView : UserControl
    {
        public PersonView()
        {
            InitializeComponent();
            LayoutRoot.KeyDown += UIHelper.KeyDown;
            Loaded += PersonView_Loaded;
        }

        #region event
        private void PersonView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            SetFocus();
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
        #endregion
    }
}
