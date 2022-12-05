using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using UniRx.Triggers;
using System;

public class Move : MonoBehaviour
{
    Rigidbody _rb;

    [SerializeField]
    [Header("“®‚­‘¬‚³")]
    float _speed;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        this.UpdateAsObservable().Subscribe(x => PlayerMove());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadSceneAsync("Battle");
        }
    }

    void PlayerMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _rb.AddForce(new Vector3(horizontal, 0, vertical) * _speed, ForceMode.Impulse);
    }
}
