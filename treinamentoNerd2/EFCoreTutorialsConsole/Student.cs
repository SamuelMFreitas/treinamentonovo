using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTutorialsConsole
{
    public class Student
    {
       //Sempre que se usa no nome da propriedade o final Id, o Ef entende que deverá
       //usar essa propriedade como chave primária
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        #region Foreing Key do BD
        public Grade Grade { get; set; }

        public int GradeId { get; set; }

        #endregion




    }
}
