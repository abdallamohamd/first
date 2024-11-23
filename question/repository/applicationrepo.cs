using Microsoft.EntityFrameworkCore;
using question.Models;

namespace question.repository
{
    public class applicationrepo : Iapplicationrepo
    {
        private readonly appcontext appcontext;

        public applicationrepo(appcontext appcontext)
        {
            this.appcontext = appcontext;
        }

        public void add(application application )
        {
            appcontext.applications.Add(application);
        }

        public List<application> all()
        {
            return appcontext.applications.Include(j=>j.job).Include(a=>a.applicant).ToList();
        }

        public void delete(int id)
        {
            application application = Get(id);
            appcontext.applications.Remove(application);
        }

        public application Get(int id)
        {
            return appcontext.applications.FirstOrDefault(x => x.id == id);
        }

        public void save()
        {
            appcontext.SaveChanges();
        }

    }
}
