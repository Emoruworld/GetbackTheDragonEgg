using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDataStore : MonoBehaviour
{
    public static DragonDataManager dragonDataManager;
    // Start is called before the first frame update
    void Start()
    {
        // Static��DragondataManager���쐬
        dragonDataManager = new DragonDataManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
