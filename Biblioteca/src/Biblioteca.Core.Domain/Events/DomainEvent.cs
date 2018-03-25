
using Biblioteca.Core.Domain.Interfaces;
using System;

namespace Biblioteca.Core.Domain.Events
{
    public class DomainEvent
    {
        public static IContainer Container { get; set; }

        public static void Raise<T>(T args) where T : IDomainEvent
        {

            if (Container == null) return;

            var obj = Container.GetInstance(typeof(IHandler<T>));
            ((IHandler<T>)obj).Handle(args);
        }
    }
}
