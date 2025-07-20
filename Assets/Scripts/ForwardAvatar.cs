using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardAvatar : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private Transform forwardDirectionSource;



    void Start()
    {
        // if (forwardDirectionSource == null)
        // {
        //     // AnimatorコンポーネントからHips(骨盤)ボーンを探す
        //     Animator animator = GetComponent<Animator>();
        //     if (animator != null)
        //     {
        //         forwardDirectionSource = animator.GetBoneTransform(HumanBodyBones.Hips);
        //     }

        //     if (forwardDirectionSource == null)
        //     {
        //         Debug.LogError("向きの基準となるボーンが見つかりませんでした。インスペクターから手動で設定してください。", this.gameObject);
        //     }
        // }
    }

    void Update()
    {
        if (forwardDirectionSource != null && Input.GetKey(KeyCode.W))
        {
            // 基準となるボーンの前方方向を取得
            Vector3 moveDirection = forwardDirectionSource.forward;

            // キャラクターが傾いても地面と水平に移動するように、上下方向のベクトル（Y成分）を無効化する
            moveDirection.y = 0;

            // ベクトルの長さを1に正規化して、純粋な方向だけを取り出す
            moveDirection.Normalize();

            // 親オブジェクト（このスクリプトがアタッチされているオブジェクト）の位置を、計算した方向に移動させる
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
