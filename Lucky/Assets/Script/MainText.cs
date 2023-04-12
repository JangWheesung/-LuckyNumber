using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainText : MonoBehaviour
{
    private void Awake()
    {
        transform.DOMoveY(700, 1.5f);
    }
}
