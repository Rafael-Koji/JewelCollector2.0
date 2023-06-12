namespace JewelCollectorGame;

static public class Map
{
    static private ICell[,] GameMap;
    static public int gridSize{get;set;}
    static public int CurrentLevel{get; set;}

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
    }

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
        for(int i=0; i<gridSize; i++){
            for(int j=0; j<gridSize; j++){
                Console.Write(GameMap[i, j].objRepresentation);
            }
            Console.Write("\n");
        }
    }

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
