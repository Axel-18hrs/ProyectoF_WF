using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoF_WF.Classes
{
    public class ConcreteUser : User
    {
        public override void Deff()
        {
            // et
            Console.WriteLine(Name);
        }
    }
}
