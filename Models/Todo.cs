using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreTodo.Models{
    public class Todo{
        public Guid Id { get; set; } // Globally unique identifier || Auto Generated
        public bool IsDone { get; set; } // Bool true or false || Default false
        [Required]// Require the Title property to be filled out, it cannot be null or empty
        public string Title { get; set; } // String or collection of char || Hold name of todo
        public DateTimeOffset? DueAt { get; set; } // Datetime element || Stores a timestamp || The ? makes datetime a nullable property or able to be empty
    }// Defines TodoItem => A class with an Id, IsDone, Title, and DueAt properties
}