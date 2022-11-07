using System;
using System.Collections.Generic;

namespace National.Repository.Entity
{
    public partial class WorkflowApproval
    {
        public int Id { get; set; }
        public string? WorkflowName { get; set; }
        public string? WorkflowLevelDetails { get; set; }
        public string? ShortDescription { get; set; }
        public string? Details { get; set; }
        public string? Status { get; set; }
        public long? CreatedBy { get; set; }
        public DateOnly? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateOnly? UpdatedDate { get; set; }
    }
}
