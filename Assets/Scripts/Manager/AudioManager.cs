using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    GameObject prefab_AudioSource;
    GameObject audioSourceContainer;
    GameObject go_audiosource;

    private void Awake(){
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this;
        }
    }

    private void Start(){
        prefab_AudioSource = GameManager.Instance.go_AudioSource;
        audioSourceContainer = GameManager.Instance.go_AudioContainer;
    }

    

    public void PlayClip(AudioClip clip){
        go_audiosource = Instantiate(prefab_AudioSource,new Vector3(0,0,0),Quaternion.identity);
        go_audiosource.GetComponent<AudioSource>().clip = clip;
        go_audiosource.GetComponent<AudioSource>().Play();
        Destroy(go_audiosource,clip.length);
    }
}
