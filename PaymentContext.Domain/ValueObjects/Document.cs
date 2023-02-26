using DocumentValidator;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract<Notification>().Requires().IsTrue(Validate(), "Document.Number", "Documento inválido"));
        }
        private bool Validate() => ((Type == EDocumentType.CNPJ) && (CnpjValidation.Validate(Number))) || ((Type == EDocumentType.CPF) && (CpfValidation.Validate(Number)));

        public string Number { get; set; }
        public EDocumentType Type{ get; private set; }
    }
}
