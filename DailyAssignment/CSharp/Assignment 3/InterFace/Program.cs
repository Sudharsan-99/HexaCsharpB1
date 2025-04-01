namespace InterFace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DayScholar dayStudent = new DayScholar(1, "Sonu", 5000);
            Resident residentStudent = new Resident(2, "Moni", 5000, 3000);

            dayStudent.ShowDetails();
            residentStudent.ShowDetails();
        }
    }
}
