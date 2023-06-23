using System.Diagnostics;

int validCpfCounter = 0;
int invalidCPFCounter = 0;
var x = 0;

Console.WriteLine("Quantos CPFs quer gerar?");
x = int.Parse(Console.ReadLine());

Random random = new Random();
Stopwatch sw = new();
sw.Start();

for (int i = 0; i < x; i++)
{
    string cpf = string.Empty;

    for (int j = 0; j < 9; j++)
    {
        cpf += random.Next(0, 10).ToString();
    }

    while (cpf.Length < 11)
    {
        cpf += random.Next(0, 10).ToString();
    }

    if (ValidaCPF.CpfValidator(cpf))
    {
        validCpfCounter++;
    }
    else
    {
        invalidCPFCounter++;
    }
}
sw.Stop();
TimeSpan totaltime = sw.Elapsed;
Console.WriteLine($"Nºs de CPFs válidos gerados: {validCpfCounter}");
Console.WriteLine($"Nºs de CPFs inválidos gerados: {invalidCPFCounter}");
Console.WriteLine($"Tempo total de execução : {totaltime.Milliseconds} ms");