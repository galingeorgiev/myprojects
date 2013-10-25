namespace RefactorCSharpCodePartTwo
{
    public class PersonBuilder
    {
        public void CreatePerson(int personID)
        {
            Person createdPerson = new Person();
            createdPerson.PersonAge = personID;
            if (personID % 2 == 0)
            {
                createdPerson.PersonName = "Brother";
                createdPerson.PersonSex = Sex.Male;
            }
            else
            {
                createdPerson.PersonName = "Chick";
                createdPerson.PersonSex = Sex.Female;
            }
        }
    }
}