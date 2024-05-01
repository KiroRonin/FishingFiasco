using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public Transform targetObject;
    private Vector3 initialPosition = new Vector3(0f, 1f, -10f);
    public Animator camanim;
    public Animator FadeBl;
    public Animator cine;
    
    private Vector3 finalPosition = new Vector3(0f, 20f, 300f);
    public GameObject FADEBLACK;
    
    
    public float lerpDuration = 2.0f;
    private float elapsedTime = 0.0f;


    private void Start()
    {
        FADEBLACK.SetActive(true);
    }
    public void Play()
    {
        targetObject.position = initialPosition;
        
        FadeBl.SetTrigger("FADEBL");
        cine.SetTrigger("Cine");
        StartCoroutine(LerpObject());
        StartCoroutine(ChangeScene());

        
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Tavern");
    }

    IEnumerator LerpObject()
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
            

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        elapsedTime = 0f;
        targetObject.position = finalPosition;

        
        
    }

    public void Howtwo()
    {
        camanim.SetTrigger("How2");
        
    }

    public void Quit()
    {
        Application.Quit();
    }


}
