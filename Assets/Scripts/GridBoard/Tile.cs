using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Color baseColor, offsetColor;
    [SerializeField] SpriteRenderer sprite;

    GameObject characterOnTile;
    bool isFilled;

    public void Init(bool isOffSet)
    {
        sprite.color = isOffSet ? offsetColor : baseColor;
    }
   
    private void OnMouseDown()
    {
        if (isFilled) return;

        if (characterOnTile != null)
        {
            isFilled = true;
        }

        characterOnTile = CardManager.Instance.SpawnCharacter(characterOnTile, transform.position);
    }
}
