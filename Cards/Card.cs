using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Cards/Card")] //Cria o menu que permite criar novas cartas nos assets
public class Card : ScriptableObject
{
   //Váriaveis que toda carta vai ter
   public Sprite image;
   public int cost;
   public List<CardEffects> effects;
}
