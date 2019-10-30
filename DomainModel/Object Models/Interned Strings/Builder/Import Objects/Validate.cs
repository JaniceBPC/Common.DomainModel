using Jbpc.Common.Import;
using Jbpc.Common.Import.ValidationExceptions;

namespace Jbpc.Common.DomainModel.InternedStrings
{
    class Validate : IValidate<ExtractedAttributes>
    {
        private ValidationResult validationResult;
        public ValidationResult ValidateAttributes(ExtractedAttributes extractedAttributes)
        {
            var attributes = (ExtractedAttributes) extractedAttributes;

            validationResult = new ValidationResult();

            if (attributes.Text == "")
            {
                validationResult.Add(new MissingItem("No Interned Text"));
            }

            return validationResult;
        }
    }
}
