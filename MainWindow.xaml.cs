using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace Timer2
{
    public partial class MainWindow : Window
    {
        #region Objects
        public ViewModel viewModel { get; set; }
        public DayTimer dayTimer = new DayTimer();
        public MyTimer myTimer = new MyTimer();
        #endregion

        #region Properties
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            viewModel = new ViewModel(this);
            this.DataContext = viewModel;
            viewModel.textRange = new TextRange(RTB.Document.ContentStart, RTB.Document.ContentEnd);
            viewModel.MaximizeIt = new Command((param) => ReshapeWindow(MainWindowFunctions.Maximize), () => viewModel.CanComm());
            viewModel.NormalizeIt = new Command((param) => ReshapeWindow(MainWindowFunctions.Normalize), () => viewModel.CanComm());
            viewModel.MinimizeIt = new Command((param) => ReshapeWindow(MainWindowFunctions.Minimize), () => viewModel.CanComm());
            viewModel.CloseIt = new Command((param) => ReshapeWindow(MainWindowFunctions.CloseWin), () => viewModel.CanComm());
            this.MouseDown += delegate { DragMove(); };
            this.Top = viewModel.TopValue;
            this.Left = viewModel.LeftValue;
            viewModel.DayTimerControl("m");
            viewModel.StartDateTime = DateTime.Now.ToString();
            viewModel.StartC();
        }
        private void WindowContentRendered(object sender, EventArgs e)
        {
            ComboAlarms.ItemsSource = viewModel.RingTones;
            ComboAlarms.SelectedItem = viewModel.SettingsList[4];
            Process[] processes = Process.GetProcessesByName("Timer2");
            if (processes.Length>1)
            {
                viewModel.AdditionalSettingsLists(processes.Length);
            }
        }
        private void TextBoxDoubleClick(object sender, EventArgs e)
        {
            if (viewModel.Timer==true)
            {
                TextBox tb = sender as TextBox;
                viewModel.TimerControl("Sb_" + tb.Text);
            }
        }
        private void MouseLeftDown(object sender, MouseEventArgs e)
        {
            if (viewModel.SettingsVis == Visibility.Visible)
            {
                viewModel.SettingsVis = Visibility.Hidden;
            }
            if (viewModel.SettingsListVis == Visibility.Visible)
            {
                viewModel.SettingsListVis = Visibility.Hidden;
            }
        }
        private void ReshapeWindow(MainWindowFunctions mode)
        {
            switch (mode)
            {
                case MainWindowFunctions.Maximize:
                    this.WindowState = WindowState.Maximized;
                    viewModel.Visible = mode;
                    break;
                case MainWindowFunctions.Normalize:
                    this.WindowState = WindowState.Normal;
                    viewModel.Visible = mode;
                    break;
                case MainWindowFunctions.Minimize:
                    this.WindowState = WindowState.Minimized;
                    break;
                case MainWindowFunctions.CloseWin:
                    System.Windows.Application.Current.Shutdown();
                    break;
                default:
                    throw new NotImplementedException(string.Format($"{mode.ToString()} not implemented"));
            }
        }
        public async Task WindowLocationStart()
        {
            await Task.Delay(2000);
            this.Top = viewModel.TopValue;
            this.Left = viewModel.LeftValue;
        }
    }
}
