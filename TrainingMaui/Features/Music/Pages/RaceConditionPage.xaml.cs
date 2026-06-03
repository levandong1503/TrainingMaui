using TrainingMaui.CoreMVVM.MVVM;

namespace TrainingMaui.Features.Music.Pages;

public partial class RaceConditionPage : BasePage
{
    // configuration for the test
    private const int TaskCount = 100;
    private const int IncrementsPerTask = 1000;

    public RaceConditionPage()
    {
        InitializeComponent();
    }

    // Unsafe: increments without any synchronization -> race condition
    private async void RunUnsafe_Clicked(object sender, EventArgs e)
    {
        DisableButtons();
        InfoLabel.Text = "Running unsafe test...";
        int shared = 0;
        var tasks = new Task[TaskCount];
        for (int i = 0; i < TaskCount; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                for (int j = 0; j < IncrementsPerTask; j++)
                {
                    // race: read-modify-write not atomic
                    shared++; // shared = shared + 1;
                }
            });
        }

        await Task.WhenAll(tasks);
        var expected = TaskCount * IncrementsPerTask;
        MainThread.BeginInvokeOnMainThread(() =>
        {
            ExpectedLabel.Text = $"Expected: {expected}";
            ActualLabel.Text = $"Actual (unsafe): {shared}";
            InfoLabel.Text = "Unsafe finished (you will likely see Actual < Expected).";
            EnableButtons();
        });
    }

    // Fix #1: lock
    private readonly object _lockObj = new object();

    private async void RunLock_Clicked(object sender, EventArgs e)
    {
        DisableButtons();
        InfoLabel.Text = "Running lock test...";
        int shared = 0;
        var tasks = new Task[TaskCount];
        for (int i = 0; i < TaskCount; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                for (int j = 0; j < IncrementsPerTask; j++)
                {
                    lock (_lockObj)
                    {
                        shared++;
                    }
                }
            });
        }

        await Task.WhenAll(tasks);
        var expected = TaskCount * IncrementsPerTask;
        MainThread.BeginInvokeOnMainThread(() =>
        {
            ExpectedLabel.Text = $"Expected: {expected}";
            ActualLabel.Text = $"Actual (lock): {shared}";
            InfoLabel.Text = "lock finished (Actual should equal Expected).";
            EnableButtons();
        });
    }

    // Fix #2: Interlocked (fast, lock-free for numeric ops)
    private async void RunInterlocked_Clicked(object sender, EventArgs e)
    {
        DisableButtons();
        InfoLabel.Text = "Running Interlocked test...";
        int shared = 0;
        var tasks = new Task[TaskCount];
        for (int i = 0; i < TaskCount; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                for (int j = 0; j < IncrementsPerTask; j++)
                {
                    Interlocked.Increment(ref shared);
                }
            });
        }

        await Task.WhenAll(tasks);
        var expected = TaskCount * IncrementsPerTask;
        MainThread.BeginInvokeOnMainThread(() =>
        {
            ExpectedLabel.Text = $"Expected: {expected}";
            ActualLabel.Text = $"Actual (Interlocked): {shared}";
            InfoLabel.Text = "Interlocked finished (Actual should equal Expected).";
            EnableButtons();
        });
    }

    // Fix #3: SemaphoreSlim (async-friendly)
    private async void RunSemaphore_Clicked(object sender, EventArgs e)
    {
        DisableButtons();
        InfoLabel.Text = "Running SemaphoreSlim test...";
        int shared = 0;
        var sem = new SemaphoreSlim(1, 1);
        var tasks = new Task[TaskCount];
        for (int i = 0; i < TaskCount; i++)
        {
            tasks[i] = Task.Run(async () =>
            {
                for (int j = 0; j < IncrementsPerTask; j++)
                {
                    await sem.WaitAsync();
                    try
                    {
                        shared++;
                    }
                    finally
                    {
                        sem.Release();
                    }
                }
            });
        }

        await Task.WhenAll(tasks);
        var expected = TaskCount * IncrementsPerTask;
        MainThread.BeginInvokeOnMainThread(() =>
        {
            ExpectedLabel.Text = $"Expected: {expected}";
            ActualLabel.Text = $"Actual (SemaphoreSlim): {shared}";
            InfoLabel.Text = "SemaphoreSlim finished (Actual should equal Expected).";
            EnableButtons();
        });
    }

    private void DisableButtons()
    {
        BtnUnsafe.IsEnabled = false;
        BtnLock.IsEnabled = false;
        BtnInterlocked.IsEnabled = false;
        BtnSemaphore.IsEnabled = false;
    }

    private void EnableButtons()
    {
        BtnUnsafe.IsEnabled = true;
        BtnLock.IsEnabled = true;
        BtnInterlocked.IsEnabled = true;
        BtnSemaphore.IsEnabled = true;
    }
}