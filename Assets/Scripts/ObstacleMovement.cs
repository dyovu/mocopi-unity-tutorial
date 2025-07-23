// ObstacleMovement.cs
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);


        if (transform.position.z < -5f)
        {
            // 画面外に出た障害物は削除
            Destroy(gameObject);
        }
    }
}