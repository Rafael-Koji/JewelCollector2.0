namespace JewelCollectorGame;

/// <summary>
/// Represents a Bag in the JewelCollector game. This is used to store collected Jewels.
/// </summary>
public class Bag
{
    /// <summary>
    /// Represents the score based on the jewels collected.
    /// </summary>
    private int score;

    /// <summary>
    /// Represents the number of jewels in the bag.
    /// </summary>
    private int numJewels;

    /// <summary>
    /// List of jewels in the bag.
    /// </summary>
    List<Jewel> jewels = new List<Jewel>();

    /// <summary>
    /// Inserts a jewel in the bag.
    /// </summary>
    public void InsertInBag(Jewel jewel){
        jewels.Add(jewel);
    }

     /// <summary>
    /// Counts the score based on the jewels in the bag.
    /// </summary>
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

    /// <summary>
    /// Returns the total score based on the jewels in the bag.
    /// </summary>
    public int GetScore(){
        CountScore();
        return score;
    }

    /// <summary>
    /// Counts the total number of jewels in the bag.
    /// </summary>
    private void CountJewels(){
        numJewels = jewels.Count();
    }

    /// <summary>
    /// Returns the total number of jewels in the bag.
    /// </summary>
    public int GetTotalJewels(){
        CountJewels();
        return numJewels;
    }
}
