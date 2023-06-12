namespace JewelCollectorGame;

/// <summary>
/// Represents the Robot in the JewelCollector game.
/// </summary>
public class Robot:ICell
{
    /// <summary>
    /// Represents the robot's bag of collected items.
    /// </summary>
    static Bag robotBag = new Bag();

    /// <summary>
    /// Represents the x-coordinate of the robot on the map.
    /// </summary
    public int x{get;set;}

    /// <summary>
    /// Represents the y-coordinate of the robot on the map.
    /// </summary>
    public int y{get;set;}

    /// <summary>
    /// Represents the symbol that will represent the robot on the map.
    /// </summary>
    public string objRepresentation{get; set;}

    /// <summary>
    /// Represents whether the robot's current position blocks movement.
    /// </summary>
    public bool blockMovement{get; set;}

    /// <summary>
    /// Represents the robot's energy level.
    /// </summary>
    public int Energy {get; set; } = 5; 

    /// <summary>
    /// Constructs a new instance of the Robot class.
    /// </summary>
    public Robot(int X, int Y){
        x = X;
        y = Y;
        objRepresentation = "ME";
        blockMovement = true;
    }

    /// <summary>
    /// Moves the robot in a specified direction.
    /// </summary>
    public void Move(string direction){

        if (Energy <= 0 ){
            Console.WriteLine($"\nOut of Energy.");
            throw new GameOverException();
             
        }
        switch (direction){
            case "a":
                if(y-1<0){
                    Console.WriteLine($"\nOutOfMapException.");
                    throw new OutOfMapException();
                } 
                if (!Map.IsBlocked(x, y-1)){
                    Map.DeleteFromMap(x, y);
                    y = y-1;
                    Map.InsertInMap(this);    
                    Energy--;                
                }else{
                    Console.WriteLine($"\n OccupiedPositionException:x({x}), y({y})");
                    throw new OccupiedPositionException();
                }
                
                break;
            case "w":
                if(x-1<0){
                    Console.WriteLine($"\nOutOfMapException.");
                    throw new OutOfMapException();
                }
                if (!Map.IsBlocked(x-1, y)){
                    Map.DeleteFromMap(x, y);
                    x = x-1;
                    Map.InsertInMap(this);
                    Energy--;
                }else{
                    Console.WriteLine($"\n OccupiedPositionException:x({x}), y({y})");
                    throw new OccupiedPositionException();
                }
                
                break;
            case "s":
                if(x+1>=Map.gridSize){
                    Console.WriteLine($"\nOutOfMapException.");
                    throw new OutOfMapException();
                }
                if (!Map.IsBlocked(x+1, y)){
                    Map.DeleteFromMap(x, y);
                    x = x+1;                    
                    Map.InsertInMap(this);
                    Energy--;
                }else{
                    Console.WriteLine($"\n OccupiedPositionException:x({x}), y({y})");
                    throw new OccupiedPositionException();
                }
                
                break;
            case "d":
                if(y+1>=Map.gridSize){
                    Console.WriteLine($"\nOutOfMapException.");
                    throw new OutOfMapException();
                }
                if (!Map.IsBlocked(x, y+1)){
                    Map.DeleteFromMap(x, y);
                    y = y+1;
                    Map.InsertInMap(this);
                    Energy--;
                }else{
                    Console.WriteLine($"\n OccupiedPositionException:x({x}), y({y})");
                    throw new OccupiedPositionException();
                }
                
                break;
        }

    }

    /// <summary>
    /// Gets the items adjacent to the robot.
    /// </summary>
    public void GetAdjacent() {
        if(y-1>=0){
            if (Map.IsJewel(x, y-1)){
                var jewel = Map.GetJewel(x,y-1);
                robotBag.InsertInBag(jewel);
                
                if (jewel.objRepresentation == "JB"){
                    Energy += 5;
                }
            }else if (Map.IsTree(x, y-1)){
                Energy += 3;
            }
        }
        if(x-1>=0){
            if (Map.IsJewel(x-1, y)){
                var jewel = Map.GetJewel(x-1, y);
                robotBag.InsertInBag(jewel);
                if (jewel.objRepresentation == "JB"){
                    Energy += 5;
                }
            } else if (Map.IsTree(x-1, y)){
                Energy += 3;
            }
        }
        if(y+1<Map.gridSize){
            if (Map.IsJewel(x, y+1)){
                var jewel = Map.GetJewel(x, y+1);
                robotBag.InsertInBag(jewel);
                //Mudar aqui
                if (jewel.objRepresentation == "JB"){
                    Energy += 5;
                } 
            } else if (Map.IsTree(x, y+1)){
                Energy += 3;
            }
        }
        if(x+1<Map.gridSize){
            if (Map.IsJewel(x+1, y)){
                var jewel = Map.GetJewel(x+1, y);
                robotBag.InsertInBag(jewel);
                if (jewel.objRepresentation == "JB"){
                    Energy += 5;
                }
            } else if (Map.IsTree(x+1, y)){
                Energy += 3;
            }
        }
    
    }

    /// <summary>
    /// Prints the robot's status to the console.
    /// </summary>
    public void PrintStatus(){
        int TotalPoints = robotBag.GetScore();
        int ItensBag = robotBag.GetTotalJewels();
        Console.WriteLine($"\nItens Bag: {ItensBag} - Total Points: {TotalPoints} - Energy: {this.Energy} - x:{this.x}, y: {this.y}\n\n");
    }

    /// <summary>
    /// Reset the robot's position.
    /// </summary>
    public void ResetPosition(){
        this.x = 0;
        this.y = 0;
    }

}
