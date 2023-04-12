using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    [SerializeField] private Text inputFieldText;
    [SerializeField] private Text expFieldText;
    [SerializeField] private Text maxFieldText;

    [SerializeField] private Text randomText;
    [SerializeField] private Text randomArray;

    private GameObject[] arrayCard;

    public void RandomNumber()
    {
        int r;
        int num;
        while (true)
        {
            r = Random.Range(1, int.Parse(inputFieldText.text));
            if (expFieldText.text == "")
                break;
            else if (r != int.Parse(expFieldText.text))
                break;
        }
        randomText.text = Random.Range(0, r).ToString();
    }

    public void RandomArray()
    {
        int[] r = new int[99];
        for (int i = 0; i < int.Parse(maxFieldText.text); i++)
        {
            while (true)
            {
                r[i] = Random.Range(1, int.Parse(inputFieldText.text));
                if (r[i] != int.Parse(expFieldText.text))
                    break;
            }
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
