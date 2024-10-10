﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.ViewModels
{
    public class WatchListViewModel
    {
        public Guid MovieId { get; set; }
        public string Title { get; set; } =  null!;

        public string Genre { get; set; } = null!;

        public string ReleaseData { get; set; } = null!;
        
        public string ImageUrl { get; set; } = null!;
    }
}
