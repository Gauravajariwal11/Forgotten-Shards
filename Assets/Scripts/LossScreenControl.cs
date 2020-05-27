using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossScreenControl : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene("riddle");
    }
}
