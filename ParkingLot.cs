using System;
using System.Collections.Generic;
class ParkingLot{
    public Ticket GetTicket(Lot lot, Vehicle vehicle){
        return new Ticket();
    }
 
}

enum VehicleType{

}

class Vehicle{
    public VehicleType type;
    public int size;
}

class Lot{
    public int size;
    public string ID;
    public bool occupied;
}
class Ticket{
    public string ticketID;
    public string ID;
    
    public DateTime timeStamp;
}

class Level{
    public string levelNumber;
    public List<Lot> lots;

}

interface CollectLot{
    Lot GetLot(List<Level> levels, Vehicle v);
}

