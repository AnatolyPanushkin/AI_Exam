// See https://aka.ms/new-console-template for more information

using System;
using chen0040.ExpertSystem;


var inferenceEngine = new RuleInferenceEngine();

var rule = new Rule("Мытый или нет");
rule.AddAntecedent(new IsClause("Значение чистоты", "1"));
rule.setConsequent(new IsClause("Мытый", "да"));
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

rule = new Rule("Съедобный или нет");
rule.AddAntecedent(new IsClause("Мытый", "да"));
rule.AddAntecedent(new IsClause("Вкусный", "да"));
rule.AddAntecedent(new IsClause("Ароматный", "да"));
rule.setConsequent(new IsClause("съедобность", "съедобно"));
inferenceEngine.AddRule(rule);

rule = new Rule("Съедобный или нет");
rule.AddAntecedent(new IsClause("Мытый", "да"));
rule.AddAntecedent(new IsClause("Вкусный", "нет"));
rule.AddAntecedent(new IsClause("Ароматный", "да"));
rule.setConsequent(new IsClause("съедобность", "не съедобно"));
inferenceEngine.AddRule(rule);

inferenceEngine.AddFact(new IsClause("Значение чистоты", "1"));
inferenceEngine.AddFact(new IsClause("Значение вкуса", "3"));
inferenceEngine.AddFact(new IsClause("Значение запаха", "3"));


// inferenceEngine.Infer();
// Console.WriteLine("все факты:");
// Console.WriteLine(inferenceEngine.Facts);

inferenceEngine.Infer();
var conclusion = inferenceEngine.Facts.IsFact(new IsClause("съедобность", "съедобно")); 
Console.WriteLine("Вывод:");
Console.WriteLine(conclusion ? "съедобно" : "Логически съедобность не определена.");
