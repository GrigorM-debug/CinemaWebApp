using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.ViewModels.Cinema
{
    public class CinemaEditViewModel
    {
        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;
    }
}
