using question.Models;

namespace question.repository
{
    public interface Iapplicationrepo
    {
        public List<application> all();
        public application Get(int id);
        public void delete(int id);
        public void save();
        public void add( application application);
    }
}
