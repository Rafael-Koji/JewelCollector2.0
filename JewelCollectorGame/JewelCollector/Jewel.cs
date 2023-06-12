namespace JewelCollectorGame;

/// <summary>
/// Represents a Jewel in the JewelCollector game.
/// </summary>
public class Jewel:ICell
{
    /// <summary>
    /// Represents the x-coordinate of the Jewel on the map.
    /// </summary>
    public int x{get;set;}

    /// <summary>
    /// Represents the y-coordinate of the Jewel on the map.
    /// </summary>
    public int y{get;set;}

     /// <summary>
    /// Represents the symbol that will represent the Jewel on the map.
    /// </summary>
    public string objRepresentation{get; set;}

    /// <summary>
    /// Represents whether the Jewel's current position blocks movement.
    /// </summary>
    public bool blockMovement{get; set;}

    /// <summary>
    /// Constructs a new instance of the Jewel class.
    /// </summary>
    public Jewel(int X, int Y, string type){
        x = X;
        y = Y;
        objRepresentation = type;
        blockMovement = true;
    }

}
