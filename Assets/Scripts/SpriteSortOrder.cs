using UnityEngine;

public class SpriteSortOrder : MonoBehaviour
{
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        sprite.sortingOrder = Mathf.RoundToInt(transform.position.y * -10f); //n�soben� ur�uje p�esnost po�ad� vykreslov�n�. 10 posta��
    }
}
