namespace AccountService.Domain.Infrastructure.Constants
{
    public class CoreMessage
    {
        public static string RequestSuccessCompleted = "Request Successfully Completed";

        public static string CommonException = "Error on:{0}, Details {1}";

        public static string UnExpectedError = "UnExpected Error on:{0}, Details {1}";

        public static string Exist = "Already in Database";

        public static string AddedSuccessfuly = "Added  Successfully";

        public static string DeleteSuccessfuly = "Delete Successfuly";

        public static string DeleteFailed = "Delete  Failed";

        public static string FailAdded = "Fail  Added Operation";

        public static string NotFound = "Not Found Database";

        public static string AuthenticateError = "Email or password is incorrect";
    }
}
