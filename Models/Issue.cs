using System;

namespace ToDoList.Models
{
    public class Issue
    {
        public int Id { get; set; }

        public string Name { get; set; }  
        
        public string Description { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DateTime EndDate { get; set; }

        public State State { get; set; }

        public Issue() { }

        public Issue(string name)
        {
            Name = name;
            CreatedDate = DateTime.Now;
            State = State.ToDo;
        }

        public override string ToString()
        {
            return $" Id: {Id}\r\n Issue: {Name}\r\n Created Date: {CreatedDate}\r\n State: {State}\r\n Description: {Description}\r\n\r\n";
        }
    } 
}
    