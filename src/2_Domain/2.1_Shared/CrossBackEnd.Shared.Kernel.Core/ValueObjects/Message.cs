
using System;

namespace CrossBackEnd.Shared.Kernel.Core.ValueObjects
{
    public class Message
    {
        public string Value { get; private set; }
        public DateTime Time { get; private set; }

        #region Constructors

        public Message(string message)
        {
            this.Value = Value;
            this.Time = DateTime.Now;
        }

        #endregion

        #region Factories

        public static Message CreateMessage(string message)
        {
            return new Message(message);
        }

        #endregion
        
    }
}