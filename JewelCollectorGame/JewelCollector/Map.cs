namespace JewelCollectorGame;

static public class Map
{
    static private ICell[,] GameMap = new ICell[10,10];

    static public void StartMap(){
        for(int i=0; i<10; i++){
            for(int j=0; j<10; j++){
            GameMap[i, j] = new Empty(i,j);
            }
        }
    }

    // static public void InsertInMap(IMapObject obj){
    //     GameMap[obj.x, obj.y] = obj;
    // }

    static public void InsertInMap<T>(T obj) where T : ICell{
        GameMap[obj.x, obj.y] = obj;
    }

    static public bool IsBlocked(int X, int Y){
        return GameMap[X,Y].blockMovement;
    }
    static public bool IsTree(int X, int Y){
        if(GameMap[X,Y] is Obstacle){
            return GameMap[X,Y].objRepresentation == "##";
            
        } else {
            //Obstacle obstacle = new Obstacle(-1,-1,GameMap[X,Y].objRepresentation);
           return false; 
        }
    }

    static public bool IsJewel(int X, int Y){
        return GameMap[X,Y] is Jewel;
    }
    static public Jewel GetJewel(int X, int Y){
        Jewel jewel = new Jewel(-1,-1,GameMap[X,Y].objRepresentation);
        DeleteFromMap(X,Y);
        return jewel;
    }
    static public void DeleteFromMap(int X, int Y){
        GameMap[X,Y] = new Empty(X,Y);
    }
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
