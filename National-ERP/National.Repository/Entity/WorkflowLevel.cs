using System;
using System.Collections.Generic;

namespace National.Repository.Entity
{
    public partial class WorkflowLevel
    {
        public int WorkflowLevelId { get; set; }
        public string? WorkflowLevelName { get; set; }
        public int? Users { get; set; }
        public long? CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public string? UpdatedDate { get; set; }

        public virtual User? UsersNavigation { get; set; }
    }
}
