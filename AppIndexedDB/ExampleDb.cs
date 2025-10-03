using Blazor.IndexedDB;
using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AppIndexedDB.Data
{
    public class ExampleDb : IndexedDb
    {
        public ExampleDb(IJSRuntime jSRuntime, string name, int version) : base(jSRuntime, name, version) 
        {
            
        }

        // Define your object stores here
        public IndexedSet<Employee> Employees { get; set; }
        public IndexedSet<Product> Products { get; set; }
    }

    public class Employee : IEntity
    {
        [Key]
        public int? Id { get; set; }
        
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
    }

    public class Product : IEntity
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }

    public interface IEntity
    {
        int? Id { get; set; }
    }
}