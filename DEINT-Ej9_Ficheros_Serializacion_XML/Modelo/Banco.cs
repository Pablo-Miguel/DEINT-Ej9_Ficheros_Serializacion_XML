﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DEINT_Ej9_Ficheros_Serializacion_XML.Modelo
{
    internal class Banco
    {
        [XmlElement("Banco")]
        public List<Cliente> clientes { get; set; }

    }
}