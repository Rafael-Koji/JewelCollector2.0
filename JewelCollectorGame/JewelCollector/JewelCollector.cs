namespace JewelCollectorGame;

public class JewelCollector {

    delegate void MoveRobot(string direction);
    delegate void GetAdj();
    delegate void UpdateMap();

    static event MoveRobot OnRobotMove;
    static event GetAdj OnGetAdj;
    static event UpdateMap OnMapChange;

    public static void Main() {
  
        bool running = true;
        Map.StartMap();
        Robot rob = new Robot(0,0);
        
        // Insert objects in map
        Map.InsertInMap(rob);
        Map.InsertInMap(new Jewel(1,9, "JR"));
        Map.InsertInMap(new Jewel(8,8, "JR"));
        Map.InsertInMap(new Jewel(9,1, "JG"));
        Map.InsertInMap(new Jewel(7,6, "JG"));
        Map.InsertInMap(new Jewel(3,4, "JB"));
        Map.InsertInMap(new Jewel(2,1, "JB"));
        Map.InsertInMap(new Obstacle(5,0, "##"));
        Map.InsertInMap(new Obstacle(5,1, "##"));
        Map.InsertInMap(new Obstacle(5,2, "##"));
        Map.InsertInMap(new Obstacle(5,3, "##"));
        Map.InsertInMap(new Obstacle(5,4, "##"));
        Map.InsertInMap(new Obstacle(5,5, "##"));
        Map.InsertInMap(new Obstacle(5,6, "##"));
        Map.InsertInMap(new Obstacle(5,9, "$$"));
        Map.InsertInMap(new Obstacle(3,9, "$$"));
        Map.InsertInMap(new Obstacle(5,9, "$$"));
        Map.InsertInMap(new Obstacle(8,3, "$$"));
        Map.InsertInMap(new Obstacle(2,5, "$$"));

        OnRobotMove += rob.Move;
        OnGetAdj += rob.GetAdjacent;
        OnMapChange += Map.PrintMap;

        do {
            OnMapChange();
            
            Console.WriteLine("Enter the command: ");
            ConsoleKeyInfo command = Console.ReadKey(true);
            switch (command.Key.ToString()){
               case "Q": 
                    running = false;
                    break;
               case "W":
                    OnRobotMove(command.Key.ToString().ToLower());
                    break;
                case "A":
                    OnRobotMove(command.Key.ToString().ToLower());
                    break;               
               case "S":
                    OnRobotMove(command.Key.ToString().ToLower());
                    break;               
               case "D":
                    OnRobotMove(command.Key.ToString().ToLower());
                    break;               
               case "G":
                    OnGetAdj();
                    break;
            }    
            
        } while (running);
  }
}

