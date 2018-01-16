using CodeLab.Assets.EFUpdateWrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateWrapperTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookLibraryEntities context = new BookLibraryEntities();
            
            //  not loaded
            Book bk = new Book() { ID = 1 };
            context.PrepareEntityForUpdate(bk, context.Books);
            bk.Author = "redaadad";
            context.SaveChanges(DirectUpdateMode.AllowAll);

           










        }
    }

    public partial class BookLibraryEntities : DbContext, IDirectUpdateContext
    {
        public DirectUpdateMode? CurrentSaveOperationMode { get; set; } = null;

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            var result = base.ValidateEntity(entityEntry, items);
            return this.RemoveEFFalseAlarms(result, entityEntry);
        }

    }

}
