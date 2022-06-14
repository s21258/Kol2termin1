using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kol2termin1.Models
{
    public class Track
    {
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public virtual Album Album{get; set;}
        public virtual ICollection <Musician> Musicians{get; set;}
    }
}