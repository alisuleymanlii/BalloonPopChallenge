using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybalon : MonoBehaviour
{

    public GameObject particleEffect;
    public float speed = 2f;
     public float maxY = -40f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (transform.position.y >= maxY)
        {
            Destroy(gameObject);
        }

    }
    void OnMouseDown()
    {
        SoundManager.instance.PlayEffect2();
        if (particleEffect != null)
        {
            GameObject effect = Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }

        CameraShake camShake = Camera.main.GetComponent<CameraShake>();
        if (camShake != null)
        {
            StartCoroutine(camShake.Shake(0.2f, 0.1f));
        }

        ScoreManager.instance.LoseHeart();
        Destroy(gameObject);
    }
}
