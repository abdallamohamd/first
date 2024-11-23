using question.Models;

namespace question.repository
{
    public interface Ijobrepo
    {

        public List<job> all();
        public job get(int id);
        public void add(job job);
        public void delete(int id);
        public void save();
    }
}
