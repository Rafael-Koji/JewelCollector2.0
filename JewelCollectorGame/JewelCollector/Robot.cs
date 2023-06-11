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
    }

    public void Move(string direction){

        if (Energy <= 0 ){
            Console.WriteLine($"\nOut of Energy.");
            throw new GameOverException();
             
        }
        switch (direction){
            case "a":
                if(y-1<0){
                    Console.WriteLine($"\nOutOfMapException.");
                    throw new OutOfMapException();
                } 
                if (!Map.IsBlocked(x, y-1)){
                    Map.DeleteFromMap(x, y);
                    y = y-1;
                    Map.InsertInMap(this);    
                    Energy--;                
                }else{
                    Console.WriteLine($"\n OccupiedPositionException:x({x}), y({y})");
                    throw new OccupiedPositionException();
                }
                
                break;
            case "w":
                if(x-1<0){
                    Console.WriteLine($"\nOutOfMapException.");
                    throw new OutOfMapException();
                }
                if (!Map.IsBlocked(x-1, y)){
                    Map.DeleteFromMap(x, y);
                    x = x-1;
                    Map.InsertInMap(this);
                    Energy--;
                }else{
                    Console.WriteLine($"\n OccupiedPositionException:x({x}), y({y})");
                    throw new OccupiedPositionException();
                }
                
                break;
            case "s":
                if(x+1>=10){
                    Console.WriteLine($"\nOutOfMapException.");
                    throw new OutOfMapException();
                }
                if (!Map.IsBlocked(x+1, y)){
                    Map.DeleteFromMap(x, y);
                    x = x+1;                    
                    Map.InsertInMap(this);
                    Energy--;
                }else{
                    Console.WriteLine($"\n OccupiedPositionException:x({x}), y({y})");
                    throw new OccupiedPositionException();
                }
                
                break;
            case "d":
                if(y+1>=10){
                    Console.WriteLine($"\nOutOfMapException.");
                    throw new OutOfMapException();
                }
                if (!Map.IsBlocked(x, y+1)){
                    Map.DeleteFromMap(x, y);
                    y = y+1;
                    Map.InsertInMap(this);
                    Energy--;
                }else{
                    Console.WriteLine($"\n OccupiedPositionException:x({x}), y({y})");
                    throw new OccupiedPositionException();
                }
                
                break;
        }

    }

    public void GetAdjacent() {
        if(y-1>=0){
            if (Map.IsJewel(x, y-1)){
                var jewel = Map.GetJewel(x,y-1);
                robotBag.InsertInBag(jewel);
                
                if (jewel.objRepresentation == "JB"){
                    Energy += 5;
                }
            }else if (Map.IsTree(x, y-1)){
                Energy += 3;
            }
        }
        if(x-1>=0){
            if (Map.IsJewel(x-1, y)){
                var jewel = Map.GetJewel(x-1, y);
                robotBag.InsertInBag(jewel);
                if (jewel.objRepresentation == "JB"){
                    Energy += 5;
                }
            } else if (Map.IsTree(x-1, y)){
                Energy += 3;
            }
        }
        if(y+1<10){
            if (Map.IsJewel(x, y+1)){
                var jewel = Map.GetJewel(x, y+1);
                robotBag.InsertInBag(jewel);
                //Mudar aqui
                if (jewel.objRepresentation == "JB"){
                    Energy += 5;
                } 
            } else if (Map.IsTree(x, y+1)){
                Energy += 3;
            }
        }
        if(x+1<10){
            if (Map.IsJewel(x+1, y)){
                var jewel = Map.GetJewel(x+1, y);
                robotBag.InsertInBag(jewel);
                if (jewel.objRepresentation == "JB"){
                    Energy += 5;
                }
            } else if (Map.IsTree(x+1, y)){
                Energy += 3;
            }
        }
    
    }

    public void PrintStatus(){
        int TotalPoints = robotBag.GetScore();
        int ItensBag = robotBag.GetTotalJewels();
        Console.WriteLine($"\nItens Bag: {ItensBag} - Total Points: {TotalPoints} - Energy: {this.Energy} - x:{this.x}, y: {this.y}\n\n");
    }

}
