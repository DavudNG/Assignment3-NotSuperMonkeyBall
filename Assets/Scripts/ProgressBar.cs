using UnityEngine;
using UnityEngine.Events;

/*
    ProgressBar.cs
    Author: David 
    Desc: UI script that changes the icon color of the progress bar's sprites.
*/
public class ProgressBar : MonoBehaviour
{
    // references to the images to change
    public UnityEngine.UI.Image trashBin;
    public UnityEngine.UI.Image RecyclingBin;
    public UnityEngine.UI.Image plantBin;

    // references to the colours to use
    private Color origColour;
    private Color deactivatedColour;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // set the colour references to grey out and recolour the sprites
        deactivatedColour = Color.gray; 
        origColour = Color.white;
        Reset(); // reset to the deactivated colors
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
        SetProgressImage(string imgToTag)   
        Author: David
        Desc: function that takes in a string to determine which image to change colour of to represent progress. 
    */
    public void SetProgressImage(string imgToTag)
    {
        switch(imgToTag) // check the img tag and set the colour of the corresponding image
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
        //return null;
    }

    /*
    Reset()   
    Author: David
    Desc: function that resets the color of the progress bar to deactivated. 
    */
    public void Reset()
    {
        trashBin.color = deactivatedColour;
        RecyclingBin.color = deactivatedColour;
        plantBin.color = deactivatedColour;
    }
}   
