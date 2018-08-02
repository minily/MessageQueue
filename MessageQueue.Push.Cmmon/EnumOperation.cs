using System;
using System.ComponentModel;
using System.Reflection;

namespace Zhongmubao.Push.Common
{
    /// <summary>
    /// 枚举操作类
    /// </summary>
    public class EnumOperation
    {
        public static string Description(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }
    }
}
