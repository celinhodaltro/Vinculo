using Person.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        public Task NotifyNewPersonCreatedAsync(string name)
        {
            Console.WriteLine($"Nova pessoa criada: {name}");
            return Task.CompletedTask;
        }
    }
}
