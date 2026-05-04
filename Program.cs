using System.Net.Http.Headers;
public class Product
{
    public string Name { get; set; }

    public Product(string name)
    {
        Name = name;
    }
}public class Program
{
	public async Task DownloadDataAsync()
    {
        try
        {
            Console.WriteLine("Download started...");
            throw new InvalidOperationException("Simulated download error.");
            await Task.Delay(3000);
            Console.WriteLine("Download completed.");
            
        }
        catch(Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        
    }
    public async Task DownloadDataAsync2()
    {
        Console.WriteLine("Download 2 started...");
        await Task.Delay(2000);
        Console.WriteLine("Download 2 completed.");
    }
    public async Task<List<Product>> FetchProductsAsync()
    {
        await Task.Delay(2000);
        return new List<Product>
        {
            new Product("Eco Bag"),
            new Product("Reusable Straw")
        };
    }
     public async Task DisplayProductsAsync()
    {
        List<Product> products = await FetchProductsAsync();
        foreach (Product product in products)
        {
            Console.WriteLine(product.Name);
        }
    }
    public static async Task Main(string[] args)
    {
        Program program = new Program();
        Task task1 = program.DownloadDataAsync();
        Task task2 = program.DownloadDataAsync2();
        Task task3 = program.DisplayProductsAsync();
        await Task.WhenAll(task1, task2, task3);
        Console.WriteLine("Main method completed.");

    }
}