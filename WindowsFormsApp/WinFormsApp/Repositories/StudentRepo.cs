using Microsoft.EntityFrameworkCore;
using WinFormsApp.DataAccess;

namespace WinFormsApp.Repositories
{
    public class StudentRepo
    {
        private WinFormsContext context;

        public StudentRepo()
        {
            context = new WinFormsContext();
        }

        public StudentModel Add(StudentModel obj)
        {
            context.Students.Add(obj);
            context.SaveChanges();
            return obj;
        }

        public bool Delete(Guid id)
        {
            var obj = Get(id);
            if (obj != null)
            {
                context.Students.Remove(obj);
            }
            return context.SaveChanges() > 0;
        }

        public List<StudentModel> Get()
        {
            return context.Students.Include("ClassModel").ToList();
        }

        public StudentModel? Get(Guid id)
        {
            return context.Students.Include("ClassModel").Where(x => x.Id == id).FirstOrDefault();
        }

        public bool Update(StudentModel obj)
        {
            var ext = Get(obj.Id);
            context.Entry(ext).CurrentValues.SetValues(obj);
            return context.SaveChanges() > 0;
        }
    }
}
