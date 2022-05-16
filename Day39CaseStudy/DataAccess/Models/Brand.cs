﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Day39CaseStudy.DataAccess.Models;

[Table("brands", Schema = "production")]
[Index("BrandName", IsUnique = true)]
public class Brand
{    
    [Key]
    [Column("brand_id")]    
    public int? BrandId { get; set; }       // Check why this worked without ?.

    [Column("brand_name")]
    public string BrandName { get; set; }

    public static string Header => "BrandId, BrandName";

    public override string ToString()
    {
        return $"{BrandId},{BrandName}";
    }
}
