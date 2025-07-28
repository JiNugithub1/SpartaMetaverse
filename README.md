# 🌐 Unity Metaverse IB Playground

**Unity 기반 메타버스 공간 프로젝트**입니다.  
이 프로젝트는 3D 공간에서 다양한 오브젝트와 상호작용하고, 미니게임을 즐기며 확장 가능한 가상 세계를 구현하는 것을<br> 목표로 하고 있습니다. 
RPG 공포게임 'IB'를 모티브로 만든 미술관 배경에 메타버스 세계관입니다. 
<br><br>
**부디 편하게 감상해주시기 바랍니다.**

<img width="1000" height="534" alt="image" src="https://github.com/user-attachments/assets/931104cc-8be5-4834-828d-02033dce9324" />

--- 
## ✨ 프로젝트 특징

- 🧍‍♂️ 플레이어 아바타 이동 및 상호작용
- 🗺️ 공간 내 다양한 오브젝트/캐릭터와의 상호작용
- 🎙 대화 시스템 (타이핑 효과 포함)
- 🧭 선택지에 따른 흐름 분기
- 🎮 **미니게임 포함 (예: Flappy Bird 스타일 게임)**

---

## 🎮 포함된 미니게임: Flappy Bird Mini Clone

> 본 프로젝트에 포함된 미니게임 중 하나로, 메타버스 내에서 플레이어가 접근 시 실행됩니다.

- 스페이스바로 점프하며 장애물을 피하는 방식
- 점수 시스템 및 최고 기록 저장
- 게임 오버 후 재시작 또는 메타버스 복귀 선택 가능
- 현재 Flappy Bird Scene에서 MainScene으로 안넘어가는 현상 수정 중..

---

## 🛠️ 사용 기술 및 권장 환경

| 항목         | 내용                        |
|--------------|-----------------------------|
| Engine       | Unity (권장: 2021.3.0f1 이상) |
| Language     | C#                          |
| Platform     | PC / 메타버스 연동 플랫폼 가능 |
| 기타         | Unity UI, SceneManager, PlayerPrefs 등 사용 |

---

## 📷 스크린샷

| 구분       | 이미지                                                                                              |
|------------|--------------------------------------------------------------------------------------------------|
| 메타버스 공간 | <img width="730" height="409" alt="image" src="https://github.com/user-attachments/assets/e9de1aae-3c78-4450-a8e7-11f8524143d1" /> |
| 대화창 UI   | ![대화창 UI](https://github.com/user-attachments/assets/d02377b8-ff34-44a6-ae74-89139f66a0ab)    |
| 선택창 UI   | ![선택창 UI](https://github.com/user-attachments/assets/104fbf76-06eb-46b7-8d43-265790fbc2c6)    |
| 미니게임    | ![미니게임](https://github.com/user-attachments/assets/391fafc2-00b4-460a-a72d-ad319e25ff84)      |


---


## 🔗 참고 자료

- Unity 공식 문서: https://docs.unity3d.com/Manual/index.html
- 'IB' Sprite 참조 사이트 : https://www.spriters-resource.com/
- '탑 다운 RPG 게임 제작' 골드메탈 : https://www.youtube.com/playlist?list=PLO-mt5Iu5TeYfyXsi6kzHK8kfjPvadC5u

---

## 🧩 프로젝트 구조 요약
**Assets/**<br>
├── Scripts/ # 게임/대화/미니게임 관련 스크립트<br>
├── Scenes/ # MainScene, MiniGameScene 등<br>
├── Prefabs/ # 캐릭터, 오브젝트, UI 프리팹<br>
├── UI/ # 대화창, 선택지, 점수판 등<br>
├── Screenshots/ # 스크린샷 폴더 (문서용)<br>




---

## 🚀 실행 방법

1. Unity로 프로젝트 열기
2. `MainScene` 실행
3. 캐릭터 조작 → 오브젝트 상호작용 → 대화 or 선택지 → 미니게임 진입

---

## 📌 개발 목적

이 프로젝트는 Unity 메타버스 개발 연습 및 확장 가능한 시스템 설계를 위한 학습용 예제입니다.  
추후 퀘스트 시스템, NPC AI, 아이템 획득 등으로 확장 가능합니다.

---

## 🙋‍♂️ 제작자 및 라이선스

- 제작: 진우  
- 사용 가능 범위: 개인 포트폴리오, 학습용 사용 가능 (상업적 목적 제외)
