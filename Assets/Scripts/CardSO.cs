using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Standard Card", menuName = "Card/Standard")]
public class CardSO : ScriptableObject
{
    public string cardName;
    public Sprite artwork;

    public int cost;
    public int damage;
    public int hits;
}
