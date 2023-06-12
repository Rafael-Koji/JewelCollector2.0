namespace JewelCollectorGame;

///<summary>
///The JewelCollector class holds the logic of the game.
///</summary>

public class JewelCollector {

     /// <summary>
     /// Delegate for moving the robot.
     /// </summary>
     /// <param name="direction">The direction in which the robot will move.</param>
     delegate void MoveRobot(string direction);

     /// <summary>
     /// Delegate for getting adjacent objects.
     /// </summary>
     delegate void GetAdj();

     /// <summary>
     /// Delegate for updating the map.
     /// </summary>
     delegate void UpdateMap();

     /// <summary>
     /// Delegate for updating the scoreboard.
     /// </summary>
     delegate void Scoreboard();

     //Events
     static event MoveRobot OnRobotMove;
     static event GetAdj OnGetAdj;
     static event UpdateMap OnMapChange;
     static event Scoreboard OnPlayerStatus;

     /// <summary>
     /// The entry point of the game.
     /// </summary>
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
          OnPlayerStatus += rob.PrintStatus;
          OnMapChange += Map.PrintMap;
          
          OnMapChange();
          OnPlayerStatus();

          do {        
               Console.WriteLine("Enter the command: ");
               ConsoleKeyInfo command = Console.ReadKey(true);
               try{
                    switch (command.Key.ToString()){
                         case "Q": 
                              running = false;
                              break;
                         case "W":
                              OnRobotMove(command.Key.ToString().ToLower());
                              OnMapChange();
                              OnPlayerStatus();
                              break;
                         case "A":
                              OnRobotMove(command.Key.ToString().ToLower());
                              OnMapChange();
                              OnPlayerStatus();
                              break;               
                         case "S":
                              OnRobotMove(command.Key.ToString().ToLower());
                              OnMapChange();
                              OnPlayerStatus();
                              break;               
                         case "D":
                              OnRobotMove(command.Key.ToString().ToLower());
                              OnMapChange();
                              OnPlayerStatus();
                              break;               
                         case "G":
                              OnGetAdj();
                              OnMapChange();
                              OnPlayerStatus();
                              break;
                    }                
               }catch(OutOfMapException e){
                    Console.WriteLine("Impossible to make this move! Out of the bounds of the map!");
               }catch(OccupiedPositionException e){
                    Console.WriteLine("Impossible to make this move! Position already occupied!");
               }catch(GameOverException e){
                    Console.WriteLine("Robot ran out of energy!");
                    Console.WriteLine("GAME OVER!");
                    running = false;
               }
          } while (running);
     }
}

