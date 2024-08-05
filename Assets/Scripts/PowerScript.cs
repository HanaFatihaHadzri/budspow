using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    public int power_ID = 0;
    public Vector3 direction = new Vector3(-1,0,0);
    public float speed = 1f;

    private void Start(){
        speed = GameManager.Instance.speed_Conveyor;
    }

    private void FixedUpdate(){
        transform.position += direction * speed * Time.fixedDeltaTime;
    }

    public void Collect(int bud_ID){
        if(power_ID != bud_ID){
            return;
        }

        AudioManager.Instance.PlayClip(GameManager.Instance.audioClip_Push);
        switch(bud_ID){
            case 0:
            GameManager.Instance.point_AMultiplier += 0.1f;
            break;
            case 1:
            GameManager.Instance.point_BMultiplier += 0.1f;
            break;
            case 2:
            GameManager.Instance.point_CMultiplier += 0.1f;
            break;
            case 3:
            GameManager.Instance.point_DMultiplier += 0.1f;
            break;
            default:
            break;
        }

        Destroy(gameObject);
    }
}
