using System;
using Modelos;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Data
{
    public class DataSocioCSV : IData<InfoSocios>
    {
        string _file = "../../dataSocios.csv";
        public void Guardar(List<InfoSocios> socio)
        {

            List<string> data = new() { };
            socio.ForEach(socio =>
            {
            var str = $"{socio.idSocio},{socio.nombre},{socio.sexo}";
            data.Add(str);
            });
            File.WriteAllLines(_file, data);
        }
        public List<InfoSocios> Leer()
        {
            return File.ReadAllLines(_file)
                .Select(InfoSocios.socio)
                .ToList();

        }
    } 

}