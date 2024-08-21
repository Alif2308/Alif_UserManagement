using Services.Dtos;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace UserManagement.UserInterfaces
{
    public static class AdminPage
    {
        private static LoginService loginService = LoginService.Instance;
        private static MemberService memberService = MemberService.Instance;
        private static LoginInfo loginInfo = loginService.GetLoginInfo();

        private static List<string> options = new List<string>()
        {
            "Add member account",
            "Disable member account",
            "Change Member Password",
            "Logout"
        };

        public static void Start()
        {
            while (loginInfo.IsLoggedIn)
            {
                var choice = Helpers.GetChoice(options);

                if (choice == options.Count)
                {
                    loginService.Logout();
                    Console.WriteLine("You've logged out.");
                    continue;
                }

                if (choice == 1)
                {
                    try
                    {
                        Console.WriteLine("Enter member username:");
                        var username = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Enter member password:");
                        var password = Console.ReadLine();

                        if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                            continue;

                        memberService.AddNewMember(username, password);
                    }
                    catch(Exception ex)
                    {
                        continue;
                    }
                }

                if (choice == 2)
                {
                    try
                    {
                        Console.WriteLine("Enter member username:");
                        var username = Console.ReadLine();
                        Console.WriteLine();
                        
                        memberService.DisableMember(username);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }

                if (choice == 3)
                {
                    try
                    {
                        Console.WriteLine("Enter member username:");
                        var username = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Enter New Password");
                        var newPassword = Console.ReadLine();

                        if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(newPassword))
                            continue;

                        memberService.ChangePassword(username, newPassword);
                        Console.WriteLine("Password has Successfully Changed");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Password Change has Failed");
                        continue;
                    }
                }
            }
        }
    }
}
