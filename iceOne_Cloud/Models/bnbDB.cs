using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iceOne_Cloud.Models
{
    public class bnbDB
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public double Price { get; set; }
        public string? Address { get; set; }
        public string? contactEmail { get; set; }
    }
}
