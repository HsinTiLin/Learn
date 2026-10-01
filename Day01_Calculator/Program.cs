// 第 1 天:Console 計算機
// 目標:輸入兩個數字與運算符號,印出結果。
// 練習重點:變數、型別、運算式、輸入輸出。
//
// 提示(查資料關鍵字):
//   Console.ReadLine()   讀取使用者輸入(回傳 string)
//   decimal.Parse()  或  decimal.TryParse()   字串轉數字
//   Console.WriteLine()  輸出,可搭配字串插值 $"{a} + {b} = {result}"

// 步驟 1:提示並讀取第一個數字,存進 decimal 變數
Console.WriteLine("請輸入第一個數字:");
// TODO: 讀取輸入並轉成 decimal
var firstNumber = Console.ReadLine();
decimal parsedFirstNumber;
while (decimal.TryParse(firstNumber, out parsedFirstNumber) == false)
{
    Console.WriteLine("請輸入有效的數字");
    firstNumber = Console.ReadLine();
}

// 步驟 2:讀取運算符號(+ - * /)
// TODO
Console.WriteLine("請輸入運算符號 (+, -, *, /):");
string operation = Console.ReadLine();
while (operation != "+" &&  operation != "-" && operation != "*" && operation != "/" )
{
    Console.WriteLine("請輸入有效的運算符號");
    operation = Console.ReadLine();
}

// 步驟 3:讀取第二個數字
Console.WriteLine("請輸入第二個數字:");
// TODO
var secondNumber = Console.ReadLine();
decimal parsedSecondNumber;
while (decimal.TryParse(secondNumber, out parsedSecondNumber) == false)
{
    Console.WriteLine("請輸入有效的數字");
    secondNumber = Console.ReadLine();
}

// 步驟 4:依運算符號計算(先用 if / else if,明天學流程控制後可改 switch)
// TODO
decimal result = 0.0m;
if (operation == "+")
{
    result = parsedFirstNumber + parsedSecondNumber;
}
else if (operation == "-")
{
    result = parsedFirstNumber - parsedSecondNumber;
}
else if(operation == "*")
{
    result = parsedFirstNumber * parsedSecondNumber;
}
else if(operation == "/")
{
    if (parsedSecondNumber == 0)
    {
        Console.WriteLine("錯誤: 除數不能為 0");
        return;
    }
    else
    {
        result = parsedFirstNumber / parsedSecondNumber;
    }
}

// 步驟 5:印出結果,格式例如 "3 + 5 = 8"
// TODO

Console.WriteLine($"{parsedFirstNumber} {operation} {parsedSecondNumber} = {result}");

// ---- 完成基本版後的挑戰 ----
// 1. 除數為 0 時,顯示錯誤訊息而不是當掉
// 2. 使用者輸入的不是數字時,用 decimal.TryParse 提示重新輸入
// 3. 把計算部分抽成方法 static decimal Calculate(decimal a, char op, decimal b)
