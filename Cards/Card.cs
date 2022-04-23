using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Card")]
public class Card : ScriptableObject
{
   public int cost;
   public List<CardEffects> effects;
}
