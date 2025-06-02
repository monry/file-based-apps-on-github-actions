#!/usr/bin/env dotnet run
#:package VYaml@1.1.1

using System.Text;
using VYaml.Annotations;
using VYaml.Serialization;

var yaml = """
           foo:
           - aaa
           - bbb
           bar:
             baz: 1
             quz: true
           """;

var sample = YamlSerializer.Deserialize<Sample>(Encoding.UTF8.GetBytes(yaml));
Console.WriteLine($"{sample.Foo[1]}, {sample.Bar.Baz}, {sample.Bar.Quz}");

[YamlObject]
public partial record Sample(
    string[] Foo,
    Bar Bar
);

[YamlObject]
public partial record Bar(
    int Baz,
    bool Quz
);