public class ParkingLotSystem {

    //Add a car to the lot.
    //Remove a car from the lot.
    //Get the current list of all parked cars.
    //Check if the lot is full or not.

    int maxCapacity;
    Dictionary<int, string> slotCar;
    public ParkingLotSystem(int maxCapacity) {
        this.maxCapacity = maxCapacity;
        slotCar = new Dictionary<int, string>();
    }

    public bool AddCar(int slot, string car) {
        if (slot > maxCapacity || slot < 1) {
            Console.WriteLine("slot number is too big or too small");
            return false;
        }
        if (slotCar.ContainsKey(slot)) {
            Console.WriteLine("The slot is taken");
            return false;
        } else {
            slotCar.Add(slot, car);
            return true;
        }
    }

    public bool RemoveCar(int slot) {
        if (slotCar.ContainsKey(slot)) {
            slotCar.Remove(slot);
            return true;
        } else {
            Console.WriteLine("There is no car in this slot");
            return false;
        }
    }

    public List<string> GetCars() {
        if (slotCar.Count > 0) {
            return slotCar.Values;
        }
        return new List<string>();
    }

    public bool isFull() {
        return maxCapacity == slotCar.Count;
    }
}