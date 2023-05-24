namespace Pharmacy.Core.Enums
{
    public enum ELogType
    {
        Trace = 0,  // – The entire trace of the codebase.
        Debug = 1,  //– useful while developing the application.
        Info = 2,   //– A general Message.
        Warn = 3,   //– Used for unexpected events.
        Error = 4,  // – When something breaks.
        Fatal = 5   // – When something very crucial breaks.
    }
}