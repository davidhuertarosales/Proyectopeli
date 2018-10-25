using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace Proyectopeli.Models
{
    public class Peliculain : DropCreateDatabaseAlways<Peliculadb>
    {

        protected override void Seed(Peliculadb context)
        {
            base.Seed(context);

            //Create some photos
            var photos = new List<Pelicula>
            {
                new Pelicula {
                    Title = "Tiburon",
                    Poster = getFileBytes("\\Images1\\tiburon1.jpg"),
                    ImageMimeType = "image/jpeg",
                    Sinopsis = "I was very impressed with myself",
                    Director = "Fred",
                    Fecha_estreno = DateTime.Today
                },
                new Pelicula {
                    Title = "Scarface",
                    Sinopsis = "It's the bees knees!",
                    Director = "Fred",
                    Poster = getFileBytes("\\Images1\\scarface1.jpg"),
                    ImageMimeType = "image/jpeg",
                    Fecha_estreno = DateTime.Today
                },
                new Pelicula {
                    Title = "Volver al Futuro",
                    Sinopsis = "I took this photo just before we started over my handle bars.",
                    Director = "Sue",
                    Poster = getFileBytes("\\Images1\\regreso-al-futuro1.jpg"),
                    ImageMimeType = "image/jpeg",
                    Fecha_estreno = DateTime.Today
                },
                new Pelicula {
                    Title = "Pulp Fiction",
                    Sinopsis = "Los dos criminales son polos opuestos que deberán trabajar juntos para cumplir su cometido. De forma paralela, Vincent tendrá que hacerse cargo de Mia Wallace (Uma Thurman, Kill Bill), la peculiar novia de su jefe, a petición del mismo, mientras él pasa unos días fuera de la ciudad. Su compañero Jules le recomienda que vaya con cautela, pues la atractiva mujer le puede meter en problemas. Mientras, el boxeador Butch Coolidge (Bruce Willis, El sexto sentido) debe perder una importante pelea, pues ha sido sobornado por Wallace para participar en este combate amañado, y la pareja formada por Pumpkin/Ringo (Tim Roth, Reservoir Dogs) y Honey Bunny/Yolanda (Amanda Plummer, Mi vida sin mí) decidirá atracar un establecimiento debido a su lamentable situación laboral. ",
                    Director = "Quentin Tarantino",
                    Poster = getFileBytes("\\Images1\\pulp-fiction.jpg"),
                    ImageMimeType = "image/jpeg",
                    Fecha_estreno = DateTime.Today
                },
                new Pelicula {
                    Title = "El padrino",
                    Sinopsis = "En el verano de 1945, se celebra la boda de Connie (Talia Shire) y Carlo Rizzi (Gianni Russo). Connie es la única hija de Don Vito Corleone (Marlon Brando), jefe de una de las familias que ejercen el mando de la Cosa Nostra en la ciudad de Nueva York. Don Vito además tiene otros tres hijos: su primogénito Sonny (James Caan), el endeble Fredo (John Cazale) y el más joven se todos, Michael (Al Pacino), un marine condecorado por su lucha en la Segunda Guerra Mundial que acaba de regresar a su hogar en Nueva York. Por designios de la fortuna, Michael terminará llevando la vida que no deseaba, tomando las riendas del negocio familiar, cambiando su moral y sus valores, para defender a toda costa a su familia. ",
                    Director = "Francis Ford Coppola",
                    Poster = getFileBytes("\\Images1\\elpadrino.jpg"),
                    ImageMimeType = "image/jpeg",
                    Fecha_estreno = DateTime.Today
                }
            };
            photos.ForEach(s => context.Pelicula.Add(s));
            context.SaveChanges();

            //Create some comments

            //Create some comments
            var comments = new List<Comentario>
            {
                new Comentario {
                    PeliID = 1,
                    UserName = "Luis Sousa",
                    Critica = "Camera Settings",
                    Cuerpo = "Nice depth-of-field. What aperture did you use?"
                },
                new Comentario {
                    PeliID = 1,
                    UserName = "Brad Sutton",
                    Critica = "Camera Settings",
                    Cuerpo = "Must have been f11 or something like that?"
                },
                new Comentario {
                    PeliID = 2,
                    UserName = "Brad Sutton",
                    Critica = "Great Shot!",
                    Cuerpo = "I know these things are easy to shoot, but I still think they're great."
                },
                new Comentario {
                    PeliID = 3,
                    UserName = "Masato Kawai",
                    Critica = "Imperfections",
                    Cuerpo = "Looks like there's a hair in the lower right. Was that in the shot?"
                }
            };
            comments.ForEach(s => context.Comentario.Add(s));
            context.SaveChanges();
        }
        //This gets byte array for a file at the path specified
        //The path is relative to the route of the web site
        //It is used to seed images
        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }
    }
}