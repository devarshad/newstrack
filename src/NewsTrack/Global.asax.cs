using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
namespace NewsTrack
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<NewsTrack.Models.ApplicationDbContext>(null);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleTable.EnableOptimizations = false;
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(Server.MapPath("~/Log4Net.config")));
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Enter - Application_Error");

            var _httpContext = ((WebApiApplication)sender).Context;

            var _currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(_httpContext));
            var _currentController = " ";
            var _currentAction = " ";

            if (_currentRouteData != null)
            {
                if (_currentRouteData.Values["controller"] != null &&
                    !string.IsNullOrEmpty(_currentRouteData.Values["controller"].ToString()))
                {
                    _currentController = _currentRouteData.Values["controller"].ToString();
                }

                if (_currentRouteData.Values["action"] != null &&
                    !string.IsNullOrEmpty(_currentRouteData.Values["action"].ToString()))
                {
                    _currentAction = _currentRouteData.Values["action"].ToString();
                }
            }

            var _exception = Server.GetLastError();

            _exception.HelpLink = "It can be due to wrong invalid view to render or invalid razor syntax or accessing invalid/inaccessible model or propoerty.";
            _exception.Data.Add("Location : ", "Exception occured while rendering view.");
            _exception.Data.Add("Applpication Tier : ", "1. NewsTrack App");
            _exception.Data.Add("Class : ", "Global.asax");
            _exception.Data.Add("Method : ", "Application_Error");

            NT.Logging.Logger.Error("Error at Application error", _exception);

            var _controller = new NewsTrack.Controllers.ErrorController();
            var _routeData = new RouteData();
            var _action = "ServerError";
            var _statusCode = 500;

            if (_exception is HttpException)
            {
                var httpEx = _exception as HttpException;
                _statusCode = httpEx.GetHttpCode();

                switch (httpEx.GetHttpCode())
                {
                    case 400:
                        _action = "BadRequest";
                        break;

                    case 401:
                        _action = "Unauthorized";
                        break;

                    case 403:
                        _action = "Forbidden";
                        break;

                    case 404:
                        _action = "PageNotFound";
                        break;

                    case 500:
                        _action = "ServerError";
                        break;

                    default:
                        _action = "Error";
                        break;
                }
            }
            else if (_exception is System.Security.Authentication.AuthenticationException)
            {
                _action = "Forbidden";
                _statusCode = 403;
            }

            _httpContext.ClearError();
            _httpContext.Response.Clear();
            _httpContext.Response.StatusCode = _statusCode;
            _httpContext.Response.TrySkipIisCustomErrors = true;

            if (_exception is HttpAntiForgeryException)
            {
                HttpContext.Current.Response.Redirect("/");
            }

            _routeData.Values["controller"] = "Error";
            _routeData.Values["action"] = _action;

            _controller.ViewData.Model = new HandleErrorInfo(_exception, _currentController, _currentAction);
            ((IController)_controller).Execute(new RequestContext(new HttpContextWrapper(_httpContext), _routeData));
        }
    }
}
