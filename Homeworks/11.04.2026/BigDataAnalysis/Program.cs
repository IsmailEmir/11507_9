using System.Diagnostics;

const string fileName = "bigdata.txt";
const int linesCount = 50_000_000;
const int bufferSize = 65536;

var random = new Random();

using (var sw = new StreamWriter(fileName))
{
    char[] lineBuffer = new char[60];
    for (long i = 0; i < linesCount; i++)
    {
        for (int j = 0; j < lineBuffer.Length; j++)
            lineBuffer[j] = (char)random.Next(32, 127);
        
        sw.WriteLine(lineBuffer);
    }
}

Console.WriteLine("Файл сгенерирован");
Console.WriteLine("\nАнализ файла:");

byte[] buffer = new byte[bufferSize];
long countA = 0;
const byte letterA = 65;

var stopwatch = Stopwatch.StartNew();

using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None, bufferSize, FileOptions.SequentialScan))
{
    int bytesRead;
    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
    {
        for (int i = 0; i < bytesRead; i++)
        {
            if (buffer[i] == letterA)
                countA++;
        }
    }
}

stopwatch.Stop();

Console.WriteLine($"Найдено символов A: {countA}");
Console.WriteLine($"Время выполнения анализа: {stopwatch.ElapsedMilliseconds} мс");
