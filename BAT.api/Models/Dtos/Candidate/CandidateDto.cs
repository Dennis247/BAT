using System.ComponentModel.DataAnnotations;

namespace BAT.api.Models.Dtos.Candidate
{
    public class AddCandidateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string AreaRepresenting { get; set; }
        public string? WhatAppNumber { get; set; }
        public string? Twitter { get; set; }
        public string? FaceBook { get; set; }
        public string? Instagram { get; set; }
        public string? Education { get; set; }
        public string? WorkExperinece { get; set; }
        public string? Achievements { get; set; }
    }


    public class CandidateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
        public string Position { get; set; }
        public string AreaRepresenting { get; set; }
        public string? WhatAppNumber { get; set; }
        public string? Twitter { get; set; }
        public string? FaceBook { get; set; }
        public string? Instagram { get; set; }
        public string? Education { get; set; }
        public string? WorkExperinece { get; set; }
        public string? Achievements { get; set; }
    }
}
