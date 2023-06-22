using LoginProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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
                    using (LoginContext context = new LoginContext())
                    {
                        loggedInUser = context.users.Include(u => u.Role).FirstOrDefault(u => u.Username == _username && u.Password == _password);
                        //LoggedInUser = context.users.Where(u => u.Username == _username && u.Password == _password).FirstOrDefault();
                    }
                    if (loggedInUser != null)
                    {
                        Console.WriteLine($"Welcome {loggedInUser.Username} you are {loggedInUser.Role.RoleName}");

                        ChooseAction(loggedInUser.Role.RoleName, loggedInUser.ID);
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
                    using (LoginContext context = new LoginContext())
                    {
                        createUser = context.users.FirstOrDefault(cu => cu.Username == _username);
                        if (createUser == null)
                        {
                            Role role = context.Roles.FirstOrDefault(r => r.RoleName == (RoleName)_role);
                            if (role == null)
                            {
                                role = context.Roles.FirstOrDefault(r => r.RoleName == (RoleName)2);
                            }
                            context.users.Add(new User() { Username = _username, Password = _password, Role = role });
                            int changes = context.SaveChanges();
                            if (changes > 0)
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

        private static void ChooseAction(RoleName rolename, Guid userId)
        {
            int action = 0;

            switch (rolename)
            {
                case RoleName.Admin:
                case RoleName.VIP:

                    {
                        Console.WriteLine("Available actions: 1. List users, 2.Delete, 3.Edit , 4.Exit");
                        Console.WriteLine("Example: 1");

                        try
                        {
                            action = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("__________exception__________");
                            Console.WriteLine(ex.Message);
                            ChooseAction(rolename, userId);
                        }
                        ActionLoader(action, rolename, userId);
                    }
                    break;
                case RoleName.Guest:
                case RoleName.Regular:
                    {
                        Console.WriteLine("Available actions:  2.Delete,3.edit, 4.Exit");
                        Console.WriteLine("Example: 2");

                        try
                        {
                            action = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("__________exception__________");
                            Console.WriteLine(ex.Message);
                            ChooseAction(rolename, userId);
                        }
                        ActionLoader(action, rolename, userId);
                    }
                    break;


            }
        }


        private static void ActionLoader(int action, RoleName rolename, Guid userId)
        {
            switch (action)
            {
                case 1:
                    {
                        if (rolename != RoleName.Guest || rolename != RoleName.Regular)
                        {
                            using (LoginContext context = new LoginContext())
                            {
                                List<User> users = context.users.Include(u => u.Role).ToList();
                                if (users == null)
                                {
                                    Console.WriteLine("No users Found");
                                }
                                else
                                {
                                    Console.WriteLine("| {0,5} | {1,15} | {2,10} |", "nr.", "Username", "Role");
                                }
                                foreach (User user in users)
                                {
                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine("| {0,5} | {1,15} | {2,10} |", users.IndexOf(user) + 1, user.Username, user.Role.RoleName);

                                }
                            }
                        }
                        ChooseAction(rolename, userId);
                    }
                    break;
                case 2:
                    {
                        if (rolename == RoleName.Admin)
                        {
                            Console.WriteLine("Enter the username you want to delete");
                            string username = Console.ReadLine();
                            User user = null;
                            using (LoginContext context = new LoginContext())
                            {
                                user = context.users.FirstOrDefault(u => u.Username == username);
                                if (user == null)
                                {
                                    Console.WriteLine("This user thoesn't exist");
                                }
                                else
                                {
                                    context.users.Remove(user);
                                    int changes = context.SaveChanges();
                                    if (changes > 0)
                                    {
                                        Console.WriteLine($"The user {user.Username} is deleted!");
                                        Console.WriteLine("");
                                    }
                                }
                            }
                            ChooseAction(rolename, userId);
                        }
                        else
                        {
                            User user = null;
                            using (LoginContext context = new LoginContext())
                            {
                                user = context.users.FirstOrDefault(u => u.ID == userId);

                                if (user == null)
                                {
                                    Console.WriteLine("This user thoesn't exist");
                                }
                                else
                                {
                                    context.users.Remove(user);
                                    int changes = context.SaveChanges();
                                    if (changes > 0)
                                    {
                                        Console.WriteLine($"The user {user.Username} is deleted!");
                                        Console.WriteLine("");
                                    }
                                }
                            }
                            Login();
                        }

                    }
                    break;
                case 3: //Da se smeni i ROle za domasna
                    {
                        Console.WriteLine("Choose option: 1.Change username, 2.Change password, 3.Cancel");
                        try
                        {
                            int option = Convert.ToInt32(Console.ReadLine());

                            switch (option)
                            {
                                case 1:
                                    {
                                        User user = null;

                                        using (LoginContext context = new LoginContext())
                                        {
                                            user = context.users.FirstOrDefault(u => u.ID == userId);
                                            if (user == null)
                                            {
                                                Console.WriteLine("user with this ID doesn't exist");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter your new username");
                                                string newUserName = Console.ReadLine();
                                                if (isUsernameAllowed(newUserName))
                                                {
                                                    user.Username = newUserName;

                                                    context.users.Update(user);
                                                    int changes = context.SaveChanges();
                                                    if (changes > 0)
                                                    {
                                                        Console.WriteLine("Your new username is:" + newUserName);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("username did't change");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case 2:
                                    {
                                        User user = null;

                                        using (LoginContext context = new LoginContext())
                                        {
                                            user = context.users.FirstOrDefault(u => u.ID == userId);
                                            if (user == null)
                                            {
                                                Console.WriteLine("user with this ID doesn't exist");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter your new password");
                                                string newPassword = Console.ReadLine();

                                                Console.WriteLine("Confirm your new password");
                                                string confirmNewPassword = Console.ReadLine();

                                                if (isPasswordAllowed(newPassword) && newPassword == confirmNewPassword)
                                                {
                                                    user.Password = newPassword;

                                                    context.users.Update(user);
                                                    int changes = context.SaveChanges();
                                                    if (changes > 0)
                                                    {
                                                        Console.WriteLine("password changed succsesfully:");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("password did't change");
                                                    }
                                                }
                                                else if (!isPasswordAllowed(newPassword))
                                                {
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Password is now allowed");
                                                    ActionLoader(3, rolename, userId);
                                                }
                                                else if (newPassword != confirmNewPassword)
                                                {
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Password did't match");
                                                    ActionLoader(3, rolename, userId);
                                                }
                                            }
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                            ChooseAction(rolename, userId);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("selected wrong option");
                            ActionLoader(3, rolename, userId);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

    }
}
