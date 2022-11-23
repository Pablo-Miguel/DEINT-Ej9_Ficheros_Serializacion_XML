using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DEINT_Ej9_Ficheros_Serializacion_XML.Modelo
{
    [Serializable]
    public class Banco
    {
        [XmlElement("Banco")]
        public List<Cliente> clientes { get; set; }

        public Banco()
        {
            clientes = new List<Cliente>();
        }

    }
}
