using System.Runtime.Serialization;

namespace FitTrek.Application.Clients.Enums;

public enum SubscriptionPlan
{
    [EnumMember(Value = "Silver")]
    Silver,
    [EnumMember(Value = "Gold")]
    Gold,
    [EnumMember(Value = "Platinum")]
    Platinum
}
