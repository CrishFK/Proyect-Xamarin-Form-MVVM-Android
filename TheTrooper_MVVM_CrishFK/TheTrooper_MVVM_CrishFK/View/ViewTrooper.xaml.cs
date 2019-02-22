using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTrooper_MVVM_CrishFK.Model;
using TheTrooper_MVVM_CrishFK.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheTrooper_MVVM_CrishFK.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewTrooper : ContentPage
	{
		public ViewTrooper (ViewTrooperViewModel ViewTrooperViewModel)
		{
			InitializeComponent ();
            this.BindingContext = ViewTrooperViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            (this.BindingContext as ViewTrooperViewModel).cOnAppearingViewModel.Execute(null);
        }


        private void btSend_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("", (this.BindingContext as ViewTrooperViewModel).Name + " road to mission", "", "OK");
        }
    }
}