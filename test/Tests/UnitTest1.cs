using System;
using Xunit;
using Modelos;

namespace Tests
{
    public class UnitTest1
    {

        [Fact]
        public void TestSocio(){
            Guid id= new Guid();
            InfoSocios esperado = new InfoSocios {
                idSocio = id,
                nombre= "Mikel",
                sexo='V',
            };

            string csv = $"{id.ToString()},Mikel,V";
            var resultado = InfoSocios.socio(csv);

            Assert.Equal(esperado.ToCSV(), resultado.ToCSV());

            }

        [Fact]
        public void TestMascota(){
            
            Guid idS= new Guid();
            Guid idM= new Guid();

            InfoMascota esperado = new InfoMascota {
                    idSocio = idS,
                    idMascota = idM,
                    nombre = "Marcos",
                    especie = 0,
                    edad = 3,
            };

            string csv = $"{idS.ToString()},{idM.ToString()},Marcos,0,3";
            var resultado = InfoMascota.mascota(csv);

            Assert.Equal(esperado.ToCSV(), resultado.ToCSV());

  
        }
    }
}
