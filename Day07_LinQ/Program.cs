// 第 7 天:LINQ(Where/Select/OrderBy/GroupBy...)
// 規則:計算一律用 LINQ,foreach 只用來「印出結果」。

List<Student> students = new List<Student>
{
    new Student("小明", "甲", 92m),
    new Student("小華", "乙", 58m),
    new Student("阿強", "乙", 85m),   // 和小美同分 → 練 ThenBy
    new Student("小美", "甲", 85m),
    new Student("小芳", "甲", 47m),
    new Student("大雄", "乙", 73m),
    new Student("靜香", "甲", 100m),
    new Student("胖虎", "乙", 60m),   // 剛好 60 → 檢查及格條件寫 >= 還是 >
};

// ---- A. 重寫 Day02 統計:筆數、總分、平均、最高、最低 ----
// TODO
var count = students.Count();
var scores = students.Select(s => s.Score).ToList();
var sum = scores.Sum();
var avg = scores.Average();
var max = scores.Max();
var min = scores.Min();

//Console.WriteLine($"共{count}筆、總分{sum}、平均{avg}、最高{max}、最低{min}");

// ---- B1. 列出所有及格(60 分以上)的學生 ----
// TODO
var pass = students.Where(s => s.Score >= 60);

foreach(var student in pass)
{

    //Console.Write(student.Name);
    //Console.Write(student.ClassName);
    //Console.WriteLine(student.Score);
}

// ---- B2. 只取出名字變成 List<string>,一行印出 ----
// TODO
var pass2 = String.Join(",",students.Where(s => s.Score >= 60).Select(s => s.Name).ToList());

//Console.WriteLine(pass2);

// ---- B3. 排行榜:分數高到低,同分依姓名 ----
// TODO
var rank = students.OrderByDescending(s => s.Score).ThenBy(s => s.Name).ToList();

foreach (var student in rank)
{
    //Console.Write($"{student.Name} {student.ClassName} {student.Score}");
}

// ---- B4. 輸入姓名找學生,找不到印「查無此人」 ----
// TODO
//Console.Write("輸入姓名找學生：");
//var search = Console.ReadLine();

//var found = students.FirstOrDefault(s => s.Name == search);

//if (found == null)
//{
//    Console.WriteLine("查無此人");
//}
//else
//{
//    Console.WriteLine($"{found.Name} {found.ClassName} {found.Score}");
//}

// ---- B5. 有沒有人不及格? ----
// TODO

//var nopass = students.Where(s => s.Score < 60).ToList();

//if (nopass.Any())
//{
//    var len = nopass.Count();
//    Console.WriteLine($"有{len}個人不及格");
//}
//else
//{
//    Console.WriteLine("沒有人不及格");
//}

// ---- B6. 點名單上有在 students 裡的人 ----
//List<string> callList = new List<string> { "小明", "小華", "不存在的人" };
//// TODO
//var called = students.Where(s => callList.Contains(s.Name));
//foreach (var student in called)
//{
//    Console.WriteLine($"{student.Name} {student.ClassName} {student.Score}");
//}


// ---- B7. 不及格的有幾人? ----
// TODO


// ---- C. 依班級分組:每班人數與平均 ----
// TODO
var groups = students.GroupBy(s => s.ClassName);

foreach (var g in groups)
{
    //Console.WriteLine(g.Key);
    //Console.WriteLine(g.Count());
    var scoresList = g.Select(s => s.Score).ToList();
    //Console.WriteLine(scoresList.Average());
    Console.WriteLine($"{g.Key}班有{g.Count()}人，平均{scoresList.Average()}");
}


public class Student
{
    public string Name { get; private set; }
    public string ClassName { get; private set; }
    public decimal Score { get; private set; }

    public Student(string name, string className, decimal score)
    {
        Name = name;
        ClassName = className;
        Score = score;
    }
}
