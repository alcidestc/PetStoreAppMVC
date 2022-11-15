namespace PetStoreApp.Servicios
{
    public class Utilidades: IUtilidades
    {

        public async Task<long> GenerarId()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);
            var value =(long)random.Next(0, int.MaxValue);

            return value;
           
        }
    }
}
