using AppNotas.Models;
using AppNotas.Repositories;

namespace TestProjectNotas
{
    public class UnitTestNotas
    {
        [Fact]
        public async Task TestAddNota()
        {
            NotasRepository notasRepository = new NotasRepository();
            Nota notaCargada = await notasRepository.AddAsync("Ajedrez Ale", "Viernes de 13:50hs a 17:20hs");
            Assert.Equal("Ajedrez Ale", notaCargada.Titulo);
            //Is. ."Ajedrez Ale", Is.EqualTo(actividadCargada.Nombre));
        }
    }
}