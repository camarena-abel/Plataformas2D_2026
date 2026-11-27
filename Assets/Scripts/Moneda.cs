using UnityEngine;

public class Moneda : MonoBehaviour
{
    [SerializeField]
    float amplitude = 0.25f;

    [SerializeField]
    float frequency = 5f;

    Transform sprite;

    void Start()
    {
        sprite = transform.Find("Sprite");
    }

    void Update()
    {
        float y = Mathf.Sin(Time.realtimeSinceStartup * frequency) * amplitude;
        sprite.transform.localPosition = new Vector3(0f, y, 0f);
    }
}
