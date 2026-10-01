// 第 2 天:成績統計
// 目標:輸入多筆成績,輸入 q 結束,印出總分、平均、最高分、最低分。
// 練習重點:List<T>、foreach、while、Dictionary、流程控制。
//
// 提示(查資料關鍵字):
//   List<decimal>.Add()          新增項目
//   List<decimal>.Count          項目數量
//   foreach (var s in scores)    逐一走訪
//   Dictionary<string, decimal>  用姓名查成績
//   decimal.TryParse()           驗證輸入(昨天用過)

// ---- 基本版 ----
Console.WriteLine("=== 成績統計 ===");

// 步驟 1:建立一個 List<decimal> 存放成績
// TODO
List<decimal> list = new List<decimal>();

// 步驟 2:用 while 重複讀取成績,輸入 q 結束
//         輸入不是數字也不是 q 時,提示重新輸入
// TODO
Console.WriteLine("請輸入數字或 q 結束");
string input = Console.ReadLine();
while (input != "q")
{
    if (decimal.TryParse(input, out decimal score))
    {
        if (score < 0 || score > 100)
        {
            Console.WriteLine("成績必須在 0 到 100 之間，請重新輸入數字或 q 結束");
            continue;
        }
        list.Add(score);
        Console.WriteLine("請輸入數字或 q 結束");
    }
    else
    {
        Console.WriteLine("輸入無效，請重新輸入數字或 q 結束");
    }
    input = Console.ReadLine();
}

// 步驟 3:沒有輸入任何成績時,提示並結束(避免除以 0)
// TODO
if (list.Count == 0)
{
    Console.WriteLine("沒有輸入任何成績");
    return;
}

// 步驟 4:用 foreach 算出總分(先不要用 Sum())
// TODO
var total = 0m;
foreach (var score in list)
{
    total += score;
}

// 步驟 5:算出平均、最高分、最低分(先用 foreach 手寫,不要用 Max()/Min())
// TODO
var avg = total / list.Count;
var max = list[0];
var min = list[0];
foreach (var score in list)
{
    if (score > max)
    {
        max = score;
    }
    else if (score < min)
    {
        min = score;
    }
}

// 步驟 6:印出結果,例如
//   共 5 筆
//   總分:410
//   平均:82
//   最高:95
//   最低:60
// TODO
Console.WriteLine($"共 {list.Count} 筆");
Console.WriteLine($"總分: {total}");
Console.WriteLine($"平均: {avg}");
Console.WriteLine($"最高: {max}");
Console.WriteLine($"最低: {min}");


// ---- 進階版(基本版完成後再做) ----
// 1. 改用 Dictionary<string, decimal> 存「姓名 → 成績」
// 2. 可以輸入姓名查詢該生成績,查不到時要提示
// 3. 統計及格(60 分以上)與不及格人數
// 4. 成績限制在 0–100,超出範圍要重新輸入
