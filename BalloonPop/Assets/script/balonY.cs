using UnityEngine;

public class balonY : MonoBehaviour
{
    public float speed = 2f;
    public GameObject particleEffect;
    public GameObject kotudurum;

    [Header("Max Y koordinatı")]
    public float maxY = -40f; // bu dəyəri inspector-dan dəyişə bilərsən

    void Update()
    {
        // hərəkət
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // müəyyən koordinatı keçibsə obyekt yox olsun
        if (transform.position.y >= maxY)
        {
            ScoreManager.instance.AddScore(-3); // xal çıxılır
            Destroy(gameObject);
            ScoreManager.instance.LoseHeart();
        }

        // toxunma ilə yoxlama
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);

                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("CanItir"))
                    {
                        ScoreManager.instance.LoseHeart();
                    }
                }
            }
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

        ScoreManager.instance.AddScore(5);
        ScoreManager.instance.randomtext();
        Destroy(gameObject);
    }
}
