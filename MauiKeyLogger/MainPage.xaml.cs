#if ANDROID
using Android.Views;
#endif

namespace MauiKeyLogger;

public partial class MainPage : ContentPage, IOnPageKeyDown
{

    public MainPage()
    {
        InitializeComponent();
    }

    private static int keyNumber = 0;
#if ANDROID

    public bool OnPageKeyDown(Keycode keyCode, KeyEvent e)
    {
        if (LogEditor.Text == null) LogEditor.Text = string.Empty;
        var text = $"KeyCode {keyCode}";

        text += $" {e.ScanCode} / {e.Number} / RC: {e.RepeatCount} / Src: {e.Source} / UC: {e.UnicodeChar} / MS: {e.MetaState} / Mods: {e.Modifiers}";
        var lastKeyLabelText = $"Key down ({++keyNumber}) : {keyCode}";
        lastKeyLabelText += $" {e.ScanCode} / {e.Number}";

        LogEditor.Text += text;
        LastKeyLabel.Text = lastKeyLabelText;


        return true;
    }
#endif

    private async void OnCopyLogBtnClicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(LogEditor.Text);
        CopyLogBtn.Text = "Copied...";
        await Task.Delay(1000);
        CopyLogBtn.Text = "Copy Log";


    }
}
