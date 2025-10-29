using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public UnityEngine.UI.Image trashBin;
    public UnityEngine.UI.Image RecyclingBin;
    public UnityEngine.UI.Image plantBin;

    private Color origColour;
    private Color deactivatedColour;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deactivatedColour = Color.gray;
        origColour = Color.white;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetProgressImage(string imgToTag)
    {
        switch(imgToTag)
            {
            case "TrashBag":
                trashBin.color = origColour;
                break;
            case "Can":
                RecyclingBin.color = origColour;
                break;
            case "Ball":
                plantBin.color = origColour;
                break;
            default:
                break;
            }
    }

    public void Reset()
    {
        trashBin.color = deactivatedColour;
        RecyclingBin.color = deactivatedColour;
        plantBin.color = deactivatedColour;
    }
}   
