using System;
using System.Collections.Generic;
using System.IO;

namespace Question4
{
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            List<Student> students = new List<Student>();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line;
                int lineNumber = 1;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length != 3)
                    {
                        throw new MissingFieldException($"Line {lineNumber}: Expected 3 fields but got {parts.Length}.");
                    }

                    try
                    {
                        int id = int.Parse(parts[0].Trim());
                        string fullName = parts[1].Trim();
                        int score = int.Parse(parts[2].Trim());

                        students.Add(new Student
                        {
                            Id = id,
                            FullName = fullName,
                            Score = score
                        });
                    }
                    catch (FormatException)
                    {
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Score is not a valid integer.");
                    }

                    lineNumber++;
                }
            }

            return students;
        }

        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var student in students)
                {
                    string reportLine = $"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {student.GetGrade()}";
                    writer.WriteLine(reportLine);
                }
            }
        }
    }
}
