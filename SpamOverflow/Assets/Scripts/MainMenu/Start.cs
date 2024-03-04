using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Start : MonoBehaviour
{
    public string scene;

    public void Awake()
    {
        SceneManager.LoadScene(scene);
    }
}
