using System;

namespace _20241031_HW_FirstSQLConnection;

public class UI
{
    public static int EnterPositionFromCL(object[] objs)
    {
        for (int i = 0; i < objs.Length; i++)
        {
            System.Console.WriteLine("{0}. {1}", i, objs[i]);
        }

        System.Console.Write("Enter number:");
        string number = Console.ReadLine();

        if (int.TryParse(number, out int value))
        {
            return value;
        }

        return 0;
    }

    public static void ShowAccountDetails(AccountController a)
    {
        System.Console.WriteLine("AccountId: {0}", a.AccountId);
        System.Console.WriteLine("Email: {0}", a.Email);
        System.Console.WriteLine("FirstName: {0}", a.FirstName);
        System.Console.WriteLine("LastName: {0}", a.LastName);
        System.Console.WriteLine("Email confirmed: {0}", a.EmailConfirm);
        System.Console.WriteLine("Country: {0}", a.Country);
    }
}
