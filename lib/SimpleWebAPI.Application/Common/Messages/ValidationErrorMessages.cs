namespace SimpleWebAPI.Application.Common.Messages
{
    public static class ValidationErrorMessages
    {
        public static string ERROR_NAME_EXISTS = "Error: Name already exists";
        public static string ERROR_NAME_DOES_NOT_EXIST = "Error: Name does not exist";
        public static string ERROR_NAME_CANNOT_BE_EMPTY = "Error: Name cannot be blank, empty or null";
        public static string ERROR_NAME_TOO_LONG = "Error: Name cannot be longer than 75 characters";
        public static string ERROR_ADDRESS_CANNOT_BE_EMPTY = "Error: Address cannot be empty";
        public static string ERROR_ADDRESS_TOO_LONG = "Error: Address cannot be longer than 150 characters";
    }
}
