using System.Runtime.Serialization;

namespace FitTrek.Application.Clients.Enums;

public enum Gender
{
    [EnumMember(Value = "Male")]
    Male,
    [EnumMember(Value = "Female")]
    Female,
    [EnumMember(Value = "Other")]
    Other
}
