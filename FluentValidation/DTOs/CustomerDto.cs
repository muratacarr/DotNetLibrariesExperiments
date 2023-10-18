namespace FluentValidationApp.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Age { get; set; }
        public string FullName { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime CreditCardValidDate { get; set; }
    }
}
