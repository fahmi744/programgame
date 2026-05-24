using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    public void SavePosition()
    {
        PlayerPrefs.SetFloat("X", transform.position.x);
        PlayerPrefs.SetFloat("Y", transform.position.y);
        PlayerPrefs.SetFloat("Z", transform.position.z);
        PlayerPrefs.SetInt("HasSave", 1);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("HasSave", 0) == 1)
        {
            transform.position = new Vector3(
                PlayerPrefs.GetFloat("X"),
                PlayerPrefs.GetFloat("Y"),
                PlayerPrefs.GetFloat("Z")
            );      
        }
    }
}
