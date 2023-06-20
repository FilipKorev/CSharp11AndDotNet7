using LoginProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoginProject
{
    internal static class LoginOrCreateUser
    {
        private static string _username;
        private static string _password;
        private static string _confirmPassword;
        private static bool _isLoginCorrect;
        private static bool _isCorrect;
        private static int _role;

        /// <summary>
        /// User login method
        /// </summary>
        public static void Login()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("LogIn:");
            Console.WriteLine("--------------");
            bool _isLoginCorrect = false;
            do
            {
                
                Console.WriteLine("Enter username");
                _username = Console.ReadLine();

                Console.WriteLine("Enter password");
                _password = Console.ReadLine();

                if (isUsernameAllowed(_username) && isPasswordAllowed(_password))
                {
                    User loggedInUser;
                    using(
                        LoginContext context = new LoginContext())
                    {
                        loggedInUser = context.users.FirstOrDefault(u => u.Username == _username && u.Password == _password);
                        //loggedInUser = context.users.Where(u => u.Username == _username && u.Password == _password).FirstOrDefault();
                    }
                    if(loggedInUser != null)
                    {
                        Console.WriteLine($"Welcome {loggedInUser.Username}");
                    }
                    else
                    {
                        Create();
                    }
                    _isLoginCorrect = true;
                }
                else
                {
                    if (!isUsernameAllowed(_username))
                    {
                        Console.WriteLine("Username is incorect!");
                    }
                    if (!isPasswordAllowed(_password))
                    {
                        Console.WriteLine("password is incorect!");
                    }
                }

            } while (!_isLoginCorrect);
        }

        /// <summary>
        /// user create method
        /// </summary>
        public static void Create()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("Create user:");
            Console.WriteLine("--------------");

            _isCorrect = false;
            do
            {

                Console.WriteLine("Enter username");
                _username = Console.ReadLine();

                Console.WriteLine("Enter password");
                _password = Console.ReadLine();

                Console.WriteLine("Confirm password");
                _confirmPassword = Console.ReadLine();

                Console.WriteLine("Select Role: example(Guest = 2, Vip = 3, Regular = 4)");
                _role = Convert.ToInt32(Console.ReadLine());

                if (isUsernameAllowed(_username) && isPasswordAllowed(_password) && _password == _confirmPassword)
                {
                    User createUser;
                    using(LoginContext context = new LoginContext())
                    {
                        createUser = context.users.FirstOrDefault(cu => cu.Username == _username);
                        if(createUser == null)
                        {
                            Role role = context.Roles.FirstOrDefault(r => r.RoleName == (RoleName)_role);
                            if(role == null)
                            {
                                role = context.Roles.FirstOrDefault(r => r.RoleName == (RoleName)2);
                            }
                            context.users.Add(new User() { Username = _username, Password = _password, Role = role });
                            int changes = context.SaveChanges();
                            if(changes > 0)
                            {
                                Login();
                            }
                        }
                    }
                    _isCorrect = true;
                }
                else
                {
                    if (!isUsernameAllowed(_username))
                    {
                        Console.WriteLine("Username is incorect!");
                    }
                    if (!isPasswordAllowed(_password))
                    {
                        Console.WriteLine("password is incorect!");
                    }
                    if (_password != _confirmPassword)
                    {
                        Console.WriteLine("passwords are not the same!");
                    }
                }

            } while (!_isCorrect);
        }

        #region Helpers

        /// <summary>
        /// Determines whether [is password allowed] [the specified password].
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>
        ///   <c>true</c> if [is password allowed] [the specified password]; otherwise, <c>false</c>.
        /// </returns>
        private static bool isPasswordAllowed(string? password)
        {
            Regex regx = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");

            if (regx.IsMatch(password) && !String.IsNullOrEmpty(password))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines whether [is username allowed] [the specified username].
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>
        ///   <c>true</c> if [is username allowed] [the specified username]; otherwise, <c>false</c>.
        /// </returns>
        private static bool isUsernameAllowed(string? username)
        {
            Regex regx = new Regex(@"^(?=[A-Za-z0-9])(?!.*[._()\[\]-]{2})[A-Za-z0-9._()\[\]-]{3,15}$");

            if (regx.IsMatch(username) && !String.IsNullOrEmpty(username))
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}
