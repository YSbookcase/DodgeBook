using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UI 관련 라이브러리
using UnityEngine.UI;
// 씬 관리 관련 라이브러리
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //게임오보 시 활성화할 텍스트 게임 오브젝트
    public GameObject gameOverText;
    //생존 기간을 표시할 텍스트 컴포넌트
    public Text timeText;
    //최고 기록을 표시할 테긋트 컴포넌트
    public Text recordText;

    //생존 시간
    private float surviveTime;
    // 게임 오버 상태
    private bool isGameover;

    private void Start()
    {
        // 생존 시간과 게임오버 상태 초기화
        surviveTime = 0;
        isGameover = false;

    }

    private void Update()
    {
        // 게임오버가 아닌 동안
        if (!isGameover)
        {
            // 생존 시간 갱신
            surviveTime += Time.deltaTime;
            //갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
            timeText.text = "Time : " + (int)surviveTime;
           
        }
        else
        {
            //게임오버 상태에서 R 키를 누른경우
            if (Input.GetKeyDown(KeyCode.R))
            {
                //SampleScene 씬을 로드
                SceneManager.LoadScene("SampleScene");

            }
        }
    }

    public void EndGame()
    {
        //현재 상태를 게임오버 상태로 전환
        isGameover = true;
        //게임오버 텍스트 게임 오브젝트를 활성화
        gameOverText.SetActive(true);

        // BestTime 키로 저장된 이전까ㅇ지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // 이전까지의 최고 기록보다 현재 생존 시간이 더 크다면
        if (surviveTime > bestTime)
        {
            //최고 기록 값을 현재 생존 시간 값으로 변경
            bestTime = surviveTime;
            //변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }

}

