using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Player reference
    public GameObject player;

    // Offset constant
    private Vector3 offset = new Vector3(-7.12f, 5.8f, -1.88f);


    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        // After the player moves, the camera follows
        this.transform.position = player.transform.position + this.offset;
    }
}
