using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApps;

public class Message
{
    public string Id { get; set; }
    public string Data { get; set; }
}
public class MarketInfo
{
    public string Id { get; set; }
    public string MessageName { get; set; }
    public string Data { get; set; }
    public string Notes { get; set; }
    public bool IsOverride { get; set; }
    public string TradingDate { get; set; }
    public DateTime ProcessTime { get; set; } = DateTime.Now;
    public long SessionNumber { get; set; }
    public long InputSequenceNumber { get; set; }

}
public class Result<T>
{
    public Result()
    {
        Errors = new List<string>();
    }

    public Result(T value) : this()
    {
        Value = value;
    }

    public Result(params string[] errors) : this()
    {
        Errors = errors;
    }

    public Result(IList<string> errors) : this()
    {
        Errors = errors;
    }

    public bool Succeeded => Errors.Count == 0;
    public T Value { get; }
    public IList<string> Errors { get; set; }
}