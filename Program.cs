using System;

class Program
{
    static void Main(string[] args)
    {
        //string name = "   [  Prabdeeddeep  = ]   ";
        //string replaceString = "eep";
        //string withString = "[replaced]";
        //string contains = "   [  P";
        //string startsWith = "   [  P";
        //string endsWith = "= ]   ";
        int[] ary = { 3, 5, 6, 7, 10, 4, 2, 7 };

        //Console.WriteLine("Trim(): [" + StringFunctions.Trim(name) + "]");
        //Console.WriteLine("TrimStart(): [" + StringFunctions.TrimStart(name) + "]");
        //Console.WriteLine("TrimEnd(): [" + StringFunctions.TrimEnd(name) + "]");
        //Console.WriteLine("Replace(): [" + StringFunctions.Replace(name, replaceString, withString) + "]" + " Answer: [" + name.Replace(replaceString, withString) + "]");
        //Console.WriteLine("All Caps: " + StringFunctions.ToUpper(name));
        //Console.WriteLine("All Small: " + StringFunctions.ToLower(name));
        //Console.WriteLine("Contains(): " + contains + " is " + StringFunctions.Contains(name, contains));
        //Console.WriteLine("StartsWith(): " + startsWith + " is " + StringFunctions.StartsWith(name, startsWith));
        //Console.WriteLine("EndsWith(): " + endsWith + " is " + StringFunctions.EndsWith(name, endsWith));
        Console.WriteLine(MathInt.GetMinValue(ary));
        Console.WriteLine(MathInt.GetMaxValue(ary));
    }
}

public static class StringFunctions
{
    // Removes empty white space both on the front and the end of the string
    public static string Trim(string str)
    {
        // return empty str if empty
        if (str == null) return str;

        string given = str;
        string result = "";
        int lastIdx = given.Length - 1;
        bool emptyStart = true;

        // get the index of 1st unique char (not empty) from the end
        if (given[lastIdx] == ' ')
        {
            for (int i = lastIdx; i >= 0; i--)
            {
                // break and pass index at 1st unique char 
                if (given[i] != ' ')
                {
                    lastIdx = i;
                    break;
                }
            }
        }

        // pass all chars to result 
        for (int i = 0; i < lastIdx + 1; i++)
        {
            // begin adding chars to result when char is unique (not empty)
            if (given[i] != ' ') emptyStart = false;
            // skip to next iteration if char is empty
            if (emptyStart) continue;

            result += given[i];
        }

        return result;
    }

    // Removes empty white space on the front of the string
    public static string TrimStart(string str)
    {
        if (str == null) return str;

        string given = str;
        string result = "";
        bool emptyStart = true;

        for (int i = 0; i < given.Length; i++)
        {
            if (given[i] != ' ') emptyStart = false;
            if (emptyStart) continue;
            result += given[i];
        }

        return result;
    }

    // Removes empty white space on the end of the string
    public static string TrimEnd(string str)
    {
        if (str == null) return str;

        string given = str;
        string result = "";
        int lastIdx = given.Length - 1;

        for (int i = lastIdx; i >= 0; i--)
        {
            if (given[i] != ' ')
            {
                lastIdx = i;
                break;
            }
        }

        for (int i = 0; i < lastIdx + 1; i++)
        {
            result += given[i];
        }

        return result;
    }

    // string.Replace(replaceStringValue, newStringValue) - Replace() takes in a string value to be replaced and takes a string value to replace as the second value
    public static string Replace(string str, string replace, string with)
    {
        // return str if any of the parameters are null
        if (str == null || replace == null || with == null) return str;

        string given = str;
        string result = "";
        int replaceCount = 0;
        bool canReplace = false;
        int startReplaceIdx = 0;
        //  "   + Prabdeepdeep +   "
        // get the index and length of the replace string within the given string 
        for (int i = 0; i < given.Length; i++)
        {
            // exit out once replace string is found within given string
            if (canReplace) break;
            // skip iteration if replace at index 0 does not match given[i]
            if (given[i] != replace[replaceCount]) continue;
            // check if replace word is within given
            for (int j = 0; j < replace.Length; j++)
            {
                // incorrect match, exit out from inner for loop 
                if (given[i + replaceCount] != replace[replaceCount])
                {
                    replaceCount = 0;
                    break;
                }

                // match found! exit both for loops since 'replace' string exists within 'given' string
                replaceCount++;
                if (replaceCount == replace.Length)
                {
                    canReplace = true;
                    int endReplaceIdx = i + replaceCount;
                    startReplaceIdx = endReplaceIdx - replaceCount;
                    break;
                }
            }
        }

        // 'replace' string was not found within 'given' string
        if (canReplace == false) return given;

        bool startSkipping = false;
        int skipCounter = 0;
        // replace the 'replace' string within 'given' string with the 'with' string
        for (int i = 0; i < given.Length; i++)
        {
            if (startSkipping && skipCounter < replace.Length - 1)
            {
                skipCounter++;
                continue;
            }
            // add 'given' string chars before 'startReplaceIdx' and after 'endReplaceIdx'
            if (i != startReplaceIdx)
            {
                result += given[i];
                continue;
            }
            startSkipping = true;
            // add 'with' string in between the 'startReplaceIdx' and 'endReplaceIdx'
            int counter = 0;
            while (counter < with.Length)
            {
                result += with[counter];
                counter++;
            }
        }

        return result;
    }

