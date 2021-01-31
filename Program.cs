using System;
using System.Linq;
using System.Collections.Generic;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine();
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = squareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }
            int[] arr = { 3, 1, 4, 1, 5 };
            Console.Write("Q4: Enter the absolute difference to check: ");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);

            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);
        }

        private static void printTriangle(int n)
        {
            try
            {
                if (n > 0)
                {
                    int i; int j; int k;

                    for (i = 1; i <= n; i++)
                    {           //outer loop
                        for (j = 1; j <= (n - i); j++)
                        {       //inner loop
                            Console.Write(' '); //printing spaces
                        }

                        for (k = 1; k < (i * 2); k++)
                        {       //printing stars
                            Console.Write("*");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }

            catch (Exception)
            {
                Console.WriteLine("Enter a valid number");
            }

        }
        private static void printPellSeries(int n2)
        {
            try
            {
                if (n2 > 0)
                {
                    int a = 0; int i; int b = 1; int sum = 0;
                    if (n2 < 3)
                    {
                        if (n2 == 1)
                        {       //if one number of series is req
                            Console.Write(a);
                        }
                        if (n2 == 2)
                        {       //if two numbers of series is req
                            Console.Write(a + " , " + b);
                        }


                    }

                    if (n2 >= 3)
                    {
                        Console.Write(a + " , " + b + " , ");
                        for (i = 3; i <= n2; i++)
                        {                       //formula => ( 2*b + a ) = c
                            sum = ((b * 2) + (a));
                            Console.Write(sum + " , ");
                            a = b;
                            b = sum;

                        }

                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a valid number");
            }

        }
        private static bool squareSums(int n3)
        {
            try
            {

                int a; int b;
                bool input = false;

                if (n3 > 0)
                {
                    for (a = 0; a <= n3; a++)//outerloop
                    {
                        for (b = 0; b <= n3; b++)//innerloop
                        {
                            if ((a * a + b * b) == n3)//check-condition
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
                else
                {
                    throw new Exception();
                }
            }

            catch (Exception)
            {
                Console.WriteLine("Enter valid number");
                return false;

            }



        }
        private static int diffPairs(int[] nums, int k)
        {
            int i; int j;
            int count = 0;
            try
            {
                System.Array.Sort(nums);    //Sorting array
                int n = nums.Length;        //Length(Array)

                HashSet<string> final_pairs = new HashSet<string>();

                for (i = 0; i < n; i++)
                {                               //Iterating the elements(Array)
                    for (j = i + 1; j < n; j++)
                    {
                        if ((nums[j] - nums[i]) == k||nums[i]-nums[j]==k)    //k-diff
                        {
                            final_pairs.Add(nums[i] + "," + nums[j]);

                            //Append to HashSet for distinct results

                            final_pairs.Distinct();
                        }
                    }
                }
                foreach (string z in final_pairs.Distinct())      //Count for each pair
                {
                    count = count + 1;
                    //Console.WriteLine(z);         //Printing pairs
                }
                Console.WriteLine(count);
                return count;

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }
        private static int UniqueEmails(List<string> emails)
        {
            HashSet<string> final_set = new HashSet<string>();

            try
            {
                foreach (string email in emails)
                {
                    string[] loc_dom = email.Split('@');  //Splitting the email id into local and domain names
                    string new_loc;
                    string loc_name = loc_dom[0];
                    string dom_name = loc_dom[1];
                    string final_loc;

                    if (loc_name.Contains('+') || loc_name.Contains('.'))
                    {                   //Remove the chars after "+"
                        new_loc = loc_name.Remove(loc_name.IndexOf("+"));

                        if (loc_name.Contains('+') || loc_name.Contains('.'))
                        {               //Avoiding "."
                            final_loc = new_loc.Replace(".", "");

                            string new_email = final_loc.Trim() + "@" + dom_name.Trim();
                            //trimming whitespaces
                            final_set.Add(new_email);

                        }

                    }


                }
                
                int ans5 = final_set.Count();
                //Counting unique emails

                return ans5;
            }

            catch (Exception e)
            {
                Console.WriteLine("Invalid email" + e.Message);
                throw;

            }
        }
        private static string DestCity(string[,] paths)
        {
            try
            {
                List<string> source = new List<string>();
                List<string> dest = new List<string>();
                int i = 0;
                foreach (string c in paths)
                {
                    //Splitting into destination and source from all cities
                    if ((i % 2) != 0)
                    {
                        dest.Add(c);
                        i++;
                    }

                    else if (i % 2 == 0)
                    {
                        source.Add(c);
                        i++;

                    }


                }

                foreach (string d in dest)
                { //Checking if the destination city is available in source
                    if (source.Contains(d) == false)
                    {
                        string final = d;
                        return final;

                    }
                }
                return "";

            }
            catch (Exception e)
            {

                Console.WriteLine("Invalid route" + e.Message);
                throw;
            }
        }
    }
}
