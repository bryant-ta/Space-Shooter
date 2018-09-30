using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Camera follows player exactly. Essentially the same as being a child

public class CameraController : MonoBehaviour {
    
    public GameObject player;

    //Update camera position to player position every frame. LateUpdate() to move camera after all actions are done for that frame.
    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }
        else
        {
            //Get player position, using camera's current z position instead of player's. Was putting camera in player before.
            Vector3 playerLoc = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

            //Set camera position to player position
            transform.position = playerLoc;
        }
    }
}
