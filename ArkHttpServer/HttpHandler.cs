using ArkHttpServer.Entities;
using ArkSaveEditor.World;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ArkHttpServer
{
    partial class Program
    {
        public static Task OnHttpRequest(Microsoft.AspNetCore.Http.HttpContext e)
        {
            //Set some headers
            e.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            
            //Since we don't have to worry about permissions or anything, we'll just have a list of services created at compile time.
            string pathname = e.Request.Path.ToString().ToLower();

            if(pathname.StartsWith("/map"))
            {
                //Check if they have provided the tribe name in the request.
                if (!e.Request.Query.ContainsKey("tribe"))
                    return QuickWriteToDoc(e, "Please provide a tribe name.", "text/html", 400);
                //Send the basic game world.
                ArkWorld world = GetArkWorld();
                //Convert to a basic Ark world
                BasicArkWorld bworld = new BasicArkWorld(world, e.Request.Query["tribe"]);
                //Write
                return QuickWriteJsonToDoc(e, bworld);
            }
            if(pathname.StartsWith("/dino/"))
            {
                //Get the dino ID
                string id = pathname.Substring("/dino/".Length);
                //Parse this into a Dino ID
                if (!ulong.TryParse(id, out ulong dinoid))
                    //Failed.
                    return QuickWriteToDoc(e, "Failed to parse dinosaur ID.", "text/plain", 400);
                //Search with this dinosaur ID
                var dinos = GetArkWorld().dinos.Where(x => x.dinosaurId == dinoid).ToArray();
                if(dinos.Length == 1)
                {
                    //Write this dinosaur.
                    return QuickWriteJsonToDoc(e, dinos[0]);
                } else
                {
                    //Failed to find.
                    return QuickWriteToDoc(e, $"The dinosaur ID '{dinoid}' was not a valid dinosaur.", "text/plain", 404);
                }
            }

            //No path exists here.
            return QuickWriteToDoc(e, "Not Found", "text/plain", 404);
        }
    }
}
