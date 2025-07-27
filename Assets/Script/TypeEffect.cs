using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TypeEffect : MonoBehaviour
{
    public int CharPerSeconds; //시간차로 천천히 타이핑 되도록
    public GameObject EndCursor;
    public GameObject talkPanel;
    string targetMsg;
    int index;
    float interval;
    Text msgText;

    private void Awake()
    {
        msgText = GetComponent<Text>();
    }

    public void SetMsg(string msg)
    {
        targetMsg = msg;
        EffectStart();
    }

    void EffectStart()
    {
        // talkPanel을 true로 바꾼다음 msgText를 초기화해서 타이핑 애니메이션을 실행
        talkPanel.SetActive(true);
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);


        //Start Animation
        interval = 1.0f / CharPerSeconds;
        Invoke("Effecting", interval); //시간차로 출력돼라.
    }
    void Effecting()
    {
        if (msgText.text == targetMsg) // 지정한 배열의 TEXT가 출력을 다할 때까지 
        {
            EffectEnd();
            return;
        }
        msgText.text += targetMsg[index];
        index++;

        Invoke("Effecting", interval);
    }
    void EffectEnd()
    {
        EndCursor.SetActive(true); // 모든 글자가 출력되고 나면 EndCursor 애니메이션 출력
    }
}
