using System.Security.Cryptography.X509Certificates;
using Red_and_Abe;

List<ProductTypeId> productTypes = new List<ProductTypeId>()
{
   new ProductTypeId()
   {
       Id = 1,
       CatName = "Apparel"
   },
   new ProductTypeId()
   {
       Id = 2,
       CatName = "Potion"
   },
   new ProductTypeId()
   {
       Id= 3,
       CatName = "Enchanted Object"
   },
   new ProductTypeId()
   {
        Id = 4,
        CatName = "Wand"
   }
};

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Invisibility Cloak",
        Price = 5000.00M,
        Available = true,
        TypeId = 3
    },
    new Product()
    {
        Name = "Witch's Hat",
        Price = 20.00M,
        Available = true,
        TypeId = 1
    },
    new Product()
    {
        Name = "Blackthorn Wand",
        Price = 75.00M,
        Available = false,
        TypeId = 4
    },
    new Product()
    {
        Name = "Remembrall",
        Price = 45.00M,
        Available = false,
        TypeId = 3
    },
    new Product()
    {
        Name = "Felix Felicis",
        Price = 150.00M,
        Available = true,
        TypeId = 2
    },
    new Product()
    {
        Name = "Polyjuice Potion",
        Price = 55.00M,
        Available = false,
        TypeId = 2
    }
};

// METHODS

// READ - View Products
void ViewProducts()
{
    Console.WriteLine("All Products:");
    foreach (Product product in products)
    {
        Console.WriteLine(@$"   -- {product.Name} --
        Cost: {product.Price} USD 
        TypeId: {product.TypeId}
        Availablity: {(product.Available ? "Unavailable" : "Available")}");
    }
}

// View Product Types

void ViewProductTypeId()
{
    Console.WriteLine("Product Type Id:");
    foreach (ProductTypeId productType in productTypes)
    {
        Console.WriteLine($"{productType.Id}. {productType.CatName}");
    }
}
// READ - ViewAvailableProducts()
// AddProduct()
void AddProduct()
{
    Console.WriteLine(@" -- ADD A PRODUCT --
Enter New Product Name:");
    string createName = Console.ReadLine().Trim();

    Console.WriteLine("Enter Product Price:");
    decimal createPrice = Convert.ToDecimal(Console.ReadLine());

    Console.WriteLine("Is this product available for sale? (True or False)");
    bool createAvailable = Convert.ToBoolean(Console.ReadLine().ToLower().Trim());

    Console.WriteLine("Select a Product Type:");
    ViewProductTypeId();
    int createTypeId = Convert.ToInt32(Console.ReadLine());

    Product createProduct = new Product();
    {
        createProduct.Name = createName;
        createProduct.Price = createPrice;
        createProduct.Available = createAvailable;
        createProduct.TypeId = createTypeId;
    }

    products.Add(createProduct);
    Console.WriteLine("Your product has been added!");
}
// DeleteProduct()
// UpdateProduct()
// SearchProductTYP()

// APP

// Greeting and Menu
string greeting = @"----Welcome to Reductio and Absurdum!----
Providers of High-Quality Magical Supplies";

Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option to continue:
            0. Exit
            1. View All Products
            2. Add a Product
            3. Delete a Product
            4. Update a Product
            5. Search for a Product
            6. View all Available Products");

    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ViewProducts();
    }
    else if (choice == "2")
    {
        AddProduct();
    }
    else if (choice == "3")
    {
        Console.WriteLine("Delete a Product");
        // DeleteProduct();
    }
    else if (choice == "4")
    {
        Console.WriteLine("Update a Product");
        // UpdateProduct();
    }
    else if (choice == "5")
    {
        Console.WriteLine("Search Products");
        // SearchProductType();
    }
    else if (choice == "6")
    {
        Console.WriteLine("View Available Products");
        // ViewAvailableProducts();
    }
}