using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool shakeCamera;
    Transform originalPos;
    [Range(0, 3)] public float shakeTime;
    private void Start()
    {
        originalPos = transform;
        shakeCamera = false;
        shakeTime = 0.2f;
    }
    public void ShakeCamera()
    {
        shakeCamera = true;
        StartCoroutine(StopShakeCamera());
        Handheld.Vibrate();
    }
    private void Update()
    {
        if(shakeCamera)
        {
            transform.position = originalPos.position - new Vector3(Mathf.Sin(Time.time * 79)/15, Mathf.Cos(Time.time * 79)/15, 0);
        }
    }
    IEnumerator StopShakeCamera()
    {
        yield return new WaitForSeconds(shakeTime);
        shakeCamera = false;
    }
}
