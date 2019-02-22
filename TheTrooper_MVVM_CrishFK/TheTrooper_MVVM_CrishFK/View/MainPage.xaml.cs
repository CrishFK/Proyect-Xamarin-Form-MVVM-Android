using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTrooper_MVVM_CrishFK.Model;
using TheTrooper_MVVM_CrishFK.View;
using TheTrooper_MVVM_CrishFK.ViewModel;
using Xamarin.Forms;

namespace TheTrooper_MVVM_CrishFK
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (this.BindingContext as MainPageViewModel).cOnAppearingViewModel.Execute(null);
        }

        private async void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ViewTrooper(new ViewTrooperViewModel(e.SelectedItem as Trooper)));
        }
    }
}
