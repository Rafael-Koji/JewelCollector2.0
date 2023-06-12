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

          Robot rob = new Robot(0,0);

          OnRobotMove += rob.Move;
          OnGetAdj += rob.GetAdjacent;
          OnPlayerStatus += rob.PrintStatus;
          OnMapChange += Map.PrintMap;

          try{
               for(int level=1; level<=30; level++){
                    Map.CurrentLevel = level;
                    Map.gridSize = level+9;
                    Map.StartMap(rob);     
                    JewelCollector.Run(rob);
                    rob.ResetPosition();
               }
          }catch(GameOverException e){
               Console.WriteLine("Robot ran out of energy!");
               Console.WriteLine("GAME OVER!");
          }catch(QuittingGameException e){
               Console.WriteLine("Closing game.");
          }          
     }

     /// <summary>
     /// Method that runs the main loop of the game.
     /// </summary>
      public static void Run(Robot rob){
          OnMapChange();
          OnPlayerStatus();

          do {        
               Console.WriteLine("Enter the command: ");
               ConsoleKeyInfo command = Console.ReadKey(true);
               try{
                    switch (command.Key.ToString()){
                         case "Q": 
                              Console.WriteLine($"\nQuitting current game.");
                              throw new QuittingGameException();
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
          }
          }while (!Map.LevelComplete()); 
     }
}

