namespace LoanApplications.Shared.BusinessLogic
{
    public class Calculations
    {
        public static string CalculateRisk(int creditRating)
        {
            return creditRating > 675 ? "AAA" : "BBB";
        }
    }
}
