namespace Kursovaya
{
    public class Zadacha
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int ExecTime { get; set; }

        public Zadacha(int id, int type, int exectime)
        {
            Id = id;
            Type = type;
            ExecTime = exectime;
        }
    }
}