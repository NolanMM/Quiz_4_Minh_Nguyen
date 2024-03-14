using System;
using System.Collections.Generic;

namespace Quiz_4Minh_Nguyen.Entities;

public partial class Bpmeasurement
{
    public int BpmeasurementId { get; set; }

    public int Systolic { get; set; }

    public int Diastolic { get; set; }

    public DateTime MeasurementDate { get; set; }

    public string MeasurementPositionId { get; set; } = null!;

    public virtual MeasurementPosition MeasurementPosition { get; set; } = null!;
}
