namespace JewelCollectorGame;

public class Obstacle : ICell
{
    public int x{get;set;}
    public int y{get;set;}
    public string objRepresentation{get; set;}
    public bool blockMovement{get; set;}
    public Obstacle(int X, int Y, string type){
        x = X;
        y = Y;
        objRepresentation = type;
        blockMovement = true;
    }

}
