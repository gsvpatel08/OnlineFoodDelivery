namespace OnlineFoodDelivery.Utility.ApiResponses
{
    public class RestaurentFoodItemListApiResponse
    {

        public string RestaurantName { get; set; }
        public int RestaurantId { get; set; }
        public string ItemName { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
    }
}
