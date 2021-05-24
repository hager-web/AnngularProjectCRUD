using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataAccessLayer.Models
{
    public partial class Employee
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("full_name")]
        [StringLength(500)]
        public string FullName { get; set; }
        [Column("job_title")]
        [StringLength(500)]
        public string JobTitle { get; set; }
        [Column("country")]
        [StringLength(50)]
        public string Country { get; set; }
        [Column("is_online")]
        public bool? IsOnline { get; set; }
        [Column("rating")]
        public int? Rating { get; set; }
        [Column("target")]
        public int? Target { get; set; }
        [Column("budget")]
        public int? Budget { get; set; }
        [Column("phone")]
        [StringLength(50)]
        public string Phone { get; set; }
        [Column("address")]
        [StringLength(500)]
        public string Address { get; set; }
        [Column("img_id")]
        public int? ImgId { get; set; }
        [Column("gender")]
        [StringLength(50)]
        public string Gender { get; set; }
    }
}
