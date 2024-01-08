using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InClass4.Entities
{
    public partial class MeasurementPosition
    {
        public MeasurementPosition()
        {
            Bpmeasurements = new HashSet<Bpmeasurement>();
        }

        [Key]
        public string MeasurementPositionId { get; set; } = null!;
        public string? Name { get; set; }

        [InverseProperty("MeasurementPosition")]
        public virtual ICollection<Bpmeasurement> Bpmeasurements { get; set; }
    }
}
