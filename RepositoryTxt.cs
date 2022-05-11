using System.IO;

namespace MySecondApp
{
    // Загуглить как добавлять в файл данные. Загуглить как из файла получить данные
    public class RepositoryTxt
    {
        public void AddIssue(Issue issue, string path)
        {
            if (issue != null)
                File.AppendAllText(path + "repc.txt", issue.ToString());
        }

        public string GetIssues(string path, string extension)
        {
            var files = Directory.GetFiles(path, extension);
            var data = "";

            foreach (var file in files)
            {
                if (File.Exists(file))
                {
                    data += File.ReadAllText(file);
                }
            }
            return data;
        }

        // Пока не трогать
        public Issue GetIssue(int id)
        {
            return null;
        }

        public void DeleteIssue(int id)
        {

        }

        public void UpdateIssue(int id)
        {

        }
    }
}
