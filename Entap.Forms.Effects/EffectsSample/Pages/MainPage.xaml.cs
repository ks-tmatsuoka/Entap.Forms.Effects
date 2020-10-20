using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EffectsSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            datePickerStyleButton.Clicked += async (sender, e) => await PushPageAsync(new DatePickerStylePage());
            keyboardOverlappingButton.Clicked += async (sender, e) => await PushPageAsync(new KeyboardOverlappingPage());
            paddingButton.Clicked += async (sender, e) => await PushPageAsync(new PaddingPage());
        }

        Task PushPageAsync(Page page)
        {
            return App.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
