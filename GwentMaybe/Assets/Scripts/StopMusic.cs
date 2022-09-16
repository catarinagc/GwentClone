using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    public GameObject stopScreen;
    public GameObject startScreen;

    public void changeMusic(){
        stopScreen.GetComponent<AudioSource>().mute =true;
        startScreen.GetComponent<AudioSource>().mute = false;
    }
}
