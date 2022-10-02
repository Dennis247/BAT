using BAT.api.Helpers;
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

        public string AreaRepresenting { get; set; }

        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string? WhatAppNumber { get; set; }
        public string? Twitter { get; set; }
        public string? FaceBook { get; set; }
        public string? Instagram { get; set; }
        public string? Education { get; set; }
        public string? WorkExperinece { get; set; }
        public string? Achievements { get; set; }
        public string CandidateImageUpload { get; set; }  

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
        public string? CandidateImage { get; set; }

        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }



    }



    public class UpdateCandidateDto
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
        public string? CandidateImage { get; set; }


    }


    public class DeleteCandidateDto
    {

        public int Id { get; set; }




    }



}
