using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FD.Dev;

public class InputField : MonoBehaviour
{
    [SerializeField] private Text inputFieldText;
    [SerializeField] private Text maxFieldText;

    [SerializeField] private Text randomText;
    [SerializeField] private Text randomArray;

    [SerializeField] private float crash = 2.5f;

    private GameObject[] arrayCard;
    private CinemachineVirtualCamera cv;
    private CinemachineBasicMultiChannelPerlin noise;

    public void RandomNumber()
    {
        cv = FindObjectOfType<CinemachineVirtualCamera>();
        noise = cv.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = crash;

        try
        {
            FAED.InvokeDelay(() => 
            {
                noise.m_AmplitudeGain = 0.0f;

                randomText.text = UnityEngine.Random.Range(1,
                int.Parse(inputFieldText.text) + 1).ToString();
            }, 0.1f);
        }
        catch (Exception exp) { }
    }

    public void RandomArray()
    {
        InputField d;

        int[] r = new int[99];
        for (int i = 0; i < int.Parse(maxFieldText.text); i++)
        {
            r[i] = UnityEngine.Random.Range(1, int.Parse(inputFieldText.text));
        }

        arrayCard = GameObject.FindGameObjectsWithTag("Card");
        foreach(GameObject card in arrayCard)
            card.SetActive(false);

        for (int i = 0; i < int.Parse(maxFieldText.text); i++)
        {
            arrayCard[i].SetActive(true);
            arrayCard[i].transform.GetChild(0).GetComponent<Text>().text = r.ToString();
        }
    }
}
