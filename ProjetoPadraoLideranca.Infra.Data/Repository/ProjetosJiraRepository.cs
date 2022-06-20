using Dapper;
using Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void Teste(DataTable funcTable, DataTable projTable)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@TblProjetos", projTable);
                param.Add("@TblFuncionarios", funcTable);
                this.Get(new ProjetosJira(), param, ProjetosJira.ListaProjetoFuncionarioResultProc);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
