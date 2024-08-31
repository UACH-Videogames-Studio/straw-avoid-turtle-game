using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackgroundLoopLogic : MonoBehaviour
{
    public UnityEvent screenPassed;
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

    public void SetShouldContinueLooping(bool value)
    {
        shouldContinueLooping = value;
    }

    private void LoopBackground()
    {
        float cameraCurrentPosition = mainCamera.transform.position.y;
        // float currentLoopThreshold = Mathf.Floor(cameraCurrentPosition / bgHeightUnits) * bgHeightUnits;

        if (cameraCurrentPosition > previousLoopThreshold)
        {
            previousLoopThreshold += bgHeightUnits;
            transform.position += new Vector3(0, bgHeightUnits, 0);
            screenPassed.Invoke();
        }
    }
}