    // string.ToUpper() - Sets all characters in string to uppercase
    public static string ToUpper(string str)
    {
        if (str == null) return str;

        string given = str;
        string result = "";
        int i = 0;

        while (i < given.Length)
        {
            switch (given[i])
            {
                case 'a':
                    result += 'A';
                    break;
                case 'b':
                    result += 'B';
                    break;
                case 'c':
                    result += 'C';
                    break;
                case 'd':
                    result += 'D';
                    break;
                case 'e':
                    result += 'E';
                    break;
                case 'f':
                    result += 'F';
                    break;
                case 'g':
                    result += 'G';
                    break;
                case 'h':
                    result += 'H';
                    break;
                case 'i':
                    result += 'I';
                    break;
                case 'j':
                    result += 'J';
                    break;
                case 'k':
                    result += 'K';
                    break;
                case 'l':
                    result += 'L';
                    break;
                case 'm':
                    result += 'M';
                    break;
                case 'n':
                    result += 'N';
                    break;
                case 'o':
                    result += 'O';
                    break;
                case 'p':
                    result += 'P';
                    break;
                case 'q':
                    result += 'Q';
                    break;
                case 'r':
                    result += 'R';
                    break;
                case 's':
                    result += 'S';
                    break;
                case 't':
                    result += 'T';
                    break;
                case 'u':
                    result += 'U';
                    break;
                case 'v':
                    result += 'V';
                    break;
                case 'w':
                    result += 'W';
                    break;
                case 'x':
                    result += 'X';
                    break;
                case 'y':
                    result += 'Y';
                    break;
                case 'z':
                    result += 'Z';
                    break;
                default:
                    result += given[i];
                    break;
            }
            i++;
        }

        return result;
    }

    // string.ToLower() - Sets all characters in string to lowercase
    public static string ToLower(string str)
    {
        if (str == null) return str;

        string given = str;
        string result = "";
        int i = 0;

        while (i < given.Length)
        {
            switch (given[i])
            {
                case 'A':
                    result += 'a';
                    break;
                case 'B':
                    result += 'b';
                    break;
                case 'C':
                    result += 'c';
                    break;
                case 'D':
                    result += 'd';
                    break;
                case 'E':
                    result += 'e';
                    break;
                case 'F':
                    result += 'f';
                    break;
                case 'G':
                    result += 'g';
                    break;
                case 'H':
                    result += 'h';
                    break;
                case 'I':
                    result += 'i';
                    break;
                case 'J':
                    result += 'j';
                    break;
                case 'K':
                    result += 'k';
                    break;
                case 'L':
                    result += 'l';
                    break;
                case 'M':
                    result += 'm';
                    break;
                case 'N':
                    result += 'n';
                    break;
                case 'O':
                    result += 'o';
                    break;
                case 'P':
                    result += 'p';
                    break;
                case 'Q':
                    result += 'q';
                    break;
                case 'R':
                    result += 'r';
                    break;
                case 'S':
                    result += 's';
                    break;
                case 'T':
                    result += 't';
                    break;
                case 'U':
                    result += 'u';
                    break;
                case 'V':
                    result += 'v';
                    break;
                case 'W':
                    result += 'w';
                    break;
                case 'X':
                    result += 'x';
                    break;
                case 'Y':
                    result += 'y';
                    break;
                case 'Z':
                    result += 'z';
                    break;
                default:
                    result += given[i];
                    break;
            }
            i++;
        }

        return result;
    }

    // string.Contains() - Check if a string contains a specified value
    public static bool Contains(string str, string contains)
    {
        if (str == null || contains == null) return false;

        int containIdx = 0;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != contains[containIdx])
            {
                containIdx = 0;
                continue;
            }

            containIdx++;
            if (containIdx == contains.Length)
            {
                return true;
            }
        }

        return false;
    }

    // string.StartsWith() - Check if a string starts with a specified value
    public static bool StartsWith(string str, string startsWith)
    {
        if (str == null || startsWith == null || str[0] != startsWith[0] || startsWith.Length > str.Length) return false;

        for (int i = 1; i < startsWith.Length; i++)
        {
            if (str[i] != startsWith[i]) return false;
        }

        return true;
    }

    // string.EndsWith() - Check if a string ends with a specified value
    public static bool EndsWith(string str, string endsWith)
    {
        if (str == null || endsWith == null || str[str.Length - 1] != endsWith[endsWith.Length - 1] || endsWith.Length > str.Length) return false;

        int finishLength = str.Length - endsWith.Length;

        for (int i = str.Length - 1; i >= finishLength; i--)
        {
            if (str[i] != endsWith[endsWith.Length + (i - str.Length)]) return false;
        }

        return true;
    }
}

public static class MyInt32
{
    // Return the Max Value of Int32
    public static int MaxValue()
    {
        int result = 0;

        for (int i = 0; i < 31; i++)
        {
            int counter = i;
            int tempValue = 2;
            if (i == 0) tempValue = 1;
            
            while (counter > 1)
            {
                tempValue *= 2;
                counter--;
            }

            result += tempValue;
        }

        return result;
    }

    // Return the Min Value of Int32 
    public static int MinValue()
    {
        int result = 0;

        for (int i = 0; i > -31; i--)
        {
            int counter = -i;
            int tempValue = -2;
            if (i == 0) tempValue = -1;

            while (counter > 1)
            {
                tempValue *= 2;
                counter--;
            }

            result += tempValue;
        }

        return result;
    }
}

static class MathInt
{
    // return the max int within an array 
    public static int GetMaxValue(int[] ary)
    {
        int[] given = ary;
        int result = MyInt32.MinValue();

        for (int i = 0; i < given.Length; i++)
        {
            if (given[i] <= result) continue;

            // set result to a greater number
            result = given[i];
        }

        return result;
    }

    public static int GetMinValue(int[] ary)
    {
        int[] given = ary;
        int result = MyInt32.MaxValue();

        for (int i = 0; i < given.Length; i++)
        {
            if (given[i] >= result) continue;

            // set result to a lower number
            result = given[i];
        }

        return result;
    }
}
