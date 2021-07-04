using ASPExcelNet5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPExcelNet5.Data
{
    public class TablesExcelContext :DbContext
    {
        public TablesExcelContext(DbContextOptions<TablesExcelContext> options):base( options)
        {

        }

        public DbSet<ColumnName> ColumnNames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<ColumnName>().ToTable("TableExcelList");
        }


    }
}
