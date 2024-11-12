using FitTrek.Application.Clients.Enums;

namespace FitTrek.Domain.Extensions;

public static class SubscriptionPlanExtensions
{
    public static decimal GetRevenue(this SubscriptionPlan plan)
    {
        return plan switch
        {
            SubscriptionPlan.Silver => 150m,
            SubscriptionPlan.Gold => 300m,
            SubscriptionPlan.Platinum => 600m,
            _ => 0m  // Default value for any unexpected enum value
        };
    }
}
