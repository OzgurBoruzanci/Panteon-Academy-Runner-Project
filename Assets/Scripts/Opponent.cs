using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    public NavMeshAgent opponentAgent;
    public GameObject target;
    public GameObject speedIcon;
    Animator _playerAnim;
    public GameObject player;
    public int score;
    bool _won = false;
    Vector3 _firstPosition;

    private void OnEnable()
    {
        EventManager.FirstCome += FirstCome;
        EventManager.RestartBtn += RestartBtn;
        EventManager.EndGame += EndGame;
    }
    private void OnDisable()
    {
        EventManager.FirstCome -= FirstCome;
        EventManager.RestartBtn -= RestartBtn;
        EventManager.EndGame -= EndGame;
    }
    void FirstCome(string firstCm)
    {
        if (firstCm==this.gameObject.name)
        {
            _won = true;
        }
    }
    void RestartBtn()
    {
        _won = false;
    }
    void EndGame()
    {
        opponentAgent.Stop();
    }
    void Start()
    {
        opponentAgent = GetComponent<NavMeshAgent>();
        _playerAnim = player.GetComponentInChildren<Animator>();
        _firstPosition = transform.position;
    }

    void Update()
    {
        opponentAgent.SetDestination(target.transform.position);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FixedObstacle"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5);
        }
        if (other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("SpeedBoost"))
        {
            this.GetComponent<Opponent>().opponentAgent.speed += 3f;
            speedIcon.SetActive(true);
            StartCoroutine(SlowAfterAWileCoroutine());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = _firstPosition;
        }
        if (collision.gameObject.CompareTag("FinishPoint"))
        {
            transform.Rotate(transform.rotation.x, 160, transform.rotation.z, Space.Self);
            this.GetComponent<Opponent>().opponentAgent.speed = 0;
            //EventManager.EndGame();
            if (_won)
            {
                _playerAnim.SetBool("Win", true);
            }
            else
            {
                _playerAnim.SetBool("Lose", true);
            }
        }
    }
    IEnumerator SlowAfterAWileCoroutine()
    {
        yield return new WaitForSeconds(2.0f);
        this.GetComponent<Opponent>().opponentAgent.speed -= 3f;
        speedIcon.SetActive(false);
    }
}
