using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class CheckCollision : MonoBehaviour
{
    Animator playerAnim;
    public GameObject speedIcon;
    public int score;
    public TextMeshProUGUI coinText;
    bool won = false;
    Vector3 _firstPosition;
    private void OnEnable()
    {
        EventManager.FirstCome += FirstCome;
        EventManager.RestartBtn += RestartBtn;
    }
    private void OnDisable()
    {
        EventManager.FirstCome -= FirstCome;
        EventManager.RestartBtn -= RestartBtn;
    }
    void FirstCome(string firstCm)
    {
        if (firstCm ==this.name)
        {
            won= true;
        }
    }
    void RestartBtn()
    {
        won=false;
    }
    private void Start()
    {
        playerAnim = this.GetComponentInChildren<Animator>();
        _firstPosition = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FixedObstacle"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5);
        }
        if (other.CompareTag("Coin"))
        {
            
            EventManager.AddCoin();
            //AddCoin();
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("SpeedBoost"))
        {
            this.GetComponent<PlayerManager>().runningSpeed += 3f;
            speedIcon.SetActive(true);
            StartCoroutine(SlowAfterAWileCoroutine());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position= _firstPosition;
        }
        if (collision.gameObject.CompareTag("FinishPoint"))
        {
            EventManager.EndGame();
            transform.Rotate(transform.rotation.x, 160, transform.rotation.z, Space.Self);
            this.GetComponent<PlayerManager>().runningSpeed = 0;
            if (won)
            {
                playerAnim.SetBool("Win", true);
            }
            else
            {
                playerAnim.SetBool("Lose", true);
            }
        }
    }
   
    IEnumerator SlowAfterAWileCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        this.GetComponent<PlayerManager>().runningSpeed -= 3f;
        speedIcon.SetActive(false);
    }
}
