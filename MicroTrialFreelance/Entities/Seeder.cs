using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using MicroTrialFreelance.Data;
using MicroTrialFreelance.Models;

namespace MicroTrialFreelance.Entities
{
    public class Seeder
    {
        public static async Task SeedDataAsync(IServiceProvider services,
            IWebHostEnvironment env, IConfiguration config)
        {
            try
            {
                using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                    var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    string email;
                    DbUser? user;
                    var result = managerRole.CreateAsync(new DbRole
                    {
                        Name = "Admin"
                    }).Result;

                    result = managerRole.CreateAsync(new DbRole
                    {
                        Name = "User"
                    }).Result;

                    result = managerRole.CreateAsync(new DbRole
                    {
                        Name = "Manager"
                    }).Result;

                    email = "admin@gmail.com";
                    user = await manager.FindByEmailAsync(email);
                    if (user == null)
                    {
                        user = new DbUser
                        {
                            Email = email,
                            FirstName = "Валадій",
                            LastName = "Фугель",
                            UserName = email,
                            Messager = "https://t.me/vlad",
                            PhoneNumber = "+380476758769",
                            Birthday = "12-05-1991",
                            FinishedOrders = 2,
                            GitHubPageLink = "https//github.com"
                        };
                        result = manager.CreateAsync(user, "@123Admin").Result;
                        result = manager.AddToRoleAsync(user, "Admin").Result;
                        context.SaveChanges();
                    }

                    email = "manager@gmail.com";
                    user = await manager.FindByEmailAsync(email);
                    if (user == null)
                    {
                        user = new DbUser
                        {
                            Email = email,
                            FirstName = "Діма",
                            LastName = "Авдейчик",
                            Messager = "https://t.me/dima",
                            UserName = email,
                            PhoneNumber = "+380493438481",
                            Birthday = "19-12-4995",
                            FinishedOrders = 1,
                            GitHubPageLink = "https//github.com"
                        };
                        result = manager.CreateAsync(user, "@123Manager").Result;
                        result = manager.AddToRoleAsync(user, "Manager").Result;

                        context.SaveChanges();
                    }

                    email = "user@gmail.com";
                    user = await manager.FindByEmailAsync(email);
                    if (user == null)
                    {
                        user = new DbUser
                        {
                            Email = email,
                            FirstName = "Даша",
                            LastName = "Дем'янчук",
                            Messager = "https://t.me/dasha",
                            UserName = email,
                            PhoneNumber = "+380476758769",
                            Birthday = "97-98-0990",
                            FinishedOrders = 0,
                            GitHubPageLink = "https//github.com"
                        };
                        result = manager.CreateAsync(user, "@123User").Result;
                        result = manager.AddToRoleAsync(user, "User").Result;

                        context.SaveChanges();
                    }

                    if (!context.Orders.Any())
                    {
                        var orders = new List<Order>
                {
                    new Order
                    {

                        Name = "Дороблення сайту",
                        Difficulty = 4,
                        Status = 1,
                        OwnerId = 1,
                        ExampleLink="https://phasmophobia.fandom.com/ru/wiki/%D0%94%D0%B5%D1%82%D0%B5%D0%BA%D1%82%D0%BE%D1%80_%D0%AD%D0%9C%D0%9F_(%D1%83%D1%80._5)",
                        GitHubLink="https://github.com/dotnet/efcore/issues/20549",
                        DbLink="",
                        PostDate="05-07-2023",
                        MainTask = "Зробити взаємодію на сайті",
                        SecondaryTasks = "Відреданувати баги при маштабуванні",
                        Description = "Потрібно зробити сайт з інформацію про ігровий свіи, лор, предмети і інше. Зараз він готовий, але є деякі баги і не повністю реалізована взаємодія."
                    },
                    new Order
                    {
                        Name = "Програма",
                        Difficulty = 1,
                        Status = 3,
                        OwnerId = 2,
                        ExampleLink="",
                        GitHubLink="",
                        PostDate="17-09-2023",
                        DbLink="",
                        MainTask = "Зробити програму яка буде робити роботу для ШІ і тим самим навантажувати і сповільнювати його",
                        SecondaryTasks = "Збити її кросплатформовою",
                        Description = "Я хочу помститися openAI за те, що зробили бота, який забрав мою роботу"
                    },
                    new Order
                    {
                        Name = "Клон ютуба",
                        Difficulty = 5,
                        Status = 1,
                        OwnerId = 3,
                        PostDate="30-01-2023",
                        ExampleLink="https://www.youtube.com/",
                        GitHubLink="https://www.guthib.com/",
                        DbLink="https://www.youtube.com/",
                        MainTask = "Зробити повністю сайт",
                        SecondaryTasks = "Просунути його в топи",
                        Description = "Хочу нагнути ютуб і зайняти його місце на ринку онлайн розваг."
                    },
                                        new Order
                    {

                        Name = "Лабораторна з програмування",
                        Difficulty = 2,
                        Status = 1,
                        OwnerId = 1,
                        ExampleLink="",
                        GitHubLink="",
                        DbLink="https://www.dbcon.com/",
                        PostDate="05-07-2023",
                        MainTask = "Підклчити базу даних до простого сайту",
                        SecondaryTasks = "Бажано використати прості методи щоб я зміг розповісти про них.",
                        Description = "Потрібно зробити простий сайт з виведеною інформацію яка лежить у базі даних, яку створив викладач."
                    },

                };
                        context.Orders.AddRange(orders);
                        context.SaveChanges();
                    }
                    if (!context.Solutions.Any())
                    {
                        var solutions = new List<Solution>
                {
                    new Solution
                    {
                        CreatorId = 1,
                         Description="Зробив простеську прогу клікер який генерує запити поки не отримає бан від бота. Якщо додасте кілька акаунтів то перейде на інший і продовжить до моменту найближчого розблокування одного з акаунтів.",
                          GitHubLink = "https://www.guthib.com/",
                           OrderId = 2
                    },
                     new Solution
                    {
                        CreatorId = 3,
                         Description="Накидав невелику взаємодію і є деякі питання, у меседжері вже пробую зв'язатися.",
                          GitHubLink = "https://www.guthib.com/",
                           OrderId = 1
                    },
                };
                        context.Solutions.AddRange(solutions);
                        context.SaveChanges();
                    }
                    if (!context.Messages.Any())
                    {
                        var messages = new List<Message>
                {
                    new Message
                    {
                        UserId = 1,
                         isRead = false,
                          MesText = "Дорогий користувач, ваше замовлення 'Дороблення сайту' має нове рішення.",
                           MesType = 1,
                            PostDate="05.12.2023", 
                             SolutionId=2,
                    },
                     new Message
                    {
                        UserId = 2,
                         isRead = false,
                          MesText = "Дорогий користувач, ваше замовлення 'Програма' має нове рішення.",
                           MesType = 1,
                            PostDate="27.11.2023",
                             SolutionId=1,
                    },
                            new Message
                    {
                        UserId = 1,
                         isRead = false,
                          MesText = "Дорогий користувач, ваш аккаунт має низький рівень безпеки, пропонуємо вам змінити пароль.",
                           MesType = 2,
                            PostDate="29.11.2023",
                             SolutionId=0,
                    },
                };
                        context.Messages.AddRange(messages);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
