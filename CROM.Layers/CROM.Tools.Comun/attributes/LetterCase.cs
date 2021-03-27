namespace CROM.Tools.Comun.attributes
{
    using System;


    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.Field)]
    public class LetterCaseAttribute : Attribute
    {
        public LetterCaseType CaseType { get; }

        public LetterCaseAttribute(LetterCaseType caseType = LetterCaseType.SensitiveCase)
        {
            CaseType = caseType;
        }

        public enum LetterCaseType
        {
            SensitiveCase = 1,
            LowerCase = 2,
            UpperCase = 3,
            CamelCase = 4,
            PascalCase = 5
        }
    }
}
