using System.Collections;
using UnityEngine;

public class SmoothLerp : MonoBehaviour
{
    public RectTransform targetObject;
    public Vector3 initialPosition;
    public Quaternion initialRotation;
    public Vector3 finalPosition;
    public Quaternion finalRotation;
    public float lerpDuration = 2.0f;

    private float elapsedTime = 0.0f;

    private void Start()
    {
        targetObject.position = initialPosition;
        targetObject.rotation = initialRotation;

        StartCoroutine(LerpObject());
    }

    private IEnumerator LerpObject()
    {
        float SmoothStep(float edge0, float edge1, float x)
        {
            x = Mathf.Clamp01((x - edge0) / (edge1 - edge0));
            return x * x * (3 - 2 * x);
        }

        while (elapsedTime < lerpDuration)
        {
            float t = SmoothStep(0.0f, lerpDuration, elapsedTime);

            targetObject.position = Vector3.Lerp(initialPosition, finalPosition, t);
            targetObject.rotation = Quaternion.Slerp(initialRotation, finalRotation, t);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        targetObject.position = finalPosition;
        targetObject.rotation = finalRotation;
    }
}
