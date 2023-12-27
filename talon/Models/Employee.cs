﻿using System.ComponentModel.DataAnnotations;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    public string Position { get; set; }
    public string Image { get; set; }
}
