# Number Guessing Game

این پروژه نسخهٔ ارتقاء‌یافتهٔ بازی حدس عدد است که ویژگی‌های زیر اضافه شده‌اند:

- انتخاب درجهٔ سختی: آسان، متوسط، سخت
- تعداد تلاش‌های مجاز بر اساس درجهٔ سختی
- امکان شروع دوباره بازی پس از پایان
- امتیازدهی بر اساس تعداد تلاش‌ها و سختی
- مدیریت ورودی‌های نامعتبر
- حالت AUTOTEST برای اجرای خودکار سناریوهای تست

ساخت و اجرا:
1. ساخت: dotnet build .\NumberGuessingGame -c Release
2. اجرای تعاملی: dotnet run --project .\NumberGuessingGame -c Release
3. اجرای خودکار تست: در PowerShell: $env:AUTOTEST="1"; dotnet run --project .\NumberGuessingGame -c Release
