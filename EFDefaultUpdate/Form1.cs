using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDefaultUpdate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookLibraryEntities ctx = new BookLibraryEntities();
            
            ctx.SaveChanges();

            //=========================


        }

       
        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                BookLibraryEntities ctx = new BookLibraryEntities();
                Book b = new Book();
                b.ID = 1;
                ctx.Books.Attach(b);

                DbEntityEntry entry = ctx.Entry(b);
                var allProps = entry.CurrentValues.PropertyNames;
                entry.Property("ID").IsModified = false;
                entry.Property("Name").IsModified = false;
                entry.Property("Author").IsModified = false;
                entry.Property("Category").IsModified = false;
              
                entry.State = EntityState.Unchanged;
                b.Author = "My Updated Author2";

                ctx.ChangeTracker.DetectChanges();

                entry.Property("ID").IsModified = false;
                entry.Property("Name").IsModified = false;
                //entry.Property("Author").IsModified = false;
                entry.Property("Category").IsModified = false;

                //entry.Property("Author").IsModified = true;
                //entry.State = EntityState.Modified;
                
                ctx.SaveChanges();


            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {

            }
        }
    }
}
