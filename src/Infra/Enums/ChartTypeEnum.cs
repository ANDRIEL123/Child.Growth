using System.ComponentModel;

namespace Child.Growth.src.Infra.Enums
{
    /// <summary>
    /// Enum com os tipos de gráficos de percentil
    /// </summary>
    public enum ChartTypeEnum
    {
        [Description("Peso")]
        Weight,

        [Description("Altura")]
        Height,

        [Description("Perímetro Cefálico")]
        CephalicPerimeter
    }
}