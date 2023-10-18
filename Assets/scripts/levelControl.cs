using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelControl : MonoBehaviour
{
 public void changeLevel()
 {
    SceneManager.LoadScene(1); 
 }
}
