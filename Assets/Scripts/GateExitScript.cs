using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateExitScript : MonoBehaviour
{
    public int gate_ID;
    float point_Multiplier = 1f;
    LuggageScript script_Luggage;

    private void Start(){
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Luggage"){
            
            if(gate_ID == 0){
                CheckLuggageExit(0);
                Destroy(col.gameObject);
                return;
            }

            CheckLuggageExit(col.gameObject.GetComponent<LuggageScript>().luggagegate_ID);
            Destroy(col.gameObject);
        }

        if(col.gameObject.tag == "Power"){
            Destroy(col.gameObject);
        }
    }

    void CheckLuggageExit(int luggagegate_ID){
        // Missed
        if(gate_ID == 0){
            GameManager.Instance.point_TotalBadLuggageSent++;
            GameManager.Instance.SubtractPoint(GameManager.Instance.point_BadExit);
            UIManager.Instance.AddValue(-1);
            return;
        }
        // Wrong Gate
        if (gate_ID != luggagegate_ID){
            GameManager.Instance.point_TotalBadLuggageSent++;
            GameManager.Instance.SubtractPoint(GameManager.Instance.point_BadExit);
            UIManager.Instance.AddValue(-5);
            return;
        }
        // Correct Gate
        GameManager.Instance.point_TotalLuggageSent++;
        GetMultiplier();
        GameManager.Instance.AddPoint(GameManager.Instance.point_GoodExit * point_Multiplier);
        UIManager.Instance.AddValue(1);
    }

    void GetMultiplier(){
        // Bad coding
        switch(gate_ID){
            case 0:
            point_Multiplier = 1f;
            break;
            case 1:
            point_Multiplier = GameManager.Instance.point_AMultiplier;
            break;
            case 2:
            point_Multiplier = GameManager.Instance.point_BMultiplier;
            break;
            case 3:
            point_Multiplier = GameManager.Instance.point_CMultiplier;
            break;
            case 4:
            point_Multiplier = GameManager.Instance.point_DMultiplier;
            break;
            default:
            break;
        }
    }
}
