using System;

namespace Api.Exceptions
{
    public class UnknownFoodException : Exception
    {
        public UnknownFoodException() : base("Oops! Unknown Food!")
        {

        }
    }
}
