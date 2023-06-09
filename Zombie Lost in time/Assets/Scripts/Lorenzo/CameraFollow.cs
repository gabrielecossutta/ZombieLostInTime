using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // player 
    public Vector3 offset; // distanza che deve mantenere la telecamera dal player
    void Update() //a ogni update la telecamera si spostera per stare dietro ai moviemnti del player 
    {
        transform.position = target.position + offset; 
    }
}
