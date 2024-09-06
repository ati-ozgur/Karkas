using System.IO;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine(Directory.GetCurrentDirectory());

Console.WriteLine();

string jsonFilePath = $"{AppDomain.CurrentDomain.BaseDirectory}/config.json";

string fileContents = File.ReadAllText(jsonFilePath);

Console.WriteLine(fileContents);
