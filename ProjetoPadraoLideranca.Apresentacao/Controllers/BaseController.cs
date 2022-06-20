using GetSenha451.Web;
using Lidercap.Auth.Domain.Entities;
using Site.ViewModel;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace ProjetoPadraoLideranca.Apresentacao.Controllers
{
    public class BaseController : Controller
    {
        public static string _VerificaGetSenha = "";
        public static GetSenha GetSenha;
        protected User _User;

        public BaseController()
        {
            if (_VerificaGetSenha == "")
                Incializa();

            if (GetSenha.IsAuthenticated())
            {
                this._User = GetSenha.GetUser();
                ViewBag.Env = GetSenha.Env;
                ViewBag.User = GetSenha.GetUser();
                ViewBag.Server = GetSenha.GetServer().ToUpper();

                // Depois de colocar o nome da aplicação no Web.config, desmarca a linha debaixo.
                ViewBag.GetResource = GetSenha.GetResources(ConfigurationManager.AppSettings["ApplicationName"]);
                ViewBag.NomeAplicacao = ConfigurationManager.AppSettings["Aplicacao"];
                ViewBag.IsAuthenticated = GetSenha.IsAuthenticated();
                ViewBag.GetUrl = GetSenha.GetUrl();
            }
        }

        public void Incializa()
        {
            GetSenha = new GetSenha();
            _VerificaGetSenha = "1";
        }

        public void Sucess(string message, bool dismissable = false)
        {
            if (!string.IsNullOrEmpty(message))
                AddAlert(Alert.AlertStyles.Success, message, dismissable);
        }
        public void Information(string message, bool dismissable = false)
        {
            if (!string.IsNullOrEmpty(message))
                AddAlert(Alert.AlertStyles.Information, message, dismissable);
        }
        public void Warning(string message, bool dismissable = false)
        {
            if (!string.IsNullOrEmpty(message))
                AddAlert(Alert.AlertStyles.Warning, message, dismissable);
        }
        public void Danger(string message, bool dismissable = false)
        {
            if (!string.IsNullOrEmpty(message))
                AddAlert(Alert.AlertStyles.Danger, message, dismissable);
        }

        private void AddAlert(string alertStyle, string message, bool dismissable)
        {
            var alerts = TempData.ContainsKey(Alert.TempDataKey) ? (List<Alert>)TempData[Alert.TempDataKey] : new List<Alert>();

            alerts.Add(new Alert()
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable
            });

            TempData[Alert.TempDataKey] = alerts;
        }
    }
}