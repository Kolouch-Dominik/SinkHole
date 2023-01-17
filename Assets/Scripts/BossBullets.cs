using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullets : MonoBehaviour
{
    [field: SerializeField] public float Speed { get; set; }
    private Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {
        //direction = (PlayerController.Instance.transform.position - transform.position);
        //direction.Normalize();
        direction = transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Speed * Time.deltaTime;

        if (!BossController.Instance.gameObject.activeInHierarchy)
            Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController.Instance.DamagePlayer();
        }
        Destroy(gameObject);
        AudioManager.Instance.PlaySFX(4);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}