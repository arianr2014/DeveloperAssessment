using System;

namespace AreyesAssessment.Data.Entities
{
    public class ChangeLog
    {  
        public int ChangelogID { get; set; }
        public DateTime ChangeDate { get; set; } = DateTime.UtcNow;
        public string ChangeDescription { get; set; } = string.Empty;
    }
}
