using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WebMVC.Models;

namespace WebMVC.Services
{
    public interface IToDoServices
    {
        List<ToDoItem> GetDoItems();
    }

    public class ToDoService : IToDoServices
    {
        private IDbConnection dbConnection;

        public ToDoService(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public List<ToDoItem> GetDoItems()
        {
            var items = dbConnection.Query<ToDoItem>("select * from ToDoListItems");
            return items.ToList();
        }
    }
}