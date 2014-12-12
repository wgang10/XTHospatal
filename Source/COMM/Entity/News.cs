using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace XTHospital.COMM.Entity
{
    /// <summary>
    /// 会员实体对象
    /// </summary>
    [DataContract]
    public class Notic
    {
        public Notic() { }
        /// <summary>
        /// 编号
        /// </summary>
        [DataMember]
        public virtual int Id { get; set; }        

        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public virtual string Title { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        [DataMember]
        public virtual string Url { get; set; }

        /// <summary>
        /// 所属系统
        /// </summary>
        [DataMember]
        public virtual string SystemName { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [DataMember]
        public virtual string Body { get; set; }

        /// <summary>
        /// 会员状态 0:正常 1:修改 2:删除 
        /// </summary>
        [DataMember]
        public virtual int Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataMember]
        public virtual DateTime UpdateTime { get; set; }
    }
}
