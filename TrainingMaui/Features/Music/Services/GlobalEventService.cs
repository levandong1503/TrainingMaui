using System.Reflection;

namespace TrainingMaui.Services
{
    // Singleton that raises a periodic "Tick" and supports both normal events and weak subscriptions
    public sealed class GlobalEventService
    {
        public static GlobalEventService Instance { get; } = new GlobalEventService();

        // normal event (strong references)
        public event EventHandler? Tick;

        // weak handlers: store only WeakReference to target + MethodInfo
        private readonly List<(WeakReference targetRef, MethodInfo method)> _weakHandlers = new();

        private Timer? _timer;

        private GlobalEventService()
        {
            // start a timer to raise Tick periodically
            _timer = new Timer(_ => RaiseTick(), null, 1000, 1000);
        }

        private void RaiseTick()
        {
            // raise normal event
            Tick?.Invoke(this, EventArgs.Empty);

            // raise weak handlers, and purge dead targets
            lock (_weakHandlers)
            {
                for (int i = _weakHandlers.Count - 1; i >= 0; i--)
                {
                    var (targetRef, method) = _weakHandlers[i];
                    var target = targetRef.Target;
                    if (target is null)
                    {
                        _weakHandlers.RemoveAt(i);
                        continue;
                    }

                    try
                    {
                        method.Invoke(target, new object[] { this, EventArgs.Empty });
                    }
                    catch
                    {
                        // swallowing exceptions for demo
                    }
                }
            }
        }

        // register weak subscription: only keep WeakReference to target
        public void WeakSubscribe(object target, MethodInfo method)
        {
            lock (_weakHandlers)
            {
                _weakHandlers.Add((new WeakReference(target), method));
            }
        }

        // helper to stop timer (not required by demo)
        public void Stop() => _timer?.Change(Timeout.Infinite, Timeout.Infinite);
    }
}