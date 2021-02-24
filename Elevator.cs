using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Linq;

namespace OOD
{
    class Elevator
    {
        string ID;
        public int floor;

        public int[] floors;
        public Elevator(string id, int levels)
        {
            floors = new int[levels];
            ID = id;
        }
        public Direction direction;
        public void open()
        {

        }

        public void move(int destination)
        {
            floor = destination;
        }

        public bool getRequest(int nextLevel)
        {
            floors[nextLevel] = 1;
            return true;
        }

        public bool stopped()
        {
            return direction == Direction.stop;
        }

        public int lowerNext()
        {
            int currentFloor = floor - 1;
            while (-1 < currentFloor && currentFloor < floors.Length)
            {
                if (floors[currentFloor] == 1)
                {
                    return (currentFloor - floor);
                }
                currentFloor--;
            }
            return currentFloor == -1 ? floor : currentFloor;
        }

        public int higherNext()
        {
            int currentFloor = floor + 1;
            while (-1 < currentFloor && currentFloor < floors.Length)
            {
                if (floors[currentFloor] == 1)
                {
                    return (currentFloor - floor);
                }
                currentFloor--;
            }
            return currentFloor == floors.Length ? floor : currentFloor;
        }

        public int next()
        {
            var nextFloor = floor;
            if (direction == Direction.down)
            {
                nextFloor = lowerNext();
            }
            else
            {
                nextFloor = higherNext();
            }
            return nextFloor;
        }

        public int getDistance(int fl)
        {
            if (direction == Direction.down && fl > floor)
            {
                return fl - lowerNext();
            }
            else if (direction == Direction.up && fl < floor)
            {
                return higherNext() - fl;
            }
            return Math.Abs(fl - floor);
        }

    }

    class Controller
    {
        Queue<Request> q;
        ElevatorCoordinator coordinator;
        public void getRequest(Request r)
        {
            q.Enqueue(r);
        }

        public void handleRequest()
        {
            while (q.Count != 0)
            {
                var request = q.Dequeue();
                if (request.isInternal)
                {

                }
            }

        }
    }
    enum Category
    {
        food = 0,
        beverage = 1
    }

    enum RequestType
    {
        internalRequest = 0,
        externalRequest = 1
    }

    enum Direction
    {
        up = 0,
        down = 1,
        stop = 2
    }

    class Request
    {
        public int floor;
        public bool fromElevator;
        public bool direction;
        public bool isInternal;

    }

    interface ElevatorCoordinator
    {
        public Elevator GetElevator(List<Elevator> elevators, Request request);
    }

    class GreedyCoordinator : ElevatorCoordinator
    {
        public Elevator GetElevator(List<Elevator> elevators, Request request)
        {
            var minFloor = elevators.Min(x => x.floors.Length);
            return elevators.Where(x => x.floors.Length == minFloor).FirstOrDefault();
        }
    }

    class FirstArrivedCoordinator : ElevatorCoordinator
    {
        public Elevator GetElevator(List<Elevator> elevators, Request request)
        {
            Elevator e = null;
            int minDistance = int.MaxValue;
            for (int i = 0; i < elevators.Count; i++){
                int distance = elevators[i].getDistance(request.floor);
                if (minDistance > distance){
                    e = elevators[i];
                }
            }
            return e;
        }
        
    }
}
