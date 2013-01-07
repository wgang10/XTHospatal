using System;
namespace XTHospital.COM
{
    /// <summary>
    /// Set DataBase log Style
    /// </summary>
    public enum enumDbLog
    {
        Connect = 0,
        Close = 1,
        Excute = 3,
        BeginTransaction,
        CommitTransaction,
        RollbackTransaction,
    }
}