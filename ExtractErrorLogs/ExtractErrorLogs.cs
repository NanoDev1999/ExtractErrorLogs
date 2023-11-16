using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class Result
{
    public static List<List<string>> extractErrorLogs(List<List<string>> logs) 
    {
        List<List<string>> errorLogs = logs
            .Where(log => log[2] == "CRITICAL" || log[2] == "ERROR")
            .OrderBy
                (
                    log => DateTime.ParseExact(log[0] + " " + log[1], 
                    "dd-MM-yyyy HH:mm", 
                    CultureInfo.InvariantCulture)
                )
            .ToList();

        return errorLogs;
    }
}



class Solution
{
    public static void Main(string[] args) 
    {
        int logsRows = Convert.ToInt32(Console.ReadLine().Trim());
        int logsColumns = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<string>> logs = new List<List<string>>();

        for (int i = 0; i < logsRows; i++) {
            logs.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
        }

        // Call the function
        List<List<string>> result = Result.extractErrorLogs(logs);

        // Output the result
        foreach (var log in result) {
            Console.WriteLine(string.Join(" ", log));
        }
    }
}





// Sample Inputs as it reads the line in rows;

// 3
// 4
// 01-01-2022 18:00 CRITICAL failed
// 01-01-2022 15:00 ERROR failed
// 01-01-2022 16:00 SUCCESS failed

// 3
// 4
// 03-07-2022 16:00 SUCCESS failed
// 04-12-2022 18:00 SUCCESS failed
// 05-08-2022 12:00 SUCCESS failed

// 5
// 4
// 20-01-2244 08:06 CRITICAL failed
// 11-08-2022 16:08 SUCCESS established
// 26-11-1947 19:47 SUCCESS established
// 16-10-2145 18:00 ERROR failed
// 21-07-2400 12:00 ERROR failed