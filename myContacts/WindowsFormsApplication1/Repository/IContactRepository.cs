using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1
{
    interface IContactRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int ContactID);
        DataTable Search(string alleh);
        bool Insert(string Name, string Family, string Email, int Age, string Phonenumber);
        bool Update(int ContactID, string Name, string Family, string Email, int Age, string Phonenumber);
        bool Delete(int ContactID);

    }
}
