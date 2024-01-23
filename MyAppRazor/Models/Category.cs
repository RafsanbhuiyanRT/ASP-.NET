﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyAppRazor.Models;

public class Category
{
    [Key]
    public int ID { get; set; }
    [Required, MaxLength(250)]
    [DisplayName("Category Name")]
    public string? Name { get; set; }
    [DisplayName("Display Order"), Range(1, 100, ErrorMessage = "Display order must be between 1-100")]
    public int DisplayOrder { get; set; }
}