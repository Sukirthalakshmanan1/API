using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class Student_Helper
    {
        Student_DAL dal = null;
        public Student_Helper()
        {
            dal = new Student_DAL();
        }


        public bool AddE(marks school)
        {
            return dal.Insert(school);

        }

        public bool Edit(marks school)
        {
            return dal.Update(school);
        }

        public marks search(int id)
        {
            return dal.Find(id);
        }
        public List<marks> BList()
        {
            return dal.List();
        }
        public bool remove(int id)
        {
            return dal.Delete(id);
        }
    }
}
