namespace OnlineFoodDelivery.Utility.ApiResponses
{
    public class FoodCategoryResponse
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<FoodItemResponse> Items { get; set; }



    }
}
