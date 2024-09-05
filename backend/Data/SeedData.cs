using CodingInterviewQuestionsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingInterviewQuestionsApi.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Remove existing data before seeding
                if (context.Questions.Any())
                {
                    context.Questions.RemoveRange(context.Questions);
                    context.SaveChanges();
                }

                // Add new seed data
                context.Questions.AddRange(
                    new Question
                    {
                        QuestionText = "1. Write a code to reverse a number-",
                        CodeSnippet = @"import java.util.Scanner;

public class ReverseNumber {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print(""Enter a number: "");
        int number = sc.nextInt();
        int reverse = 0;
        while (number != 0) {
            reverse = reverse * 10 + number % 10;
            number /= 10;
        }
        System.out.println(""Reversed number: "" + reverse);
        sc.close();
    }
}"
                    },
                    new Question
                    {
                        QuestionText = "2. Write the code to find the Fibonacci series up to the nth term.",
                        CodeSnippet = @"import java.util.Scanner;

public class FibonacciSeries {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print(""Enter the number of terms: "");
        int n = sc.nextInt();
        int first = 0, second = 1;
        System.out.print(""Fibonacci Series: "" + first + "" "" + second);
        for (int i = 3; i <= n; i++) {
            int next = first + second;
            System.out.print("" "" + next);
            first = second;
            second = next;
        }
        sc.close();
    }
}"
                    },
                    new Question
                    {
                        QuestionText = "3. Write code for Greatest Common Divisor (GCD).",
                        CodeSnippet = @"import java.util.Scanner;

public class GCD {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.print(""Enter first number: "");
        int num1 = sc.nextInt();
        System.out.print(""Enter second number: "");
        int num2 = sc.nextInt();
        while (num2 != 0) {
            int temp = num2;
            num2 = num1 % num2;
            num1 = temp;
        }
        System.out.println(""Greatest Common Divisor: "" + num1);
        sc.close();
    }
}"
                    }
                    // Add other questions similarly...
                );

                context.SaveChanges();
            }
        }
    }
}
