using System.ComponentModel;

namespace Child.Growth.src.Infra.Enums
{
    public enum UserTypeEnum
    {
        [Description("Pediatra")]
        Doctor,
        [Description("Responsável pela criança")]
        Responsible
    }
}