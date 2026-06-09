using UnityEngine;
using System.Collections;
public class Dishleveler : MonoBehaviour
{
    public static ScoreManager Instance;
    public GameObject cookie;
    public GameObject chicken;
    public GameObject caviar;


    [Header("Click Effect")]
    public float shrinkScale = 0.8f;   // 80% of original size
    public float shrinkDuration = 0.1f;
    private Vector3 originalScale;


    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnMouseDown()
    {

        ScoreManager.Instance.AddScore(1);
        StartCoroutine(ClickEffect());
        
        if (ScoreManager.Instance.score == 25)
        {
            Instantiate(
                caviar,
                transform.position,
                transform.rotation
            );
            Destroy(gameObject);
        }
    }
        private IEnumerator ClickEffect()
    {
        transform.localScale = originalScale * shrinkScale;

        yield return new WaitForSeconds(shrinkDuration);

        transform.localScale = originalScale;
    }
    public void SwapToChicken()
    {
        if (ScoreManager.Instance.score >= 10)
        {
            // Remove 25 score
            ScoreManager.Instance.score -= 10;

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
