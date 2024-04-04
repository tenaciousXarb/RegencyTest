using WinFormsApp.DataAccess;

namespace WinFormsApp.Repositories
{
    public class ClassRepo
    {
        private WinFormsContext context;

        public ClassRepo()
        {
            context = new WinFormsContext();
        }

        public ClassModel Add(ClassModel obj)
        {
            context.Classes.Add(obj);
            context.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var obj = Get(id);
            if (obj != null)
            {
                context.Classes.Remove(obj);
            }
            return context.SaveChanges() > 0;
        }

        public List<ClassModel> Get()
        {
            return context.Classes.ToList();
        }

        public ClassModel? Get(int id)
        {
            return context.Classes.Find(id);
        }

        public bool Update(ClassModel obj)
        {
            var ext = Get(obj.Id);
            context.Entry(ext).CurrentValues.SetValues(obj);
            return context.SaveChanges() > 0;
        }
    }
}
