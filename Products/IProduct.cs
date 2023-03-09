namespace VicTechTask.Products;

public interface IProduct
{
    public string name { get; }
    public double price { get; }
    public int quantity { get; set; }
    public int code { get; }
}