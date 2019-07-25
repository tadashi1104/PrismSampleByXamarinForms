using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using PrismSampleByXamarinForms.Services;
using System.Linq;
using PrismSampleByXamarinForms.Consts;
using PrismSampleByXamarinForms.Models;

namespace PrismSampleByXamarinForms.ViewModels
{
    public class _InputCreditInfoRollAViewModel : Helpers.Observable
    {
        public Views._InputCreditInfoRollA View { get; private set; } = null;

        private CommonApiService _service = new CommonApiService();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public _InputCreditInfoRollAViewModel()
        {

        }

        public async void Initialize(Views._InputCreditInfoRollA page)
        {
            View = page;
            //Masters = await GetMaster();
            AppInfoStore.Masters.Master_001 item1 = new AppInfoStore.Masters.Master_001 { Code = 1, Name = "item 1" };
            AppInfoStore.Masters.Master_001 item2 = new AppInfoStore.Masters.Master_001 { Code = 2, Name = "item 2" };
            var masters = new List<AppInfoStore.Masters.Master_001> { item1, item2 };
            this.Masters = masters;
        }

        /// <summary>
        /// Master 001
        /// </summary>
        /// <returns></returns>
        private async Task<List<AppInfoStore.Masters.Master_001>> GetMaster()
        {
            var response = await _service.Send_API_999(AppInfoStore.token, CommonEnums.MasterTypes.Master01);

            if (response.result)
            {
                return response.returnBody.Masters.Select(_ => new AppInfoStore.Masters.Master_001 { Code = _.Code, Name = _.Name }).ToList();
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

        #region お名前（漢字）姓
        public string Sei
        {
            get => this.Sei_;
            set => Set(ref this.Sei_, value, nameof(Sei));
        }
        private string Sei_;
        #endregion お名前（漢字）姓

        #region お名前（漢字）名
        public string Mei
        {
            get => this.Mei_;
            set => Set(ref this.Mei_, value, nameof(Mei));
        }
        private string Mei_;
        #endregion お名前（漢字）名

        #region お名前（カナ）姓
        public string SeiKana
        {
            get => this.SeiKana_;
            set => Set(ref this.SeiKana_, value, nameof(SeiKana));
        }
        private string SeiKana_;
        #endregion お名前（カナ）姓

        #region お名前（カナ）名
        public string MeiKana
        {
            get => this.MeiKana_;
            set => Set(ref this.MeiKana_, value, nameof(MeiKana));
        }
        private string MeiKana_;
        #endregion お名前（カナ）名

        #region 郵便番号
        public string ZipCode
        {
            get => this.ZipCode_;
            set => Set(ref this.ZipCode_, value, nameof(ZipCode));
        }
        private string ZipCode_;
        #endregion 郵便番号

        #region 都道府県
        public string Prefecture
        {
            get => this.Prefecture_;
            set => Set(ref this.Prefecture_, value, nameof(Prefecture));
        }
        private string Prefecture_;
        #endregion 都道府県

        #region 市区町村
        public string Address1
        {
            get => this.Address1_;
            set => Set(ref this.Address1_, value, nameof(Address1));
        }
        private string Address1_;
        #endregion 市区町村

        #region 町名/番地
        public string Address2
        {
            get => this.Address2_;
            set => Set(ref this.Address2_, value, nameof(Address2));
        }
        private string Address2_;
        #endregion 町名/番地

        #region ビル/マンション名など
        public string Address3
        {
            get => this.Address3_;
            set => Set(ref this.Address3_, value, nameof(Address3));
        }
        private string Address3_;
        #endregion ビル/マンション名など

        #region 電話番号
        public string PhoneNumber
        {
            get => this.PhoneNumber_;
            set => Set(ref this.PhoneNumber_, value, nameof(PhoneNumber));
        }
        private string PhoneNumber_;
        #endregion 電話番号

        #region マスター
        private List<AppInfoStore.Masters.Master_001> Masters_ = new List<AppInfoStore.Masters.Master_001>();
        public List<AppInfoStore.Masters.Master_001> Masters
        {
            get => this.Masters_;
            set => Set(ref Masters_, value, nameof(Masters));
        }
        public string Master
        {
            get => this.Master_;
            set
            {
                Set(ref this.Master_, value, nameof(Master));
                MasterCode = Masters.Where(_ => _.Name == this.Master_).First().Code.ToString();
            }
        }
        private string Master_;

        public string MasterCode
        {
            get => this.MasterCode_;
            set => Set(ref this.MasterCode_, value, nameof(MasterCode));
        }
        private string MasterCode_;
        #endregion マスター

        #region 登録
        private Helpers.RelayCommand RegistrationCreditInfoCommand_;
        public Helpers.RelayCommand RegistrationCreditInfoCommand
        {
            get { return RegistrationCreditInfoCommand_ = RegistrationCreditInfoCommand_ ?? new Helpers.RelayCommand(RegistrationCreditInfo); }
        }

        private async void RegistrationCreditInfo()
        {
            // API呼び出し
            try
            {
                //// 会員審査情報登録
                //var response = await _service.Send_004(
                //    new ApiRequestModels.Request_API_004
                //    {
                //        Sei = this.Sei,
                //        Mei = this.Mei,
                //        SeiKana = this.SeiKana,
                //        MeiKana = this.MeiKana,
                //        ZipCode = this.ZipCode,
                //        Prefecture = this.Prefecture,
                //        Address1 = this.Address1,
                //        Address2 = this.Address2,
                //        Address3 = this.Address3,
                //        PhoneNumber = this.PhoneNumber,
                //    });

                //if (response.result)
                //{
                //    MessagingCenter.Send(this, "GoNextPage", new UserType
                //    {
                //        userCategory = (CommonEnums.UserCategoryType)AppInfoStore.UserInfo.Type
                //        ,
                //        userStatus = (CommonEnums.UserStatusType)AppInfoStore.UserInfo.Status
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
        #endregion 登録

    }
}
