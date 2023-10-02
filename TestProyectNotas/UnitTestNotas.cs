namespace TestProyectNotas
{
    public class UnitTestNotas
    {
        [Fact]
        public async Task TestAddNota()
        {
            NotasRepository notasRepository = new NotasRepository();
            Nota notaCargada = await notasRepository.AddAsync("Padel del Gerva", "Jueves 21hs");
            Assert.Equal("Padel del Gerva", notaCargada.Titulo);
            //Is. ."Ajedrez Ale", Is.EqualTo(actividadCargada.Nombre));
        }

        [Fact]
        public async Task TestDeleteNota()
        {
            var notasRepository = new NotasRepository();
            var borrado = await notasRepository.RemoveAsync(9);
            Assert.Equal(true, borrado);
        }

        [Fact]
        public async Task TestUpdateNota()
        {
            var notasRepository = new NotasRepository();
            var actualizado = await notasRepository.UpdateAsync("Tenis colon", "Sábado 14hs",  8);
            Assert.Equal(true, actualizado);
        }

        [Fact]
        public async Task TestGetAllAsyncNotas()
        {
            var notasRepository = new NotasRepository();
            var notas = await notasRepository.GetAllAsync();
            var primeraNota = notas.ElementAt<Nota>(0);
            Assert.Equal("Nota1", primeraNota.Titulo);
        }
        [Fact]
        public async Task TestGetById()
        {
            var notasRepository = new NotasRepository();
            var nota = await notasRepository.GetById(1);
            Assert.Equal("Nota1", nota.Titulo);
        }
    }
}