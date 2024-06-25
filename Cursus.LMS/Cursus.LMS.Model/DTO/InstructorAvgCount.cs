namespace Cursus.LMS.Model.DTO;

public class InstructorAvgCount
{
    public double Avg
    {
        get
        {
            int totalRatings = One + Two + Three + Four + Five;
            if (totalRatings == 0) return 0.0;
            double sum = (One * 1) + (Two * 2) + (Three * 3) + (Four * 4) + (Five * 5);

            return sum / totalRatings;
        }
    }

    public int One { get; set; }
    public int Two { get; set; }
    public int Three { get; set; }
    public int Four { get; set; }
    public int Five { get; set; }
}