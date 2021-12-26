using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWillCry : MonoBehaviour
{
    #region Singleton
    public static PlayerWillCry instance;
    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;


}
