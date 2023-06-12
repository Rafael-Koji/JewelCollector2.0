namespace JewelCollectorGame;

/// <summary>
/// Represents a Cell in the JewelCollector game.
/// </summary>
public interface ICell
{   /// <summary>
    /// Represents the x-coordinate of the Cell on the map.
    /// </summary>
    public int x{get;set;}

    /// <summary>
    /// Represents the y-coordinate of the Cell on the map.
    /// </summary>
    public int y{get;set;}

    /// <summary>
    /// Represents the symbol that will represent the Cell on the map.
    /// </summary>
    public string objRepresentation{get;set;}

     /// <summary>
    /// Represents whether the Cell's current position blocks movement.
    /// </summary>
    public bool blockMovement{get;set;}

}
