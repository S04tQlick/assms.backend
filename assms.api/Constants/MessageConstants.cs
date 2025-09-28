using assms.entities;
using assms.entities.Enums;

namespace assms.api.Constants;

public static class MessageConstants
{
    public const string NotFoundRecord = "The record could not be found.";

    public const string InvalidRequest = "The request is invalid.";

    public static string UnexpectedError =>
        "We apologize, but an unforeseen error prevented us from completing this. Please try again later.";
    
    public static string NotFoundResource =>
        "The requested resource could not be found.";

    public static string Success(RecordTypeEnum attendanceType) =>
        attendanceType switch
        {
            RecordTypeEnum.LogIn=>"Login Successful",
            RecordTypeEnum.LogOut=>"Login Successful",
            RecordTypeEnum.Save => "Record Added Successful",
            RecordTypeEnum.Edit => "Record Updated Successful",
            RecordTypeEnum.Delete=> "Record Deleted Successful",
            RecordTypeEnum.GetAll => "Get record Successful",
            RecordTypeEnum.GetAllByDate => "Get record by date Successful",
            _ => "Request processed successfully."
        };
}