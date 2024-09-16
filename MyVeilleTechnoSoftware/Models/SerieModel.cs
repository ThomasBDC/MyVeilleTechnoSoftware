using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVeilleTechnoSoftware.Models
{
    public class SerieModel
    {
        public SerieModel(Guid id, string title, string url, string? description = null)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
