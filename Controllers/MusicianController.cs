using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kol2termin1.Controllers
{
    [Route("[controller]")]
    public class MusicianController : ControllerBase
    {
        private readonly IMusService _service;

        public MusicianController(IMusService service)
        {
            _service=service;
        }
        [HttpGet]
        public async Task<IActionResult> GetMusician(MusicianGet data){
            await _service.GetMusician(Models.Musician{
                select musician from musicians where IdMusician = data.IdMusician
            })
            return OK()
        }


    }
}