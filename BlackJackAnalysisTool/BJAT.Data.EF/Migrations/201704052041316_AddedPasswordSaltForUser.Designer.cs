// <auto-generated />
namespace BJAT.Data.EF.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class AddedPasswordSaltForUser : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddedPasswordSaltForUser));
        
        string IMigrationMetadata.Id
        {
            get { return "201704052041316_AddedPasswordSaltForUser"; }
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
