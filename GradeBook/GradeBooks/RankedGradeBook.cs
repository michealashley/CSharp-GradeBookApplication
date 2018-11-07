using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int numberOfStudents = Students.Count;
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
    }
}
