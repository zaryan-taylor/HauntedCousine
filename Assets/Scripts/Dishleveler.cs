using UnityEngine;
using System.Collections;
public class Dishleveler : MonoBehaviour
{
    public static ScoreManager Instance;
    public GameObject cookie;
    public GameObject chicken;
    public GameObject caviar;


    
    

    private void Start()
    {
       
    }

    
    public void SwapToChicken()
    {
        if (ScoreManager.Instance.score >= 25)
        {
            // Remove 25 score
            ScoreManager.Instance.score -= 25;

            // Spawn chicken
            Instantiate(
                 chicken,
                 transform.position,
                 Quaternion.identity
             );
            Debug.Log("new object");
            Destroy(cookie);
        
            Debug.Log("Upgraded to Chicken!");

            
        }
        else
        {
            Debug.Log($"Not enough score, need { 25 - ScoreManager.Instance.score}");
        }
    }




}
