using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoF_WF.Classes
{
    public static class ClientManager
    {
        public static Client ClientInstance { get; private set; }
        public static Administrator AdministratorInstance { get; private set; }
        public static string UserFolderPath
        {
            get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProyectoF_WF", "Users"); }
        }
        public static string AdministratorFolderPath
        {
            get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ProyectoF_WF", "Administrator"); }
        }

        public static void InitializeCliente(Client user)
        {
            ClientInstance = user;
        }
        public static void InitializeAdministrator(Administrator user)
        {
            AdministratorInstance = user;
        }
    }
}
