using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Models;


namespace ToDoList
{
    public class IssueRepository
    {
        private readonly JsonContext _context;

        public IssueRepository(string path)
        {
            _context = new JsonContext(path);
        }

        public void Add(Issue issue)
        {
            var issueId = SetId();

            var issueDto = new Issue
            {
                Id = issueId,
                Name = issue.Name,
                Description = issue.Description,
                CreatedDate = issue.CreatedDate,
                EndDate = issue.EndDate
            };

            _context.Add(issueDto);
        }

        public void Delete(int id)
        {
            _context.Delete(id);
        }

        public Issue Get(int id)
        {
            return Get().FirstOrDefault(x => x.Id == id);
        }

        public List<Issue> Get()
        {
            var result = _context.Get();

            return result.ToList();
        }

        public void Update(int id, State state, string Description = null)
        {
            var issueDto = Get(id);

            if (issueDto == null) return;

            var issue = new Issue
            {
                Id = id,
                Name = issueDto.Name,
                Description = Description,
                CreatedDate = issueDto.CreatedDate,
                State = state
            };

            _context.Update(issue);
        }

        private int SetId()
        {
            var issues = Get();
            if (issues.Count != 0)
            {
                var ids = new List<int>();
                foreach (var issue in issues)
                {
                    ids.Add(issue.Id);
                }
                return ids.Max(x => x) + 1;
            }
            else
                return 1;
        }
    }
}
