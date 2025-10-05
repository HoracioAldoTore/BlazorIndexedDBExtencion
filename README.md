# BlazorIndexedDBExtencion
Métodos de extensión que utilizan el paquete de NuGet de Blazor.IndexedDB version 3.0.3, facilitándonos la escritura del CRUD en la IndexedDB.

Video sobre una aplicacion Blazor en lenguaje C#
https://youtu.be/WPkL43kr5x0

## Pasos a seguir para la instalacion:

**1)** Instalar el paquete de NuGet de Blazor.IndexedDB version 3.0.3. Siguindo lo indicado en: 
https://www.nuget.org/packages/Blazor.IndexedDB

**2)** Copiar el archivo **BlazorIndexedDBExtencion.cs** en su proyecto para acceder a los metodos de extensión.
Los métodos de extensión se encuentran definidos en el archivo **BlazorIndexedDBExtencion.cs** 
y utilizan reflection c# para descubrir métodos y propiedades.

**3)** Crear el modelo de base heredando de IndexedDb, puede tomar como ejemplo el arrchivo **ExampleDb.cs**

## Codigo de ejemplo de un CRUD

**Create** 
```csharp
	private async void Crear()
	{
	  // Crear (Create)
	  var newEmployee = new Employee
	  {
		  FirstName = $"Manuel",
		  LastName = $"Sadosky - {Guid.NewGuid()}"
	  };
	  await DbFactory.Insert(newEmployee);
	  //await DbFactory.Save(newEmployee);

	  await Refresh();
	}
```

**Read** 
```csharp
    private async void Leer()
    {

        // Leer (Read)  
        int id = _Employees.Last().Id.Value;
        var oneEmployee = await DbFactory.SelectOne<Employee>(id);
        string msg = $"Id:        {oneEmployee.Id}\n" +
                     $"FirstName: {oneEmployee.FirstName}\n" +
                     $"LastName:  {oneEmployee.LastName}\n";
        
        await JsRuntime.InvokeVoidAsync("alert", msg); // Alert

        await Refresh();
    }
```

**Update** 
```csharp
	private async void Actualizar()
	{
		// Actualizar (Update)
		foreach(Employee employee in _Employees)
		{
			if (employee.LastName.Contains("Sadosky"))
			{
				employee.FirstName = "René";
				employee.LastName = $"Favaloro - {Guid.NewGuid()}";
			}
			else
			{
				employee.FirstName = "Manuel";
				employee.LastName = $"Sadosky  - {Guid.NewGuid()}";
			}
			await DbFactory.Update(employee);
		}
		
		await Refresh();
	}
```

**Delete** 
```csharp
	private async void Eliminar()
	{
		// Eliminar (Delete)
		Employee employee = _Employees.Last(); 

		await DbFactory.Delete<Employee>(employee.Id.Value);

		await Refresh();
	}
```

## Todas las entidades deben implementar la siguiente interfaz:
```csharp
	public interface IEntity
	{
	 int? Id { get; set; }
	}
```
**Ejemplo de entidad** 
```csharp
	public class Employee : IEntity
	{
	 [Key]
	 public int? Id { get; set; }
	 
	 public string? FirstName { get; set; }
	 
	 public string? LastName { get; set; }
	}
```

**Ejemplo de IndexedDb** 
```csharp
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
```
