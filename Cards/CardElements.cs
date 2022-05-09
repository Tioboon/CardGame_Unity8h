using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.UI;

public class CardElements : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI text;
    public TextMeshProUGUI cost;

    public PlayableAsset openAnim;
    public PlayableAsset closeAnim;
    
    private PlayableDirector director;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
    }

    public void OnMouseEnter()
    {
        director.playableAsset = openAnim;
        director.Play();
    }

    public void OnMouseExit()
    {
        director.playableAsset = closeAnim;
        director.Play();
    }
}
