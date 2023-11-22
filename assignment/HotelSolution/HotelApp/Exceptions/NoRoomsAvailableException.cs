namespace HotelApp.Exceptions
{
    public class NoRoomsAvailableException : Exception
    {
        string message;
        public NoRoomsAvailableException()
        {
            message = "No Questions are available In This Quiz";
        }
        public override string Message => message;
    }
}
