using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_scene : MonoBehaviour
{
    public void Loadscene(string scene_name){
        SceneManager.LoadScene(scene_name);
    }
}
