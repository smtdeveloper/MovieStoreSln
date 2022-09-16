namespace WebApi.Application.OrderOperations.Model;
    public class CreateOrderModel
    {
        public int MovieId { get; set; }
        public int CustomerId { get; set; }
        DateTime purchasedTime = DateTime.Now;
        bool movieStatus = true;

    }


