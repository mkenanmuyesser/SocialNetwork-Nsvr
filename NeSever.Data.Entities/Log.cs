using NeSever.Common.Infra.DataLayer.Entity;
using System;

namespace NeSever.Data.Entities
{
    public partial class Log : Entity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
    }
}
