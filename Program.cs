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
        TypeId = 3,
        DateStocked = new DateTime(2023, 11, 20)
    },
    new Product()
    {
        Name = "Witch's Hat",
        Price = 20.00M,
        Available = true,
        TypeId = 1,
        DateStocked = new DateTime(2023, 12, 20)
    },
    new Product()
    {
        Name = "Blackthorn Wand",
        Price = 75.00M,
        Available = false,
        TypeId = 4,
        DateStocked = new DateTime(2023, 10, 12)
    },
    new Product()
    {
        Name = "Remembrall",
        Price = 45.00M,
        Available = false,
        TypeId = 3,
        DateStocked = new DateTime(2023, 1, 19)
    },
    new Product()
    {
        Name = "Felix Felicis",
        Price = 150.00M,
        Available = true,
        TypeId = 2,
        DateStocked = new DateTime(2022, 11, 20)
    },
    new Product()
    {
        Name = "Polyjuice Potion",
        Price = 55.00M,
        Available = false,
        TypeId = 2,
        DateStocked = new DateTime(2023, 7, 1)
    }
};

// METHODS

// READ - View Products
void ViewProducts()
{
    Console.WriteLine("All Products:");
    for (int i = 0; i < products.Count; i ++)
    {
        Console.WriteLine(@$"   -- {i + 1} {products[i].Name} --
        Cost: {products[i].Price} USD 
        TypeId: {products[i].TypeId}
        Availablity: {(products[i].Available ? "Unavailable" : "Available")}
        Days on Shelf: {products[i].DaysOnShelf}");
    }
}

// Listed Products

void ListProducts()
{
    Console.WriteLine("All Products");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
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
// Delete a Product

void DeleteProduct()
{
    Console.WriteLine(@" -- DELETE A PRODUCT -- 
    Choose a product to delete:");
    ListProducts();

    Product chosen = null;
    
    while (chosen == null) 
    {
        Console.WriteLine("Please enter the product number you wish to delete:");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosen = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integars!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Please follow the prompt!");
        }

    }
    Console.WriteLine($@"Are you sure you want to delete {chosen.Name}?
                        1. Yes
                        2. No");
    string choice = null;

    choice = Console.ReadLine();

    if (choice == "1")
    {
        products.Remove(chosen);
        Console.WriteLine($"{chosen.Name} has been deleted.");
    }
    else if (choice == "2")
    {
        Console.WriteLine($"Nevermind!");
    }
    else
    {
        Console.WriteLine($"Invalid Entry");
    }
}
// Update Product

void UpdateProduct()
{
    Console.WriteLine(@" -- EDIT PRODUCT --
    Choose a product to edit:");

    ListProducts();

    Product chosen = null;

    while (chosen == null)
    {
        Console.WriteLine("Please enter the product number you wish to edit:");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosen = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integars!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Please follow the prompt!");
        }
    }

    Console.WriteLine($@"Which would you like to edit?
                        1. Name: {chosen.Name}
                        2. Price: {chosen.Price}
                        3. Availablity: {chosen.Available}
                        4. Type Id: {chosen.TypeId}");

    string answer = Console.ReadLine();
    decimal priceAnswer = 0M;
    bool availAnswer = true;
    int idAnswer = 0;

    if (answer == "1")
    {
        Console.WriteLine("Please enter the updated name:");
        answer = Console.ReadLine();
        chosen.Name = answer;
        Console.WriteLine("Your product name has been updated!");
    } else if (answer == "2")
    {
        Console.WriteLine("Please enter the updated price:");
        priceAnswer = Convert.ToDecimal(Console.ReadLine());
        chosen.Price = priceAnswer;
        Console.WriteLine("Your product availability has been updated!");
    } else if (answer == "3")
    {
        Console.WriteLine("Please enter the updated availability (true / false):");
        availAnswer = Convert.ToBoolean(Console.ReadLine().ToLower().Trim());
        chosen.Available = availAnswer;
        Console.WriteLine("Your product availability has been updated!");
    } else if (answer == "4")
    {
        Console.WriteLine("Please choose an updated type Id:");
        ViewProductTypeId();
        idAnswer = Convert.ToInt32(Console.ReadLine());
        chosen.Price = idAnswer;
        Console.WriteLine("Your product type Id has been updated!");
    }
}

// SearchProductType()
 

void SearchForProduct()
{
    Console.WriteLine("Enter the TypeId you would like to see:");
    ViewProductTypeId();

    int response = int.Parse(Console.ReadLine());

    List<Product> matchingProducts = products.Where(p => p.TypeId == response).ToList();
    Console.WriteLine("Here are the requested products:");
    foreach (Product product in matchingProducts)
    {
        Console.WriteLine($"{product.Name}");
    }
}

// View Available Products
void ViewAvailableProducts()
{
    List<Product> unsoldProducts = products.Where(p => !p.Available).ToList();
    foreach (Product product in unsoldProducts)
    {
        Console.WriteLine($"{product.Name}");
    }
}


// Greeting and Menu

string greeting = @"---- Welcome to Reductio and Absurdum! ----
Providers of High-Quality Magical Supplies";
string choice = null;

Console.WriteLine(greeting);
while (choice != "0")
    {
        Console.WriteLine(@"Choose an option to continue:
            0. Exit
            1. View All Products
            2. Add a Product
            3. Delete a Product
            4. Edit a Product
            5. Search for a Product by Type
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
            DeleteProduct();
        }
        else if (choice == "4")
        {
            UpdateProduct();
        }
        else if (choice == "5")
        {
            SearchForProduct();
        }
        else if (choice == "6")
        {
            ViewAvailableProducts();
        }
    }
