namespace JewelCollectorGame;

/// <summary>
/// Represents the Map in the JewelCollector game.
/// </summary>
static public class Map
{
     /// <summary>
    /// Represents the game map as a 2D array of ICell objects.
    /// </summary>
    static private ICell[,] GameMap;
    static public int gridSize{get;set;}
    static public int CurrentLevel{get; set;}

    /// <summary>
    /// Initializes the game map with empty cells.
    /// </summary>
    static public void StartMap(Robot rob){
        GameMap = new ICell[gridSize,gridSize];
        for(int i=0; i<gridSize; i++){
            for(int j=0; j<gridSize; j++){
            GameMap[i, j] = new Empty(i,j);
            }
        }
        if(CurrentLevel == 1){
            FixedMap(rob);
        }else{
            RandomMap(rob);
        }
    }
    /// <summary>
    /// Creates the game map with fixed cells.
    /// </summary>
    static private void FixedMap(Robot rob){
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
    }

    /// <summary>
    /// Inserts an object into the game map.
    /// </summary>
    /// <typeparam name="T">The type of object to insert, which implements ICell.</typeparam>
    /// <param name="obj">The object to insert into the map.</param>
    
    static public void InsertInMap<T>(T obj) where T : ICell{
        GameMap[obj.x, obj.y] = obj;
    }

    /// <summary>
    /// Creates the game map with random cells.
    /// </summary>
    static private void RandomMap(Robot rob){
        Random rNum = new Random(1);
        Map.InsertInMap(rob);

        for(int i = 0; i < 3+CurrentLevel; i++){
            int xRandom;
            int yRandom;
            do{
                xRandom = rNum.Next(0, gridSize);
                yRandom = rNum.Next(0, gridSize);
            }while(xRandom == 0 && yRandom == 0);

            Map.InsertInMap(new Jewel(xRandom, yRandom, "JB"));
        }
        for(int i = 0; i < 3+CurrentLevel; i++){
            int xRandom;
            int yRandom;
            do{
                xRandom = rNum.Next(0, gridSize);
                yRandom = rNum.Next(0, gridSize);
            }while(xRandom == 0 && yRandom == 0);
            Map.InsertInMap(new Jewel(xRandom, yRandom, "JG"));
        }
        for(int i = 0; i < 3+CurrentLevel; i++){
            int xRandom;
            int yRandom;
            do{
                xRandom = rNum.Next(0, gridSize);
                yRandom = rNum.Next(0, gridSize);
            }while(xRandom == 0 && yRandom == 0);
            Map.InsertInMap(new Jewel(xRandom, yRandom, "JR"));
        }
        for(int i = 0; i < 10+CurrentLevel; i++){
            int xRandom;
            int yRandom;
            do{
                xRandom = rNum.Next(0, gridSize);
                yRandom = rNum.Next(0, gridSize);
            }while(xRandom == 0 && yRandom == 0);
            Map.InsertInMap(new Obstacle(xRandom, yRandom, "$$"));
        }
        for(int i = 0; i < 10+CurrentLevel; i++){
            int xRandom;
            int yRandom;
            do{
                xRandom = rNum.Next(0, gridSize);
                yRandom = rNum.Next(0, gridSize);
            }while(xRandom == 0 && yRandom == 0);
            Map.InsertInMap(new Obstacle(xRandom, yRandom, "##"));
        }

    /// <summary>
    /// Checks if a cell at a given location is blocked.
    /// </summary>
    /// <returns>true if the cell is blocked, false otherwise.</returns>
    static public bool IsBlocked(int X, int Y){
        return GameMap[X,Y].blockMovement;
    }

    /// <summary>
    /// Checks if a cell at a given location is a tree.
    /// </summary>
    /// <returns>true if the cell is a tree, false otherwise.</returns>
    static public bool IsTree(int X, int Y){
        if(GameMap[X,Y] is Obstacle){
            return GameMap[X,Y].objRepresentation == "##";
            
        } else {
           return false; 
        }
    }

    /// <summary>
    /// Checks if a cell at a given location is a jewel.
    /// </summary>
    /// <returns>true if the cell is a jewel, false otherwise.</returns>
    static public bool IsJewel(int X, int Y){
        return GameMap[X,Y] is Jewel;
    }
    
    /// <summary>
    /// Gets the jewel at a given location and removes it from the map.
    /// </summary>
    /// <returns>The jewel object from the map.</returns>
    static public Jewel GetJewel(int X, int Y){
        Jewel jewel = new Jewel(-1,-1,GameMap[X,Y].objRepresentation);
        DeleteFromMap(X,Y);
        return jewel;
    }

    /// <summary>
    /// Deletes a cell from the map, replacing it with an Empty cell.
    /// </summary>
    static public void DeleteFromMap(int X, int Y){
        GameMap[X,Y] = new Empty(X,Y);
    }

    /// <summary>
    /// Prints the current state of the game map to the console.
    /// </summary>
    static public void PrintMap(){
        Console.Clear();
        for(int i=0; i<gridSize; i++){
            for(int j=0; j<gridSize; j++){
                Console.Write(GameMap[i, j].objRepresentation);
            }
            Console.Write("\n");
        }
    }

    /// <summary>
    /// Verifies if the current level is completed.
    /// </summary>
    static public bool LevelComplete(){
        bool gotAllJewels = true;

        for(int i=0; i<gridSize; i++){
            for(int j=0; j<gridSize; j++){
                if(IsJewel(i,j)){
                    gotAllJewels = false;
                    return gotAllJewels;
                }
            }
        }
        return gotAllJewels;
    }
}
