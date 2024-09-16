using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVeilleTechnoSoftware.Models
{
    public class LinkModel
    {
        public LinkModel(Guid id, string title, string url, string? description = null)
        {
            Id = id;
            Title = title;
            Description = description;
            Url = url;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Url { get; set; }

        //Clé étrangère vers une potentielle série ???
        public Guid? IdSerie { get; set; }
    }
}
