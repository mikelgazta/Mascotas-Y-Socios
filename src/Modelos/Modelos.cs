using System;

namespace Modelos{
        
    public class InfoSocios
    {
        public Guid idSocio {get; set;}
        public string nombre {get; set;}
        public char sexo {get; set;}

        public override string ToString()
            => $"{nombre}";

        public string ToCSV() => $"{idSocio},{nombre},{sexo}";

        public static InfoSocios socio(string _file){
            var campos = _file.Split(",");
            return new InfoSocios
            {
                idSocio = Guid.Parse(campos[0]),
                nombre= (campos[1]),
                sexo= Char.Parse(campos[2]),
            };
        }}
    
        public enum Especie
        {
            Perro,
            Gato,
            Ave,
            Cerdo,
            Serpiente,
        }
    public class InfoMascota
    {   

        public Guid idSocio {get; set;}
        public Guid idMascota {get; set;}
        public string nombre {get; set;}
        public Especie especie {get; set;}
        public int edad {get; set;}

        public string ToCSV() => $"{idSocio},{idMascota},{nombre},{especie},{edad}";

        public static InfoMascota mascota(string _file){
            var campos = _file.Split(",");
            return new InfoMascota
            {
                    idSocio = Guid.Parse(campos[0]),
                    idMascota= Guid.Parse(campos[1]),
                    nombre= (campos[2]),
                    especie= (Especie)Enum.Parse(typeof(Especie), campos[3]),
                    edad= Int32.Parse(campos[4]),
            };
        }

        public override string ToString()
        {
            return $"{nombre},{especie},{edad}";
        }
    }

}