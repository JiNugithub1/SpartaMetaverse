using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public GameObject player;

    // 카메라 이동 제한값
    public float minX = 0f;
    public float maxX = 10f;
    public float minY = 0f;
    public float maxY = 5f;

    void LateUpdate()
    {
        Vector3 targetPos = player.transform.position;
        targetPos.z = transform.position.z;

        // 1. 카메라 이동 위치를 0.1 단위로 끊기
        targetPos.x = Mathf.Round(targetPos.x * 20f) / 20f;
        targetPos.y = Mathf.Round(targetPos.y * 20f) / 20f;

        // 2. 이동 제한 걸기
        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

        // 3. 적용
        this.transform.position = targetPos;
    } 
   
}
