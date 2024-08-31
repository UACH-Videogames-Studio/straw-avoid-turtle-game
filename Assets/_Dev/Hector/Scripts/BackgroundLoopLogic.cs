using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoopLogic : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private bool isGameFinished = false;
    private float previousLoopThreshold = 0f;

    void Start()
    {
        if (mainCamera == null)
        {
            Debug.LogWarning("Camara no encontrada");
        }        
    }

    // Update is called once per frame
    void Update()
    {
        CheckBackgroundLoopCondition();
    }

    private void CheckBackgroundLoopCondition()
    {
        float cameraCurrentPosition = mainCamera.transform.position.y;
        float currentLoopThreshold = Mathf.Floor(cameraCurrentPosition / 9) * 9;

        if (currentLoopThreshold > previousLoopThreshold && !isGameFinished)
        {
            previousLoopThreshold = currentLoopThreshold;
            transform.position += new Vector3(0, 9, 0);
        }
    }
}
