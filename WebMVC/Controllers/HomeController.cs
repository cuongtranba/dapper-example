using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Dapper;
using WebMVC.Models;
using WebMVC.Services;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private IToDoServices toDoServices;
        private IDbConnection dbConnection;
        public HomeController(IToDoServices toDoServices, IDbConnection dbConnection)
        {
            this.toDoServices = toDoServices;
            this.dbConnection = dbConnection;
        }

        public async Task<ActionResult> Index()
        {
            //var queryBuilder = new StringBuilder();
            //queryBuilder.Append("select count(*) from ToDoListItems;");
            //queryBuilder.Append("select * from ToDoListItems;");
            //queryBuilder.Append("select count(*) from ToDoListItems;");
            //var items = await dbConnection.QueryMultipleAsync(queryBuilder.ToString());
            //return Json(new { count = items.Read<int>(), item = items.Read<ToDoItem>().ToList() ,count2=items.Read<int>()}, JsonRequestBehavior.AllowGet);
            var queryBuilder = new StringBuilder();
            queryBuilder.Append("select count(*) from cuahang;");
            queryBuilder.Append("select * from cuahang;");
            queryBuilder.Append("select count(*) from cuahang;");
            var items = await dbConnection.QueryMultipleAsync(queryBuilder.ToString());
            return Json(new { count = items.Read<int>(), item = items.Read<CuaHang>().ToList(), count2 = items.Read<int>() }, JsonRequestBehavior.AllowGet);
        }
    }
}