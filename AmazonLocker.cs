using System;
using System.Collections.Generic;

class AmazonLocker{
    List<Grid> Grids;
    LockerSelectoer lockerSelectoer;
    
    LockerTicket inputBox(Box box){
        var grid = lockerSelectoer.GetGrid(Grids, box);
        if (grid == null){
            return null;
        }
        return generateTicket(grid, box);
    }

    LockerTicket generateTicket(Grid grid, Box box){
        var ticket = new LockerTicket();
        return ticket;
    }

    
}

class Grid{
    public Size size;
    public bool occupied;
    public bool isFitted(Box box){
        return (int)box.size < (int) size;
    }

    public void open(){

    }

    public bool use(){
        if (!occupied){
            occupied = true;
            return true;
        }
        return false;
    }
}

class LockerTicket{
    public DateTime timeStamp;
    public string TrackingNumber;
    public Grid grid;
    public string code;
}

class Box{
    public Size size;
    public string TrackingNumber{get;set;}
    public DateTime date;
    public float weight;
    public Box(Size sz, string tn){
        size = sz;
        TrackingNumber = tn;
    }

}

enum Size{
    small=0,
    medium=1,
    large=2
}
interface LockerSelectoer{
    Grid GetGrid(List<Grid> grids, Box box);
}