using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    // この関数は、このオブジェクト（または子オブジェクト）のColliderに
    // 他のColliderが物理的に衝突した瞬間に自動的に呼び出される
    private void OnCollisionEnter(Collision collision)
    {
        // 衝突した相手のオブジェクト情報をログに出力
        Debug.Log(collision.gameObject.name + " が衝突しました！");
        Debug.Log("衝突したオブジェクトのタグ: " + collision.gameObject.tag);

        // 自分（アバター）のどの部分に当たったかを取得
        // collision.collider は、自分自身の当たったColliderを指します。
        GameObject hitPart = collision.collider.gameObject;
        Debug.Log("当たった部位: " + hitPart.name);

        // 衝突した正確な位置（ワールド座標）を取得
        Vector3 hitPoint = collision.contacts[0].point;
        Debug.Log("衝突座標: " + hitPoint);

        // 迫ってくる障害物に当たったら
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // デバッグログにゲームオーバーと表示
            Debug.LogWarning("バーに衝突！ ゲームオーバー！");

            // ゲームの時間を止めて、動きを完全に停止させる
            Time.timeScale = 0;

            // 当たったバーは念のため破壊しておく
            Destroy(collision.gameObject);
        }
    }
}
