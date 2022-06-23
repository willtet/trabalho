using Dapper;
using Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendaTsdigital.Dominio.Entidades;

namespace VendaTsdigital.Infra.Data.Repository
{
    public class ProjetosJiraRepository : RepositoryBase<ProjetosJira>
    {
        public List<ProjetosJira> consultaProjetosJira(string projeto)
        {
            try
            {
                var param = new DynamicParameters();
                string codigo = ((projeto == "" | projeto == null) ? null : projeto);
                param.Add("@Projeto", codigo);
                return this.GetAll(new ProjetosJira(), param, ProjetosJira.ConsultaProjetosJira).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<ProjetosJira> ListarCodigosProjeto()
        {
            try
            {
                return this.GetAll(new ProjetosJira(),  ProjetosJira.ConsultaNomeProjetosProc).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void GerarResultado(DataTable funcTable, DataTable projTable)
        {
            

            using (var con = new SqlConnection(StrConnection))
            {
                con.Open();
                using (var cmd = new SqlCommand(ProjetosJira.GerarProjetoFuncionarioResultProc, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TblProjetos", projTable);
                    cmd.Parameters.AddWithValue("@TblFuncionarios", funcTable);

                    cmd.CommandTimeout = 0;
                    SqlDataReader rs = cmd.ExecuteReader();
                }
            }
        }

        


    }
}
