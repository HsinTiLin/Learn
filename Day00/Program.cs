// Generate a random number of days until expiration
Random random = new Random();
int daysUntilExpiration = random.Next(12);
decimal discountPercentage = 0;

// Display an expiration message based on the days remaining
if (daysUntilExpiration == 0)
{
    Console.WriteLine("訂閱已過期");
} 
else if (daysUntilExpiration == 1)
{
    discountPercentage = 20;
    Console.WriteLine("一天內到期!");
} 
else if (daysUntilExpiration > 1 && daysUntilExpiration < 6)
{
    discountPercentage = 10;
    Console.WriteLine($"還剩{daysUntilExpiration}天到期");
} 
else if (daysUntilExpiration > 5 && daysUntilExpiration < 11)
{
    Console.WriteLine("快到期了,請續訂");
}

if (discountPercentage > 0)
{
    Console.WriteLine($"您有{discountPercentage}%的折扣!");
}

// Display a discount message if a discount applies
