using System.Linq;

namespace TestProyectNotas
{
    public class UnitTestPeliculas
    {
        [Fact]
        public async Task TestAddPelicula()
        {
            PeliculasRepository peliculasRepository = new PeliculasRepository();
            Pelicula peliculaCargada = await peliculasRepository.AddAsync("Réquiem por un sueño","Drama", 102, "https://www.youtube.com/watch?v=GlcGf-p8jFI", "La película cuenta la historia de Harry Goldfarb (Jared Leto), su madre Sara Goldfarb (Ellen Burstyn), su novia Marion Silver (Jennifer Connelly) y su amigo Tyrone C. Love (Marlon Wayans). La historia se divide en tres estaciones: verano, otoño e invierno.", "https://pics.filmaffinity.com/requiem_for_a_dream-174867645-large.jpg");
            Assert.Equal("Réquiem por un sueño", peliculaCargada.nombre);
        }

        [Fact]
        public async Task TestDeletePelicula()
        {
            var peliculasRepository = new PeliculasRepository();
            var borrado = await peliculasRepository.RemoveAsync("6483627c71c264620007846b");
            Assert.Equal(true, borrado);
        }

        [Fact]
        public async Task TestUpdatePelicula()
        {
            var peliculasRepository = new PeliculasRepository();
            var actualizado = await peliculasRepository.UpdateAsync("Matrix Recargado", "Ciencia Ficción recargado",  138, "https://www.youtube.com/watch?v=3tT-lSxzBAo", "The Matrix recargado", "https://www.gainesville.com/gcdn/authoring/2003/05/14/NTGS/ghows-LK-826aa8d2-53d9-49b8-ba32-b7050cba087d-cecda844.jpeg", "647a289571c264620007423d");
            Assert.Equal(true, actualizado);
        }

        [Fact]
        public async Task TestGetAllAsyncNotas()
        {
            var peliculasRepository = new PeliculasRepository();
            var peliculas = await peliculasRepository.GetAllAsync();
            var primeraPelicula = peliculas.ElementAt<Pelicula>(0);
            Assert.Equal("Réquiem por un sueño", primeraPelicula.nombre);
        }
        [Fact]
        public async Task TestGetById()
        {
            var peliculasRepository = new PeliculasRepository();
            var pelicula = await peliculasRepository.GetById("648ca55f71c264620007cd46");
            Assert.Equal("Interestelar", pelicula.nombre);
        }
    }
}