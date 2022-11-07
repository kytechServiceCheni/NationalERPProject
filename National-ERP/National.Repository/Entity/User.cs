using System;
using System.Collections.Generic;

namespace National.Repository.Entity
{
    public partial class User
    {
        public User()
        {
            WorkflowLevels = new HashSet<WorkflowLevel>();
        }

        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? Designation { get; set; }
        public string? UserProcess { get; set; }
        public string? ProofOfId { get; set; }
        public string? Photo { get; set; }
        public string? Password { get; set; }
        public long? Status { get; set; }
        public long? CreatedBy { get; set; }
        public DateOnly? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateOnly? UpdatedDate { get; set; }
        public byte[]? StoredSalt { get; set; }

        public virtual ICollection<WorkflowLevel> WorkflowLevels { get; set; }
    }
}
