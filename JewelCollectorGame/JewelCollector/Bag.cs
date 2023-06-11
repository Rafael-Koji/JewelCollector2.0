namespace JewelCollectorGame;

public class Bag
{
    private int score;
    private int numJewels;
    List<Jewel> jewels = new List<Jewel>();
    public void InsertInBag(Jewel jewel){
        jewels.Add(jewel);
    }
    private void CountScore(){
        score = 0;
        foreach(Jewel j in jewels){
            switch(j.objRepresentation){
                case "JR":
                    score += 100;
                    break;
                case "JG":
                    score += 50;
                    break;
                case "JB":
                    score += 10;
                    break;
            }            
        }
    }
    public int GetScore(){
        CountScore();
        return score;
    }
    private void CountJewels(){
        numJewels = jewels.Count();
    }
    public int GetTotalJewels(){
        CountJewels();
        return numJewels;
    }
}
