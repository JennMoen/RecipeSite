using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using RecipeApp.Repositories;

namespace RecipeApp.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var catRepo = serviceProvider.GetService<CategoryRepo>();
            var db = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            db.Database.EnsureCreated();

            // Ensure admin (IsAdmin)
            var Admin = await userManager.FindByNameAsync("admin@gmail.com");
            if (Admin == null)
            {
                // create user
                Admin = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com"
                };
                await userManager.CreateAsync(Admin, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(Admin, new Claim("IsAdmin", "true"));
            }

            // Ensure non-admin (not IsAdmin)
            var NonAdmin = await userManager.FindByNameAsync("nonadmin@gmail.com");
            if (NonAdmin == null)
            {
                // create user
                NonAdmin = new ApplicationUser
                {
                    UserName = "nonadmin@gmail.com",
                    Email = "nonadmin@gmail.com"
                };
                await userManager.CreateAsync(NonAdmin, "Secret123!");
            }

            if (!db.Categories.Any())
            {
                db.Categories.AddRange(
                    new Category()
                    {
                        Name = "Breakfast and Brunch"
                    },
                    new Category()
                    {
                        Name = "Appetizers/Snacks"
                    },
                    new Category()
                    {
                        Name = "Soups"
                    },
                    new Category()
                    {
                        Name = "Salads"
                    },
                     new Category()
                     {
                         Name = "Breads"
                     },
                     new Category()
                     {
                         Name = "Pizzas/Pastas/Tasty Carbs"
                     },
                     new Category()
                     {
                         Name = "Sides"
                     },
                     new Category()
                     {
                         Name = "Birds"
                     },
                     new Category()
                     {
                         Name = "Beasts"
                     },
                     new Category()
                     {
                         Name = "Seafood"
                     },
                     new Category()
                     {
                         Name = "Vegetables"
                     },
                     new Category()
                     {
                         Name = "Desserts"
                     },
                     new Category()
                     {
                         Name = "Rubs and Marinaes"
                     },
                     new Category()
                     {
                         Name = "Drinks"
                     },
                     new Category()
                     {
                         Name = "Everything Else"
                     });


            }

            db.SaveChanges();

            if (!db.Menus.Any())
            {
                db.Menus.AddRange(
                    new Menu()
                    {
                        Name = "Comfort Food Fest",
                        User = NonAdmin,
                        MenuItems = new List<Recipe>()
                        {
                            new Recipe()
                    {
                        Title = "Mac N Cheese",
                        TimeToMake = "30 min",
                        User = NonAdmin,
                        CatId = catRepo.GetCatByName("Pizzas/Pastas/Tasty Carbs").First().Id,
                        ImageUrl = "../images/Bistro-Mac-Cheese.jpg",
                        Notes = "Be sure to add cheese slowly off heat so that it doesn't seize",
                        Ingredients = new List<Ingredient>()
                        {
                            new Ingredient()
                            {
                                Name="Milk",
                                Amount="1 cup"
                            },
                            new Ingredient()
                            {
                                Name="Butter",
                                Amount="1 Tablespoon"
                            },
                            new Ingredient()
                            {
                                Name="Velveeta",
                                Amount="1 block"
                            },
                            new Ingredient()
                            {
                                Name="Pasta",
                                Amount="1 bag"
                            },
                             new Ingredient()
                            {
                                Name="Shredded cheddar",
                                Amount="2 cups"
                            },

                        },

                        Steps = new List<Step>()
                            {
                                new Step()
                                {
                                    Description="Bring a large pot of salted water to a boil"
                                },
                                 new Step()
                                {
                                     Description="Add pasta and cook until a few minutes before package time says"
                                },
                                  new Step()
                                {
                                      Description="Melt velveeta according to package directions in a pot large enough to hold cooked pasta"
                                },
                                   new Step()
                                {
                                       Description="When pasta is a few minutes away from desired doneness, scoop into pot of velveeta"
                                },
                                 new Step()
                                {
                                     Description="Let velveeta and pasta mixture simmer very gently for a few minutes"
                                },
                                    new Step()
                                {
                                    Description="Take off heat and slowly stir in shredded cheese, a little at a time"
                                }
                            }


                    },

                            new Recipe()
                    {
                        Title = "Cheater's Piza",
                        TimeToMake = "30 min",
                        User =  NonAdmin,
                        CatId = catRepo.GetCatByName("Pizzas/Pastas/Tasty Carbs").First().Id,
                        ImageUrl = "../images/pizza.jpg",
                        Notes = "Who would think a frozen pizza could taste so awesome?",
                        Ingredients = new List<Ingredient>()
                        {
                            new Ingredient()
                            {
                                Name="Frozen pizza",
                                Amount="as many as you need"
                            },
                            new Ingredient()
                            {
                                Name="Assorted cheeses/veg/spices",
                                Amount="This is really your call.  Use what you like"
                            }
                        },
                        Steps = new List<Step>()
                            {
                                new Step()
                                {
                                    Description="Add fresh mozzarella, provolone, or any other cheese to supplement the skimpy amount you usually get"
                                },
                                 new Step()
                                {
                                     Description="Add toppings: slivered salami, olives, good anchovies, pepper flakes, and a drizzle of high-quality olive oil can cover up a mediocre crust and sad frozen veggies"
                                },
                                 new Step()
                            {
                                Description="Bake pizza according to package directions.  I like to use a really hot pizza stone to get the crust extra crisp"
                                 }
                        }

                        }
                        }

                    });



                db.SaveChanges();
            }

        }
    }
}


