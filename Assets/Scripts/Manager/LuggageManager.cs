using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuggageManager : MonoBehaviour
{
    List<GameObject> prefab_Luggage;
    public int size_PrefabLuggage;
    List<GameObject> prefab_Power;
    public int size_PrefabPower;
    Transform transform_LuggageSpawnPoint;
    List<GameObject> list_Luggage;

    int itemIndexSpawn = 0;
    int luggageType = 0;
    float spawnTimer = 0f;
    public float delayTime = 0f;

    private void Start(){
        prefab_Luggage = GameManager.Instance.prefab_Luggage;
        prefab_Power = GameManager.Instance.prefab_Power;
        transform_LuggageSpawnPoint = GameManager.Instance.go_LuggageSpawnPoint.transform;
        delayTime = GameManager.Instance.timer_SpawnDelay;
        size_PrefabLuggage = prefab_Luggage.Count;
        size_PrefabPower = prefab_Power.Count;
    }

    private void FixedUpdate(){
        if(Time.time < spawnTimer){
            return;
        }

        luggageType = Random.Range(0,100);
        if(luggageType >= 0 && luggageType <= 80){
            itemIndexSpawn = Random.Range(0,size_PrefabLuggage);
            Instantiate(prefab_Luggage[itemIndexSpawn],transform_LuggageSpawnPoint.position,Quaternion.identity);
        }else if(luggageType >= 81 && luggageType < 100){
            itemIndexSpawn = Random.Range(0,size_PrefabPower);
            Instantiate(prefab_Power[itemIndexSpawn],transform_LuggageSpawnPoint.position,Quaternion.identity);
        }    
        spawnTimer = Time.time + delayTime;
    }
}
