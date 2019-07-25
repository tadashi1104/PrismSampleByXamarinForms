using Prism.Services;
using PrismSampleByXamarinForms.Consts;
using PrismSampleByXamarinForms.Models;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using Xamarin.Essentials;

namespace PrismSampleByXamarinForms.Services
{

    public interface ILoginPageService
    {
        (ServiceResultModel serviceResult, string id) CreateUser(ReactiveProperty<string> email, ReactiveProperty<CommonEnums.UserCategoryType> userCategory);
        ServiceResultModel Login(ReactiveProperty<string> email, ReactiveProperty<string> password);
    }

    public class LoginPageService : ILoginPageService 
    {

        private readonly ICommonApiService _service;

        /// <summary>
        /// 新規登録
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userCategory"></param>
        /// <returns>(処理結果、会員ID)</returns>
        /// <remarks>処理結果のErrorInfomationはresult = Falseの時のみ入ります</remarks>
        public (ServiceResultModel serviceResult, string id) CreateUser(ReactiveProperty<string> email, ReactiveProperty<CommonEnums.UserCategoryType> userCategory)
        {
            ServiceResultModel serviceResult = new ServiceResultModel();
            string id;

            // API呼び出し
            try
            {
                var errorMessages = new[]
                {
                    // エラーを束ねて
                    email.ObserveErrorChanged
                    , userCategory.ObserveErrorChanged
                }
                .CombineLatest(x =>
                {
                    // null(エラーなし)を省いて
                    return x.Where(y => y != null)
                        // IE<string>を平らに慣らす
                        .SelectMany(y => y.OfType<string>());
                })
                .ToReactiveProperty()?.Value.ToList();

                if (errorMessages.Any())
                {
                    serviceResult = new ServiceResultModel
                    {
                        result = false
                        ,
                        errorInformation = new ServiceResultModel.ErrorInformationModel
                        {
                            title = "Error"
                            ,
                            message = string.Join(Environment.NewLine, errorMessages)
                        }
                    };
                    id = null;
                    return (serviceResult, id);
                }

                AppInfoStore.token = "";
                var info = new ApiResponseModels.Response_API_001 { Id = "ABCD123", Status = 0, Type = (int)userCategory.Value };
                AppInfoStore.UserInfo = info;

                //var response = await _service.Send_API_001(NewEmail, UserCategory);

                //if (response.result)
                if (true)
                {
                    serviceResult = new ServiceResultModel
                    {
                        result = true
                        ,
                        errorInformation = null
                    };
                    id = "ABCD123";
                    return (serviceResult, id);
                }
                else
                {
                    serviceResult = new ServiceResultModel
                    {
                        result = false
                        ,
                        errorInformation = new ServiceResultModel.ErrorInformationModel
                        {
                            title = "Error"
                            ,
                            message = $"Error"
                            //message = $"{response.message}"
                        }
                    };
                    id = null;
                    return (serviceResult, id);
                }

            }
            catch (Exception ex)
            {
                serviceResult = new ServiceResultModel
                {
                    result = false
                    ,
                    errorInformation = new ServiceResultModel.ErrorInformationModel
                    {
                        title = "Error"
                        ,
                        message = ex.Message
                    }
                };
                id = null;
                return (serviceResult, id);
            }

        }

        /// <summary>
        /// ログイン
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>処理結果</returns>
        /// <remarks>処理結果のErrorInfomationはresult = Falseの時のみ入ります</remarks>
        public ServiceResultModel Login(ReactiveProperty<string> email, ReactiveProperty<string> password)
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

                var errorMessages = new[]
                {
                    // エラーを束ねて
                    email.ObserveErrorChanged
                    , password.ObserveErrorChanged
                }
                .CombineLatest(x =>
                {
                    // null(エラーなし)を省いて
                    return x.Where(y => y != null)
                        // IE<string>を平らに慣らす
                        .SelectMany(y => y.OfType<string>());
                })
                .ToReactiveProperty()?.Value.ToList();

                if (errorMessages.Any())
                {
                    return new ServiceResultModel
                    {
                        result = false
                        ,
                        errorInformation = new ServiceResultModel.ErrorInformationModel
                        {
                            title = "Error"
                            ,
                            message = string.Join(Environment.NewLine, errorMessages)
                        }
                    };
                }

                AppInfoStore.token = "";
                var info = new ApiResponseModels.Response_API_001 { Id = "ABCD123", Status = 0, Type = 1 };
                AppInfoStore.UserInfo = info;
            
                return new ServiceResultModel
                {
                    result = true
                    ,
                    errorInformation = null
                };

            }
            catch (Exception ex)
            {

                return new ServiceResultModel
                {
                    result = false
                    ,
                    errorInformation = new ServiceResultModel.ErrorInformationModel
                    {
                        title = "Error"
                        ,
                        message = ex.Message
                    }
                };
            }

        }

    }
}
