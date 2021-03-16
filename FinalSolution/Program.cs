using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace FinalSolution
{
    
    class Program
    {
        private static void Main(string[] args)
        {
            /*var option = new DbContextOptionsBuilder<Models.TradingContext>()
                .UseSqlite(@"Data Source=/tmp/blogging.db").Options;

            var dbcontext = new Models.TradingContext(option); */
            
            //setup our DI to connect the SqLite Data Base
            var serviceProvider = new ServiceCollection()
                .AddLogging().AddDbContextPool<Models.TradingContext>(options => 
                    options.UseSqlite("Data Source=/tmp/blogging.db", builder =>
                {}))
                .AddSingleton<IDatabaseAccess, DatabaseAccess>()
                .AddSingleton<IDBManager, DBManager>()
                 .BuildServiceProvider();
            
            //Setting up the Menu to take the required input
             Console.WriteLine("Welcome to the LendTable SqLite Explorer. Enter the following:");
             Console.WriteLine("1 for Entering A User's Name.");
             Console.WriteLine("2 for querying an Id number.");

             var entry = Console.ReadLine();

             if (entry.Equals("1"))
             {  
                 // Function to Save entry into an sqlite table
                 Console.WriteLine("Enter the name of the User");
                 var name = Console.ReadLine();
                 var dbAccess = serviceProvider.GetService<IDatabaseAccess>();
                 dbAccess.RegisterUser(name);
                 Console.WriteLine("Registration successful");
             }
             
             if (entry.Equals("2"))
             {
                 // Function to Retreive entry from an sqlite table
                 // Possible entries include 5,6,7,8
                 // The program is capable of letting the user know if an iD is invalid.
                 Console.WriteLine("Enter the iD number of the User");
                 var id = Convert.ToInt32(Console.ReadLine());
                 var dbAccess = serviceProvider.GetService<IDatabaseAccess>();

                 var user = dbAccess.GetUser(id);
                 
                 if (user != null)
                 {
                     Console.WriteLine("User is :"+user.Name);
                 }
                 else
                 {
                     Console.WriteLine("User not found");
                 }
             }
             if (entry != "1" && entry !="2")
             {
                 Console.WriteLine("Invalid");
             }

        }
        //Older trials, please ignore (here for educational purposes)
       /* public void Old()
        {
            using (var db = new Models.TradingContext())
            {
                // Create
                Console.WriteLine("Inserting a new person");
                db.Add(new Models.Identity { Name = "Anirudh Nair" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a person");
                var trade1 = db.Identitys
                    .OrderBy(b => b.Id)
                    .First();
                Console.WriteLine(trade1.Name);

                // Update
                Console.WriteLine("Updating the person and adding a trade");
                trade1.Name = "Anirudh Nair";
                trade1.Trades.Add(
                    new Models.Trade { Asset = "BTC", Value = 0.4 });
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");
                db.Remove(trade1);
                db.SaveChanges();
            } 
        } */
    }
}