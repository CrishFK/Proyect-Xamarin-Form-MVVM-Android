using System;
using System.Collections.Generic;
using System.Text;
using TheTrooper_MVVM_CrishFK.Model;
using Xamarin.Forms;

namespace TheTrooper_MVVM_CrishFK.ViewModel
{
    public class ViewTrooperViewModel : BindableObject
    {
        Color backColor, textColor;
        Trooper trooper;
        string name,id;
        public string Name { get => name; set => name = value; }
        public string Id { get => id; set => id = value; }
        public Color BackColor { get => backColor; set { backColor = value; OnPropertyChanged(); } }
        public Color TextColor { get => textColor; set { textColor = value; OnPropertyChanged(); } }

        public ViewTrooperViewModel(Trooper trooper)
        {
            this.trooper = trooper;
            Name = trooper.Name;
            Id = trooper.Id.ToString();
            cOnAppearingViewModel = new Command(OnAppearingViewModel);
        }

        public Command cOnAppearingViewModel;
        public  void OnAppearingViewModel()
        {
            if (trooper.Accuracy < 25)
            {
                TextColor = Color.White;
                BackColor = Color.Red;
            }
            else if (trooper.Accuracy < 75)
            {
                TextColor = Color.White;
                BackColor = Color.Yellow;
            }
            else
            {
                TextColor = Color.White;
                BackColor = Color.Blue;
            }
        }

        


    }
}