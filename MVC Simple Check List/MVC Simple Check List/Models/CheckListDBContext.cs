namespace MVC_Simple_Check_List.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class CheckListDBContext : DbContext
    {
        // Your context has been configured to use a 'CheckListDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MVC_Simple_Check_List.Models.CheckListDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CheckListDB' 
        // connection string in the application configuration file.
        public CheckListDBContext()
            : base("name=CheckListDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<CheckList> CheckLists { get; set; }
        public virtual DbSet<CheckListItem> CheckListItems { get; set; }
    }

    public class CheckListItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool state { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StatusChangedDate { get; set; }
    }

    public class CheckList
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<CheckListItem> CheckListItems { get; set; }
    }
}