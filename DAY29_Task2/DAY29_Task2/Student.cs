using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DAY29_Task2
{
    internal class Student
    {
        public Student(string fullname)
        {
            _no++;
            this.No = _no;
            this.Fullname = fullname;
        }


        static int _no;
        public readonly int No;
        public string Fullname;
        public new Dictionary<string, byte> Exams;

        public void AddExam(string examName, byte point)
        {
            Exams.Add(examName, point);
        }

        public byte GetExamResult(string examName)
        {
            foreach (var exam in Exams)
            {
                if(exam.Key == examName)
                    return exam.Value;  
            }
            return 0;
        }

        public double GetExamAvg()
        {
            byte total = 0;
            byte count = 0;

            foreach (var exam in Exams)
            {
                total += exam.Value;
                count++;
            }
            return count > 0 ? (double)total / count : 0;
        }


        public override string ToString()
        {
            return $"{No}. {Fullname} - Imtahan sayi : {(Exams != null ? Exams.Count : 0)}";
        }
    }
}
