using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Action eventIsDead;

    void Dead()
    {
        SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        eventIsDead += Dead;
    }

    private void OnDisable()
    {
        eventIsDead -= Dead;
    }
}