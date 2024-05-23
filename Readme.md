# 🏹 Defending Castle
 캐릭터를 조종하여 몰려오는 적들로부터 성을 지키는 디펜스 게임

<br>

## 📂 프로젝트 소개
 인풋 시스템과 충돌 감지, 오브젝트 풀링 기법 등이 활용된 2D 탑다운 뷰 프로젝트입니다.

<br>

### 📆 제작 기간
**24-05-14 ~ 24-05-23**

### 👨‍💻 제작 인원
**A02 - 김민우 , 안보연 , 이강혁 , 이시원**

<br>

## 📌 주요 기능

### Input System 을 통한 Player 움직임 구현
W/A/S/D 키를 통해 캐릭터를 움직이고, 마우스 위치를 통해 캐릭터의 방향이 바뀌게 설정하였습니다.

### Collider 를 통한 충돌 감지
투사체 (화살, 다이너마이트) 와 타겟 (적, 플레이어) 의 충돌 감지를 통해 데미지를 입게 하였습니다.

근접 몬스터의 경우, 사정 거리 안에 타겟 (플레이어 , 성)이 존재하면 공격하도록 설정하였습니다.

### 아이템 시스템
적 처치 시 드랍하는 아이템을 통해 임시로 이동 속도를 올려주거나, 체력을 회복하는 효과를 부여하였습니다.

특히, 이동 속도 버프를 받았을 때 파티클 시스템이 적용되어 캐릭터가 빛나는 것을 볼 수 있습니다.

### 오브젝트 풀링
반복적으로 생성되고 소멸되는 객체를 오브젝트 풀링으로 관리해주었습니다.

투사체 (화살, 다이너마이트) , 적 , 드랍 아이템 등이 있습니다.

### 사운드 효과
배경 음악과 효과음을 추가하여 게임의 분위기를 높였습니다.

설정을 통해 전체 볼륨, 배경 음악, SFX 볼륨을 각각 조절할 수 있게 설정하였습니다.

<br>

## 🖼 씬 소개 / 🎬 플레이 화면

### 1. Intro Scene
- 가장 먼저 보여지는 화면입니다.
- **게임 시작 , 사운드 조절 , 나가기**, 3 가지 버튼이 있습니다.

<details>
  <summary> 🎬 인트로 / 🔊 사운드 설정</summary>
  <img src = "https://github.com/SnowScapes/DefendTheCastle/assets/122630746/f5706958-6cf5-4f22-8a4a-548b0eb3c4e2" width = 500>
</details>

<br>

### 2. Tutorial Scene
- 기초 가이드를 제공하는 화면입니다.
- **적들에 대한 정보, 게임 종료 조건, 아이템**에 대한 정보를 제공합니다.

<details>
  <summary> 📕 튜토리얼</summary>
  <img src = "https://github.com/SnowScapes/DefendTheCastle/assets/122630746/0666a15a-a10e-4055-b049-57d3ab068896" width = 500>
</details>

<br>

### 3. Main Scene
- 본격적인 게임 화면 입니다.
- ⌨ W/A/S/D 키를 통해 캐릭터를 움직이고, 🖱 마우스 좌클릭을 통해 공격합니다.
- 적을 처치하면 다양한 아이템이 드랍됩니다.
- 상점을 통해 업그레이드를 진행할 수 있습니다.
- 특수 기능을 통해, 쿨 타임마다 성을 수리할 수 있습니다.
<details>
  <summary> 🎮 플레이어 이동 / 💎 상점 </summary>
  <img src = "https://github.com/SnowScapes/DefendTheCastle/assets/122630746/bb5403d4-b9f2-4148-a5cc-7dbd7bf5020c" width = 500>
</details>

<details>
  <summary> 🏹 공격 / 🧟‍♂️ 적 / 🎁 아이템 </summary>
  <img src = "https://github.com/SnowScapes/DefendTheCastle/assets/122630746/44b6d181-279c-467e-bba1-a9c870886c59" width = 500>
</details>

<details>
  <summary> 🛠 특수 기능 </summary>
  <img src = "https://github.com/SnowScapes/DefendTheCastle/assets/122630746/48df322c-6a44-4617-83de-a662180585bf" width = 500>
</details>

<br>

#### 4. End Scene
- 게임 성공 또는 실패 시 이동하게 되는 화면입니다.
- **다시하기 와 종료하기**, 2 가지 버튼이 있습니다.
- 점수 로직을 통해 계산한 점수를 표시해줍니다.

<details>
  <summary> 🖼 엔딩 씬/ 📊 점수 표시  </summary>
  <img src = "https://github.com/SnowScapes/DefendTheCastle/assets/122630746/23ffcb75-2977-4525-80c4-632e6c65695b" width = 500>
  <img src ="https://github.com/SnowScapes/DefendTheCastle/assets/122630746/ff3f3317-5296-40b7-a97b-84849023d77f" width = 500>
</details>

## 사용 에셋

디자인 에셋 [Tiny Swords](https://pixelfrog-assets.itch.io/tiny-swords)

배경 음악 에셋 [BGM 1](https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116)

[BGM 2](https://assetstore.unity.com/packages/audio/music/casual-game-bgm-5-135943)
