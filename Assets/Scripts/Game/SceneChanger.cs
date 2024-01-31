using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator transition;
    public void MoveToScene(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName).GetEnumerator());
    }

    IEnumerable LoadLevel(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(sceneName);
    }
}
