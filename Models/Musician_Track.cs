using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kol2termin1.Models
{
    public class Musician_Track
    {
        public virtual IdTrack IdTrack { get; set; }
        public virtual IdMusician IdMusician{get;set;}
    }
}