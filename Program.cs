using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MySecondApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\AAcht\Desktop\repc\";

            var issue1 = new Issue("First issue");
            var issue2 = new Issue("Second issue");
            var issue3 = new Issue("Third issue");

            var rep = new RepositoryTxt();

            //rep.AddIssue(issue1, path);
            //rep.AddIssue(issue2, path);
            //rep.AddIssue(issue3, path);

            var issues = rep.GetIssues(path, "*txt");

            //Console.WriteLine(issues);

            var issuesList = issues.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            var param = new List<string>();

            var result = new List<Issue>();

            foreach (var issue in issuesList)
            {
                foreach (var items in issue.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToList())
                {
                    var p = items.Split(": ");
                    param.Add(p[1]);
                }
                var issueObj = new Issue();

                issueObj.Id = Convert.ToInt32(param[0]);
                issueObj.Name = param[1];
                issueObj.CreatedDate = Convert.ToDateTime(param[2]);
                issueObj.State = Enum.Parse<State>(param[3]);

                result.Add(issueObj);

                //param.Clear();
            }

            foreach (var p in result)
            {
                Console.WriteLine(p);
            }
        }
    }

    public class IssueService
    {
        public void ChangeState(Issue issue, State state)
        {
            issue.State = state;
        }
    }
}
