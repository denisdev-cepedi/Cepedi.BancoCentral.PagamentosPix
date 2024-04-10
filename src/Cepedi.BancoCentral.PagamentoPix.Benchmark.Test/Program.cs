// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Cepedi.BancoCentral.PagamentoPix.Benchmark.Test;
using Cepedi.BancoCentral.PagamentoPix.Benchmark.Test.Helpers;
using Cepedi.BancoCentral.PagamentoPix.Benchmark.Tests;

//var summary = BenchmarkRunner.Run<StringConcatenationVsStringBuilderBenchmark>();
//var summary = BenchmarkRunner.Run<IterationBenchmark>();
//var summary = BenchmarkRunner.Run<ArrayCopyBenchmark>();
var summary = BenchmarkRunner.Run<DapperVsEfCoreBenchmark>();
