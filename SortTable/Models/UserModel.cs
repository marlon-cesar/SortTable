using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SortTable.Models
{
    public class UserModel
    {
        public UserModel(int id, string name, int document)
        {
            Id = id;
            Name = name;
            Document = document;
        }
        [HiddenInput]
        public int Id { get; set; }
        [Display(Name = "User Name")]
        public string Name { get; set; }
        public int Document { get; set; }
    }
}
