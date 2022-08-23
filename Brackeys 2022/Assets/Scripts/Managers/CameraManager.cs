using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static CameraManager _instance;
    public static CameraManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CameraManager>();
            }
            return _instance;
        }
    }

    // ==================================================
    
    public float heightOffset = 1.5f;
    // public float frontOffset = 0.5f;
    // public float moveSpeed = 1;
    
    // ==================================================

    void Update()
    {
        Vector3 offset = Vector3.up * heightOffset;

        Vector3 playerPos = PlayerController.Instance.transform.position;
        playerPos.z = transform.position.z;

        transform.position = playerPos + offset;
        
    }
}
