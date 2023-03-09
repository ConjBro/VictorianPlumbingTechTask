// See https://aka.ms/new-console-template for more information

using VicTechTask;
using VicTechTask.Products;

// Populate the inventory with products.
IProduct[] products =
{
    new Cola("Cola", 1.00, 1, 1), 
    new Crisps("Crisps", 0.50, 1, 2),
    new Chocolate("Chocolate", 0.65, 1, 3)
};

var inv = new Inventory(products);

// Add the inventory to the VendingMachine
var vendingMachine = new VendingMachine(inv);

while (vendingMachine.on)
{
    // Input Coins
    vendingMachine.InputCoins();

    //Select a Product
    vendingMachine.SelectProduct();
}
