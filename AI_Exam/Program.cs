// See https://aka.ms/new-console-template for more information

using System;
using chen0040.ExpertSystem;


var inferenceEngine = new RuleInferenceEngine();

var rule = new Rule("Мытый или нет");
rule.AddAntecedent(new IsClause("Значение чистоты", "1"));
rule.setConsequent(new IsClause("Мытый", "да"));
inferenceEngine.AddRule(rule);

rule = new Rule("Мытый или нет");
rule.AddAntecedent(new IsClause("Значение чистоты", "0"));
rule.setConsequent(new IsClause("Мытый", "нет"));
inferenceEngine.AddRule(rule);

rule = new Rule("Вкусный или нет");
rule.AddAntecedent(new GreaterClause("Значение вкуса", "2"));
rule.setConsequent(new IsClause("Вкусный", "да"));
inferenceEngine.AddRule(rule);

rule = new Rule("Вкусный или нет");
rule.AddAntecedent(new LessClause("Значение вкуса", "2"));
rule.setConsequent(new IsClause("Вкусный", "нет"));
inferenceEngine.AddRule(rule);

rule = new Rule("Ароматный или нет");
rule.AddAntecedent(new GreaterClause("Значение запаха", "2"));
rule.setConsequent(new IsClause("Ароматный", "да"));
inferenceEngine.AddRule(rule);

rule = new Rule("Ароматный или нет");
rule.AddAntecedent(new LessClause("Значение запаха", "2"));
rule.setConsequent(new IsClause("Ароматный", "нет"));
inferenceEngine.AddRule(rule);

rule = new Rule("Съедобный или нет");
rule.AddAntecedent(new IsClause("Мытый", "да"));
rule.AddAntecedent(new IsClause("Вкусный", "да"));
rule.AddAntecedent(new IsClause("Ароматный", "да"));
rule.setConsequent(new IsClause("съедобность", "съедобно"));
inferenceEngine.AddRule(rule);

rule = new Rule("Съедобный или нет");
rule.AddAntecedent(new IsClause("Мытый", "нет"));
rule.AddAntecedent(new IsClause("Вкусный", "нет"));
rule.AddAntecedent(new IsClause("Ароматный", "нет"));
rule.setConsequent(new IsClause("съедобность", "не съедобно"));
inferenceEngine.AddRule(rule);

rule = new Rule("Съедобный или нет");
rule.AddAntecedent(new IsClause("Мытый", "нет"));
rule.AddAntecedent(new IsClause("Вкусный", "нет"));
rule.AddAntecedent(new IsClause("Ароматный", "да"));
rule.setConsequent(new IsClause("съедобность", "не съедобно"));
inferenceEngine.AddRule(rule);

rule = new Rule("Съедобный или нет");
rule.AddAntecedent(new IsClause("Мытый", "нет"));
rule.AddAntecedent(new IsClause("Вкусный", "да"));
rule.AddAntecedent(new IsClause("Ароматный", "да"));
rule.setConsequent(new IsClause("съедобность", "съедобно"));
inferenceEngine.AddRule(rule);

rule = new Rule("Съедобный или нет");
rule.AddAntecedent(new IsClause("Мытый", "да"));
rule.AddAntecedent(new IsClause("Вкусный", "нет"));
rule.AddAntecedent(new IsClause("Ароматный", "нет"));
rule.setConsequent(new IsClause("съедобность", "не съедобно"));
inferenceEngine.AddRule(rule);

Console.WriteLine("Введите значения через пробел:");

string str = Console.ReadLine()!;

inferenceEngine.AddFact(new IsClause("Значение чистоты", str.Split(" ")[0]));
inferenceEngine.AddFact(new IsClause("Значение вкуса", str.Split(" ")[1]));
inferenceEngine.AddFact(new IsClause("Значение запаха", str.Split(" ")[2]));


inferenceEngine.Infer();
Console.WriteLine("все факты:");
Console.WriteLine(inferenceEngine.Facts); 

/*
inferenceEngine.Infer();
var conclusion = inferenceEngine.Facts.IsFact(new IsClause("съедобность", "съедобно")); 
Console.WriteLine("Вывод:");
Console.WriteLine(conclusion ? "съедобно" : "Логически съедобность не определена.");
*/
