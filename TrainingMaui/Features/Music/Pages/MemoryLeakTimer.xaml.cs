namespace TrainingMaui.Features.Music.Pages;

public partial class MemoryLeakTimer : ContentPage
{
    IDispatcherTimer timer;
    public MemoryLeakTimer()
    {
        InitializeComponent();
        // Timer định kỳ, callback giữ reference tới this (closure)
        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(1000);
        timer.Tick += RunTimer;
        timer.Start();
    }



    private void RunTimer(object s, EventArgs e)
    {
        // đây vẫn có thể chạy sau khi Page đã đóng => leak / lỗi UI
        MainThread.BeginInvokeOnMainThread(() => LabelCounter.Text = DateTime.Now.ToString());
    }
}