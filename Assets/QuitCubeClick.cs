using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitCubeClick : MonoBehaviour
{
    public PlayerMovement3D playerMovement3D;
    public InputHandler3D inputHandler;

    private Vector3 offset;
    private Vector2 moveVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ReadWrite.WriteAttribute("clickedObject", "false");
    }
    
    IEnumerator moveCoroutine()
    {
        inputHandler.DisableAllInputs();
        ReadWrite.WriteAttribute("clickedObject", "true");
        Debug.Log("clicked on the play cube1");
        while (Vector3.Distance(
               new Vector3(playerMovement3D.transform.position.x, 0, playerMovement3D.transform.position.z),
               new Vector3(transform.position.x, 0, transform.position.z)
           ) > 0.05f)
        {
            Debug.Log("clicked on the play cube2");
            offset = new Vector3(transform.position.x - playerMovement3D.transform.position.x, 0, transform.position.z - playerMovement3D.transform.position.z);
            moveVector = new Vector2(offset.x, offset.z);
            playerMovement3D.Move(moveVector);
            yield return new WaitForSeconds(0.01f);
        }
        if (Vector3.Distance(
               new Vector3(playerMovement3D.transform.position.x, 0, playerMovement3D.transform.position.z),
               new Vector3(transform.position.x, 0, transform.position.z)
           ) < 0.05f)
        {
            playerMovement3D.Jump();
            StartCoroutine(forceJump());
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("clicked on the play cube");


        if (ReadWrite.CheckAttribute("clickedObject") == false)
        {
            StartCoroutine(moveCoroutine());
        }
    }

IEnumerator forceJump(float duration = 0.2f)
{
    Vector3 startPos = playerMovement3D.transform.position;
    Vector3 peakPos = new Vector3(startPos.x, 8.5f, startPos.z);

    float elapsed = 0f;

    // Rise
    while (elapsed < duration)
    {
        playerMovement3D.transform.position = Vector3.Lerp(startPos, peakPos, elapsed / duration);
        elapsed += Time.deltaTime;
        yield return null;
    }

    // Ensure exact peak position
    playerMovement3D.transform.position = peakPos;

    elapsed = 0f;

    // Fall
    while (elapsed < duration)
    {
        playerMovement3D.transform.position = Vector3.Lerp(peakPos, startPos, elapsed / duration);
        elapsed += Time.deltaTime;
        yield return null;
    }

    // Ensure exact final position
    playerMovement3D.transform.position = startPos;
    Application.Quit();
}


    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == transform)
            {
                Debug.Log("Mouse is hovering over " + gameObject.name);
            }
        }
    }
}
