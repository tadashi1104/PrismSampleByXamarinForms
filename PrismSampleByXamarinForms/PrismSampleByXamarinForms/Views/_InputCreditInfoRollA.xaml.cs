using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PrismSampleByXamarinForms.Models;
using PrismSampleByXamarinForms.ViewModels;

namespace PrismSampleByXamarinForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class _InputCreditInfoRollA : ContentPage
    {
        public ViewModels._InputCreditInfoRollAViewModel ViewModel { get; private set; } = new ViewModels._InputCreditInfoRollAViewModel();

        public _InputCreditInfoRollA()
        {
            InitializeComponent();
            ViewModel.Initialize(this);
            this.BindingContext = ViewModel;
            InitPage();
        }

        private void InputCreditInfoRollA_Appearing(object sender, EventArgs e)
        {
            MessagingCenter.Subscribe<_InputCreditInfoRollAViewModel, AlertParameter>(this, "DisplayAlert", DisplayAlert);
            MessagingCenter.Subscribe<_InputCreditInfoRollAViewModel, UserType>(this, "GoNextPage", GoNextPage);
        }

        private void InputCreditInfoRollA_Disappearing(object sender, EventArgs e)
        {
            MessagingCenter.Unsubscribe<_InputCreditInfoRollAViewModel, AlertParameter>(this, "DisplayAlert");
            MessagingCenter.Unsubscribe<_InputCreditInfoRollAViewModel, UserType>(this, "GoNextPage");
        }

        private async void DisplayAlert<T>(T sender, AlertParameter arg)
        {
            var isAccept = await DisplayAlert(arg.Title, arg.Message, arg.Accept, arg.Cancel);
            arg.Action?.Invoke(isAccept);
        }

        private async void GoNextPage<T>(T sender, UserType arg)
        {
            //this.Navigation.PushAsync(new SecondPage());
        }

        private void RePasswordButton_Clicked(object sender, EventArgs e)
        {
            //this.Navigation.PushAsync(new SecondPage());
        }

        private void InitPage()
        {
            #region 都道府県設定
            this.PikerPrefectures.Items.Add("北海道");
            this.PikerPrefectures.Items.Add("青森県");
            this.PikerPrefectures.Items.Add("岩手県");
            this.PikerPrefectures.Items.Add("宮城県");
            this.PikerPrefectures.Items.Add("秋田県");
            this.PikerPrefectures.Items.Add("山形県");
            this.PikerPrefectures.Items.Add("福島県");
            this.PikerPrefectures.Items.Add("茨城県");
            this.PikerPrefectures.Items.Add("栃木県");
            this.PikerPrefectures.Items.Add("群馬県");
            this.PikerPrefectures.Items.Add("埼玉県");
            this.PikerPrefectures.Items.Add("千葉県");
            this.PikerPrefectures.Items.Add("東京都");
            this.PikerPrefectures.Items.Add("神奈川県");
            this.PikerPrefectures.Items.Add("新潟県");
            this.PikerPrefectures.Items.Add("富山県");
            this.PikerPrefectures.Items.Add("石川県");
            this.PikerPrefectures.Items.Add("福井県");
            this.PikerPrefectures.Items.Add("山梨県");
            this.PikerPrefectures.Items.Add("長野県");
            this.PikerPrefectures.Items.Add("岐阜県");
            this.PikerPrefectures.Items.Add("静岡県");
            this.PikerPrefectures.Items.Add("愛知県");
            this.PikerPrefectures.Items.Add("三重県");
            this.PikerPrefectures.Items.Add("滋賀県");
            this.PikerPrefectures.Items.Add("京都府");
            this.PikerPrefectures.Items.Add("大阪府");
            this.PikerPrefectures.Items.Add("兵庫県");
            this.PikerPrefectures.Items.Add("奈良県");
            this.PikerPrefectures.Items.Add("和歌山県");
            this.PikerPrefectures.Items.Add("鳥取県");
            this.PikerPrefectures.Items.Add("島根県");
            this.PikerPrefectures.Items.Add("岡山県");
            this.PikerPrefectures.Items.Add("広島県");
            this.PikerPrefectures.Items.Add("山口県");
            this.PikerPrefectures.Items.Add("徳島県");
            this.PikerPrefectures.Items.Add("香川県");
            this.PikerPrefectures.Items.Add("愛媛県");
            this.PikerPrefectures.Items.Add("高知県");
            this.PikerPrefectures.Items.Add("福岡県");
            this.PikerPrefectures.Items.Add("佐賀県");
            this.PikerPrefectures.Items.Add("長崎県");
            this.PikerPrefectures.Items.Add("熊本県");
            this.PikerPrefectures.Items.Add("大分県");
            this.PikerPrefectures.Items.Add("宮崎県");
            this.PikerPrefectures.Items.Add("鹿児島県");
            this.PikerPrefectures.Items.Add("沖縄県");
            this.PikerPrefectures.SelectedIndex = 0;
            #endregion 都道府県設定


        }
    }
}