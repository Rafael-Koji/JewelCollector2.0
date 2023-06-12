namespace JewelCollectorGame;

public static class JewelCollector {

     delegate void MoveRobot(string direction);
     delegate void GetAdj();
     delegate void UpdateMap();
     delegate void Scoreboard();

     static event MoveRobot OnRobotMove;
     static event GetAdj OnGetAdj;
     static event UpdateMap OnMapChange;
     static event Scoreboard OnPlayerStatus;

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

