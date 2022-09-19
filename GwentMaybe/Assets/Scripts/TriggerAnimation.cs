using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] private Animator pointSet;
    [SerializeField] private string name = "blue_anim";

    public void OnTriggerStart(){
        pointSet.Play(name, 0, 0.0f);
    }
}
