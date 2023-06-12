namespace JewelCollectorGame;


/// <summary>
/// Represents an Obstacle in the JewelCollector game.
/// </summary>
public class Obstacle : ICell
{   
    /// <summary>
    /// Represents the x-coordinate of the Obstacle on the map.
    /// </summary>
    public int x{get;set;}

    /// <summary>
    /// Represents the y-coordinate of the Obstacle on the map.
    /// </summary>
    public int y{get;set;}

    /// <summary>
    /// Represents the symbol that will represent the Obstacle on the map.
    /// </summary>
    public string objRepresentation{get; set;}

    /// <summary>
    /// Represents whether the Obstacle's current position blocks movement.
    /// </summary>
    public bool blockMovement{get; set;}

     /// <summary>
    /// Constructs a new instance of the Obstacle class.
    /// </summary>
    public Obstacle(int X, int Y, string type){
        x = X;
        y = Y;
        objRepresentation = type;
        blockMovement = true;
    }

}
