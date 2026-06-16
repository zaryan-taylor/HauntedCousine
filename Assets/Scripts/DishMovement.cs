using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DishMovement : MonoBehaviour
{


    public float teleportInterval = 1f;

    [Header("Allowed Area")]
    public float minX = -7f;
    public float maxX = 3f;
    public float minY = -4f;
    public float maxY = 4f;

    [Header("Score")]
    public int score = 0;
    public float shrinkScale = 0.8f;   // 80% of original size
    public float shrinkDuration = 0.1f;
    private Vector3 originalScale;





    private void Start()
    {
        originalScale = transform.localScale;
        StartCoroutine(TeleportRoutine());
    }

    private IEnumerator TeleportRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(teleportInterval);

            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            transform.position = new Vector3(randomX, randomY, transform.position.z);
        }
    }

    private void OnMouseDown()
    {

        ScoreManager.Instance.AddScore(1);
        StartCoroutine(ClickEffect());

    }
    private IEnumerator ClickEffect()
    {
        transform.localScale = originalScale * shrinkScale;

        yield return new WaitForSeconds(shrinkDuration);

        transform.localScale = originalScale;
    }

}
