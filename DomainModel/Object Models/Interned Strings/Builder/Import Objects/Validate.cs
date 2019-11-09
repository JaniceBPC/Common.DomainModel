using System.ComponentModel.DataAnnotations;
using Jbpc.Common.Import;
using Jbpc.Common.Import.ValidationExceptions;

namespace Jbpc.Common.DomainModel.InternedStrings
{
    class Validate : IValidate<ExtractedAttributes>
    {
        private ValidationResultCollection validationResult;
        public ValidationResultCollection ValidateAttributes(ExtractedAttributes extractedAttributes)
        {
            var attributes = (ExtractedAttributes) extractedAttributes;

            validationResult = new ValidationResultCollection();

            if (attributes.Text == "")
            {
                validationResult.Add(new MissingItem("No Interned Text"));
            }

            return validationResult;
        }
    }
}
