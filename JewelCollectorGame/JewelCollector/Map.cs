namespace JewelCollectorGame;

/// <summary>
/// Represents the Map in the JewelCollector game.
/// </summary>
static public class Map
{   
    /// <summary>
    /// Represents the game map as a 2D array of ICell objects.
    /// </summary>
    static private ICell[,] GameMap = new ICell[10,10];

    /// <summary>
    /// Initializes the game map with empty cells.
    /// </summary>
    static public void StartMap(){
        for(int i=0; i<10; i++){
            for(int j=0; j<10; j++){
            GameMap[i, j] = new Empty(i,j);
            }
        }
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
            //Obstacle obstacle = new Obstacle(-1,-1,GameMap[X,Y].objRepresentation);
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
        for(int i=0; i<10; i++){
            for(int j=0; j<10; j++){
                Console.Write(GameMap[i, j].objRepresentation);
            }
            Console.Write("\n");
        }
    }
}
