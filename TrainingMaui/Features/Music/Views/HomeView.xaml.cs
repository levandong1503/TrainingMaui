using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Diagnostics.Metrics;
using TrainingMaui.Features.Music.ViewModels;

namespace TrainingMaui.Features.Music.Views;

public partial class HomeView : ContentView
{
    CancellationTokenSource _cts = new CancellationTokenSource();
    private bool isRunning = false;
    private int counter = 1;
    public HomeView(HomeContentViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
    }

    private void RadButton_Clicked(object sender, EventArgs e)
    {
        if (isRunning)
        {
            _cts.Cancel();
            isRunning = false;
            return;
        }

        //while (true)
        //{
        //    Thread.Sleep(1000);
        //    // crash app
        //    MyButton.Text = counter.ToString();
        //    counter++;
        //}

        try
        {
            _cts.Dispose();
        }
        catch { /* ignore if already disposed */ }
        _cts = new CancellationTokenSource();
        var token = _cts.Token;

        isRunning = true;
        Task.Run(async () =>
        {
            while (!token.IsCancellationRequested)
            {
                //Thread.Sleep(1000);
                //// crash app
                //MyButton.Text = counter.ToString();
                //counter++;

                await Task.Delay(1000, token);
                // no crash app
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    MyButton.Text = counter.ToString();
                });
                counter++;
            }
        }, token);
    }
}