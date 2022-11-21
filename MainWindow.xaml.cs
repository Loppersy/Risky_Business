namespace Risky_Business
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    public MainWindow()
    {
      InitializeComponent();
            CallGateway.Initialize();
            // create the framework for calls
    }
  }
}
