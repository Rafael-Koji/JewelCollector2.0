namespace JewelCollectorGame;

public interface ICell
{
    public int x{get;set;}
    public int y{get;set;}
    public string objRepresentation{get;set;}
    public bool blockMovement{get;set;}

}
