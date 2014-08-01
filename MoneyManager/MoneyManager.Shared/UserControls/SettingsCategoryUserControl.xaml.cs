﻿using MoneyManager.Models;
using MoneyManager.ViewModels;
using MoneyManager.ViewModels.Views;
using MoneyManager.Views;
using MoneyTracker.Src;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

namespace MoneyManager.UserControls
{
    public sealed partial class SettingsCategoryUserControl
    {
        public SettingsCategoryUserControl()
        {
            InitializeComponent();
        }

        public SettingsCategoryViewModel SettingsCategoryViewModel
        {
            get { return new ViewModelLocator().SettingsCategory; }
        }

        private async void CategoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryList.SelectedItem != null)
            {
                var category = CategoryList.SelectedItem as Category;
#if WINDOWS_PHONE_APP
                await new CategoryDialog(category).ShowAsync();
#endif
                CategoryList.SelectedItem = null;
            }
        }

        private async void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)sender;
            var category = element.DataContext as Category;
            if (category == null) return;

            var dialog = new MessageDialog(Utilities.GetTranslation("DeleteQuestionMessage"),
                Utilities.GetTranslation("DeleteCategoryQuestionMessage"));
            dialog.Commands.Add(new UICommand(Utilities.GetTranslation("YesLabel")));
            dialog.Commands.Add(new UICommand(Utilities.GetTranslation("NoLabel")));
            dialog.DefaultCommandIndex = 1;

            var result = await dialog.ShowAsync();

            if (result.Label == Utilities.GetTranslation("YesLabel"))
            {
                SettingsCategoryViewModel.CategoryViewModel.Delete(category);
            }
        }

        private void CategoryList_Holding(object sender, HoldingRoutedEventArgs e)
        {
            var senderElement = sender as FrameworkElement;
            var flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);

            flyoutBase.ShowAt(senderElement);
        }
    }
}