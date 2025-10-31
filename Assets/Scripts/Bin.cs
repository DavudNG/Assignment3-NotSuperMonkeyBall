using UnityEngine;
using UnityEngine.Events;

/*
    Bin.cs
    Author: David 
    Desc:  Script controls the bin functions such as animation and turning the "ball" objects off.
*/
public class Bin : MonoBehaviour
{
    // references
    public Animator myAnimator; // reference to the animator of the bin
    public UnityEvent progressEvent; // reference to the event to invoke

    public string tagTocheck; // string that represents the name of the tag to pass
    private bool isCompleted = false; // bool to check the completed status
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if(collision.CompareTag(tagTocheck)) // check if the tag is the right one
        {
            collision.gameObject.SetActive(false); // turn the colliding object off
            SetCompleted(); // set the completion status
            progressEvent.Invoke(); // invoke the event to call the increase progress and progress bar functions from other scripts
        }
    }

    // quick function to set complete and send the set the animator param
    public void SetCompleted()
    {
        isCompleted = true;
        myAnimator.SetTrigger("isComplete");
    }

    
    // getter func
    public bool GetCompleted()
    {
        return isCompleted;
    }
}
