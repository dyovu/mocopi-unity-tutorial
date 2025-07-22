using UnityEngine;

public class CameraController : MonoBehaviour
{
    // 追従するターゲットのTransform, inspectorから指定する
    public Transform target;
    // カメラの追従速度
    public float smoothSpeed = 0.125f;
    // カメラの回転速度
    public float rotationSpeed = 100.0f;
    // カメラとターゲットの初期相対位置を保持する変数
    private Vector3 offset;

    void Start()
    {
        if (target != null)
        {
            offset = transform.position - target.position;
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // 十字キーの左右（Horizontal軸）の入力を取得し、回転角度を計算
            float horizontalInput = Input.GetAxis("Horizontal");
            float rotationAngle = horizontalInput * rotationSpeed * Time.deltaTime;

            // Y軸を中心にoffsetを回転させる
            Quaternion rotation = Quaternion.Euler(0, rotationAngle, 0);
            offset = rotation * offset;

            // ターゲットの位置に回転させたoffsetを加算して、カメラのあるべき位置を計算
            Vector3 desiredPosition = target.position + offset;
            
            // 現在のカメラの位置から、あるべき位置へ滑らかに移動させる
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            
            // 計算した位置をカメラの位置に設定
            transform.position = smoothedPosition;

            // カメラが常にターゲットの方を向くように設定
            transform.LookAt(target);
        }
    }
}