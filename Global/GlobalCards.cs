using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCards : MonoBehaviour
{
    public static GlobalCards instance;
    public GameObject cardPrefab;
    public GameObject cardCanvas;
    
    void Awake()
    {
        instance = this;
    }
}
