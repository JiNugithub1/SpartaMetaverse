using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;
    public TypeEffect talk;
    public GameObject scanObject; //player에게 주어진 상호작용 오브젝트
    public bool isAction;
    public int talkIndex;
    public GameObject choicePanel; //  선택지 패널
    public Button yesButton;       // Yes 버튼
    public Button noButton;        //  No 버튼
    private bool isChoiceTarget = false; // 이 오브젝트가 선택지용인지 확인
    void Start()
    {
        // 버튼 이벤트 연결
        yesButton.onClick.AddListener(OnYes);
        noButton.onClick.AddListener(OnNo);
    }
    public void Action(GameObject scanObj)
    {
        isAction = true;
        scanObject = scanObj;
        ObjectData objectData = scanObj.GetComponent<ObjectData>();
        Talk(objectData.id, objectData.isNpc);
        isChoiceTarget = objectData.hasChoice; // ✅ 선택지 대상인지 판단

        talkPanel.SetActive(isAction);
    }
    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);
        if (talkData == null)
        {
            if (id == 501) // ← 선택지가 필요한 대상 ID
            {
                ShowChoice(); // 선택지 표시
            }
            else
            {
                EndTalk();
            }
            return;
        }
        if (isNpc)
        {
            talk.SetMsg(talkData);
        }
        else
        {
            talk.SetMsg(talkData);
        }
        isAction = true;
        talkIndex++;
    }
    void EndTalk()
    {
        isAction = false;
        talkPanel.SetActive(false);
        talkIndex = 0;
    }
     void ShowChoice()
    {
        choicePanel.SetActive(true);
    }

    void OnYes()
    {
        SceneManager.LoadScene("FlyingBird"); // ✅ 원하는 씬 이름으로 변경
    }

    void OnNo()
    {
        choicePanel.SetActive(false);
        EndTalk(); // ✅ 대화 종료
    }
}