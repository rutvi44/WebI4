using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InClass4.Entities
{
    [Table("BPMeasurements")]
    public partial class Bpmeasurement
    {
        [Key]
        [Column("BPMeasurementId")]
        public int BpmeasurementId { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public DateTime MeasurementDate { get; set; }
        [StringLength(450)]
        public string MeasurementPositionId { get; set; } = null!;

        [ForeignKey("MeasurementPositionId")]
        [InverseProperty("Bpmeasurements")]
        public virtual MeasurementPosition MeasurementPosition { get; set; } = null!;
    }
}
