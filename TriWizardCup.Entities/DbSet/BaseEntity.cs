﻿namespace TriWizardCup.Entities.DbSet
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = new Guid();
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public int Status { get; set; }
    }
}
