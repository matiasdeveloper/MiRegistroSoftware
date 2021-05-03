using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class UserCache
{
    public static int IdUser { get; set; }
    public static int IdPerfil { get; set; }
    public static int IdSecurity { get; set; }
    public static string User { get; set; }
    public static string Email { get; set; }
    public static DateTime LastAcess { get; set; }
    public static int isRoot { get; set; }
}
