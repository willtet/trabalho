using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Infra.Data.Repository
{
    public class RecursoRepository : RepositoryBase<Recurso>, IRecursoRepository
    {
        public List<Recurso> ListaRecurso(string usuario)
        {
            using (var con = new SqlConnection(StrConnection))
            {
                con.Open();

                using (var cmd = new SqlCommand("RecursoProc", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario);

                    var listaRecurso = new List<Recurso>();
                    var reader = cmd.ExecuteReader();

                    listaRecurso = PreencherLista(reader, listaRecurso);
                    return listaRecurso;
                }
            }
        }

        public List<Recurso> PreencherLista(SqlDataReader reader, List<Recurso> listaRecurso)
        {
            while (reader.Read())
            {
                var recurso = new Recurso();

                if (reader.HasRows)
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("CodRecurso")))
                        recurso.CodRecurso = (int)reader["CodRecurso"];

                    if (!reader.IsDBNull(reader.GetOrdinal("NomeRecurso")))
                        recurso.NomeRecurso = (string)reader["NomeRecurso"];

                    if (!reader.IsDBNull(reader.GetOrdinal("DescRecurso")))
                        recurso.DescRecurso = (string)reader["DescRecurso"];

                    if (!reader.IsDBNull(reader.GetOrdinal("Link")))
                        recurso.Link = (string)reader["Link"];

                    if (!reader.IsDBNull(reader.GetOrdinal("ParentID")))
                        recurso.ParentID = (int)reader["ParentID"];

                    if (!reader.IsDBNull(reader.GetOrdinal("ParentName")))
                        recurso.ParentName = (string)reader["ParentName"];

                    if (!reader.IsDBNull(reader.GetOrdinal("ParentOrdem")))
                        recurso.ParentOrdem = (Int32)reader["ParentOrdem"];

                    if (!reader.IsDBNull(reader.GetOrdinal("ParentDescr")))
                        recurso.ParentDescr = (string)reader["ParentDescr"];

                    if (!reader.IsDBNull(reader.GetOrdinal("ParentIcone")))
                        recurso.ParentIcone = (string)reader["ParentIcone"];

                    if (!reader.IsDBNull(reader.GetOrdinal("Ordem")))
                        recurso.Ordem = (Int32)reader["Ordem"];

                    if (!reader.IsDBNull(reader.GetOrdinal("Icone")))
                        recurso.Icone = (string)reader["Icone"];

                    if (!reader.IsDBNull(reader.GetOrdinal("Menu")))
                        recurso.Menu = (int)reader["Menu"];

                    listaRecurso.Add(recurso);
                }
            }

            return listaRecurso;
        }
    }
}
