using System;
using Microsoft.AspNetCore.Mvc;

namespace orderapi.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MicroservicesAuthAttribute : TypeFilterAttribute
    {
        public MicroservicesAuthAttribute(string realm = null)
            : base(typeof(MicroservicesAuth))
        {
            Arguments = new object[]
            {
                realm
            };
        }
    }
}