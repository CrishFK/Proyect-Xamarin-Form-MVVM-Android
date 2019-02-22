 using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using TheTrooper_MVVM_CrishFK.Model;
using Newtonsoft.Json;
using System.Linq;
using Xamarin.Forms;

namespace TheTrooper_MVVM_CrishFK.ViewModel
{
    public class MainPageViewModel : BindableObject
    {
        List<Trooper> listaTrooper = new List<Trooper>();
        private List<Trooper> listLow = new List<Trooper>();
        private List<Trooper> listMid = new List<Trooper>();
        private List<Trooper> listHigh = new List<Trooper>();

        public List<Trooper> ListLow { get => listLow; set { listLow = value; OnPropertyChanged(); }
}
        public List<Trooper> ListMid { get => listMid; set { listMid = value; OnPropertyChanged(); }
}
        public List<Trooper> ListHigh { get => listHigh; set { listHigh = value; OnPropertyChanged(); } }

        public MainPageViewModel() 
        {
            cOnAppearingViewModel = new Command(OnAppearingViewModel);
        }

        public Command cOnAppearingViewModel;
        public void OnAppearingViewModel()
        {
            HttpClient httpClient = new HttpClient();
            string trooperJSON = httpClient.GetStringAsync("http://www.mocky.io/v2/5c5e8e97320000bd0c40b3b4").Result;
            listaTrooper = JsonConvert.DeserializeObject<List<Trooper>>(trooperJSON);
            ListLow = listaTrooper.Where(x => x.Accuracy < 26).OrderBy(x => x.Accuracy).ToList();
            ListMid = listaTrooper.Where(x => x.Accuracy > 24 && x.Accuracy < 76).OrderBy(x => x.Accuracy).ToList();
            ListHigh = listaTrooper.Where(x => x.Accuracy > 75).OrderBy(x => x.Accuracy).ToList();
        }      

    }
}
