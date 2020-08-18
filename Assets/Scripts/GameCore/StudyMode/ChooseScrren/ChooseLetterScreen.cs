using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseLetterScreen : MonoBehaviour
{
    public GameObject content;
    public GameObject selectLevelBtn;
    float offset;
    // Start is called before the first frame update
    void Start()
    {
        offset =  -100;
        for (int i = 1; i < GameStates.maxLevel + 1; i+=3)
        {
           for(int j=0;j<3;j++)
            {
                GameObject newOne = Instantiate(selectLevelBtn, Vector3.zero, Quaternion.identity, content.transform);
                bool cheker = DataStorage.passedLevels[i +j - 1].letters && DataStorage.passedLevels[i + j - 1].slogs && DataStorage.passedLevels[i + j - 1].words && DataStorage.passedLevels[i + j - 1].images;
                if (cheker)
                {
                    newOne.GetComponent<Image>().color = Color.green;
                }
                newOne.GetComponent<LevelSelectController>().levelNum = i + j;
                newOne.GetComponentInChildren<Text>().text = (i+j).ToString();
                newOne.GetComponent<RectTransform>().anchoredPosition = new Vector3(-350 + (1080/3 *j), (i - 1) * offset, 0);
                content.GetComponent<RectTransform>().sizeDelta = new Vector2(content.GetComponent<RectTransform>().rect.width, -((i + 1) * offset));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
