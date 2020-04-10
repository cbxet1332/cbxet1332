namespace PersonSearch.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string Forenames { get; set; }
        public string Surname { get; set; }
        public Group Group { get; set; }
        public int GroupId { get; set; }
    }
}