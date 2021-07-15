using FavoriteDonutes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteDonutes.Controllers
{
    [Route("favorite")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        // Reminder: these are database calls,
        // which are not "async". So we don't
        // need to wrap our return tpes in Task<..>

        // Add user favorite
        // Username will be in the URL; however!!!
        // In a real program we would extract the username
        // from an encrypted "token" that was stored in a cookie
        // That way one use can't add a favorite for another user

        // URL Format:
        // /favorite/add?username=jeffcoggs&donut=5
        // favorite/add/jeffcoggs/5

        [HttpPost("add")]
        public bool AddUserFavortie(string username, int donut)
        {
            DAL.AddFavorite(username, donut);
            return true;
        }

        // Get favorites by user
        // /favorite/jeff
        // favorite/joe
        // favorite/fred

        [HttpGet("getfavs/{username}")]
        public List<Favorite> GetFavsByUser(string username)
        {
            return DAL.GetFavsByUser(username);
        }

        // remove user favorite
        // For this we will remove by ID. HOWEVER: In a real
        // app, we also need to make sure to that the logged in user
        // (which we get from the encrypted cookie token) matches
        // the one we're trying to delete, and that it's not somebody
        // deleting someone else's favorite.
        // When we're writing code, although we are not security
        // experts, still, security should be on our mind constantly

        [HttpDelete("remove/{id}")]
        public bool RemoveUserFavorite(int id)
        {
            DAL.RemoveUserFavorite(id);
            return true;

        }

        [HttpGet("isfav")]
        public bool IsFavorite(string userName, int donut)
        {
            return DAL.IsFavorite(userName, donut);
        }
    }
}
