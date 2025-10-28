using System.Collections;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveDuration = 2f; // how long it takes to move from 0 to -10
    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        startPos = new Vector3(0f, 30f, transform.position.z);
        endPos = new Vector3(-10f, 10.27f, transform.position.z);
        StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        float elapsed = 0f;

        while (elapsed < moveDuration)
        {
            // Interpolate between start and end positions
            transform.position = Vector3.Lerp(startPos, endPos, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null; // wait until next frame
        }

        // Ensure exact final position
        transform.position = endPos;
    }
}
