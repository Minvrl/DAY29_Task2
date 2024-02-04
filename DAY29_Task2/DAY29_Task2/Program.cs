

using DAY29_Task2;
using System.Globalization;

List<Student> Students = new List<Student>();

string opt,fullname,stdNoStr,pointStr,exam;
int stdNo;
byte point;

do
{
    Console.WriteLine("\n === MENU === ");
    Console.WriteLine("1. Telebe elave et");
    Console.WriteLine("2. Telebeye imtahan elave et");
    Console.WriteLine("3. Telebenin bir imtahan balına bax");
    Console.WriteLine("4. Telebenin butun imtahanlarını goster");
    Console.WriteLine("5. Telebenin imtahan ortalamasını goster");
    Console.WriteLine("6. Telebeden imtahan sil");
    Console.WriteLine("7. Butun telebeler ve imtahan saylarini goster");
    Console.WriteLine("0. Proqramı bitir");

    opt = Console.ReadLine();

    switch (opt)
    {
        case "1":
            do
            {
                Console.Write("\nTelebenin ad,soyadini daxil edin - ");
                fullname = Console.ReadLine();

            } while (string.IsNullOrEmpty(fullname) || !CheckName(fullname));
            Student std = new Student(fullname);
            Students.Add(std);
            Console.WriteLine("Telebe elave olundu !");
            break;

        case "2":
            do
            {
                Console.Write("\nTelebenin nomresini daxil edin - ");
                stdNoStr = Console.ReadLine();
            } while (!int.TryParse(stdNoStr, out stdNo) || stdNo < 0);

            do
            {
                Console.Write(" Imtahan adini daxil edin - ");
                exam = Console.ReadLine();
            } while (string.IsNullOrEmpty(exam));

            do
            {
                Console.Write("  Balini daxil edin - ");
                pointStr = Console.ReadLine();
            } while (!byte.TryParse(pointStr, out point));

            Student student = Students.FirstOrDefault(s => s.No == stdNo);

            if (student != null)
            {
                if (student.Exams == null)
                {
                    student.Exams = new Dictionary<string, byte>();
                }

                student.Exams.Add(exam, point);
                Console.WriteLine("Imtahan telebeye elave olundu!");
            }
            else
            {
                Console.WriteLine("Telebe tapilmadi!");
            }
            break;
        case "3":
            do
            {
                Console.Write("\nTelebenin nomresini daxil edin - ");
                stdNoStr = Console.ReadLine();
            } while (!int.TryParse(stdNoStr, out stdNo) || stdNo < 0);

            do
            {
                Console.Write(" Imtahan adini daxil edin - ");
                exam = Console.ReadLine();
            } while (string.IsNullOrEmpty(exam));

            Student studentPoint = Students.FirstOrDefault(s => s.No == stdNo);

            if (studentPoint != null)
            {
                if (studentPoint.Exams != null && studentPoint.Exams.ContainsKey(exam))
                {
                    var thePoint = studentPoint.GetExamResult(exam);
                    Console.WriteLine($"Telebenin {exam} imtahani bali : {thePoint}");
                }
                else
                {
                    Console.WriteLine($"{stdNo}. telebede bu imtahan movcud deyil");
                }
            }
            else
            {
                Console.WriteLine($"'{stdNo}' nomreli telebe tapilmadi");
            }

            break;

        case "4":
            do
            {
                Console.Write("\nTelebenin nomresini daxil edin - ");
                stdNoStr = Console.ReadLine();
            } while (!int.TryParse(stdNoStr, out stdNo) || stdNo < 0);

            Student stdAllExams = Students.FirstOrDefault(s => s.No == stdNo);
            if(stdAllExams != null)
            {
                if(stdAllExams.Exams != null)
                {
                    foreach (var item in stdAllExams.Exams)
                    {
                        Console.WriteLine($"{item.Key} -  {item.Value} bal");
                    }
                }
                else Console.WriteLine("Bu telebe hecbir imtahanda istirak etmeyib !");
            }
            else Console.WriteLine("Bu nomreli telebe movcud deyil !");

            break;

        case "5":
            do
            {
                Console.Write("\nTelebenin nomresini daxil edin - ");
                stdNoStr = Console.ReadLine();
            } while (!int.TryParse(stdNoStr, out stdNo) || stdNo < 0);

            Student stdAvg = Students.FirstOrDefault(s=> s.No == stdNo);
            if (stdAvg != null)
            {
                if (stdAvg.Exams != null)
                {
                    Console.WriteLine($"\tTelebenin imtahan ortalamasi : {stdAvg.GetExamAvg()}");
                }
                else Console.WriteLine("Bu telebe hecbir imtahanda istirak etmeyib");
            }
            else Console.WriteLine("Telebe tapilmadi");
            break;

        case "6":
            do
            {
                Console.Write("\nTelebenin nomresini daxil edin - ");
                stdNoStr = Console.ReadLine();
            } while (!int.TryParse(stdNoStr, out stdNo) || stdNo < 0);

            do
            {
                Console.Write(" Imtahan adini daxil edin - ");
                exam = Console.ReadLine();
            } while (string.IsNullOrEmpty(exam));

            Student studentExamRmv = Students.FirstOrDefault(s => s.No == stdNo);
            if (studentExamRmv != null)
            {
                if (studentExamRmv.Exams != null)
                {
                    studentExamRmv.Exams.Remove(exam);
                    Console.WriteLine("Imtahan silindi !");
                }
                else Console.WriteLine("Bu telebe hecbir imtahanda istirak etmeyib");
            }
            else Console.WriteLine("Telebe tapilmadi");
            break;

        case "7":
            Console.WriteLine("\n === TELEBELER === ");
            foreach (Student item in Students)
                Console.WriteLine(item);
            break;
        case "0":
            Console.WriteLine("Proqram bitdi.");
            break;
        default:
            Console.WriteLine("Duzgun operator daxil edin !");
            break;
    }

} while (opt != "0");



static bool CheckName(string fullname)
{
    var parts = fullname.Split(' ');
    if (parts.Length != 2) return false;
    return true;
}