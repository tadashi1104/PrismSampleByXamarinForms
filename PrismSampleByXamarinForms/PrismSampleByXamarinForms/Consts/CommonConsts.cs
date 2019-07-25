using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSampleByXamarinForms.Consts
{
    public static class CommonConsts
    {
        public const string baseUrl = "https://example.com/api";
        public const string apiVersion = "/v2";
    }

    public static class CommonEnums
    {

        /// <summary>
        /// メソッドタイプ
        /// </summary>
        public enum MethodType
        {
            Get, Post, Put, Delete,
        }

        /// <summary>
        /// アクションタイプ
        /// </summary>
        /// <remarks>過不足あれば追加ください</remarks>
        public enum ActionName
        {
            /// <summary>認証</summary>
            Authentication,
            /// <summary>検索</summary>
            Search,
            /// <summary>登録</summary>
            Create,
            /// <summary>詳細</summary>
            Details,
            /// <summary>編集</summary>
            Edit,
            /// <summary>削除</summary>
            Delete,
        }

        public enum UserCategoryType
        {
            /// <summary>
            /// Roll A
            /// </summary>
            UserRollA = 1,
            /// <summary>
            /// Roll B
            /// </summary>
            UserRollB = 2,
            /// <summary>
            /// 管理者
            /// </summary>
            Management = 9
        }

        /// <summary>
        /// 会員ステータス
        /// </summary>
        public enum UserStatusType
        {
            /// <summary>
            /// 仮会員
            /// </summary>
            Temporary = 0,
            /// <summary>
            /// 審査中
            /// </summary>
            Examination = 1,
            /// <summary>
            /// 本会員
            /// </summary>
            Member = 2,
            /// <summary>
            /// 強制停止
            /// </summary>
            ForcedStop = 3,
            /// <summary>
            /// 退会
            /// </summary>
            Withdrawal = 9,
        }

        /// <summary>
        /// マスタ種別区分
        /// </summary>
        public enum MasterTypes
        {
            /// <summary>Master01</summary>
            Master01 = 1
        }
    }

}
