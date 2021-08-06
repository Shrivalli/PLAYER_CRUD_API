using API_CRUD.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        //Necessary code to create the DbContext object properly.
        private readonly PlayerContext _context;

        public PlayerController(PlayerContext context)
        {
            _context = context;
        }

        //Action method to return list of all players.
        [HttpGet]
        public IEnumerable<Player> GetAll()
        {
            return _context.Players.ToList();
        }

        //Action method to return player details by jersey number.
        [HttpGet("playerdetail/{id}")]
        public IEnumerable<Player> GetById(int id)
        {
            IEnumerable<Player> res = from p in _context.Players
                                      where p.P_Jno == id
                                      select p;
            return res;
        }


        //Action method to store the data/create the records.
        [HttpPost]
        public IActionResult Create([FromBody] Player player)
        {
            var obj = _context.Players.Find(player.P_Jno);
            if (player == null || obj!=null)
            return BadRequest();

            
            _context.Players.Add(player);
            _context.SaveChanges();

            //Verifying if player details are stored correctly.
            return CreatedAtAction("GetById", new { id = player.P_Jno },player);
        }

        //Action method to update player data.
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Player player)
        {
            //Checking if correct id is there.
            if (id != player.P_Jno || player == null)
                return BadRequest();

            var obj = _context.Players.Find(id);

            if (obj == null)
                return NotFound();

            
                //Updating the values.
                obj.P_Name = player.P_Name;
                obj.P_Age = player.P_Age;
                obj.P_Category = player.P_Category;
                obj.P_Jno = player.P_Jno;

                _context.SaveChanges();
            

            return new NoContentResult();
        }

        //Action method to delete player data.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var obj = _context.Players.Find(id);

            if (obj == null)
                return NotFound();

            _context.Players.Remove(obj);
            _context.SaveChanges();

            return new NoContentResult();
        }

    }
}
