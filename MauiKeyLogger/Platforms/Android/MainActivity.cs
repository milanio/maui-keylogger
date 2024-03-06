using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Android.Views;

namespace MauiKeyLogger
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        public override bool OnKeyDown(Keycode keyCode, KeyEvent? e)
        {

            Log.Debug("MauiLogger", $"OnKeyDown - {keyCode} - {e?.ScanCode}");
            if (e != null)
            {
                try
                {
                    if (AppShell.Current.CurrentPage is IOnPageKeyDown x)
                    {
                        bool handled = x.OnPageKeyDown(keyCode, e);

                        if (handled) return true;
                        else return base.OnKeyDown(keyCode, e);
                    }
                }
                catch (Exception exc)
                {
                    Log.Error("MauiLogger", $"Unhandled exception : OnKeyDown - {keyCode} - {e?.ScanCode}. Exception: {exc} ");
                }

            }
            return base.OnKeyDown(keyCode, e);

        }
    }
}
