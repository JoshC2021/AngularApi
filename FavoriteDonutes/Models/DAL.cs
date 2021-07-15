using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

namespace FavoriteDonutes.Models
{
    public class DAL
    {
        // Favorite table operations
        public static IDbConnection db;


        public static Favorite AddFavorite(string newUsername, int newDonut)
        {

            // Make sure the favorite doesn't already oopa
            Favorite fav = new Favorite() { username = newUsername, donut = newDonut};
            db.Insert(fav);
            return fav;
        }

        // Get all favorites for a particular user

        public static List<Favorite> GetFavsByUser(string username)
        {
            // do not do this, susceptible to sql injection
           // db.Query("select * from favorite where username = '{ username }'");


            return db.Query<Favorite>(
                "select * from favorite where username = @uname",
                new { uname = username }).ToList();
        }

        // Find out if a donut has been favorited by a particular user
        // Not sure if we need this yet. We'll add it if/when we do.

        // Add and remove favorites
        // These method names will describe in terms of how it's used , NOT in terms of database table
        // For example, not "insertFavorite" and "deleteeFavortie" but rather "AddUserFavorite"
        // and "RemoveUserFavorite"

        public static void RemoveUserFavorite(int theid)
        {
            Favorite del = new Favorite() { id = theid };
            db.Delete(del);
        }

        public static bool IsFavorite(string username, int donut)
        {
            return db.Query<Favorite>(
                "select * from favorite where username = @uname and donut = @did",
                new { uname = username, did = donut}
                ).ToList().Count >0;
        }
        

    }
}
