namespace DBStuff.Models
{
    public class Record
    {
        public int Id { get; set; }
        public string Line {get; set;}
        public string AnotherLine {get; set;}

        public Record(int Id, string Line, string AnotherLine)
        {
            this.Id = Id;
            this.Line = Line;
            this.AnotherLine = AnotherLine;
        }
    }
}