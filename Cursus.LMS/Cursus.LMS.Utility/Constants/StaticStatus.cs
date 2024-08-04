namespace Cursus.LMS.Utility.Constants;

public static class StaticStatus
{
    public static class Category
    {
        public const int New = 0;
        public const int Activated = 1;
        public const int Deactivated = 2;
    }

    public static class Order
    {
        public const int Pending = 0;
        public const int Paid = 1;
        public const int Confirmed = 2;
        public const int Rejected = 3;
        public const int PendingRefund = 4;
        public const int ConfirmedRefund = 5;
        public const int RejectedRefund = 6;
    }

    public static class StudentCourse
    {
        public const int Pending = 0;
        public const int Confirmed = 1;
        public const int Enrolled = 2;
        public const int Learning = 3;
        public const int Completed = 4;
        public const int Canceled = 5;
    }
    
    public static class CourseReview
    {
        public const int Activated = 0;
        public const int Deactivated = 1;
    }
}