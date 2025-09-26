using assms.entities;

namespace assms.api.Constants;

public static class MessageConstants
{
    public const string NotFoundRecord = "The record could not be found.";

    public const string InvalidRequest = "The request is invalid.";

    public static string UnexpectedError =>
        "We apologize, but an unforeseen error prevented us from completing this. Please try again later.";
    
    public static string NotFoundResource =>
        "The requested resource could not be found.";

    public static string Success(RecordType attendanceType) =>
        attendanceType switch
        {
            RecordType.LogIn=>"Login Successful",
            RecordType.LogOut=>"Login Successful",
            RecordType.Save => "Record Added Successful",
            RecordType.Edit => "Record Updated Successful",
            RecordType.Delete=> "Record Deleted Successful",
            RecordType.GetAll => "Get record Successful",
            RecordType.GetAllByDate => "Get record by date Successful",
            _ => "Request processed successfully."
        };
}