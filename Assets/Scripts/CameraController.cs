using UnityEngine;

// クラス名を「Camera」にするとUnity標準のCameraクラスと競合するため、
// 「CameraController」などの名前に変更することをおすすめします。
public class CameraController : MonoBehaviour
{
    // 追従するターゲットのTransform, inspectorから指定する
    public Transform target;
    // カメラの追従速度
    public float smoothSpeed = 0.125f;
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
            // Debug.Log("Target Position: " + target.position);

            Vector3 desiredPosition = target.position + offset;
            
            // 現在のカメラの位置から、本来あるべき位置へ滑らかに移動させる
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            
            // 計算した位置をカメラの位置に設定
            transform.position = smoothedPosition;
        }
    }
}