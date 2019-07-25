using System;
using Xamarin.Forms;

namespace PrismSampleByXamarinForms.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void RollA_Clicked(object sender, EventArgs e)
        {
            this.ButtonSelectedRollB.BorderColor = Color.Gray;
            this.ButtonSelectedRollA.BorderColor = Color.FromHex("94C565");
        }

        private void RollB_Clicked(object sender, EventArgs e)
        {
            this.ButtonSelectedRollA.BorderColor = Color.Gray;
            this.ButtonSelectedRollB.BorderColor = Color.FromHex("94C565");
        }

        private void RePasswordButton_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new SecondPage());
        }
    }
}
