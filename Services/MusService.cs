using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kol2termin1.Services
{
    public class MusService : IMusService
    {
        private readonly MusDbContext _context;
        public MusService(MusDbContext context){
            _context = context;
        }

        public async Task GetMusician(Musician musician){
            await _context.Musicians.GetMusician(musician);
        }

    }
}