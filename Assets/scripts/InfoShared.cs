using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoShared : MonoBehaviour
{
    public static InfoShared Instance;
    public static int record = 0;
    public static float initTime;
    void Start()
    {
        Instance = this;
    }
}
