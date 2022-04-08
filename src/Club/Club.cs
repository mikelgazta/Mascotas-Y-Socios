using System;
using System.Collections.Generic;
using Data;
using Modelos;

namespace Libreria
{
    public class Club
    {
        public List<InfoSocios> socio { get; set; } = new();
        public List<InfoMascota> mascota { get; set; } = new();

        public Club(DataSocioCSV repo, DataMascotaCSV repo2)
        {
            Repositorio = repo;
            Repositorio2= repo2;
            socio= Repositorio.Leer();
            mascota= Repositorio2.Leer();
        }

        DataSocioCSV Repositorio;
        DataMascotaCSV Repositorio2;
        public void DarDeAltaSocio(InfoSocios s)
        {
            socio.Add(s);
            Repositorio.Guardar(socio);
        }
        public void EliminarSocio(InfoSocios s)
        {
            socio.Remove(s);
            Repositorio.Guardar(socio);
        }
        public void DarDeAltaMascota(InfoMascota m)
        {
            mascota.Add(m);
            Repositorio2.Guardar(mascota);
        }
        public void EliminarMascota(InfoMascota m)
        {
            mascota.Remove(m);
            Repositorio2.Guardar(mascota);
        }

        public void cambiarDueño(InfoSocios s, InfoMascota m)
        {
            m.idSocio=s.idSocio;
            Repositorio2.Guardar(mascota);
        }

    }
}
