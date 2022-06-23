using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaTsdigital.Dominio.Interfaces;

namespace VendaTsdigital.Dominio.Entidades.dtos
{
    public class FuncionarioDto
    {

        public int CodFuncionario { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string RegimeD { get; set; }
        public string TipoD { get; set; }
        public string CargaHorariaD { get; set; }
        public decimal SalarioD { get; set; }
    }
}
