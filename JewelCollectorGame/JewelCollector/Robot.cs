namespace JewelCollectorGame;

public class Robot:ICell
{
    static Bag robotBag = new Bag();
    public int x{get;set;}
    public int y{get;set;}
    public string objRepresentation{get; set;}
    public bool blockMovement{get; set;}
    public int Energy {get; set; } = 5; 
    
    public Robot(int X, int Y){
        x = X;
        y = Y;
        objRepresentation = "ME";
        blockMovement = true;
        energy = 5;
    }

    public void Move(string direction){

        if (Energy <= 0 ){
            throw new Exception("Game over"); 
        }
        switch (direction){
            case "a":
                if(y-1<0) break;
                if (!Map.IsBlocked(x, y-1)){
                    Map.DeleteFromMap(x, y);
                    y = y-1;
                    Map.InsertInMap(this);                    
                }
                Energy--;
                break;
            case "w":
                if(x-1<0) break;
                if (!Map.IsBlocked(x-1, y)){
                    Map.DeleteFromMap(x, y);
                    x = x-1;
                    Map.InsertInMap(this);
                }
                Energy--;
                break;
            case "s":
                if(x+1>=10) break;
                if (!Map.IsBlocked(x+1, y)){
                    Map.DeleteFromMap(x, y);
                    x = x+1;                    
                    Map.InsertInMap(this);
                }
                break;
            case "d":
                if(y+1>=10) break;
                if (!Map.IsBlocked(x, y+1)){
                    Map.DeleteFromMap(x, y);
                    y = y+1;
                    Map.InsertInMap(this);
                }
                Energy--;
                break;
        }

    }

    public void GetAdjacent() {
        if(y-1>=0){
            if (Map.IsJewel(x, y-1)){
                robotBag.InsertInBag(Map.GetJewel(x,y-1));
            } 
        }
        if(x-1>=0){
            if (Map.IsJewel(x-1, y)){
                robotBag.InsertInBag(Map.GetJewel(x-1, y));
            } 
        }
        if(y+1<10){
            if (Map.IsJewel(x, y+1)){
                robotBag.InsertInBag(Map.GetJewel(x, y+1));
            } 
        }
        if(x+1<10){
            if (Map.IsJewel(x+1, y)){
                robotBag.InsertInBag(Map.GetJewel(x+1, y));
            } 
        }
    }

    public void PrintStatus(){
        int TotalPoints = robotBag.GetScore();
        int ItensBag = robotBag.GetTotalJewels();
        Console.WriteLine($"\nItens Bag: {ItensBag} - Total Points: {TotalPoints} - Energy: {this.energy} - x:{this.x}, y: {this.y}\n\n");
    }

}
