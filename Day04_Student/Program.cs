var a = new Student("小明", 80);
var b = new Student("小華", 59.9m);
var c = new Student("小美", 60);

List<Student> students = new List<Student> { a, b, c };
var max = students[0];
var min = students[0];

foreach (var student in students)
{
    Console.WriteLine(student);

    if (student.Score > max.Score)
    {
        max = student;
    }
    else if (student.Score < min.Score)
    {
        min = student;
    }
}
Console.WriteLine($"最高分: {max.Score}, 學生姓名: {max.Name}");
Console.WriteLine($"最低分: {min.Score}, 學生姓名: {min.Name}");

public class Student
{
    public string Name { get; private set; }
    public decimal Score { get; private set; }


    public Student(string name, decimal score)
    {
        Name = name;
        if (score < 0 || score > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(score), "成績必須在 0 到 100 之間");
        }
        Score = score;
    }

    public bool IsPass()
    {
        return Score >= 60;
    }

    public string GetGrade()
    {
        if (Score >= 90)
        {
            return "A";
        }
        else if (Score >= 80)
        {
            return "B";
        }
        else if (Score >= 70)
        {
            return "C";
        }
        else if (Score >= 60)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }

    public override string ToString()
    {
        return $"學生姓名: {Name}, 成績: {Score}, 是否及格: {(IsPass() ? "及格" : "不及格")}, 等級: {GetGrade()}";
    }

}