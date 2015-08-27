using Android.OS;
using Android.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.FullFragging.Fragments;
using MoneyManager.Core.ViewModels;

namespace MoneyManager.Droid.Fragments
{
    public class AccountListFragment : MvxFragment
    {
        public new AccountListViewModel ViewModel
        {
            get { return (AccountListViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.AccountListLayout, null);
        }
    }
}