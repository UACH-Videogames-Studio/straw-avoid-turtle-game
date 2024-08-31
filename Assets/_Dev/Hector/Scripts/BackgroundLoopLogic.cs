using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoopLogic : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private bool shouldContinueLooping = true;
    private float previousLoopThreshold = 0f;

    void Start()
    {
        if (mainCamera == null)
        {
            Debug.LogWarning("Camara no encontrada");
        }        
    }

    void Update()
    {
        if (shouldContinueLooping)
        {
            LoopBackground();
        }
    }

    private void LoopBackground()
    {
        float cameraCurrentPosition = mainCamera.transform.position.y;
        float currentLoopThreshold = Mathf.Floor(cameraCurrentPosition / 9) * 9;

        if (currentLoopThreshold > previousLoopThreshold)
        {
            previousLoopThreshold = currentLoopThreshold;
            transform.position += new Vector3(0, 9, 0);
        }
    }
}
