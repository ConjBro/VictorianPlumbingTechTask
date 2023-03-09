namespace VicTechTask.Products;

public class Inventory
{
    public IProduct[] products { get; }

    public Inventory(IProduct[] products)
    {
        this.products = products;
    }
    
    //INSERT CRUD Database logic here for an SQLiteDB
}