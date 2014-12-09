using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COMM.Entity;
using System.Reflection;
using ConfOrm;

namespace XTHospital.ORM
{
    public class PoidPropertyAsIdClassName : IPattern<MemberInfo>
    {
        private string keyName = "ID";
        public PoidPropertyAsIdClassName(string KeyName)
        {
            keyName = KeyName;
        }
        #region Implementation of IPattern<MemberInfo>
        public bool Match(MemberInfo subject)
        {
            if (subject == null)
            {
                return false;
            }
            var name = subject.Name;
            var expected = GetIdPrefix();//+ subject.DeclaringType.Name;
            return name.Equals(expected);
        }
        #endregion
        protected virtual string GetIdPrefix()
        {
            return keyName;
        }
    }
}
