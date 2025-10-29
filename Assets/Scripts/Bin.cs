using UnityEngine;

public class Bin : MonoBehaviour
{
    public Animator myAnimator;
    public LevelProgress myProgress;
    public ProgressBar myProgressBar;
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

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if(collision.CompareTag(tagTocheck))
        {
            collision.gameObject.SetActive(false);
            SetCompleted();
        }
    }

    public void SetCompleted()
    {
        isCompleted = true;
        myProgress.IncreaseProgress();
        myAnimator.SetTrigger("isComplete");
        myProgressBar.SetProgressImage(tagTocheck);
    }

    public bool GetCompleted()
    {
        return isCompleted;
    }
}
