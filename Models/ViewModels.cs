using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPExcelNet5.Models
{
    public class ListExcelsViewModel
    {
        public ListExcelsViewModel()
        {
            ListExcels = new List<ListExcel>();
        }

        public List<ListExcel> ListExcels { get; set; }

        //кол-во ошибок при импорте
        public int ErrorsTotal { get; set; }
    }
}
