## Backend Setup

1.เปลี่ยน ConnectionStrings ที่ appsettings.json
   "ConnectionStrings": {
     "DefaultConnection": "Server=ServerName; Database=TestTCC; User Id=UserName; Password=Password; TrustServerCertificate=True;"
 } 
2. สร้าง DB
รันคำสั่งในโฟลเดอร์ /server ด้วย dotnet ef database update
หรือ
เปิดไฟล์ ScriptDB.sql แล้วรันใน SQL Server SSMS
3. Run
