Console.WriteLine("1 新增、2 列出全部、3 依姓名查詢、4 刪除、q 離開");
var ans = Console.ReadLine();
IContactBook book = new ContactBook();
while (ans != "q") {
    switch (ans)
    {
        case "1":
           Console.WriteLine("你選了新增");
           Console.WriteLine("姓名:");
            var name = Console.ReadLine();
            Console.WriteLine("電話:");
            var phone = Console.ReadLine();
           var info = new Contact(name, phone);
           if (book.Insert(info))
            {
                Console.WriteLine("已新增");
            }
            else
            {
                Console.WriteLine("此人已存在");
            }
           break;
        case "2":
            Console.WriteLine("你選了列出全部");
            if (book.ListAll().Count()>0)
            {
                foreach (var text in book.ListAll())
                {
                    Console.WriteLine($"姓名:{text.Name} 電話:{text.Phone}");
                }
            }
            else
            {
                Console.WriteLine("列表為空");
            }

            break;
        case "3":
            Console.WriteLine("你選了依姓名查詢");
            Console.WriteLine("姓名:");
            var sname = Console.ReadLine();
            var  c = book.Search(sname);
            if (c != null)
            {
                Console.WriteLine($"姓名:{c.Name} 電話:{c.Phone}");
            }
            else
            {
                Console.WriteLine($"查無{sname}");
            }

            break;
        case "4":
            Console.WriteLine("你選了刪除");
            Console.WriteLine("姓名:");
            var dname = Console.ReadLine();
            if (book.Remove(dname))
            {
                Console.WriteLine($"已刪除{dname}");
            }
            else
            {
                Console.WriteLine($"查無{dname}");
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

interface IContactBook
{
    // 新增
    bool Insert(Contact contact);// 新增:成功或失敗
    // 列出全部
    List<Contact> ListAll();// 列出全部:一疊名片
    // 依姓名查詢
    Contact? Search(string name);// 查詢:一張名片,或沒有
    // 刪除
    bool Remove(string name);// 刪除:成功或失敗
}


public class ContactBook : IContactBook
{
    private Dictionary<string, Contact> textTable = new();

    public bool Insert(Contact contact)
    {
        if (textTable.ContainsKey(contact.Name))
        {
            return false;
        }
        else
        {
            textTable.Add(contact.Name, contact);
            return true;
        }
    } 

    public Contact? Search(string name)
    {
        if (textTable.ContainsKey(name))
        {
            var c = textTable[name];
            return c;
        }
        else
        {
            return null;
        }
    }

    public List<Contact> ListAll()
    {
        // 1. 準備一個空的清單(Day02 怎麼 new 一個 List<decimal>?換成 Contact)
        List<Contact> result = new();

        // 2. 一張一張看名片盒(跟選單 case 2 的 foreach 一樣)
        foreach (var text in textTable)
        {
            // 3. 把名片放進清單(選單 case 2 怎麼從 text 拿出名片?)
            result.Add(text.Value);
        }

        // 4. 交出清單
        return result;

    }


    public bool Remove(string name)
    {
        if (textTable.Remove(name))
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

}