using System;
using System.IO;

class Program
{
    static void Main()
    {
        // プロジェクトのルートディレクトリを指定してください
        string projectDirectory = Environment.CurrentDirectory;

        // 'obj' と 'bin' フォルダを削除する
        DeleteDirectory(projectDirectory, "obj");
        DeleteDirectory(projectDirectory, "bin");
        Console.WriteLine("完了");
        Console.ReadKey();
    }

    static void DeleteDirectory(string parentDirectory, string directoryName)
    {
        // 指定されたディレクトリ名を持つすべてのフォルダを検索
        string[] directories = Directory.GetDirectories(parentDirectory, directoryName, SearchOption.AllDirectories);

        foreach (string directory in directories)
        {
            try
            {
                // フォルダとその内容を削除
                Directory.Delete(directory, true);
                Console.WriteLine($"Deleted {directory}");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred while deleting {directory}: {e.Message}");
            }
        }
    }
}
