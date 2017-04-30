using StudentsManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentsManagement.Repository
{
    public class ActivityRepository : IActivity, IDisposable
    {
        private StudentContext context;

        public ActivityRepository(StudentContext ctx)
        {
            this.context = ctx;
        }

        //for activity
        public IEnumerable<Activity> GetActivity()
        {
            return context.Activities.ToList();
        }

        public Activity GetActivityID(int? id)
        {
            return context.Activities.Find(id);
        }

        public void AddActivity(Activity act)
        {
            context.Activities.Add(act);
            context.SaveChanges();
        }

        public void EditActivity(Activity act)
        {
            context.Entry(act).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteActivity(int id)
        {
            Activity act = context.Activities.Find(id);
            context.Activities.Remove(act);
            context.SaveChanges();
        }


        ///////////// for tool
        public IEnumerable<Tool> GetTool()
        {
            return context.Tools.ToList();
        }

        public Tool GetToolID(int? id)
        {
            return context.Tools.Find(id);
        }

        public void AddTool(Tool tool)
        {
            context.Tools.Add(tool);
            context.SaveChanges();
        }

        public void EditTool(Tool tool)
        {
            context.Entry(tool).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteTool(int id)
        {
            Tool tool = context.Tools.Find(id);
            context.Tools.Remove(tool);
            context.SaveChanges();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


      
    }
}