using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;


namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string principalName)
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsLowerThan(principalName, 80, "PrincipalName", "O nome deve ter menos de 100 caracteres")
                .IsGreaterThan(principalName, 3, "PrincipalName", "O Nome deve conter mais de 3 caracteres"));

            if (!IsValid)
            {
                return;
            }

            PrincipalName = principalName;

            if (string.IsNullOrEmpty(principalName))
            {
                AddNotification("Name.PrincipalName", "Nome Inválido");
            }
        }

        public string PrincipalName { get; set; }
    }
}
