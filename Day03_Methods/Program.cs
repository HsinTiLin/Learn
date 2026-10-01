// 第 3 天:方法(Method)
// 目標:把昨天「一長串」的成績統計,拆成一個個有名字、可重複使用的方法。
// 練習重點:方法的宣告、參數、回傳值、out 參數、方法的作用域。
//
// 提示(查資料關鍵字,Microsoft Learn 繁中):
//   C# 方法 (method)
//   回傳型別 void
//   return
//   參數 (parameter) 與引數 (argument)
//   List<decimal> 當作參數傳入
//   區域變數的作用域

// ---- 暖身(先做這 3 個,體會方法的寫法)----
// 1. 寫 static decimal Add(decimal a, decimal b),回傳 a+b,在下面呼叫並印出結果
// 2. 寫 static bool IsPass(decimal score),60 分以上回傳 true
// 3. 寫 static void PrintLine(string text),印出「--- text ---」
//    思考:為什麼 3 回傳 void,而 1、2 不是?

Console.WriteLine("=== 暖身 ===");
// TODO
static decimal Add(decimal a, decimal b)
{
    return a + b;
}

static bool IsPass(decimal score)
{
    return score >= 60;
}

static void PrintLine(string text)
{
    Console.WriteLine("--- {0} ---",text);
}


// ---- 基本版:重構成績統計 ----
// 把昨天 Day02_Grades 的程式,拆成下列方法(簽章自己決定,至少要有這些功能):
//   ReadScores()          讀取輸入,回傳 List<decimal>(q 結束,0–100 驗證)
//   CalcTotal(...)        回傳總分(仍用 foreach,不用 Sum())
//   CalcMax(...)          回傳最高分
//   CalcMin(...)          回傳最低分
//   PrintResult(...)      印出結果
// 最後 Main 區(最上面那段)只剩幾行:讀取 → 檢查是否為空 → 呼叫計算 → 印出。
Console.WriteLine("=== 成績統計 ===");
// TODO
var res = ReadScores();
Console.WriteLine("次數:{0}", res.Count);

List<decimal> ReadScores()
{
    List<decimal> scores = new List<decimal>();
    Console.WriteLine("請輸入數字或 q 結束");
    var score = Console.ReadLine();
    while ( score != "q")
    {
        if (decimal.TryParse(score,out decimal parsedScore))
        {
            if (parsedScore < 0 || parsedScore > 100)
            {
                Console.WriteLine("成績必須在 0 到 100 之間，請重新輸入數字或 q 結束");
                score = Console.ReadLine();
                continue;
            }
            scores.Add(parsedScore);

        }else
        {
            Console.WriteLine("輸入無效，請重新輸入數字或 q 結束");
        }
        score = Console.ReadLine();
    }
    return scores;
}
decimal CalcTotal(List<decimal> scores)
{
    decimal total = 0;
    foreach (var score in scores)
    {
        total += score;
    }
    return total;
}

// ---- 進階版(基本版完成後再做)----
// 1. 寫 static bool TryReadScore(string? input, out decimal score)
//    把「是數字且在 0–100」包成一個方法,仿照 decimal.TryParse 的樣子
// 2. 寫 static decimal CalcAverage(...),列表為空時要怎麼處理?想好再寫
// 3. 寫 static int CountPass(List<decimal> scores),回傳及格人數
// 4. 方法的「多載(overload)」是什麼?試著寫兩個同名但參數不同的方法


// ---- 打卡表的產出:字串處理工具(基本版做完後再做)----
// 寫成方法,各自在上面呼叫測試:
//   1. static int CountWords(string text)          算有幾個單字(以空白分隔)
//   2. static string ReverseText(string text)      反轉字串
//   3. static bool IsPalindrome(string text)       是否迴文(忽略大小寫)
//   4. static string MaskId(string id)             A123456789 -> A12****789
// 查資料關鍵字:string.Split、string.Trim、ToUpper/ToLower、Substring、
//   string.IsNullOrWhiteSpace、string.Join、char[] 與 Array.Reverse



// 方法寫在這個檔案的最下面(top-level statements 的方法可寫在這裡)
// TODO
