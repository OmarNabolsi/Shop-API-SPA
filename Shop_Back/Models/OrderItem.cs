namespace Shop_Back.Models
{
  public class OrderItem
  {
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
  }
}