# بازی حدس عدد (Number Guessing Game)

این پروژه یک برنامهٔ کنسول سادهٔ C# است که از کاربر می‌خواهد عددی بین 1 تا 100 حدس بزند.

نحوهٔ ساخت و اجرا:

1. برای ساخت:
   dotnet build .\NumberGuessingGame -c Release

2. برای اجرای تعاملی:
   dotnet run --project .\NumberGuessingGame -c Release

3. برای اجرای خودکار (برای تست بدون نیاز به ورودی کاربر):
   در PowerShell:
     $env:AUTOTEST = "1"; dotnet run --project .\NumberGuessingGame -c Release

این پروژه شامل حالت AUTOTEST است تا بتوان اجرای بدون خطا را به صورت غیرتعاملی اعتبارسنجی کرد.
