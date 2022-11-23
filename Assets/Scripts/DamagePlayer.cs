using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamagePlayerOnEvent(other);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        DamagePlayerOnEvent(other);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        DamagePlayerOnEvent(other);
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        DamagePlayerOnEvent(other);
    }

    private void DamagePlayerOnEvent(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
            PlayerHealthController.Instance.DamagePlayer();
    }
    private void DamagePlayerOnEvent(Collider2D other)
    {
        if (other.tag.Equals("Player"))
            PlayerHealthController.Instance.DamagePlayer();
    }
}
