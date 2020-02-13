using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


namespace LibraryServiceSolution
{
    [ServiceContract]
    interface ILibraryService
    {
        [OperationContract]
        Book SearchBook(string bookName);
    }
}
