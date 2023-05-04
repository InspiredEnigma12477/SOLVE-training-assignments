namespace StockMarketAPI.Utils
{
    using System.Text.RegularExpressions;

    public static class RegexPatterns
    {
        public static readonly Regex StockTickerSymbol = new Regex(@"^[A-Za-z]{3,10}$");
        public static readonly Regex StockName = new Regex(@"^[A-Za-z0-9.&()/-]+$");
    }
}