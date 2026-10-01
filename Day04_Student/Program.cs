var a = new Student("小明", 150);
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
        Console.WriteLine($"學生姓名: {Name}, 成績: {Score}"); 
    }

}