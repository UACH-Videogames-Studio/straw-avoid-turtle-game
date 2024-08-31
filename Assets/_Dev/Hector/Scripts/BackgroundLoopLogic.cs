using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoopLogic : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private bool shouldContinueLooping = true;
    [SerializeField] protected float bgHeightUnits = 9;
    private float previousLoopThreshold = 0f;

    void Start()
    {
        previousLoopThreshold=bgHeightUnits;
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
        // float currentLoopThreshold = Mathf.Floor(cameraCurrentPosition / bgHeightUnits) * bgHeightUnits;

        if (cameraCurrentPosition > previousLoopThreshold)
        {
            previousLoopThreshold += bgHeightUnits;
            transform.position += new Vector3(0, bgHeightUnits, 0);
        }
    }
}
