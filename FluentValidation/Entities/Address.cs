namespace FluentValidationApp.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public string? Province { get; set; }
        public string? PostCode { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}
