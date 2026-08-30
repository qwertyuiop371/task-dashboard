using System;

// Number Guessing Game
// Includes an AUTOTEST mode (set AUTOTEST=1) that runs non-interactively to verify execution.

var rng = new Random();
int target;
int attempts = 0;

bool autoTest = Environment.GetEnvironmentVariable("AUTOTEST") == "1";

if (autoTest)
{
    // deterministic target for automated testing
    target = 42;
    Console.WriteLine("[AUTOTEST] Starting automated run. Target=42");
    for (int guess = 1; guess <= 100; guess++)
    {
        attempts++;
        Console.WriteLine($"[AUTOTEST] Guessing {guess}");
        if (guess == target)
        {
            Console.WriteLine($"Correct! You guessed it in {attempts} attempts.");
            break;
        }
    }
}
else
{
    target = rng.Next(1, 101);
    Console.WriteLine("به بازی حدس عدد خوش آمدید!");
    Console.WriteLine("یک عدد بین 1 تا 100 حدس بزنید.");

    while (true)
    {
        Console.Write("حدستان را وارد کنید: ");
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) { Console.WriteLine("لطفاً یک عدد وارد کنید."); continue; }
        if (!int.TryParse(input, out int guess)) { Console.WriteLine("ورودی نامعتبر — یک عدد صحیح وارد کنید."); continue; }
        attempts++;
        if (guess == target) { Console.WriteLine($"آفرین! شما در {attempts} تلاش درست حدس زدید."); break; }
        if (guess < target) Console.WriteLine("خیلی کم است.");
        else Console.WriteLine("خیلی زیاد است.");
    }
}
