using VicTechTask.Products;

namespace VicTechTask;

public class VendingMachine
{
    public bool on { get; }
    private readonly Inventory _inventory;
    private double coinBalance;
    public VendingMachine(Inventory inventory)
    {
        _inventory = inventory;
        on = true;
    }

    public void InputCoins()
    {
        var menuInput = 0.00;
        Console.WriteLine("\nEnter coin value in decimal format. Type '9999' to finish entering coins, '0000' to return coins.");
        while (menuInput != 9999)
        {
            Console.Write("\n> INSERT COIN : ");
            var userInput = Console.ReadLine();

            try
            {
                menuInput = Convert.ToDouble(userInput);
            }
            catch (Exception e)
            {
                Console.WriteLine(">>>> RETURNING ILLEGAL TENDER: " + userInput + " <<<<");
                continue;
            }
            
            if (menuInput == 0000)
            {
                Console.WriteLine(">>>> RETURNING BALANCE: £" + ReturnCoins() + " <<<<");
            }

            switch (menuInput)
            {
                case 0.01:
                case 0.02:
                case 0.05:
                case 0.10:
                case 0.20:
                case 0.50:
                case 1.00:
                case 2.00:
                    coinBalance += menuInput;     
                    Console.WriteLine(">>>> NEW BALANCE: £" + coinBalance + " <<<<");
                    break;
            }
        }
    }

    public void SelectProduct()
    {
        var menuInput = 0.00;
        Console.WriteLine("\nEnter Product code (1 = Cola, 2 = Crisps, 3 = Chocolate). Type '9999' to return to coin input, '0000' to return coins.");
        
        while (menuInput != 9999)
        {
            Console.Write("\n> ENTER CODE : ");
            var userInput = Console.ReadLine();

            try
            {
                menuInput = Convert.ToDouble(userInput);
            }
            catch (Exception e)
            {
                Console.WriteLine(">>>> PRODUCT NOT FOUND: " + userInput + " <<<<");
                continue;
            }
            
            if (menuInput == 0000)
            {
                Console.WriteLine(">>>> RETURNING BALANCE: £" + ReturnCoins() + " <<<<");
            }
            
            foreach (var product in _inventory.products)
            {
                if (menuInput != product.code) 
                    continue;
                
                if (product.quantity > 0)
                {
                    if (coinBalance >= product.price)
                    {
                        product.quantity--;
                        coinBalance -= product.price;
                        Console.WriteLine(">>>> THANK YOU <<<<");
                        Console.WriteLine(">>>> RETURNING BALANCE: £" + ReturnCoins() + " <<<<");
                        return;
                    }
                    
                    Console.WriteLine(">>>> PRICE: £" + product.price + " <<<<");
                    Console.WriteLine(">>>> BALANCE: £" + coinBalance + " <<<<");
                    InputCoins();
                }
                else
                {
                    Console.WriteLine(">>>> SOLD OUT <<<<");
                }
            }
        }
    }

    public double ReturnCoins()
    {
        var returnBalance = coinBalance;
        coinBalance = 0;
        
        return returnBalance;
    }
}