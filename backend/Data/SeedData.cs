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
    QuestionText = "1. Write a code to reverse a number.",
    CodeSnippet = @"import java.util.Scanner;

public class ReverseNumber {
    public static void main(String[] args) {
        // Scanner object to take user input
        Scanner sc = new Scanner(System.in);

        // Prompt user to enter a number
        System.out.print(""Enter a number: "");
        int number = sc.nextInt();  // Store the input number
        int reverse = 0;  // Variable to store the reversed number

        // Loop to reverse the digits of the number
        while (number != 0) {
            // Get the last digit of the number and add it to reverse
            reverse = reverse * 10 + number % 10;
            // Remove the last digit from the number
            number /= 10;
        }

        // Output the reversed number
        System.out.println(""Reversed number: "" + reverse);

        // Close the Scanner to avoid resource leaks
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
        // Scanner object to take user input
        Scanner sc = new Scanner(System.in);

        // Prompt user to enter the number of terms for the Fibonacci series
        System.out.print(""Enter the number of terms: "");
        int n = sc.nextInt();  // Store the input number of terms

        // Initialize the first two terms of the Fibonacci series
        int first = 0, second = 1;

        // Print the first two terms of the series
        System.out.print(""Fibonacci Series: "" + first + "" "" + second);

        // Loop to generate the next terms of the Fibonacci series
        for (int i = 3; i <= n; i++) {
            // Calculate the next term by adding the previous two terms
            int next = first + second;

            // Print the next term
            System.out.print("" "" + next);

            // Update the first and second terms for the next iteration
            first = second;
            second = next;
        }

        // Close the Scanner to avoid resource leaks
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
        // Scanner object to take user input
        Scanner sc = new Scanner(System.in);

        // Prompt user to enter the first number
        System.out.print(""Enter first number: "");
        int num1 = sc.nextInt();  // Store the first input number

        // Prompt user to enter the second number
        System.out.print(""Enter second number: "");
        int num2 = sc.nextInt();  // Store the second input number

        // Loop to find the GCD using the Euclidean algorithm
        while (num2 != 0) {
            // Store the second number in a temporary variable
            int temp = num2;

            // Update num2 to the remainder of num1 divided by num2
            num2 = num1 % num2;

            // Update num1 to the value of temp (previous num2)
            num1 = temp;
        }

        // Output the greatest common divisor (GCD)
        System.out.println(""Greatest Common Divisor: "" + num1);

        // Close the Scanner to avoid resource leaks
        sc.close();
    }
}"
    },

                    new Question
{
    QuestionText = "4. Write code for a Perfect Number.",
    CodeSnippet = @"import java.util.Scanner;

public class PerfectNumber {
    public static void main(String[] args) {
        // Scanner to take user input
        Scanner sc = new Scanner(System.in);
        System.out.print(""Enter a number: "");
        int number = sc.nextInt();  // Store the input number
        int sum = 0;  // Variable to store the sum of divisors

        // Loop through all numbers less than the input number and find divisors
        for (int i = 1; i <= number / 2; i++) {
            if (number % i == 0) {  // Check if 'i' is a divisor
                sum += i;  // Add divisor to sum
            }
        }

        // Check if the sum of divisors equals the input number (Perfect Number condition)
        if (sum == number) {
            System.out.println(number + "" is a Perfect Number"");
        } else {
            System.out.println(number + "" is not a Perfect Number"");
        }
        sc.close();  // Close the Scanner to avoid resource leaks
    }
}"
},
new Question
{
    QuestionText = "5. Write code to Check if two strings are Anagram or not.",
    CodeSnippet = @"import java.util.Arrays;
import java.util.Scanner;

public class AnagramCheck {
    public static void main(String[] args) {
        // Scanner to take input from the user
        Scanner sc = new Scanner(System.in);
        System.out.print(""Enter first string: "");
        String str1 = sc.nextLine();  // First string input
        System.out.print(""Enter second string: "");
        String str2 = sc.nextLine();  // Second string input

        // Check if the two strings are anagrams
        if (isAnagram(str1, str2)) {
            System.out.println(""The strings are Anagrams."");
        } else {
            System.out.println(""The strings are not Anagrams."");
        }
        sc.close();  // Close the Scanner
    }

    // Method to check if two strings are anagrams
    public static boolean isAnagram(String str1, String str2) {
        // Remove spaces and convert to lowercase, then convert to char arrays
        char[] charArray1 = str1.replaceAll(""\\s"", """").toLowerCase().toCharArray();
        char[] charArray2 = str2.replaceAll(""\\s"", """").toLowerCase().toCharArray();

        // Sort both char arrays
        Arrays.sort(charArray1);
        Arrays.sort(charArray2);

        // Return true if sorted arrays are equal (anagram condition)
        return Arrays.equals(charArray1, charArray2);
    }
}"
},
new Question
{
    QuestionText = "6. Write code to Check if the given string is a Palindrome or not.",
    CodeSnippet = @"import java.util.Scanner;

public class PalindromeCheck {
    public static void main(String[] args) {
        // Scanner for user input
        Scanner sc = new Scanner(System.in);
        System.out.print(""Enter a string: "");
        String input = sc.nextLine();  // Input string

        // Check if the string is a palindrome
        if (isPalindrome(input)) {
            System.out.println(""The string is a Palindrome."");
        } else {
            System.out.println(""The string is not a Palindrome."");
        }
        sc.close();  // Close Scanner
    }

    // Method to check if a string is a palindrome
    public static boolean isPalindrome(String str) {
        int start = 0;  // Start pointer
        int end = str.length() - 1;  // End pointer

        // Loop to compare characters from start and end
        while (start < end) {
            if (str.charAt(start) != str.charAt(end)) {
                return false;  // Return false if mismatch
            }
            start++;  // Move start pointer
            end--;  // Move end pointer
        }
        return true;  // Return true if all characters match
    }
}"
},
new Question
{
    QuestionText = "7. Write code to Calculate the frequency of characters in a string.",
    CodeSnippet = @"import java.util.HashMap;
import java.util.Scanner;

public class CharacterFrequency {
    public static void main(String[] args) {
        // Scanner for input
        Scanner sc = new Scanner(System.in);
        System.out.print(""Enter a string: "");
        String input = sc.nextLine();  // Input string

        // HashMap to store character frequencies
        HashMap<Character, Integer> frequencyMap = new HashMap<>();

        // Loop through each character in the string
        for (char c : input.toCharArray()) {
            // Add character to map or update its frequency
            frequencyMap.put(c, frequencyMap.getOrDefault(c, 0) + 1);
        }

        // Print the frequency map
        System.out.println(""Character frequencies: "" + frequencyMap);
        sc.close();  // Close Scanner
    }
}"
},
new Question
{
    QuestionText = "8. Write code for Bubble Sort.",
    CodeSnippet = @"import java.util.Scanner;

public class BubbleSort {
    public static void main(String[] args) {
        // Scanner for input
        Scanner sc = new Scanner(System.in);
        System.out.print(""Enter the number of elements: "");
        int n = sc.nextInt();  // Number of elements

        int[] arr = new int[n];  // Array to store elements

        // Input array elements
        System.out.println(""Enter the elements: "");
        for (int i = 0; i < n; i++) {
            arr[i] = sc.nextInt();
        }

        // Call bubble sort method
        bubbleSort(arr);

        // Print sorted array
        System.out.println(""Sorted array: "");
        for (int num : arr) {
            System.out.print(num + "" "");
        }
        sc.close();  // Close Scanner
    }

    // Method to perform bubble sort
    public static void bubbleSort(int[] arr) {
        int n = arr.length;  // Get array length

        // Outer loop for each pass
        for (int i = 0; i < n - 1; i++) {
            // Inner loop for comparing adjacent elements
            for (int j = 0; j < n - i - 1; j++) {
                if (arr[j] > arr[j + 1]) {
                    // Swap arr[j] and arr[j + 1]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}"
},
new Question
{
    QuestionText = "9. How is the Merge Sort algorithm implemented?",
    CodeSnippet = @"import java.util.Arrays;

public class MergeSort {
    public static void main(String[] args) {
        // Sample array to be sorted
        int[] array = {38, 27, 43, 3, 9, 82, 10};
        System.out.println(""Unsorted array: "" + Arrays.toString(array));

        // Call mergeSort method
        mergeSort(array, array.length);

        // Print sorted array
        System.out.println(""Sorted array: "" + Arrays.toString(array));
    }

    // Recursive method to split and sort the array
    public static void mergeSort(int[] array, int n) {
        if (n < 2) {
            return;  // Base case
        }
        int mid = n / 2;  // Find the middle of the array

        // Split the array into two halves
        int[] left = Arrays.copyOfRange(array, 0, mid);
        int[] right = Arrays.copyOfRange(array, mid, n);

        // Recursively sort both halves
        mergeSort(left, left.length);
        mergeSort(right, right.length);

        // Merge the two sorted halves
        merge(array, left, right);
    }

    // Method to merge two sorted arrays
    public static void merge(int[] array, int[] left, int[] right) {
        int i = 0, j = 0, k = 0;  // Pointers for left, right, and original array

        // Compare elements from left and right arrays and merge them
        while (i < left.length && j < right.length) {
            if (left[i] <= right[j]) {
                array[k++] = left[i++];
            } else {
                array[k++] = right[j++];
            }
        }

        // Copy remaining elements from left array (if any)
        while (i < left.length) {
            array[k++] = left[i++];
        }

        // Copy remaining elements from right array (if any)
        while (j < right.length) {
            array[k++] = right[j++];
        }
    }
}"
},
new Question
{
    QuestionText = "10. Write code to check whether a given year is a leap year or not.",
    CodeSnippet = @"import java.util.Scanner;

public class LeapYearCheck {
    public static void main(String[] args) {
        // Scanner to take input
        Scanner sc = new Scanner(System.in);
        System.out.print(""Enter a year: "");
        int year = sc.nextInt();  // Input year

        // Call method to check if it's a leap year
        if (isLeapYear(year)) {
            System.out.println(year + "" is a Leap Year."");
        } else {
            System.out.println(year + "" is not a Leap Year."");
        }
        sc.close();  // Close Scanner
    }

    // Method to check if the year is a leap year
    public static boolean isLeapYear(int year) {
        // Check if the year is divisible by 4 and not divisible by 100,
        // unless it's divisible by 400 (leap year condition)
        if (year % 4 == 0) {
            if (year % 100 == 0) {
                return year % 400 == 0;
            }
            return true;
        }
        return false;
    }
}"
}


                );

                context.SaveChanges();
            }
        }
    }
}
