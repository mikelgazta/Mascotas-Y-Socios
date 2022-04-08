using Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Data
{
    public class DataMascotaCSV : IData<InfoMascota>
    {
        string _file = "../../dataMascotas.csv";

        public void Guardar(List<InfoMascota> mascota)
        {
            List<string> data = new() { };
            mascota.ForEach(mascota =>
            {
                var str = $"{mascota.idSocio},{mascota.idMascota},{mascota.nombre},{mascota.especie},{mascota.edad}";
                data.Add(str);
            });
            File.WriteAllLines(_file, data);

        }
        public List<InfoMascota> Leer()
        {
            return File.ReadAllLines(_file)
                .Select(InfoMascota.mascota)
                .ToList();
        }
    }
}
