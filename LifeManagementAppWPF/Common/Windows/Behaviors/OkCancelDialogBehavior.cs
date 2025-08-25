using LifeManagementAppWPF.Common.Windows.Interfaces;
using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace LifeManagementAppWPF.Common.Windows.Behaviors
{
    internal class OkCancelDialogBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += WindowLoaded;
            base.OnAttached();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            if (AssociatedObject?.DataContext is IOkWindow okWindowVM)
            {
                okWindowVM.OnOkEvent += OnOkExecute;
            }

            if (AssociatedObject?.DataContext is ICancelWindow cancelWindowVM)
            {
                cancelWindowVM.OnCancelEvent += OnCancelExecute;
            }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= WindowLoaded;

            if (AssociatedObject?.DataContext is IOkWindow okWindowVM)
            {
                okWindowVM.OnOkEvent -= OnOkExecute;
            }

            if (AssociatedObject?.DataContext is ICancelWindow cancelWindowVM)
            {
                cancelWindowVM.OnCancelEvent -= OnCancelExecute;
            }

            base.OnDetaching();
        }

        void OnOkExecute()
        {
            AssociatedObject.DialogResult = true;
            AssociatedObject.Close();
        }

        void OnCancelExecute()
        {
            AssociatedObject.DialogResult = false;
            AssociatedObject.Close();
        }
    }
}
