using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuggageScript : MonoBehaviour
{
    public Vector3 direction = new Vector3(-1,0,0);
    public float speed = 1f;
    public int luggagegate_ID = 0;

    private void Start(){
        speed = GameManager.Instance.speed_Conveyor;
    }

    private void FixedUpdate(){
        transform.position += direction * speed * Time.fixedDeltaTime;
    }

    public void Pushed(){
        AudioManager.Instance.PlayClip(GameManager.Instance.audioClip_Push);
        direction = new Vector3(0, 1f, 0);
    }

}
