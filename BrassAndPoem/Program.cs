//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

using System.Net;
using System.Runtime.InteropServices;

List<Product> products = new List<Product>
{
    new Product
    {
        Name = "Trumpet",
        Price = 150.99M,
        ProductTypeId = 1,
    },
    new Product
    {
        Name = "Trombone",
        Price = 246.99M,
        ProductTypeId = 1,
    },
    new Product
    {
        Name = "Tuba",
        Price = 1250.99M,
        ProductTypeId = 1,
    },
    new Product
    {
        Name = "Ozymandias",
        Price = 12350.99M,
        ProductTypeId = 2,
    },
    new Product
    {
        Name = "Leaves of Grass",
        Price = 15650.99M,
        ProductTypeId = 2,
    },
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List.
List<ProductType> productTypes = new List<ProductType>
{
    new ProductType { Id = 1, Title = "Brass" },
    new ProductType { Id = 2, Title = "Poem" },
};

//put your greeting here

string greeting = "Welcome to Verses & Brass - Where Poetry Meets Music!";
Console.WriteLine(greeting);

//implement your loop here

string choice = null;
while (choice != "5")
{
    DisplayMenu();
    choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            DisplayAllProducts(products, productTypes);
            break;
        case "2":
            DeleteProduct(products, productTypes);
            break;
        case "3":
            AddProduct(products, productTypes);
            break;
        case "4":
            UpdateProduct(products, productTypes);
            break;
        case "5":
            Console.WriteLine("Thank you for visiting Verses and Brass!");
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.WriteLine();
            break;
    }
}

void DisplayMenu()
{
    Console.WriteLine(
        @"1. Display all products
2. Delete a product
3. Add a new product
4. Update product properties
5. Exit"
    );
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    if (products.Count == 0)
    {
        Console.WriteLine("No products in inventory!");
        return;
    }
    var productsWithTypes = products.Select(
        (product, index) =>
            new
            {
                Number = index + 1,
                Product = product,
                TypeName = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId)?.Title
                    ?? "Unknown Type",
            }
    );
    foreach (var item in productsWithTypes)
    {
        Console.WriteLine(
            $"{item.Number}. {item.Product.Name} ({item.TypeName}) - ${item.Product.Price}"
        );
    }
    Console.WriteLine("\nPress any key to continue...");
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    if (products.Count == 0)
    {
        Console.WriteLine("There are no products to delete at this time.");
        return;
    }
    DisplayAllProducts(products, productTypes);
    Product chosenProduct = null;
    int chosenIndex = -1;

    while (chosenProduct == null)
    {
        Console.WriteLine("\nPlease enter the number of the product you want to delete:");
        int response = int.Parse(Console.ReadLine().Trim());
        chosenIndex = response - 1;

        if (chosenIndex >= 0 && chosenIndex < products.Count)
        {
            chosenProduct = products[chosenIndex];
        }
        else
        {
            Console.WriteLine("Please choose a valid product number.");
        }
    }
    products.RemoveAt(chosenIndex);
    Console.WriteLine($"{chosenProduct.Name} has been deleted.");
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Enter product name: ");
    string name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
        return;
    }

    decimal price = 0;
    Console.WriteLine("Enter price: ");
    while (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
    {
        Console.WriteLine("Please enter a valid number.");
    }
    Console.WriteLine("\nProduct Types: ");
    foreach (var line in productTypes.Select((pt, index) => $"Id: {index + 1} {pt.Title}"))
    {
        Console.WriteLine(line);
    }
    int typeId = 0;
    while (true)
    {
        Console.WriteLine("Please enter product Id");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int choice) || choice < 1 || choice > productTypes.Count)
        {
            Console.WriteLine("Please enter a valid product Id.");
            continue;
        }
        typeId = productTypes[choice - 1].Id;
        break;
    }
    //The [] is array/list indexing syntax in C# - it's how you access a specific element in a list or array by its position. [i]
    Product newProduct = new Product
    {
        Name = name,
        Price = price,
        ProductTypeId = typeId,
    };
    products.Add(newProduct);
    Console.WriteLine("\nProduct added successfully!");
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    if (products.Count == 0)
    {
        Console.WriteLine("No products to update.");
        return;
    }

    DisplayAllProducts(products, productTypes);
    Product chosenProduct = null;
    int chosenIndex = -1;

    while (chosenProduct == null)
    {
        Console.WriteLine("\nPlease enter the number of the product you want to update:");
        int response = int.Parse(Console.ReadLine().Trim());
        chosenIndex = response - 1;

        if (chosenIndex >= 0 && chosenIndex < products.Count)
        {
            chosenProduct = products[chosenIndex];
        }
        else
        {
            Console.WriteLine("Please choose a valid product number.");
        }
    }

    Console.Write("Enter new product name (or press Enter to keep current product name): ");
    string name = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(name))
    {
        chosenProduct.Name = name;
    }

    Console.Write("Enter new price (or press Enter to keep current price): ");
    string priceInput = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(priceInput))
    {
        if (decimal.TryParse(priceInput, out decimal price) && price >= 0)
        {
            chosenProduct.Price = price;
        }
    }
    Console.WriteLine("Product updated successfully!");
}

// don't move or change this!
public partial class Program { }
