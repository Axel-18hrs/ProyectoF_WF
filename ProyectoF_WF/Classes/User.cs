using System;

namespace ProyectoF_WF.Classes
{
    public abstract class User
    {
        public Guid Id { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime Registration_Date { get; set; }

        public User() 
        {
            // Id = Guid.NewGuid();et
            DateTime now = DateTime.Now;
            DateTime trimmedDateTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
            Registration_Date = trimmedDateTime;
        }
        public virtual void Deff()
        {
            Console.WriteLine("user");
        }
    }
}
