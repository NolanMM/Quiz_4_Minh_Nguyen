using System;
using System.Collections.Generic;

namespace Quiz_4Minh_Nguyen.Entities;

public partial class MeasurementPosition
{
    public string MeasurementPositionId { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<Bpmeasurement> Bpmeasurements { get; set; } = new List<Bpmeasurement>();
}
