using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace PerfomanceConcatenation.Application;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class Program
{
    static void Main(string[] args) =>
        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());

    private readonly string _firstName = "Daniel", _middleName = "Abreu", _lastName = "Dantas";

    [Benchmark]
    public string StringBuilder()
    {
        var stringBuilder = new StringBuilder();
        return stringBuilder.Append(_firstName).Append(" ")
            .Append(_middleName).Append(" ")
            .Append(_lastName).Append(" ").ToString();
    }

    [Benchmark]
    public string StringBuilderExact24()
    {
        var stringBuilder = new StringBuilder(24);
        return stringBuilder.Append(_firstName).Append(" ")
            .Append(_middleName).Append(" ")
            .Append(_lastName).Append(" ").ToString();
    }

    [Benchmark]
    public string StringBuilderEstimate100()
    {
        var stringBuilder = new StringBuilder(100);
        return stringBuilder.Append(_firstName).Append(" ")
            .Append(_middleName).Append(" ")
            .Append(_lastName).Append(" ").ToString();
    }

    [Benchmark]
    public string StringPlus()
    {
        return _firstName + " " + _middleName + " " + _lastName;
    }

    [Benchmark]
    public string StringFormat()
    {
        return string.Format("{0} {1} {2}", _firstName, _middleName, _lastName);
    }

    [Benchmark]
    public string StringInterpolation()
    {
        return $"{_firstName} {_middleName} {_lastName}";
    }

    [Benchmark]
    public string StringJoin()
    {
        return string.Join(" ", _firstName, _middleName, _lastName);
    }

    [Benchmark]
    public string StringConcat()
    {
        return string.Concat(new string[] { _firstName, " ", _middleName, " ", _lastName });
    }
}