using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        int numberOfStudents;
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
            numberOfStudents = Students.Count;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (numberOfStudents < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work." );
            }

            int fifth = (int)Math.Floor(numberOfStudents * 0.2);
            var gradeOrder = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (gradeOrder[fifth - 1] <= averageGrade)
                return 'A';
            else if(gradeOrder[(fifth * 2) - 1] <= averageGrade)
                return 'B';
            else if (gradeOrder[(fifth * 3) - 1] <= averageGrade)
                return 'C';
            else if (gradeOrder[(fifth * 4) - 1] <= averageGrade)
                return 'D';
            else return 'F';
        }

        public override void CalculateStatistics()
        {
            if (numberOfStudents < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            } else
            {
                base.CalculateStatistics();
            }
            
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (numberOfStudents < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
                base.CalculateStudentStatistics(name);
        }
    }
}
