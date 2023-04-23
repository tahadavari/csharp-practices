using System.Text.Json;


namespace ConsoleApp1
{
    public class Student
    {
        public int StudentNumber {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}

        public float StudentGradePointAverage {get; set;}

        public Student(int studentNumber, string firstName, string lastName)
        {
            StudentNumber = studentNumber;
            FirstName = firstName;
            LastName = lastName;
        }
    }

    public class StudentScore
    {
        public int StudentNumber {get; set;}
        public string Lesson {get; set;}
        public float Score {get; set;}
        
        public StudentScore(int studentNumber, string lesson, float score)
        {
            StudentNumber = studentNumber;
            Lesson = lesson;
            Score = score;
        }

        

    }
    class Program
    {
        static void Main(string[] args)
        {
            string studentJson = File.ReadAllText(@"E:\mohaymen\practice C#\P1\ConsoleApp1\student.json");
            List<Student>? students = JsonSerializer.Deserialize<List<Student>>(studentJson);
            // Console.Write(students);
            string scoreJson = File.ReadAllText(@"E:\mohaymen\practice C#\P1\ConsoleApp1\scores.json");
            List<StudentScore>? scores = JsonSerializer.Deserialize<List<StudentScore>>(scoreJson);
            // Console.Write(scores);
            IDictionary<Student, float> studentGradePointAverage = new Dictionary<Student, float>();
            
            
            foreach (StudentScore sco in scores)
            {
                foreach (Student stu in students)
                {
                    if (stu.StudentNumber == sco.StudentNumber)
                    { 
                        float gradePointAverage = (stu.StudentGradePointAverage + sco.Score) / 2;
                        stu.StudentGradePointAverage = gradePointAverage;
                        studentGradePointAverage[stu] = gradePointAverage;
                    }
                }
            }
            
            var sortStudentsByGradeAverage = from entry in studentGradePointAverage orderby entry.Value descending select entry;
            foreach (KeyValuePair<Student, float> kvp in sortStudentsByGradeAverage)
            {
                //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                Console.WriteLine("First Name = {0}, Last Name = {1}, Grade Point Average = {2}", kvp.Key.FirstName, kvp.Key.LastName, kvp.Value);
            }
        }
    }
}