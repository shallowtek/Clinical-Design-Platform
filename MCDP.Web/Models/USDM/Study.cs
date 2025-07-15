using Microsoft.AspNetCore.Components;

namespace MCDP.Web.Models.USDM;

public class Study
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string ProtocolIdentifier { get; set; }
    public DateTime CreatedOn { get; set; }
    public List<Identifier> Identifiers { get; set; }
    public List<Arm> Arms { get; set; }
    public List<Epoch> Epochs { get; set; }
    public List<Objective> Objectives { get; set; }
    public List<Criterion> Criteria { get; set; }
    public List<Activity> Activities { get; set; }
    public List<Intervention> Interventions { get; set; }
    public List<Endpoint> Endpoints { get; set; }
    public List<Visit> Visits { get; set; }
    public List<ArmEpoch> ArmEpochs { get; set; }
    public List<Revision> RevisionHistory { get; set; }

}

public class Revision
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public Guid StudyId { get; set; }
}

public class Identifier
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }
    public Guid StudyId { get; set; }
}

public class Arm
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class Epoch
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}

public class Objective
{
    public Guid Id { get; set; }
    public string Type { get; set; }    // Primary / Secondary
    public string Description { get; set; }
    public Guid StudyId { get; set; }
}

public class Criterion
{
    public Guid Id { get; set; }
    public bool IsInclusion { get; set; }
    public string Text { get; set; }
    public Guid StudyId { get; set; }
}

public class Activity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; } // e.g., Procedure, Assessment
    public Guid StudyId { get; set; }
}

public class Intervention
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class Endpoint
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } // Primary/Secondary
    public string Description { get; set; }
    public Guid StudyId { get; set; }
}

public class Visit
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Day { get; set; }
    public Guid StudyId { get; set; }
}

public class ArmEpoch
{
    public Guid Id { get; set; }
    public string ArmName { get; set; }
    public string EpochName { get; set; }
}

