using System.Web.Mvc;

namespace N3API.Areas.Entity
{
    public class EntityAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Entity";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Entity_default",
                "Entity/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}