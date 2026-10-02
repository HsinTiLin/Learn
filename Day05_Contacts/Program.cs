Console.WriteLine("1 新增、2 列出全部、3 依姓名查詢、4 刪除、q 離開");
var ans = Console.ReadLine();
Dictionary<string, Contact> textTable = new();
while (ans != "q") {
    switch (ans)
    {
        case "1":
            Console.WriteLine("你選了新增");
            Console.Write("請輸入姓名：");
            var name = Console.ReadLine();
            if (textTable.ContainsKey(name))
            {
                Console.WriteLine("此人已存在");
            }
            else
            {
                Console.Write("請輸入電話：");
                var phone = Console.ReadLine();
                var info = new Contact(name, phone);
                textTable.Add(info.Name, info);
            }
           
            break;
        case "2":
            Console.WriteLine("你選了列出全部");
            if (textTable.Count() > 0)
            {
                foreach (var text in textTable)
                {
                    var c = text.Value;
                    Console.WriteLine("姓名:{0}", c.Name);
                    Console.WriteLine("電話:{0}", c.Phone);
                }
            }
            else
            {
                Console.WriteLine("尚無資料");
            }
            break;
        case "3":
            Console.WriteLine("你選了依姓名查詢");
            var sname = Console.ReadLine();
            if (textTable.ContainsKey(sname))
            {
                var c = textTable[sname];
                Console.WriteLine("姓名:{0}", c.Name);
                Console.WriteLine("電話:{0}", c.Phone);
            }
            else
            {
                Console.WriteLine("查無此人");
            }
            break;
        case "4":
            Console.WriteLine("你選了刪除");
            var dname = Console.ReadLine();
            if (textTable.Remove(dname))
            {
                Console.WriteLine("已刪除:{0}", dname);
            }
            else
            {
                Console.WriteLine("查無此人");
            }
            break;
        default:
            Console.WriteLine("無效輸入");
            break;
    }
    Console.WriteLine("1 新增、2 列出全部、3 依姓名查詢、4 刪除、q 離開");
    ans = Console.ReadLine();
}
Console.WriteLine("離開");


public class Contact  
{
    public string Name { get; private set; }
    public string Phone { get; private set; }
    public Contact (string name, string phone)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException("name is require!");
        }
        Name = name.Trim();
        Phone = phone.Trim();
    }
}



