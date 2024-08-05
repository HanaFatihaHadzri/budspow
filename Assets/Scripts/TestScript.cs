using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    BoxCollider2D col;
    public int bud_ID;
    public float activeDuration = 1f;
    public float activeTime = 0f;

    private void Awake(){
        col = this.GetComponent<BoxCollider2D>();
        col.enabled = false;
    }

    private void Update() {
        if(Time.time > activeTime){
            col.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Luggage"){
            other.gameObject.GetComponent<LuggageScript>().Pushed();
        }
        if(other.gameObject.tag == "Power"){
            other.gameObject.GetComponent<PowerScript>().Collect(bud_ID);
        }
    }

    public void EnabledTrigger(){
        activeTime = Time.time + activeDuration;
        col.enabled = true;
    }
}
