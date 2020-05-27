using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenController : MonoBehaviour
{
    public void onClick()
    {
        SceneManager.LoadScene("Persistent");
    }
}
