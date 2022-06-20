using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public partial class Recurso 
    {
        public int? CodRecurso { get; set; }
        public string NomeRecurso { get; set; }
        public string DescRecurso { get; set; }
        public string Link { get; set; }
        public int? ParentID { get; set; }
        public string ParentName { get; set; }
        public int? ParentOrdem { get; set; }
        public string ParentDescr { get; set; }
        public string ParentIcone { get; set; }
        public int? Ordem { get; set; }
        public string Icone { get; set; }
        public int Menu { get; set; }

        // Novos campos
        public int? IDRecurso { get; set; }
        public int? IDAplicacao { get; set; }
        public int? IDStatusRecurso { get; set; }
        public string StatusRecurso { get; set; }
        public string Nome { get; set; }
        public bool Associado { get; set; }
        public string Usuario { get; set; }
        public DateTime? DtAtualiza { get; set; }
        public Int64? idTicket { get; set; }

        public static IEnumerable<Recurso> ListaRecurso = new List<Recurso>();
    }

    public partial class Recurso
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        // parametros da proc
        public int? IdPerfil { get; set; }

        // procs
        public static string RecursoProc = "RecursoProc";
    }
}
