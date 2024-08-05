using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBadExitScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Luggage"){
            Destroy(col.gameObject);
            print("Deleted");
        }
    }
}
