using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnowledgeBaseAllInOne
{
    public partial class WorkingWithLinq : Form
    {
        public WorkingWithLinq()
        {
            InitializeComponent();
        }

        private void WorkingWithLinq_Load(object sender, EventArgs e)
        {
            // our collection with students
            List<Student> students = new List<Student>();
            
            // Fill data
            // ...

            var res = from st in students
                      where st.Id == 20
                      select st;

            // get only one result
            var res2 = (from st in students
                where st.Id == 20
                select st).FirstOrDefault();

            // another where 
            var res3 = students.Where(st => st.Id == 20);

            // само студентите, които имат успех не по-малък от средния успех 
            var res4 = from st in students
                        let totalMarks = students.Sum(mark => mark.Marks)
                        let avgMarks = totalMarks / students.Count // среден успех 
                        where st.Marks >= avgMarks
                        select st;

            // резултата да е друг обект
            var res5 = from st in students
                       where st.Marks > 20
                       select new { st.Id, st.First };

            int firstId = res5.ElementAt(0).Id;

        }
    }

    internal class Student
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public int Marks { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.First, this.Last);
        }
    }
}
