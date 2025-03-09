/*Para aplicar el principio de polimorfismo se debe definir una clase abstracta para un Tipo de Vehiculo
 * con el objetivo de que la clase VehiculoManager no cree instancias de las clases concretas Auto y Bicicleta
 * me modo que permita cambiar el tipo de vehiculo facilmente mediante TipoVehiculo
*/

// Abstracción
abstract class TipoVehiculo {
    public abstract void moverse();
}

// Las clases Auto y Bicicleta son un tipo de vehiculo
class Auto extends TipoVehiculo{
    @Override
    public void moverse() {
        System.out.println("El auto se mueve sobre ruedas.");
    }
}

class Bicicleta extends TipoVehiculo{
    @Override
    public void moverse() {
        System.out.println("La bicicleta se mueve con pedales.");
    }
}

// Ahora esta clase dependerá de TipoVehiculo y utilizará su método abstracto
class VehiculoManager {

    TipoVehiculo tipoVehiculo;

    public VehiculoManager(TipoVehiculo tipoVehiculo){
        this.tipoVehiculo = tipoVehiculo;
    }

    public void iniciarMovimiento(){
        tipoVehiculo.moverse();
    }
}

// Clase con método principal
public class Program {
    public static void main(String[] args) {

        VehiculoManager autoManager = new VehiculoManager(new Auto());
        autoManager.iniciarMovimiento();

        VehiculoManager bicicletaManager = new VehiculoManager(new Bicicleta());
        bicicletaManager.iniciarMovimiento(); 
    }
}
