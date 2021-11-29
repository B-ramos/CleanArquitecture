using System;

namespace CleanArchitecture.Service.Utils
{
    public static class Verification
    {
        public static void ArgumentIsNull(object obj, string message)
        {
            if (obj is null)
                throw new InvalidOperationException(message);
        }
    }
}
