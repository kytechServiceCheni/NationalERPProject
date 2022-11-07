using System;
using System.Collections.Generic;

namespace National.Repository.Entity
{
    public partial class WorkflowDetail
    {
        public int WorkflowDetailId { get; set; }
        public long? WorkflowId { get; set; }
        public long? CurrentState { get; set; }
        public long? Predecessor { get; set; }
        public long? Successor { get; set; }
        public long? CreatedBy { get; set; }
        public DateOnly? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateOnly? UpdatedDate { get; set; }
    }
}
