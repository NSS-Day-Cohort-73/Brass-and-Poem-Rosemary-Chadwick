//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

List<Product> products = new List<Product>
{
    new Product
    {
        Name = "Bach Stradivarius Trumpet",
        Price = 2899.99m,
        ProductTypeId = 1,
    },
    new Product
    {
        Name = "Yamaha Professional Trombone",
        Price = 3299.99m,
        ProductTypeId = 1,
    },
    new Product
    {
        Name = "Student French Horn",
        Price = 1499.99m,
        ProductTypeId = 1,
    },
    new Product
    {
        Name = "Beginner Euphonium",
        Price = 1299.99m,
        ProductTypeId = 1,
    },
    new Product
    {
        Name = "Professional Tuba",
        Price = 6999.99m,
        ProductTypeId = 1,
    },
    new Product
    {
        Name = "Collected Works of Emily Dickinson",
        Price = 24.99m,
        ProductTypeId = 2,
    },
    new Product
    {
        Name = "Modern Love: Contemporary Verses",
        Price = 19.99m,
        ProductTypeId = 2,
    },
    new Product
    {
        Name = "Sonnets Through the Ages",
        Price = 29.99m,
        ProductTypeId = 2,
    },
    new Product
    {
        Name = "Haiku Masters Collection",
        Price = 15.99m,
        ProductTypeId = 2,
    },
    new Product
    {
        Name = "The Art of Poetry: Anthology",
        Price = 34.99m,
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
    Console.WriteLine();
    Console.WriteLine(
        @"Choose an option:
        1. Display All Products
        2. Delete a Product
        3. Add a New Product
        4. Update Product properties
        5. Exit"
    );
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    throw new NotImplementedException();
}

// don't move or change this!
public partial class Program { }
