using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Ebac.Core.Singleton;

public class PlayerController : Singleton<PlayerController>
{
    //publics
    //[Header("Lerp")]
    //public Transform target;
    //public float lerpSpeed = 1f;
    public float speed = 1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";
    //public Rigidbody rb;

    [Header("Text PowerUp Name")]
    public TextMeshPro uiTextPowerUp;

    public bool invecible = true;

    [Header("Collector Candys")]
    public GameObject CandyCollector;

    //privates
    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
        _startPosition = transform.position;
        ResetSpeed();
        _canRun = true;
    }

    void Update()
    {
        if(!_canRun) return;
        //_pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        //transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
        //rb.AddForce(Vector3.forward * speed * _currentSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == tagToCheckEnemy)
        {
            if (!invecible) LoadLoserScene();
        }
        if (collision.transform.tag == "Finish")
        {
            print("colidiu com a parede");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheckEndLine)
        {
            if (!invecible) LoadWinnerScene();
        }
    }

    private void LoadWinnerScene()
    {
        SceneManager.LoadScene("WinnerScene");
    }

    private void LoadLoserScene()
    {
        _canRun = false;
        SceneManager.LoadScene("LoserScene");
    }

    public void StartToRun()
    {
        _canRun=true;
    }

    #region PowerUps

    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }

    public void SetInvencible(bool b = true)
    {
        invecible = b;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void ChangeFly(float amount, float duration, float animationDuration, Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;*/

        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);//.onComplete(ResetFly);
        Invoke(nameof(ResetFly), duration);
    }

    public void ResetFly()
    {
        transform.DOMoveY(_startPosition.y, -1f);
    }

    public void changeCoinCollectorSize(float amount)
    {
        CandyCollector.transform.localScale = Vector3.one * amount;
    }
    #endregion
}