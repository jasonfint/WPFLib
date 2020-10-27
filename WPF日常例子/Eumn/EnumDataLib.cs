using System.ComponentModel;

namespace WPF日常例子
{

    public enum Status
    {
        Horrible,
        Bad,
        SoSo,
        Good,
        Better,
        Best
    }
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum StatusD
    {
        [Description("This is horrible")]
        Horrible,
        [Description("This is Bad")]
        Bad,
        [Description("This is SoSo")]
        SoSo,
        [Description("This is Good")]
        Good,
        [Description("This is Better")]
        Better,
        [Description("This is Best")]
        Best
    }
}
