using System.Data.Entity;

namespace BuildingGraphic.Models
{
    public class ContextInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            context.Equations.Add(new Equation
            {
                CoefficientSecondDegrees = 2,
                CoefficientFirstDegrees = 3,
                CoefficientZeroDegrees = 0
            });
            base.Seed(context);
        }
    }
}