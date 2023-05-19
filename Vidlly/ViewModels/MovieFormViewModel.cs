using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Vidlly.Models;

namespace Vidlly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
        [Display(Name = "Number in Stock")]
        [Range(1,20)]
        [Required]
        public byte? NumberInStock { get; set; }
        public string Title
        {
            get
            {
                if (Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
        public MovieFormViewModel()
        {
            Id= 0;
        }
    }
}