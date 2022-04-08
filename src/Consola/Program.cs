using Libreria;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var repositorio = new Data.DataMascotaCSV();
            var repositorio2= new Data.DataSocioCSV();
            var view=new Vista();
            var sistema=new Club(repositorio2, repositorio);
            var controlador=new Controlador(view, sistema);
            controlador.Run();
        }
    }
}
