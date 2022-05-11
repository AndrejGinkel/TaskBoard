using System;
using ToDoList.Models;


namespace ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"E:\!C#_Profect_for_Git\DataJson";
            var issueRepository = new IssueRepository(path);

            var issue = new Issue("First");

            for (int i = 0; i < 5; i++)
            {
                issueRepository.Add(issue);
            }
           
            

            //Console.WriteLine(issueRepository.Get(1));

            //issueRepository.Update(1,State.InProgress, "Test Description");

            //Console.WriteLine(issueRepository.Get(1));

            //issueRepository.Delete(2);

            var result = issueRepository.Get();


            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
