using System;  
using System.Collections.Generic;  
  
// Clase para representar un Asiento  
public class Asiento  
{  
    public int Numero { get; set; }  
    public bool Ocupado { get; set; }  
  
    public Asiento(int numero)  
    {  
        Numero = numero;  
        Ocupado = false;  
    }  
  
    public override string ToString()  
    {  
        return $"Asiento #{Numero} - {(Ocupado ? "Ocupado" : "Disponible")}";  
    }  
}  
  
// Clase para representar a una Persona en la cola  
public class Persona  
{  
    public string Nombre { get; set; }  
  
    public Persona(string nombre)  
    {  
        Nombre = nombre;  
    }  
  
    public override string ToString()  
    {  
        return Nombre;  
    }  
}  
  
  
// Clase para simular la Atraccion y la asignacion de Asientos  
public class Atraccion  
{  
    private Queue<Persona> colaEspera;  
    private List<Asiento> asientos;  
    private int numeroAsientos;  
  
    public Atraccion(int capacidad)  
    {  
        numeroAsientos = capacidad;  
        colaEspera = new Queue<Persona>();  
        asientos = new List<Asiento>();  
  
        // Inicializar los asientos  
        for (int i = 1; i <= numeroAsientos; i++)  
        {  
            asientos.Add(new Asiento(i));  
        }  
    }  
  
    // Agregar una persona a la cola de espera  
    public void AgregarPersona(Persona persona)  
    {  
        colaEspera.Enqueue(persona);  
        Console.WriteLine($"{persona.Nombre} se ha unido a la cola de espera.");  
    }  
  
    // Asignar asientos a las personas en la cola  
    public void AsignarAsientos()  
    {  
        while (colaEspera.Count > 0 && HayAsientosDisponibles())  
        {  
            Persona persona = colaEspera.Dequeue();  
            Asiento asientoAsignado = AsignarPrimerAsientoDisponible();  
  
            if (asientoAsignado != null)  
            {  
                asientoAsignado.Ocupado = true;  
                Console.WriteLine($"¡{persona.Nombre} ha sido asignado al asiento #{asientoAsignado.Numero}!");  
            }  
            else  
            {  
                Console.WriteLine($"No hay asientos disponibles para {persona.Nombre}.");  
                colaEspera.Enqueue(persona); // Regresar a la cola para intento posterior  
                break; // Salir del bucle si no hay más asientos.  Podría implementarse un mecanismo para "volver a intentar"  
            }  
        }  
  
        if (colaEspera.Count == 0)  
        {  
            Console.WriteLine("Todos en la cola han sido asignados a un asiento.");  
        }  
        else  
        {  
            Console.WriteLine($"Ya no hay asientos disponibles.  {colaEspera.Count} personas permanecen en la cola.");  
        }  
  
        MostrarEstadoAsientos();  
    }  
  
  
    private Asiento AsignarPrimerAsientoDisponible()  
    {  
        foreach (var asiento in asientos)  
        {  
            if (!asiento.Ocupado)  
            {  
                return asiento;  
            }  
        }  
        return null;  
    }  
  
    private bool HayAsientosDisponibles()  
    {  
        foreach (var asiento in asientos)  
        {  
            if (!asiento.Ocupado)  
            {  
                return true;  
            }  
        }  
        return false;  
    }  
  
    // Mostrar el estado de los asientos  
    public void MostrarEstadoAsientos()  
    {  
        Console.WriteLine("\nEstado de los Asientos:");  
        foreach (var asiento in asientos)  
        {  
            Console.WriteLine(asiento.ToString());  
        }  
    }  
  
}  
  
// Clase principal para ejecutar la simulación  
public class Program  
{  
    public static void Main(string[] args)  
    {  
        // Crear una atraccion con 30 asientos  
        Atraccion atraccion = new Atraccion(30);  
  
        // Agregar personas a la cola de espera  
        atraccion.AgregarPersona(new Persona("Ana"));  
        atraccion.AgregarPersona(new Persona("Juan"));  
        atraccion.AgregarPersona(new Persona("Maria"));  
        atraccion.AgregarPersona(new Persona("Pedro"));  
        atraccion.AgregarPersona(new Persona("Sofia"));  
        atraccion.AgregarPersona(new Persona("Carlos"));  
        atraccion.AgregarPersona(new Persona("Lucia"));  
        atraccion.AgregarPersona(new Persona("David"));  
        atraccion.AgregarPersona(new Persona("Elena"));  
        atraccion.AgregarPersona(new Persona("Javier"));  
        atraccion.AgregarPersona(new Persona("Isabel"));  
        atraccion.AgregarPersona(new Persona("Miguel"));  
        atraccion.AgregarPersona(new Persona("Carmen"));  
        atraccion.AgregarPersona(new Persona("Daniel"));  
        atraccion.AgregarPersona(new Persona("Paula"));  
        atraccion.AgregarPersona(new Persona("Sergio"));  
        atraccion.AgregarPersona(new Persona("Raquel"));  
        atraccion.AgregarPersona(new Persona("Alberto"));  
        atraccion.AgregarPersona(new Persona("Sara"));  
        atraccion.AgregarPersona(new Persona("Oscar"));  
        atraccion.AgregarPersona(new Persona("Valeria"));  
        atraccion.AgregarPersona(new Persona("Adrian"));  
        atraccion.AgregarPersona(new Persona("Natalia"));  
        atraccion.AgregarPersona(new Persona("Hector"));  
        atraccion.AgregarPersona(new Persona("Andrea"));  
        atraccion.AgregarPersona(new Persona("Ricardo"));  
        atraccion.AgregarPersona(new Persona("Carolina"));  
        atraccion.AgregarPersona(new Persona("Guillermo"));  
        atraccion.AgregarPersona(new Persona("Patricia"));  
        atraccion.AgregarPersona(new Persona("Jorge"));  
        atraccion.AgregarPersona(new Persona("Daniela"));  
  
  
        // Asignar los asientos  
        atraccion.AsignarAsientos();  
  
        Console.ReadKey();  
    }  
}  