using UnityEngine;
using UnityEngine.PlayerLoop;

public class HiddenBridge : MonoBehaviour
{
    float initialHeight = 0f;

    int movingDir = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the height that the bridge starts at
        initialHeight = this.gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float currentHeight = this.gameObject.transform.position.y;
        
        // When the bridge is 1 unit above its initial height, it should stop moving up
        if (currentHeight >= initialHeight + 1f)
        {
            movingDir = 0;
        }

        // When the bridge is 1 unit below it's initial height, it should stop moving down
        if (currentHeight <= initialHeight - 1f)
        {
            movingDir = 1;
        }

        // Based on the moving direction, move the bridge up or down
        if (movingDir == 1)
        {
            moveUp();
        }
        else
        {
            moveDown();
        }
    }
    
    void moveUp() 
    {
        // Move the bridge up by 1 unit
        this.gameObject.transform.Translate(0f, 0.005f, 0f);
    }

    void moveDown()
    {
        // Move the bridge down by 1 unit
        this.gameObject.transform.Translate(0f, -0.005f, 0f);
    }
}
