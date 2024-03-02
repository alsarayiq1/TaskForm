namespace FormPage.Dto
{
    public class PersonDto
    {
        public int PersonInfoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public object Name { get; internal set; }
    }
}
