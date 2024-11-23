using question.Models;

namespace question.repository
{
    public class jobrepo : Ijobrepo
    {
        private readonly appcontext appcontext;

        public jobrepo(appcontext appcontext)
        {
            this.appcontext = appcontext;
        }

        public void add(job job)
        {
            appcontext.jobs.Add(job);
        }

        public List<job> all()
        {
            return appcontext.jobs.ToList();
        }

        public void delete(int id)
        {
            job job = get(id);
            appcontext.jobs.Remove(job);
        }

        public job get(int id)
        {
            return appcontext.jobs.FirstOrDefault(x => x.id == id);
        }

        public void save()
        {
            appcontext.SaveChanges();
        }
    }
}
