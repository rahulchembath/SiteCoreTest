using Sitecore;
using Sitecore.Data.Validators;
using System;
using System.Runtime.Serialization;

namespace Claro.Foundation.Core.Validator
{
    [Serializable]
    public class CustomMaxLengthFieldValidator : StandardValidator
    {
        public CustomMaxLengthFieldValidator() { }
        public CustomMaxLengthFieldValidator(SerializationInfo info, StreamingContext context)
         : base(info, context)
        {
        }

        public override string Name
        {
            get
            {
                return Exceptions.Constants.CustomMaxLengthFieldName;
            }
        }

        protected override ValidatorResult Evaluate()
        {
            int num = MainUtil.GetInt(base.Parameters["maxlength"], 0);
            if (num <= 0)
            {
                return ValidatorResult.Valid;
            }
            string controlValidationValue = GetControlValidationValue();
            if (string.IsNullOrEmpty(controlValidationValue))
            {
                return ValidatorResult.Valid;
            }
            if (controlValidationValue.Length <= num)
            {
                return ValidatorResult.Valid;
            }
            string[] fieldDisplayName = new string[] { base.GetFieldDisplayName(), num.ToString() };
            base.Text = base.GetText("The maximum length of the field \"{0}\" is {1} characters.", fieldDisplayName);
            return base.GetFailedResult(ValidatorResult.FatalError);
        }

        protected override ValidatorResult GetMaxValidatorResult()
        {
            string result = base.Parameters["result"].ToString();
            return base.GetFailedResult(ValidatorResult.FatalError);
        }
    }
}