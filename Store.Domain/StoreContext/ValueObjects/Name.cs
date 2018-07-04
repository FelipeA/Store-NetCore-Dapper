namespace Store.Domain.StoreContext.ValueObjects
{
    public class Name{

        public Name(string firstname, string lastName)
        {
            this.FirstName = firstname;
            this.LastName = lastName;
            
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString(){
            return $"{FirstName} {LastName}";
        }
    }
}