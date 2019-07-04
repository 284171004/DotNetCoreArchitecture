using DotNetCoreArchitecture.Model;
using System;

namespace DotNetCoreArchitecture.Domain
{
    public class UserLogEntity
    {
        protected internal UserLogEntity
        (
            long userId,
            LogType logType
        )
        {
            UserId = userId;
            LogType = logType;
        }

        private UserLogEntity() { }

        public long UserLogId { get; private set; }

        public long UserId { get; private set; }

        public LogType LogType { get; private set; }

        public DateTime DateTime { get; private set; }

        public UserEntity User { get; private set; }

        public void Add()
        {
            UserLogId = default;
            DateTime = DateTime.UtcNow;
        }
    }
}
