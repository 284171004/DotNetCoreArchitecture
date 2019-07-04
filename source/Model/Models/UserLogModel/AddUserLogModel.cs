namespace DotNetCoreArchitecture.Model
{
    public class AddUserLogModel
    {
        public AddUserLogModel
        (
            long userId,
            LogType logType
        )
        {
            UserId = userId;
            LogType = logType;
        }

        public long UserId { get; }

        public LogType LogType { get; }
    }
}
