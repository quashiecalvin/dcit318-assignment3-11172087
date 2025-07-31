using System;
using System.Collections.Generic;
using System.IO;

namespace Question4
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "students.txt";
            string outputFile = "report.txt";

            try
            {
                StudentResultProcessor processor = new StudentResultProcessor();

                List<Student> students = processor.ReadStudentsFromFile(inputFile);

                processor.WriteReportToFile(students, outputFile);

                Console.WriteLine("Report successfully generated.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error: Input file not found.");
                Console.WriteLine(ex.Message);
            }
            catch (InvalidScoreFormatException ex)
            {
                Console.WriteLine("Error: Invalid score format.");
                Console.WriteLine(ex.Message);
            }
            catch (MissingFieldException ex)
            {
                Console.WriteLine("Error: Missing field in student record.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
