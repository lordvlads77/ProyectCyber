using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneChanger : MonoBehaviour
{
    [SerializeField] private int sceneBuildIndex;

    public void ChangeZonee()
    {
        SceneManager.LoadScene(sceneBuildIndex + 1);
    }
}
