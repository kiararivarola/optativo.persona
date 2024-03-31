using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public interface IPersona
    {
        bool add(PersonaModel persona);
        string remove(int id);
        string update(int id);
        PersonaModel get(int id);
        IEnumerable<PersonaModel> list();
    }
}