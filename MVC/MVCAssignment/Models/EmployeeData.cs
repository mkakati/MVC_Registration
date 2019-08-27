using System;
using System.ComponentModel.DataAnnotations;

namespace MVCAssignment.Models
{
    public class EmployeeData
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string Address { get; set; }
        public string ImageActualName { get; set; }
        public string ImageName { get; set; }
    }

    //    public class Country
    //    {
    //        public int Id { get; set; }
    //        public string Name { get; set; }
    //    }
    //    public class State
    //    {
    //        public int Id { get; set; }
    //        public string Name { get; set; }
    //        public int CountryID { get; set; }
    //    }
}