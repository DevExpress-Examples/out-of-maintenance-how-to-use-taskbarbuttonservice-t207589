using System.Windows;
namespace DXSampleTaskbarButtonService {
    public partial class App : Application {
        private void OnAppStartup_UpdateThemeName(object sender, StartupEventArgs e) {
            DevExpress.Xpf.Core.ApplicationThemeHelper.UpdateApplicationThemeName();
        }
    }
}
