using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// @Karaotkelskiy
namespace ControlWork
{
    class Program
    {
        static void Main(string[] args)
        {



            int usersChouse;
            Console.WriteLine("Введите \n 1-Регистрация \n 2-Вход");
            while (true)
            {
                try
                {
                    usersChouse = int.Parse(Console.ReadLine());
                    if (usersChouse == 1 || usersChouse == 2)
                        break;
                    else
                    {
                        Console.WriteLine("Данные введены неверно!");
                        Console.WriteLine("Введите еще раз");
                        Console.WriteLine(2);
                    }
                      
                }
                catch (Exception)
                {
                    Console.WriteLine(1);
                    Console.WriteLine("Данные введены неверно!");
                    Console.WriteLine("Введите еще раз");
                }
                
            }

            if (usersChouse == 1)
            {
                User user = new User();
                Console.WriteLine("Введите ваше имя:");
                while (true)
                {
                    user.FullName = Console.ReadLine();
                    if (user.FullName.Length == 0)
                    {
                        Console.WriteLine("Имя должно состоять хотябы из одного символа!");
                        Console.WriteLine("Введите еще раз!");
                    }
                    else
                    {
                        break;
                    }
                }

                Console.WriteLine("Введите ваш возраст:");
                while (true)
                {
                    int age;
                    if (Int32.TryParse(Console.ReadLine(), out age))
                    {
                        if (age > 0 && age < 120)
                        {
                            user.Age = age;
                            break;
                        }
                    }
                    Console.WriteLine("Данные введены неверно!");
                }

                Console.WriteLine("Введите пароль");
                while (true)
                {
                    user.Password += Console.ReadLine();
                    if (user.Password.Length < 6)
                    {
                        Console.WriteLine("Пароль не должен состоять из менее 6 символов!");
                    }
                    else
                    {
                        break;
                    }
                }

                Console.WriteLine("Введите Email");

                while (true)
                {
                    user.Email = Console.ReadLine();
                    int dogPosition = user.Email.IndexOf("@");
                    int dotPosition = user.Email.LastIndexOf(".");
                    if (dogPosition < dotPosition)
                    {
                        break;
                    }
                    Console.WriteLine("Неверный ввод!");
                    Console.WriteLine("Введите еще раз!");
                }

                Console.WriteLine("Введите номер телефона:");
                Console.WriteLine("Формат: +7-000-111-22-33");
                while (true)
                {
                    user.Phone = Console.ReadLine();
                    if (user.Phone.Length == 16)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод!");
                    }
                }

                UserController registrationService = new UserController();
                registrationService.FindSimilarUser(user.Email);
                Console.Read();
                registrationService.Register(user);
            }
            else
            {
                UserController userController = new UserController();
                while (true)
                {
                    Console.WriteLine("Введите Ваш Email");
                    string email = Console.ReadLine();
                    Console.WriteLine("Введите пароль");
                    string password = Console.ReadLine();
                    if (userController.IsUserExists(email, password))
                    {
                        Console.WriteLine($"Добро пожаловать, {userController.GetUserFromEmail(email)}");
                        break;
                    }


                }

            }
            Console.WriteLine("Для выхода введите enter");

            Console.ReadLine();
        }
    }
}
