using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kol2termin1.Models
{
    public class Album
    {
        [key]
        public int IdAlbum { get; set; }
        [required]
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual IEnumerable<MusicLabel> MusicLabels{get; set;}
    }
}