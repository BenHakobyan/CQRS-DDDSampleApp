namespace SampleApp.Domain.Contact.Checkers
{
    public interface IContactUniquenessChecker
    {
        bool Check(Entities.Contact contact, out string paramName);
    }
}
