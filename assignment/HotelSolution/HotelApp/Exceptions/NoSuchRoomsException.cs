namespace HotelApp.Exceptions
{
    public class NoSuchRoomsException : Exception
    {
        string message;
        public NoSuchRoomsException()
        {
            message = "The Doctor with the given id is not present";
        }
        public override string Message => message;
    }
}
