using System.ComponentModel;

namespace Child.Growth.src.Infra.Enums
{
    /// <summary>
    /// Enum com os tipos de gráficos de percentil
    /// </summary>
    public enum ChartTypeEnum
    {
        [Description("Gráfico comparativo de peso P50")]
        Weight,

        [Description("Gráfico comparativo de altura P50")]
        Height,

        [Description("Gráfico comparativo de perímetro cefálico P50")]
        CephalicPerimeter
    }
}