using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook (string name, bool isWeighted): base(name, isWeighted)

            {
            Type = GradebookType.Ranked;
            }

        public override char GetLetterGrade(double averageGrade)
        {
            int numberOfStudents = Students.Count;
            int minimumNumberOfStudents = 5;

            if (numberOfStudents < minimumNumberOfStudents)
            {
                throw new InvalidOperationException("Ranking grading requires at least 5 students");

            }

            var threshold = (int)Math.Ceiling(numberOfStudents * 0.2);//works out 20% of students, crsde, int, index
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            var aThreshold = threshold - 1;
            var bThreshold = (2 * threshold) - 1;
            var cThreshold = (3 * threshold) - 1;
            var dThreshold = (4 * threshold) - 1;
            var eThreshold = (5 * threshold) - 1;

            if (grades[aThreshold] <= averageGrade)
            {
                return 'A';
            }
            else if (grades[bThreshold] <= averageGrade)
                return 'B';

            else if (grades[cThreshold] <= averageGrade)
                return 'C';

            else if (grades[dThreshold] <= averageGrade)
                return 'D';

            else if (grades[eThreshold] <= averageGrade)
                return 'E';

            else
                return 'F';

            //return base.GetLetterGrade(averageGrade);
        }


        public override void CalculateStatistics()
        {
            int minimumNuberOfStudents = 5;
            int numberOfStudents = Students.Count;
            if(numberOfStudents<minimumNuberOfStudents)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a students overall grade");
                return;
            }
            base.CalculateStatistics();
    
        }

        public override void CalculateStudentStatistics(string name)
        {

            int minimumNuberOfStudents = 5;
            int numberOfStudents = Students.Count;
            if (numberOfStudents < minimumNuberOfStudents)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a students overall grade");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
