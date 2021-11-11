using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace WiredBrainCoffeeSurveys.Reports
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quitApp = false;

            do
            {
                Console.WriteLine("Please specify a report to run (rewards, comments, tasks, quit):");
                var selectedReport = Console.ReadLine();

                if (selectedReport == "quit")
                {
                    quitApp = true;
                } 
                else
                {
                    Console.WriteLine("Please specify which quarter of data: (q1, q2)");
                    var selectedData = Console.ReadLine();

                    var surveyResults = JsonConvert.DeserializeObject<SurveyResults>
                        (File.ReadAllText($"data/{selectedData}.json"));

                    switch (selectedReport)
                    {
                        case "rewards":
                            GenerateWinnerEmails(surveyResults);
                            break;
                        case "comments":
                            GenerateCommentsReport(surveyResults);
                            break;
                        case "tasks":
                            GenerateTasksReport(surveyResults);
                            break;
                        default:
                            Console.WriteLine("Sorry, that's not a valid option.");
                            break;
                    }
                }

                Console.WriteLine();
            }
            while (!quitApp);
        }

        public static void GenerateWinnerEmails(SurveyResults results)
        {
            var selectedEmails = new List<string>();
            int counter = 0;

            Console.WriteLine(Environment.NewLine + "Selected Winners Output:");
            while (selectedEmails.Count < 2 && counter < results.Responses.Count)
            {
                var currentItem = results.Responses[counter];

                if (currentItem.FavoriteProduct == "Cappucino")
                {
                    selectedEmails.Add(currentItem.EmailAddress);
                    Console.WriteLine(currentItem.EmailAddress);
                }

                counter++;
            }

            File.WriteAllLines("WinnersReport.csv", selectedEmails); // writes list to .csv file, 1 line per list item
        }

        public static void GenerateCommentsReport(SurveyResults results)
        {
            var comments = new List<string>();

            Console.WriteLine(Environment.NewLine + "Comments Output:");
            for (var i = 0; i < results.Responses.Count; i++)
            {
                var currentResponse = results.Responses[i];

                if (currentResponse.WouldRecommend < 7.0)
                {
                    Console.WriteLine(currentResponse.Comments);
                    comments.Add(currentResponse.Comments);
                }
            }

            foreach (var response in results.Responses)
            {
                if (response.AreaToImprove == results.AreaToImprove)
                {
                    Console.WriteLine(response.Comments);
                    comments.Add(response.Comments);
                }
            }

            File.WriteAllLines("CommentsReport.csv", comments);
        }

        public static void GenerateTasksReport(SurveyResults results)
        {
            var tasks = new List<string>();

            double responseRate = results.NumberResponded / results.NumberSurveyed;
            double overallScore = (results.ServiceScore + results.CoffeeScore + results.FoodScore + results.PriceScore) / 4;

            if (results.CoffeeScore < results.FoodScore)
                tasks.Add("Investigate coffee recipes and ingredients.");

            // Ternary statement. Super basic if statement. Use the ? after a statement, left of colon happens if true and right of colon happens if false.
            tasks.Add(overallScore > 8.0 ? "Work with leadership." : "Work with employees for ideas.");

            if (responseRate < .33)
            {
                tasks.Add("Research options to improve response rate.");
            }
            else if (responseRate > .33 && responseRate < .66)
            {
                tasks.Add("Reward participants with free coffee coupon.");
            }
            else
            {
                tasks.Add("Rewards participants with discount coffee coupon.");
            }

            // Alternative way to do the above if else block with expression switch statement using when statements. Object becomes a local variable. This is known as lambda.
            /*
            tasks.Add(responseRate switch
            {
                var rate when rate < .33 => "Research options to improve response rate.",
                var rate when rate > .33 && rate < .66 => "Reward participants with free coffee coupon.",
                var rate when rate > .66 => "Rewards participants with discount coffee coupon.",
                _ => "No task to add"
            });
            */

            // Expression syntax for a switch. When used as an expression switch comes after the object we're comparing against
            tasks.Add(results.AreaToImprove switch
            {
                "RewardsProgram" => "Revisit the rewards deals.",
                "Cleanliness" => "Contact the cleaning vendor",
                "MobileApp" => "Contact the consulting firm about the app.",
                _ => "Investigate individual comments for ideas."
            });

            Console.WriteLine(Environment.NewLine + "Tasks Output:");
            foreach(var task in tasks)
            {
                Console.WriteLine(task);
            }

            File.WriteAllLines("TasksReport.csv", tasks);
        }
    }
}

/* Notes

Selection statement = if else statement
example: 
if (todayIsMonday)
{
sendPhoneReminder(); <--- only executes on monday
}
else
{
sendTextReminder();
}

Iteration statement = loops
example:

foreach(customer in mailing list)
{
sendEmail(customer);
}

Declaration statement = strings/types statements

Expression statements = Inline addition subtraction aka int sum = 50 + 50;

Exception statements = try catch blocks

Structure of expressions:
2 * 3
is
operand operator operand

-- Key statement concepts --

STATEMENTS are written using C# KEYWORDS and EXPRESSIONS

EXPRESSIONS are constructed using OPERATORS and OPERANDS

OPERATORS act upon OPERANDS to produce a result

-- Summary --

Program flow defines the order inw ihch code statements are executed

Statements are the smallest complete actions or instructions of a C# program

Some types of statements can manipulate program flow and the order of execution

Statements are composed of reserved C# keywords and expressions

Expressions are a sequence of opreators and operands

Staements can be written using either a single line of code, or multiple using blocks

--

Selection statements directly control Program flow by selecting code blocks to run

If-else statements select code to run based on logical boolean comparisons

Allow for branching conditions using if, else, else-if

Switch statements are an alternative to if-else stamenets that use pattern matching

Switch statements can match many different cases against a top level switch expression

-- Summary of Loops --

foreach loops for when you want to loop over everything in a collection

for loops for when you want to loop a certain amount of times

while loops continue to repeat a block of code as lnog as a condition is true

do while is the same as while, but guarantees atleast one execution

--



*/