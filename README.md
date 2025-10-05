# BlazorIndexedDBExtencion
Métodos de extensión que utilizan el paquete de NuGet de Blazor.IndexedDB version 3.0.3, facilitándonos la escritura del CRUD en la IndexedDB.

Video sobre una aplicacion Blazor en lenguaje C#
https://youtu.be/WPkL43kr5x0

## Pasos a siguir para la instalacion:

**1)** Instalar el paquete de NuGet de Blazor.IndexedDB version 3.0.3. Siguindo lo indicado en: 
https://www.nuget.org/packages/Blazor.IndexedDB

**2)** Copiar el archivo **BlazorIndexedDBExtencion.cs** en su proyecto para acceder a los metodos de extensión.
Los métodos de extensión se encuentran definidos en el archivo **BlazorIndexedDBExtencion.cs** 
y utilizan reflection c# para descubrir métodos y propiedades.

**3)** Crear el modelo de base heredando de IndexedDb, puede tomar como ejemplo el arrchivo **ExampleDb.cs**

```
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

