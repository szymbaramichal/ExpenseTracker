namespace ExpenseTracker.Business.Models.Stocks;

public class Datum
{
    public double Open { get; set; }
    public double High { get; set; }
    public double Low { get; set; }
    public double Close { get; set; }
    public double Volume { get; set; }
    public double AdjHigh { get; set; }
    public double AdjLow { get; set; }
    public double AdjClose { get; set; }
    public double AdjOpen { get; set; }
    public double AdjVolume { get; set; }
    public double SplitFactor { get; set; }
    public double Dividend { get; set; }
    public string Symbol { get; set; }
    public string Exchange { get; set; }
    public DateTime Date { get; set; }
}

public class Pagination
{
    public int Limit { get; set; }
    public int Offset { get; set; }
    public int Count { get; set; }
    public int Total { get; set; }
}

public class StockDataModel
{
    public Pagination Pagination { get; set; }
    public List<Datum> Data { get; set; }
}