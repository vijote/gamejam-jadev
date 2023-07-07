using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnLand : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(Player.instance.IsAbleToEvolve());
        }

    }
    

    private void OnDrawGizmos()
    {
        SphereCollider sc = GetComponent<SphereCollider>();
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sc.radius);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
