using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialMover : MonoBehaviour
{
    public GameObject[] instructions;
    public Camera mainCamera;
    public Camera alternateCamera;
    private int currentIndex = 0;
    public GameObject playercapsule;

    void Start()
    {
        // Ensure that at least one instruction is enabled at the start
        if (instructions.Length > 0)
        {
            instructions[currentIndex].SetActive(true);
            // Activate alternate camera and deactivate main camera at start
            mainCamera.gameObject.SetActive(false);
            alternateCamera.gameObject.SetActive(true);
            playercapsule.gameObject.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Next()
    {
        // Deactivate the current instruction
        instructions[currentIndex].SetActive(false);

        // Move to the next instruction
        currentIndex = (currentIndex + 1) % instructions.Length;

        // Activate the next instruction
        instructions[currentIndex].SetActive(true);
    }

    public void Back()
    {
        // Deactivate the current instruction
        instructions[currentIndex].SetActive(false);

        // Move to the previous instruction
        currentIndex = (currentIndex - 1 + instructions.Length) % instructions.Length;

        // Activate the previous instruction
        instructions[currentIndex].SetActive(true);
    }

    public void Play()
    {
        // Deactivate alternate camera and reactivate main camera
        mainCamera.gameObject.SetActive(true);
        alternateCamera.gameObject.SetActive(false);
        playercapsule.gameObject.SetActive(true);
        // Deactivate the tutorial object
        gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
