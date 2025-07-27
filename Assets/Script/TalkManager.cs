using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData() // 식별 코드를 통해 NPC와 오브젝트 간의 차이를 두고 데이터 저장
    {
        talkData.Add(1000, new string[] { "이 작품...매우 근사한 거 같아!", "우리집에 가져가고 싶다.."});
        talkData.Add(1001, new string[] { "이 작품이랑 비슷한 게임이 있던 거 같은데..","｢IB｣...였나..?" });

        talkData.Add(500, new string[] { "｢스파르타코딩클럽 공룡｣" }); // 마술작품 설명
        talkData.Add(501, new string[] { "｢하늘을 날고싶은 비행기｣","...!","자세히 보니 탈 수 있을 것 같다." });

        talkData.Add(100, new string[] { "｢개미의 발자취｣" }); //그림 설명 데이터
        talkData.Add(101, new string[] { "｢진주 귀고리를 하고 발냄새가 지독한 소녀｣" }); //그림 설명 데이터
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length) //Talk Index의 범위만큼 배열 출력
        {
            return null;
        }
        else
            return talkData[id][talkIndex];
    }
}
