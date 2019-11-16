using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Saving object");
        DontDestroyOnLoad(this.gameObject);
    }

}
