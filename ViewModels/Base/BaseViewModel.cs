using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Ingenium.Materiaalbeheer.ClientApp.ViewModels
{
    public partial class BaseViewModel : ObservableValidator, IDisposable
    {
        [ObservableProperty]
        [AlsoNotifyChangeFor(nameof(IsNotBusy))]
        private bool isBusy;

        public bool IsNotBusy => !IsBusy;

        [ObservableProperty]
        private bool canLoadMore;

        [ObservableProperty]
        private string? title = string.Empty;

        [ObservableProperty]
        private string? subtitle = string.Empty;

        [ObservableProperty]
        private string? icon = string.Empty;

        [ObservableProperty]
        private string? header = string.Empty;

        [ObservableProperty]
        private string? footer = string.Empty;

        [ObservableProperty]
        private bool isValid = true;

        [ObservableProperty]
        private List<string?> errors = new();

        public BaseViewModel()
        {
            ErrorsChanged += OnErrorsChanged;
        }

        public void Dispose()
        {
            ErrorsChanged -= OnErrorsChanged;
        }

        private void OnErrorsChanged(object? sender, DataErrorsChangedEventArgs e)
        {
            IsValid = !HasErrors;
        }

        public bool Validate()
        {
            Errors.Clear();
            ValidateAllProperties();
            Errors = GetErrors().Select(e => e.ErrorMessage).ToList();
            IsValid = !HasErrors;
            return IsValid;
        }
    }
}
