using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordManager : MonoBehaviour
{
    public static RecordManager Instance;
    public Text record;
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        record.text = InfoShared.record.ToString();
    }

}
