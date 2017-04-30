using StudentsManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsManagement.Repository
{
    public interface IActivity
    {
        IEnumerable<Activity> GetActivity();

        Activity GetActivityID(int? id);
        void AddActivity(Activity act);
        void EditActivity(Activity act);
        void DeleteActivity(int id);
        

        //tools

        IEnumerable<Tool> GetTool();
        Tool GetToolID(int? id);
        void AddTool(Tool tool);
        void EditTool(Tool tool);
        void DeleteTool(int id);

    }
}