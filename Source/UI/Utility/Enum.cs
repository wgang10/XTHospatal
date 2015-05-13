using System;

namespace UI
{
    public enum enumOperation
    {
        /// <summary>
        /// 初始化
        /// </summary>
        Initial = 0,

        /// <summary>
        /// 检索
        /// </summary>
        Search = 1,

        /// <summary>
        /// 添加
        /// </summary>
        Add = 2,

        /// <summary>
        /// 更新
        /// </summary>
        Update = 3,

        /// <summary>
        /// 删除
        /// </summary>
        Delete = 4,

        /// <summary>
        /// 印刷
        /// </summary>
        Print = 5
    }

    public enum enumCheckItems
    {
        ItemID = 1,
        USER_LOGIN_ID = 2,
        PHONE_NO = 3,
        ItemName = 4,
        E_Mail = 5,
        Post = 6,
        DateYMD = 7,
        UserGroup = 8,
        ItemMEMO = 9
    }

    /// <summary>
    /// InputKey
    /// </summary>
    public enum InputType
    {
        Num,
        Dbl,
        Tel,
        Date,
        AlphaAndNum
    }

    /// <summary>
    /// 服务器端配置项名称
    /// </summary>
    public enum ConfigName
    {
        WebServicesURL,
        InstallURL,
        InstallPath,
        PictureLoading,
        PictureTop,
        PictureLogin,
        ManagerPassword
    }
}
