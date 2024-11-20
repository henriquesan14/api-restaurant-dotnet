namespace Restaurant.Core.Errors
{
    public static class ErrorMessages
    {
        public const string UNAUTHORIZED = "Email/Senha incorreto(s)";
        public const string USER_EMAIL_ALREADY_EXISTS = "Já possui um usuário com este email";

        public const string TABLE_NOT_FOUND = "Não existe mesa com id: {0}";
    }
}
