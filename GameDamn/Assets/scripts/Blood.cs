using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("���ѧ���Թ���...");

        // ���¡������ʹ StartProgressBar() �����������ᶺ���ʹ
        StartProgressBar();

        // �ӧҹ����Ѻ���ҷ���˹��������ᶺ���ʹ����͹���
        for (int i = 0; i <= 100; i++)
        {
            UpdateProgressBar(i); // ���¡������ʹ UpdateProgressBar() �����ѻവᶺ���ʹ
            Thread.Sleep(50); // ��ش�ѡ���������������ö�ͧ��繡������͹��Ǣͧᶺ���ʹ
        }

        Console.WriteLine("�������!");
    }

    static void StartProgressBar()
    {
        Console.Write("["); // ����������ҧᶺ���ʹ��������ͧ���� [
    }

    static void UpdateProgressBar(int progress)
    {
        Console.CursorLeft = 1; // ���µ��˹� Cursor 价����˹觷���ͧ����ʴ�ᶺ���ʹ
        Console.Write(new string('#', progress) + new string('-', 100 - progress) + $"] {progress}%"); // ���ҧᶺ���ʹ��������ͧ���� # ��� - ����ʴ������繵�����׺˹��
    }
}
