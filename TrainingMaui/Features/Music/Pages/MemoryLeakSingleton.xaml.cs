using System.Diagnostics;
using System.Reflection;
using TrainingMaui.Services;

namespace TrainingMaui.Features.Music.Pages;

public partial class MemoryLeakSingleton : ContentPage
{
    // strong reference to subscriber (simulates ViewModel/Page subscribing then losing strong ref)
    private LeakSubscriber? _subscriberStrong;

    // weak reference for testing whether object was collected
    private WeakReference? _weakRef;

    // keep last weak-subscribed object's weakref for check
    private WeakReference? _weakSubscribedRef;

    public MemoryLeakSingleton()
    {
        InitializeComponent();
    }

    // create subscriber and subscribe via normal (strong) event
    private void CreateSubscriber_Clicked(object sender, EventArgs e)
    {
        _subscriberStrong = new LeakSubscriber("S-strong");
        // subscribe to strong event -> singleton now holds reference to subscriber via delegate
        GlobalEventService.Instance.Tick += _subscriberStrong.HandleTick;

        // store a WeakReference for later GC check
        _weakRef = new WeakReference(_subscriberStrong);
        StatusLabel.Text = "Created subscriber and subscribed (strong).";
        DetailsLabel.Text = $"Weak.IsAlive = {_weakRef.IsAlive}";
    }

    // release the page's strong reference (simulates navigating away and losing strong refs)
    private void ReleaseStrongRef_Clicked(object sender, EventArgs e)
    {
        _subscriberStrong = null;
        StatusLabel.Text = "Released local strong reference (singleton event still holds reference).";
    }

    // force GC and check weakref
    private async void ForceGc_Clicked(object sender, EventArgs e)
    {
        await Task.Delay(50); // let any pending work complete
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        bool alive = _weakRef?.IsAlive ?? false;
        StatusLabel.Text = $"After GC: Weak.IsAlive = {alive} (true = leaked)";
        DetailsLabel.Text = alive
            ? "Object still alive because singleton holds a strong delegate reference."
            : "Object collected.";
    }

    // unsubscribe explicitly from singleton (fix #1)
    private void Unsubscribe_Clicked(object sender, EventArgs e)
    {
        if (_weakRef is null)
        {
            StatusLabel.Text = "No subscriber to unsubscribe.";
            return;
        }

        // We don't have the strong reference anymore possibly; in real apps keep reference to unsubscribe.
        // For demo, try to find target from weakref and unsubscribe if alive:
        var target = _weakRef.Target as LeakSubscriber;
        if (target != null)
        {
            GlobalEventService.Instance.Tick -= target.HandleTick;
            StatusLabel.Text = "Unsubscribed target from strong event (fix #1).";
        }
        else
        {
            StatusLabel.Text = "Target already null when attempting unsubscribe.";
        }
    }

    // create subscriber and weak-subscribe (fix #2)
    private void CreateWeakSubscriber_Clicked(object sender, EventArgs e)
    {
        var sub = new LeakSubscriber("S-weak");
        // weak subscribe: only store WeakReference inside the GlobalEventService
        var method = typeof(LeakSubscriber).GetMethod(nameof(LeakSubscriber.HandleTick), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (method != null)
        {
            GlobalEventService.Instance.WeakSubscribe(sub, method);
        }

        // simulate losing strong reference (we won't keep `sub` around)
        _weakSubscribedRef = new WeakReference(sub);
        StatusLabel.Text = "Created subscriber with weak-subscribe (singleton holds only weak ref).";

        // drop strong reference immediately -> allow GC to collect later
        sub = null;
    }
}

// simple subscriber class (simulating ViewModel/Page instance)
public class LeakSubscriber
{
    private readonly string _name;
    private int _count;

    public LeakSubscriber(string name)
    {
        _name = name;
    }

    public void HandleTick(object? sender, EventArgs e)
    {
        // do trivial work on tick
        _count++;
        // avoid touching UI here; this simulates background handler held by the subscriber.
        Debug.WriteLine($"{_name} tick {_count}");
    }

    ~LeakSubscriber()
    {
        Debug.WriteLine($"{_name} finalized");
    }
}