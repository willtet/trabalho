using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IRecursoRepository : IRepositoryBase<Recurso>
    {
        List<Recurso> ListaRecurso(string usuario);

        List<Recurso> PreencherLista(SqlDataReader reader, List<Recurso> listaRecurso);
    }
}