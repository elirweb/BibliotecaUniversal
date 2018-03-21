namespace Usuario.Domain.ValueObjects
{
    public class Email
    {
        public string Endereco { get; private set; }

        public Email(string end)
        {
            if (IsValid(end))
                Endereco = end;
        }

        public bool IsValid(string end)
        {
            if (end.Contains("@"))
                return true;
            return false;
        }


    }
}

