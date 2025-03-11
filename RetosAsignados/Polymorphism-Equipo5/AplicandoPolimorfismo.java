/*Para aplicar el principio de polimorfismo se debe definir una clase abstracta para un vehiculo
 * con el objetivo de que la clase VehiculoManager no cree instancias de las clases concretas Auto y Bicicleta
 * de modo que permita cambiar el tipo de vehiculo facilmente mediante la clase Vehiculo
*/

// Abstracción
abstract class Vehiculo {
    public abstract void moverse();
}

// Las clases Auto y Bicicleta son un tipo de vehiculo
class Auto extends Vehiculo{
    @Override
    public void moverse() {
        System.out.println("El auto se mueve sobre ruedas.");
    }
}

class Bicicleta extends Vehiculo{
    @Override
    public void moverse() {
        System.out.println("La bicicleta se mueve con pedales.");
    }
}

// Ahora esta clase dependerá de TipoVehiculo y utilizará su método abstracto
class VehiculoManager {

    Vehiculo vehiculo;

    public VehiculoManager(Vehiculo vehiculo){
        this.vehiculo = vehiculo;
    }

    public void iniciarMovimiento(){
        vehiculo.moverse();
    }
}

// Clase principal con método principal
public class AplicandoPolimorfismo {
    public static void main(String[] args) {

        VehiculoManager autoManager = new VehiculoManager(new Auto());
        autoManager.iniciarMovimiento();

        VehiculoManager bicicletaManager = new VehiculoManager(new Bicicleta());
        bicicletaManager.iniciarMovimiento(); 
    }
}
