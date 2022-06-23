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
    public class RelatorioJiraRepository : RepositoryBase<RelatorioJira>
    {

        public List<RelatorioJira> PesquisarResultado(string regime, int mes, int ano)
        {
            try
            {
                List<RelatorioJira> retorno = new List<RelatorioJira>();

                var param = new DynamicParameters();


                if (!String.IsNullOrEmpty(regime) | !(regime == ""))
                {
                    param.Add("@regime", regime);
                }
                if (!(mes == 0))
                {
                    param.Add("@mes", mes);
                }
                if (!(ano == 0))
                {
                    param.Add("@ano", ano);
                }



                return this.GetAll(new RelatorioJira(), param, RelatorioJira.PesquisarProjetosJira).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable DownloadResultado(string regime, int mes, int ano)
        {
            try
            {
                DataTable retorno = new DataTable();
                using (var con = new SqlConnection(StrConnection))
                {
                    con.Open();
                    using (var cmd = new SqlCommand(RelatorioJira.PesquisarProjetosJira, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (!String.IsNullOrEmpty(regime) | !(regime == ""))
                        {
                            cmd.Parameters.AddWithValue("@regime", regime);
                        }
                        if (!(mes == 0))
                        {
                            cmd.Parameters.AddWithValue("@mes", mes);
                            
                        }
                        if (!(ano == 0))
                        {
                            cmd.Parameters.AddWithValue("@ano", ano);
                        }

                        var reader = cmd.ExecuteReader();

                        retorno.Load(reader);

                    }

                    return retorno;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
