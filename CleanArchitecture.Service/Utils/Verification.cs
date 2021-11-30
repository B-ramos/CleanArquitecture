using System;

namespace CleanArchitecture.Service.Utils
{
    public static class Verification
    {
        // compara se o objto de entrada e nulo, caso nulo gera uma exceção 
        public static void ArgumentIsNull(object obj, string message)
        {
            if (obj is null)
                throw new InvalidOperationException(message);
        }
    }
}
