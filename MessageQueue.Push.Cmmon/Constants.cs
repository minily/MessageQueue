using System.ComponentModel;

namespace Zhongmubao.Push.Common
{
    public static class Constants
    {

        public struct Jpush
        {
            public const string AppKey = "8620c8059a65516c1df2197e";
            public const string MasterSecret = "f50a411b70985ac0003ecc68";
        }

        public struct DataType
        {
            public enum Platform
            {
                [Description("01")]
                Android = 01,

                [Description("02")]
                Ios = 02
            }
        }
    }
}
