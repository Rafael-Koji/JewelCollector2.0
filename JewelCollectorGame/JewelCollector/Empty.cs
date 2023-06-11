namespace JewelCollectorGame;

public class Empty:ICell
{
    public int x{get;set;}
    public int y{get;set;}
    public string objRepresentation{get; set;}
    public bool blockMovement{get; set;}
    public Empty(int X, int Y){
        this.x = X;
        this.y = Y;
        objRepresentation = "--";
        blockMovement = false;
    }
}
