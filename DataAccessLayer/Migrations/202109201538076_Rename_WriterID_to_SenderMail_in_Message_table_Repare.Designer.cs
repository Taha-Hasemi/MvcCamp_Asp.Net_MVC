﻿// <auto-generated />
namespace DataAccessLayer.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed partial class Rename_WriterID_to_SenderMail_in_Message_table_Repare : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(Rename_WriterID_to_SenderMail_in_Message_table_Repare));
        
        string IMigrationMetadata.Id
        {
            get { return "202109201538076_Rename_WriterID_to_SenderMail_in_Message_table_Repare"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
