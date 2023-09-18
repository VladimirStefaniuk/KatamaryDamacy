using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController player; 
    [SerializeField] private Vector3 offset; 

    void Start()
    {  
        transform.position = player.transform.position + offset;
    }
 
    void LateUpdate()
    {
        //Get the forward vector from the katamari script
        var forwardVector = player.GetForwardVector();

        //Update the position and reposition based on the forward vector
        Vector3 newPos = player.transform.position + Vector3.Scale(offset, forwardVector);

        newPos.y = offset.y;
        transform.position = newPos;

        //Look at the ball
        //Use our position and the offset for the y to create a smoother camera experience
        //Using the katamari's position would cause a lot of jitter with the weird mesh shape
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y - offset.y, player.transform.position.z));
    }
}
