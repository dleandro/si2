using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class App
    {
        static void Main(string[] args)
        {
            Aluno a2 = new Aluno();
            a2.Numero = 4444;
            a2.Nome = "zeca";

            a2.Hobbies = new List<String>();
            a2.Hobbies.Add("h1");
            a2.Hobbies.Add("h2");

            Aluno a3 = new Aluno();
            a3.Numero = 5555;
            a3.Nome = "rita";

            a3.Hobbies = new List<String>();
            a3.Hobbies.Add("h2");
            a3.Hobbies.Add("h3");

            using (var s = new Session())
            {
                IMapperAluno map = s.CreateMapperAluno();
        s.OpenConnection();
                s.BeginTran();
                map.Create(a2);  
                map.Create(a3);
                s.EndTransaction(true,true);
                //s.EndTransaction(false, true);
                s.CloseConnection(true);
            }
}
    }
    }
}
