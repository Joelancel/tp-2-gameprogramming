using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene("scene_base");
    }

}
