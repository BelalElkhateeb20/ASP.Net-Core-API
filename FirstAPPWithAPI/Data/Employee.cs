using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FirstAPPWithAPI.Data;

[Table("EFCoreModeling")]
public partial class Employee
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("first_name")]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Column("email")]
    [StringLength(50)]
    public string Email { get; set; } = null!;

    [Column("gender")]
    [StringLength(50)]
    public string Gender { get; set; } = null!;

    [Column("ip_address")]
    [StringLength(50)]
    public string IpAddress { get; set; } = null!;

    [Column("location")]
    [StringLength(50)]
    public string Location { get; set; } = null!;

    [StringLength(50)]
    public string DepartMent { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Balance { get; set; }

    [StringLength(50)]
    public string PhoneNum { get; set; } = null!;

    [StringLength(50)]
    public string CarModel { get; set; } = null!;
}
