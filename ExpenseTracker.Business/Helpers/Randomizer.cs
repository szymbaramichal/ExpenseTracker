using System;

namespace ExpenseTracker.Business.Helpers;

public static class Randomizer
{

    public static string GenerateRandomCode(int length = 6)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        char[] result = new char[length];

        Random rnd = new Random();

        for(int i = 0; i < length; i++)
        {
            int indexNum = rnd.Next(0, 36);
            result[i] = chars[indexNum];
        }

        return new string(result);
    }
}
