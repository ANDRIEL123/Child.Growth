using System.ComponentModel.DataAnnotations.Schema;
using Child.Growth.src.Entities.Base;

namespace Child.Growth.src.Entities
{
    /// <summary>
    /// Consulta de paciente
    /// </summary>
    public class PatientConsultation : EntityBase
    {
        /// <summary>
        /// Data da consulta
        /// </summary>
        [Column("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Column("height")]
        public float Height { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Column("weight")]
        public float Weight { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Column("cephalic_perimeter")]
        public float CephalicPerimeter { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Column("observations")]
        public float Observations { get; set; }

        /// <summary>
        /// Id da criança
        /// </summary>
        [Column("children_id")]
        public long ChildrenId { get; set; }

        #region References

        public virtual Children Children { get; set; }

        #endregion
    }
}