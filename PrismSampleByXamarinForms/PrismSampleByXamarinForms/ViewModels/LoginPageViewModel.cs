using Prism.Commands;
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PrismSampleByXamarinForms.Consts;
using PrismSampleByXamarinForms.Services;
using Prism.Services;
using PrismSampleByXamarinForms.Models;
using Xamarin.Essentials;
using Prism.Navigation;

namespace PrismSampleByXamarinForms.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        #region DIで渡されるサービスクラス
        /// <summary>
        /// LoginPage Service
        /// </summary>
        private readonly ILoginPageService _service;
        /// <summary>
        /// Dialog Service
        /// </summary>
        private readonly IPageDialogService _pageDialogService;
        /// <summary>
        /// 画面遷移 Service
        /// </summary>
        private readonly INavigationService _navigationService;
        #endregion DIで渡されるサービスクラス
        
        #region 新規登録関連
        /// <summary>
        /// New Email
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public ReactiveProperty<string> NewEmail { get; }
        /// <summary>
        /// RollA ボタン
        /// </summary>
        public ReactiveCommand SelectedRollACommand { get; set; } = new ReactiveCommand();
        /// <summary>
        /// RollB ボタン
        /// </summary>
        public ReactiveCommand SelectedRollBCommand { get; set; } = new ReactiveCommand();
        /// <summary>
        /// User category
        /// </summary>
        [Required]
        [Range((double)CommonEnums.UserCategoryType.UserRollA
            , (double)CommonEnums.UserCategoryType.UserRollB
            , ErrorMessage = "Select RollA or RollB.")]
        private ReactiveProperty<CommonEnums.UserCategoryType> UserCategory { get; set; }
        /// <summary>
        /// 新規登録ボタン
        /// </summary>
        public ReactiveCommand CreateUserCommand { get; set; } = new ReactiveCommand();
        #endregion 新規登録関連


        #region ログイン関連
        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public ReactiveProperty<string> Email { get; }
        /// <summary>
        /// パスワード
        /// </summary>
        [Required(ErrorMessage = "Pasword is required.")]
        public ReactiveProperty<string> Password { get; }
        /// <summary>
        /// ログインボタン
        /// </summary>
        public ReactiveCommand LoginCommand { get; set; } = new ReactiveCommand();
        #endregion ログイン関連

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="service"></param>
        /// <param name="pageDialogService"></param>
        /// <param name="navigationService"></param>
        public LoginPageViewModel(ILoginPageService service, IPageDialogService pageDialogService, INavigationService navigationService)
        {
            _service = service;
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;

            // バリデーションチェック有効化
            NewEmail = new ReactiveProperty<string>().SetValidateAttribute(() => NewEmail);
            UserCategory = new ReactiveProperty<CommonEnums.UserCategoryType>().SetValidateAttribute(() => UserCategory);
            Email = new ReactiveProperty<string>().SetValidateAttribute(() => Email);
            Password = new ReactiveProperty<string>().SetValidateAttribute(() => Password);

            // ボタンの監視登録
            SelectedRollACommand.Subscribe(_ => { UserCategory.Value = CommonEnums.UserCategoryType.UserRollA; });
            SelectedRollBCommand.Subscribe(_ => { UserCategory.Value = CommonEnums.UserCategoryType.UserRollB; });

            CreateUserCommand.Subscribe(_ => 
            {
                // 新規登録
                var result = _service.CreateUser(NewEmail, UserCategory);
                AfterProcForCreateUser(result.serviceResult, result.id);
            });

            LoginCommand.Subscribe(_ =>
            {
                // ログイン
                var result = _service.Login(Email, Password);
                AfterProcForLogin(result);
            });
            
            // 初期処理
            InitializeLoginPage();

        }

        #region Private method
        /// <summary>
        /// 初期処理
        /// </summary>
        private async void InitializeLoginPage()
        {
            Email.Value = await SecureStorage.GetAsync("email");
            Password.Value = await SecureStorage.GetAsync("password");
        }

        /// <summary>
        /// 新規登録後処理
        /// </summary>
        /// <param name="serviceResult"></param>
        /// <param name="id"></param>
        private async void AfterProcForCreateUser(ServiceResultModel serviceResult, string id)
        {
            if (serviceResult.result)
            {
                await _pageDialogService.DisplayAlertAsync("Information", $"初期パスワードのメールが送信されます。{Environment.NewLine}会員ID:{id}", "OK");
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync(serviceResult.errorInformation.title, serviceResult.errorInformation.message, "OK");
            }
        }

        /// <summary>
        /// ログイン後処理
        /// </summary>
        /// <param name="serviceResult"></param>
        private async void AfterProcForLogin(ServiceResultModel serviceResult)
        {
            if (serviceResult.result)
            {
                if (await _pageDialogService.DisplayAlertAsync("Confirm", $"ログインを維持しますか？", "Yes", "No"))
                {
                    await SecureStorage.SetAsync("email", Email.Value);
                    await SecureStorage.SetAsync("password", Password.Value);
                    await SecureStorage.SetAsync("token", AppInfoStore.token);
                }
                else
                {
                    SecureStorage.Remove("email");
                    SecureStorage.Remove("password");
                    SecureStorage.Remove("token");
                }

                //if (UserCategory.Value == CommonEnums.UserCategoryType.UserRollA)
                //{
                    await _navigationService.NavigateAsync("InputCreditInfoAPage");
                //}
                //else
                //{
                    //await _navigationService.NavigateAsync("InputCreditInfoBPage");
                //}
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync(serviceResult.errorInformation.title, serviceResult.errorInformation.message, "OK");
            }
        }
        #endregion Private method
    }
}
