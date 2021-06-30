using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPExcelNet5.Models
{
    public class CellPosition
    {
        
        public string FirstName { get; set; }

       
        public string Cell { get; set; }
    }

    public class ColumnName
    {
        public ColumnName()
        {
            ColumnPositions = new List<CellPosition>();
        }

        
        public string Title { get; set; }

        public List<CellPosition> ColumnPositions { get; set; }
    }

    public class ListExcel
    {
        public ListExcel()
        {
            CollectionOfSheets = new List<ColumnName>();
        }

        //Название листа
        public string Title { get; set; }

        public List<ColumnName> CollectionOfSheets { get; set; }
    }
}
