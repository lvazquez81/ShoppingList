namespace ShoppingListWeb.Models
{
    public class MyItem
    {
        public int Id { get; set; }

        public string Item { get; set; }

        public MyItem() { }

        public MyItem(int id, string item)
        {
            this.Id = id;
            this.Item = item;
        }
    }
}
