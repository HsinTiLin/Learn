using System.Text.Json;
using System.Text.Json.Serialization;

var c = new Contact("小明", "123", ContactType.Friend);
string json = JsonSerializer.Serialize(c);

Console.WriteLine(json);
await Task.Delay(3000);
File.WriteAllText("contact.json", json);          // 寫：檔名、內容
string fromFile = File.ReadAllText("contact.json"); // 讀：檔名

Contact? back = JsonSerializer.Deserialize <Contact> (fromFile);
Console.WriteLine(back?.Name);
Console.WriteLine(back?.CreatedAt.ToString("HH:mm:ss"));



public class Contact
{
    public string Name { get; private set; }
    public string Phone { get; private set; }
    public ContactType Type { get; private set; }
    [JsonInclude]
    public DateTime CreatedAt { get; private set; }


    public Contact(string name, string phone, ContactType type)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("姓名必填");
        }
        Name = name.Trim();
        Phone = phone.Trim();
        Type = type;
        CreatedAt = DateTime.Now;

    }
}

public enum ContactType
{
    Family,
    Friend,
    Work
}


