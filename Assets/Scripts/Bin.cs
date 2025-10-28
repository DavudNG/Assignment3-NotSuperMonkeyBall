using UnityEngine;

public class Bin : MonoBehaviour
{
    public string tagTocheck;
    private bool isCompleted = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag(tagTocheck))
        {
            collision.gameObject.SetActive(false);
            SetCompleted();
        }
    }

    public void SetCompleted()
    {
        isCompleted = true;

    }
}
