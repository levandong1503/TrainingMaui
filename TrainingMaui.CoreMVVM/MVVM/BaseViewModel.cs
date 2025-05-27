
using Serilog;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Data.Common;
using TrainingMaui.CoreMVVM.Navigation;
using TrainingMaui.Utils.Resources;

namespace TrainingMaui.CoreMVVM.MVVM;

public abstract partial class BaseViewModel : ObservableRecipient
{
    [ObservableProperty]
    protected bool isBusy;

    protected async Task ExecuteCommandAsync(string commandName, Func<Task> action)
    {
        if (IsBusy) return;

        try
        {
            Log.Information($"{AppResources.ActionInfoMessage}:{commandName}");
            IsBusy = true;
            await action();
        }
        catch (DbException ex1)
        {
            Log.Error(ex1, AppResources.ErrorMessage, ex1.StackTrace);
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.StackTrace);
        }
        finally
        {
            IsBusy = false;
        }
    }

    protected void ExecuteCommand(string commandName, Action action)
    {
        if (IsBusy) return;

        try
        {
            Log.Information($"{AppResources.ActionInfoMessage}:{commandName}");
            IsBusy = true;
            action();
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.StackTrace);
        }
        finally
        {
            IsBusy = false;
        }
    }

    protected IAppNavigator AppNavigator { get; }

    protected BaseViewModel(IAppNavigator appNavigator)
    {
        AppNavigator = appNavigator;
    }

    public virtual Task OnAppearingAsync()
    {
        System.Diagnostics.Debug.WriteLine($"{GetType().Name}.{nameof(OnAppearingAsync)}");

        return Task.CompletedTask;
    }

    public virtual Task OnDisappearingAsync()
    {
        System.Diagnostics.Debug.WriteLine($"{GetType().Name}.{nameof(OnDisappearingAsync)}");

        return Task.CompletedTask;
    }

    [RelayCommand]
    protected virtual Task BackAsync() => AppNavigator.GoBackAsync(data: GetType().FullName);
}
