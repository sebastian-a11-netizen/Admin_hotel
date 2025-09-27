using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabitacionesController : ControllerBase
    {
        private readonly Habitaciones repo;

        public HabitacionesController(Habitaciones repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Habitacion>>> ObtenerHabitaciones()
        {
            return Ok(await repo.ObtenerHabitaciones());
        }
        
        [HttpGet("{id_hab}")]
        public async Task<ActionResult<Habitacion>> ObtenerHabitacionPorID(int id_hab)
        {
            return Ok(await repo.ObtenerHabitacionPorId(id_hab));
        }
    }
}