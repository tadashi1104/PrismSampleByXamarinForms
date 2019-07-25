using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using PrismSampleByXamarinForms.Consts;
using PrismSampleByXamarinForms.Models;
using PrismSampleByXamarinForms.Services;

namespace PrismSampleByXamarinForms.ViewModels
{
    public class _LoginViewModel : Helpers.Observable
    {
        public Views._Login View { get; private set; } = null;

        private CommonApiService _service = new CommonApiService();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public _LoginViewModel()
        {

        }


        public async void Initialize(Views._Login page)
        {
            View = page;
            Email = await SecureStorage.GetAsync("email");
            Password = await SecureStorage.GetAsync("password");
        }

        #region NewEmail
        public string NewEmail
        {
            get => this.NewEmail_;
            set => Set(ref this.NewEmail_, value, nameof(NewEmail));
        }
        private string NewEmail_;
        #endregion NewEmail


        #region Email
        public string Email
        {
            get => this.Email_;
            set => Set(ref this.Email_, value, nameof(Email));
        }
        private string Email_;
        #endregion Email


        #region Password
        public string Password
        {
            get => this.Password_;
            set => Set(ref this.Password_, value, nameof(Password));
        }
        private string Password_;
        #endregion Password

        private int UserCategory { get; set; }

        #region RollA選択
        private Helpers.RelayCommand SelectedRollACommand_;
        public Helpers.RelayCommand SelectedRollACommand
        {
            get { return SelectedRollACommand_ = SelectedRollACommand_ ?? new Helpers.RelayCommand(SelectedRollA); }
        }

        private void SelectedRollA()
        {
            UserCategory = 1;
        }
        #endregion RollA選択

        #region RollB選択
        private Helpers.RelayCommand SelectedRollBCommand_;
        public Helpers.RelayCommand SelectedRollBCommand
        {
            get { return SelectedRollBCommand_ = SelectedRollBCommand_ ?? new Helpers.RelayCommand(SelectedRollB); }
        }

        private void SelectedRollB()
        {
            UserCategory = 2;
        }
        #endregion RollB選択

        #region 新規会員登録
        private Helpers.RelayCommand CreateUserCommand_;
        public Helpers.RelayCommand CreateUserCommand
        {
            get { return CreateUserCommand_ = CreateUserCommand_ ?? new Helpers.RelayCommand(CreateUser); }
        }

        private async void CreateUser()
        {
            // API呼び出し
            try
            {
                //var response = await _service.Send_API_001(NewEmail, UserCategory);

                //if (response.result)
                //{
                //    MessagingCenter.Send(this, "DisplayAlert", new AlertParameter()
                //    {
                //        Title = "Info.",
                //        Message = $"初期パスワードのメールが送信されます。{Environment.NewLine}会員ID:{response.returnBody.Id}",
                //        Accept = "OK",
                //        Cancel = null
                //    });
                //}
                //else
                //{
                //    MessagingCenter.Send(this, "DisplayAlert", new AlertParameter()
                //    {
                //        Title = "Error",
                //        Message = $"{response.message}",
                //        Accept = "OK",
                //        Cancel = null
                //    });
                //}

                MessagingCenter.Send(this, "DisplayAlert", new AlertParameter()
                {
                    Title = "Info.",
                    Message = $"初期パスワードのメールが送信されます。{Environment.NewLine}会員ID:{123456789}",
                    Accept = "OK",
                    Cancel = null
                });

            }
            catch (Exception ex)
            {
                MessagingCenter.Send(this, "DisplayAlert", new AlertParameter()
                {
                    Title = "Error",
                    Message = ex.Message,
                    Accept = "OK",
                    Cancel = null
                });
            }

        }
        #endregion 新規会員登録

        #region ログイン
        private Helpers.RelayCommand LoginCommand_;
        public Helpers.RelayCommand LoginCommand
        {
            get { return LoginCommand_ = LoginCommand_ ?? new Helpers.RelayCommand(Login); }
        }

        private async void Login()
        {
            // API呼び出し
            try
            {
                //// ログイン
                //AppInfoStore.token = await new Helpers.ApiSend().GetToken(Email, Password);
                //// Registoration
                //// TODO: Registrationの登録を追加。Fire Baseへのアプリ登録が必要みたい。
                //// 情報取得
                //AppInfoStore.UserInfo = await GetUserInfo();
                //if (AppInfoStore.UserInfo == null)
                //{
                //    return;
                //}

                AppInfoStore.token = "";
                var info = new ApiResponseModels.Response_API_001 { Id = "ABCD123", Status = 0, Type = 1 };
                AppInfoStore.UserInfo = info;

                MessagingCenter.Send(this, "DisplayAlert", new AlertParameter()

                {
                    Title = "Confirm",
                    Message = "ログインを維持しますか？",
                    Accept = "Yes",
                    Cancel = "No",
                    Action = async result =>
                    {
                        if (result)
                        {
                            await SecureStorage.SetAsync("email", Email);
                            await SecureStorage.SetAsync("password", Password);
                            await SecureStorage.SetAsync("token", AppInfoStore.token);
                        }
                    }
                });

                MessagingCenter.Send(this, "GoNextPage", new UserType
                {
                    userCategory = (CommonEnums.UserCategoryType)AppInfoStore.UserInfo.Type
                    ,
                    userStatus = (CommonEnums.UserStatusType)AppInfoStore.UserInfo.Status
                });

            }
            catch (Exception ex)
            {
                MessagingCenter.Send(this, "DisplayAlert", new AlertParameter()
                {
                    Title = "Error",
                    Message = ex.Message,
                    Accept = "OK",
                    Cancel = null
                });
            }

        }
        #endregion 新規会員登録


        /// <summary>
        /// 会員情報取得
        /// </summary>
        private async Task<ApiResponseModels.Response_API_001> GetUserInfo()
        {
            var response = await _service.Send_API_001(AppInfoStore.token, 1);

            if (response.result)
            {
                return response.returnBody;
            }
            else
            {
                MessagingCenter.Send(this, "DisplayAlert", new AlertParameter()
                {
                    Title = "Error",
                    Message = $"{response.message}",
                    Accept = "OK",
                    Cancel = null
                });
                return null;
            }

        }
    }
}
