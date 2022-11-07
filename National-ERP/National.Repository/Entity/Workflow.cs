using System;
using System.Collections.Generic;

namespace National.Repository.Entity
{
    public partial class Workflow
    {
        public int WorkflowId { get; set; }
        public string? WorkflowName { get; set; }
        public string? Description { get; set; }
        public long? CreatedBy { get; set; }
        public DateOnly? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateOnly? UpdatedDate { get; set; }
    }
}
