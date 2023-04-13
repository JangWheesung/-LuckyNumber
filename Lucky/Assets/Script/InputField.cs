using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FD.Dev;
using DG.Tweening;

public class InputField : MonoBehaviour
{
    [Header("RandomNumber")]
    [SerializeField] private Text inputFieldText;

    [Header("RandomArray")]
    [SerializeField] private Text randomText;
    [SerializeField] private Text maxFieldText;
    [SerializeField] private GameObject card;
    [SerializeField] private GameObject panel;

    [Header("Chinmashine")]
    [SerializeField] private float crash = 2.5f;

    private GameObject[] arrayCard;
    private CinemachineVirtualCamera cv;
    private CinemachineBasicMultiChannelPerlin noise;

    bool isSetting;

    private void Awake()
    {
        cv = FindObjectOfType<CinemachineVirtualCamera>();
        noise = cv.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void RandomArray()
    {
        int[] r = new int[99];
        List<int> wt = new List<int>();

        InputTry();
        CardDestory();
        CardNumber(out r, out wt);
        StartCoroutine(CardSettingDelay(r, 0.1f));

        FAED.InvokeDelay(() => { isSetting = false; }, int.Parse(maxFieldText.text) * 0.1f);
    }

    void InputTry()
    {
        if (randomText.text == "" || maxFieldText.text == "" || isSetting)
            return;
        isSetting = true;
    }

    void CardDestory()
    {
        foreach (GameObject card in GameObject.FindGameObjectsWithTag("Card"))
        {
            Destroy(card);
        }
    }

    void CardNumber(out int[] r, out List<int> wt)
    {
        r = new int[99];
        wt = new List<int>();
        wt.Clear();

        for (int i = 0; i < int.Parse(maxFieldText.text); i++)
        {
            if (i - int.Parse(randomText.text) >= 0)
                wt.Clear();

            bool isDuplicate = true;
            while (isDuplicate)
            {
                r[i] = UnityEngine.Random.Range(1, int.Parse(randomText.text) + 1);
                isDuplicate = wt.Contains(r[i]);
            }
            wt.Add(r[i]);
        }
    }

    void CardSetting(GameObject card, int[] r, int i)
    {
        card.transform.SetParent(panel.transform);
        card.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);

        card.transform.GetChild(0).GetComponent<Image>().DOFade(1, 0.1f);
        card.transform.GetChild(0).GetChild(0).GetComponent<Text>()
            .text = r[i].ToString();
    }

    void CarmerShake()
    {
        noise.m_AmplitudeGain = crash;
        FAED.InvokeDelay(() => { noise.m_AmplitudeGain = 0; }, 0.1f);
    }

    IEnumerator CardSettingDelay(int[] r, float time)
    {
        for (int i = 0; i < int.Parse(maxFieldText.text); i++)
        {
            GameObject creatCard = Instantiate(card);
            CardSetting(creatCard, r, i);
            CarmerShake();
            yield return new WaitForSeconds(time);
        }
    }
}
