
public static class ValidaCPF
{
    public struct Cpf
    {
        private readonly string _value;
        public readonly bool IsValid;

        private Cpf(string value)
        {
            _value = value;
            if (value == null)
            {
                IsValid = false;
                return;
            }
            var position = 0;
            var totalDigit1 = 0;
            var totalDigit2 = 0;
            var verDigit1 = 0;
            var verDigit2 = 0;

            bool equalsDigits = true;
            var lastDigit = -1;

            foreach ( var c in value )
            {
                if (char.IsDigit(c))
                {
                    var digit = c - '0';
                    if(position != 0 && lastDigit != digit)                    
                        equalsDigits = false;                    

                    lastDigit = digit;
                    if(position < 9)
                    {
                        totalDigit1 += digit * (10 - position);
                        totalDigit2 += digit * (11 - position);
                    }
                    else if (position == 9)                    
                        verDigit1 = digit;                    
                    else if(position == 10)                    
                        verDigit2 = digit;                    
                    position++;
                }
            }

            if (position > 11)
            {
                IsValid = false;
                return;
            }

            if (equalsDigits)
            {
                IsValid = false;
                return;
            }

            var firstDigit = totalDigit1 % 11;
            firstDigit = firstDigit < 2 ? 0 : 11 - firstDigit;

            if(verDigit1 != firstDigit)
            {
                IsValid = false;
                return;
            }

            totalDigit2 += firstDigit * 2;
            var secondDigit = totalDigit2 % 11;
            secondDigit = secondDigit < 2 ? 0 : 11 - secondDigit;

            IsValid = verDigit2 == secondDigit;
        }
        public static implicit operator Cpf (string value) => new Cpf (value);
        public override string ToString() => _value;        
    }
    public static bool CpfValidator(Cpf sourceCpf) => sourceCpf.IsValid;
}