using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class MaterialEvento
    {
        public MaterialEvento()
        {

        }

        public string tipo_material { get; set; }

        public Material material { get; set; }

        public Evento evento { get; set; }
    }
}
