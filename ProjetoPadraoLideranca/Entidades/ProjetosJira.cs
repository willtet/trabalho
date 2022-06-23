using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendaTsdigital.Dominio.Entidades
{
    public class ProjetosJira
    {
        public static string ConsultaProjetosJira = "ConsultaProjetosJiraProc";
        public static string ConsultaNomeProjetosProc = "ConsultaNomeProjetosProc";
        public static string GerarProjetoFuncionarioResultProc = "GerarProjetoFuncionarioResultProc";
        


        public int AnoCriacao { get; set; }
        public string Status { get; set; }
        public int? MesCriacao { get; set; }
        public int? MesConclusao { get; set; }
        public string ChaveProjeto { get; set; }
        public string NomeProjeto { get; set; }
        public string CategoriaProjeto { get; set; }
        public string TipoTarefa { get; set; }
        public string Responsavel { get; set; }
        public string Author { get; set; }
        public string TempoTrabalhado { get; set; }
        public int Issuenum { get; set; }
        public string CodigoJira { get; set; }
        public DateTime Created { get; set; }
    }
}
