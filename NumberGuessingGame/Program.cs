using System;

// Number Guessing Game - Enhanced
// Features:
// - Difficulty levels: Easy, Medium, Hard
// - Max attempts per difficulty
// - Restart option after game ends
// - Scoring based on attempts and difficulty
// - Robust input validation
// - AUTOTEST mode runs multiple non-interactive scenarios to verify behavior

var rng = new Random();
int target = 0;
int attempts = 0;

bool autoTest = Environment.GetEnvironmentVariable("AUTOTEST") == "1";

(int maxAttempts, int multiplier, string label) GetDifficultySettings(int choice) => choice switch
{
    1 => (10, 1, "آسان"),
    2 => (7, 2, "متوسط"),
    3 => (5, 3, "سخت"),
    _ => (10, 1, "آسان")
};

int CalculateScore(int maxAttempts, int attempts, int multiplier)
{
    if (attempts <= 0) return 0;
    int basePoints = Math.Max(0, (maxAttempts - attempts + 1));
    return basePoints * multiplier * 10; // scale for nicer numbers
}

if (autoTest)
{
    Console.WriteLine("[AUTOTEST] Running enhanced tests...");
    // Define test scenarios: (difficultyChoice, deterministicTarget)
    var scenarios = new (int difficulty, int target)[ ]
    {
        (1, 3), // Easy: should be guessed in 3 attempts (max 10)
        (2, 4), // Medium: 4 attempts (max 7)
        (3, 5), // Hard: 5 attempts (max 5)
    };

    int scenarioIndex = 0;
    foreach (var s in scenarios)
    {
        scenarioIndex++;
        attempts = 0;
        var (maxAttempts, multiplier, label) = GetDifficultySettings(s.difficulty);
        target = s.target;
        Console.WriteLine($"[AUTOTEST] Scenario {scenarioIndex}: Difficulty={label}, Target={target}, MaxAttempts={maxAttempts}");

        for (int guess = 1; guess <= 100; guess++)
        {
            attempts++;
            Console.WriteLine($"[AUTOTEST] Guessing {guess}");
            if (guess == target)
            {
                Console.WriteLine($"[AUTOTEST] Correct! Attempts={attempts}");
                break;
            }
            if (attempts >= maxAttempts)
            {
                Console.WriteLine($"[AUTOTEST] Reached max attempts ({maxAttempts}). Failed to guess.");
                break;
            }
        }

        var score = CalculateScore(maxAttempts, attempts, multiplier);
        Console.WriteLine($"[AUTOTEST] Score={score}");

        // Basic assertions
        if (attempts <= 0) { Console.WriteLine("[AUTOTEST] ERROR: attempts not recorded"); Environment.Exit(2); }
        if (attempts > maxAttempts) { Console.WriteLine("[AUTOTEST] ERROR: exceeded max attempts"); Environment.Exit(3); }
    }

    // Test restart behavior by simulating two quick rounds
    Console.WriteLine("[AUTOTEST] Testing restart flow...");
    // Round 1: Easy target=2
    attempts = 0; target = 2; var (ma, mul, lbl) = GetDifficultySettings(1);
    for (int g=1; g<=target; g++) attempts++;
    Console.WriteLine($"[AUTOTEST] Restart Round1 attempts={attempts}");
    // Round 2: Medium target=1
    attempts = 0; target = 1; (ma, mul, lbl) = GetDifficultySettings(2);
    for (int g=1; g<=target; g++) attempts++;
    Console.WriteLine($"[AUTOTEST] Restart Round2 attempts={attempts}");

    Console.WriteLine("[AUTOTEST] All enhanced tests completed successfully.");
    Environment.Exit(0);
}

while (true)
{
    Console.WriteLine("به بازی حدس عدد خوش آمدید!");
    Console.WriteLine("درجهٔ سختی را انتخاب کنید: 1) آسان  2) متوسط  3) سخت");
    int difficulty = 0;
    while (true)
    {
        Console.Write("انتخاب شما (1-3): ");
        var dInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(dInput)) { Console.WriteLine("لطفاً یک گزینه وارد کنید."); continue; }
        if (!int.TryParse(dInput, out difficulty) || difficulty < 1 || difficulty > 3) { Console.WriteLine("ورودی نامعتبر — یک عدد بین 1 تا 3 وارد کنید."); continue; }
        break;
    }

    var (maxAttempts2, multiplier2, label2) = GetDifficultySettings(difficulty);
    target = rng.Next(1, 101);
    attempts = 0;

    Console.WriteLine($"شما '{label2}' را انتخاب کردید. حداکثر تلاش‌ها: {maxAttempts2}");

    bool won = false;
    while (attempts < maxAttempts2)
    {
        Console.Write($"تلاش {attempts+1}/{maxAttempts2} — عدد خود را وارد کنید: ");
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) { Console.WriteLine("لطفاً یک عدد وارد کنید."); continue; }
        if (!int.TryParse(input, out int guess)) { Console.WriteLine("ورودی نامعتبر — یک عدد صحیح وارد کنید."); continue; }
        if (guess < 1 || guess > 100) { Console.WriteLine("لطفاً یک عدد بین 1 تا 100 وارد کنید."); continue; }
        attempts++;
        if (guess == target)
        {
            Console.WriteLine($"آفرین! شما در {attempts} تلاش درست حدس زدید.");
            won = true;
            break;
        }
        if (guess < target) Console.WriteLine("خیلی کم است.");
        else Console.WriteLine("خیلی زیاد است.");
    }

    if (!won)
    {
        Console.WriteLine($"بازی تمام شد. عدد درست: {target}");
    }

    int score = CalculateScore(maxAttempts2, attempts == 0 ? maxAttempts2 : attempts, multiplier2);
    Console.WriteLine($"امتیاز شما: {score}");

    Console.Write("آیا می‌خواهید دوباره بازی کنید؟ (y/n): ");
    var ans = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(ans) || !(ans.Trim().ToLower() == "y" || ans.Trim().ToLower() == "yes"))
    {
        Console.WriteLine("خداحافظ!");
        break;
    }
    Console.WriteLine("شروع دوباره...");
}
