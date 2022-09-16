namespace WebApi.Application.OrderOperations.Model;
    public class OrderViewModel
    {
        public string NameSurname { get; set; }
        public IReadOnlyCollection<string> Movies { get; set; }
        public IReadOnlyCollection<string> Price { get; set; }
        public IReadOnlyCollection<string> PurchasedDate { get; set; }
    }

