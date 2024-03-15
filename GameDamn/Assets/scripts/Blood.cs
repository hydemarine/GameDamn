using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("กำลังดำเนินการ...");

        // เรียกใช้เมท็อด StartProgressBar() เพื่อเริ่มต้นแถบเลือด
        StartProgressBar();

        // ทำงานสำหรับเวลาที่กำหนดเพื่อให้แถบเลือดเคลื่อนไหว
        for (int i = 0; i <= 100; i++)
        {
            UpdateProgressBar(i); // เรียกใช้เมท็อด UpdateProgressBar() เพื่ออัปเดตแถบเลือด
            Thread.Sleep(50); // หยุดสักครู่เพื่อให้สามารถมองเห็นการเคลื่อนไหวของแถบเลือด
        }

        Console.WriteLine("เสร็จสิ้น!");
    }

    static void StartProgressBar()
    {
        Console.Write("["); // เริ่มต้นสร้างแถบเลือดด้วยเครื่องหมาย [
    }

    static void UpdateProgressBar(int progress)
    {
        Console.CursorLeft = 1; // ย้ายตำแหน่ง Cursor ไปที่ตำแหน่งที่ต้องการแสดงแถบเลือด
        Console.Write(new string('#', progress) + new string('-', 100 - progress) + $"] {progress}%"); // สร้างแถบเลือดโดยใช้เครื่องหมาย # และ - และแสดงเปอร์เซ็นต์ความคืบหน้า
    }
}
