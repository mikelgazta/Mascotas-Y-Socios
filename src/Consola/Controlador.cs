using System;
using Libreria;
using System.Collections.Generic;
using Modelos;
using System.Linq;


namespace Consola
{
    class Controlador
    {
        private Vista _vista;
        private Club _sistema;
        private Dictionary<string, Action> _casosDeUso;
        public Controlador(Vista vista, Club sistema)
        {
            _vista = vista;
            _sistema = sistema;
            _casosDeUso = new Dictionary<string, Action>(){
                {"Dar de alta a un socio.", DarDeAltaSocio},
                {"Dar de baja a un socio.", EliminarSocio},
                {"Dar de alta a una mascota.", DarDeAltaMascota},
                {"Dar de baja a una mascota.", EliminarMascota},
                {"Comprar una mascota.", ComprarMascota},
                {"Ver todos los socios", MostrarSocios},
                {"Ver todas las mascotas.", MostrarMascotas},

            };
        }
        public void Run()
        {
            _vista.LimpiarPantalla();
            // Acceso a las Claves del diccionario
            var menu = _casosDeUso.Keys.ToList<String>();

            while (true)
                try
                {
                    //Limpiamos
                    _vista.LimpiarPantalla();
                    // Menu
                    var key = _vista.TryObtenerElementoDeLista("Menu de Usuario", menu, "Seleciona una opción");
                    _vista.Mostrar("");
                    // Ejecución de la opción escogida
                    _casosDeUso[key].Invoke();
                    // Fin
                    _vista.MostrarYReturn("Pulsa <Return> para continuar");
                }
                catch { return; }
        }
        public void DarDeAltaSocio()
        {
            try
            {
                var name = _vista.TryObtenerDatoDeTipo<string>("Nombre ");
                var gender = _vista.TryObtenerDatoDeTipo<char>("Genero ");

                InfoSocios socio = new InfoSocios
                {
                    idSocio = Guid.NewGuid(),
                    nombre = name,
                    sexo = gender,
                };
                _sistema.DarDeAltaSocio(socio);
            }
            catch (Exception e)
            {
                _vista.Mostrar($"UC: {e.Message}");
            }
        }
        public void DarDeAltaMascota()
        {
            try
            {
                var socio = _vista.TryObtenerElementoDeLista<InfoSocios>("Socios", _sistema.socio, "");
                var name = _vista.TryObtenerDatoDeTipo<string>("Nombre ");
                var age = _vista.TryObtenerDatoDeTipo<int>("Edad ");
                var esp = _vista.TryObtenerDatoDeTipo<Especie>("Especie ");

                InfoMascota mascota = new InfoMascota
                {
                    idSocio = socio.idSocio,
                    idMascota = Guid.NewGuid(),
                    nombre = name,
                    edad = age,
                    especie = esp,
                };
                _sistema.DarDeAltaMascota(mascota);
            }
            catch (Exception e)
            {
                _vista.Mostrar($"UC: {e.Message}");
            }
        }

        public void MostrarSocios()
        {
            _vista.MostrarListaEnumerada<InfoSocios>("Socios actuales: ", _sistema.socio);
        }

        public void MostrarMascotas()
        {
            _vista.MostrarListaEnumerada<InfoMascota>("Mascotas actuales: ", _sistema.mascota);
        }


        public void EliminarSocio()
        {
            try
            {
                MostrarSocios();
                var ids = _vista.TryObtenerValorEnRangoInt(1, _sistema.socio.Count, "Socio que vas a eliminar");
                var sc = _sistema.socio[ids - 1];
                _sistema.EliminarSocio(sc);
                _vista.Mostrar($"Se ha eliminado con exito al socio {sc.nombre},{sc.sexo}");
            }
            catch (Exception e)
            {
                _vista.Mostrar($"{e.Message}");
            }

        }
        public void EliminarMascota()
        {
            try
            {
                MostrarMascotas();
                var ids = _vista.TryObtenerValorEnRangoInt(1, _sistema.mascota.Count, "Mascota que vas a eliminar");
                var mas = _sistema.mascota[ids - 1];
                _sistema.EliminarMascota(mas);
                _vista.Mostrar($"Se ha eliminado con exito a la mascota {mas.nombre},{mas.especie}");
            }
            catch (Exception e)
            {
                _vista.Mostrar($"{e.Message}");
            }

        }
        public void ComprarMascota()
        {
           MostrarSocios();
            var ids = _vista.TryObtenerValorEnRangoInt(1, _sistema.socio.Count, "Socio que va a comprar la mascota.");
            var comprador = _sistema.socio[ids - 1];

           MostrarMascotas();
            var idM = _vista.TryObtenerValorEnRangoInt(1, _sistema.mascota.Count, "Mascota que va a comprar el comprador.");
            var comprada = _sistema.mascota[idM - 1];

            if (comprador.idSocio == comprada.idSocio)
            {
                _vista.Mostrar("Esa mascota ya pertenece a ese dueño.");
            }
            else
            {
                _sistema.cambiarDueño(comprador , comprada);
                _vista.Mostrar($"La mascota{comprada.nombre},{comprada.especie},{comprada.edad}, ahora pertenece al socio { comprador.nombre}");
            }
        }
    }
}
