namespace Domain.Abstractions
{
    public abstract class EntityAbstraction
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsEnableForSystem { get; set; }
    }
}
