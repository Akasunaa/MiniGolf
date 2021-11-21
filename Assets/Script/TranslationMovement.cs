using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationMovement : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    private float moveSpeed = 2f;
    [SerializeField] private float waitTime;
    [SerializeField] private float moveTime;
    private float timer = 0f;

    private enum State { Moving, Waiting }
    private State state;

    private void Awake()
    {
        direction = direction.normalized;
        state = State.Moving;
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (state == State.Moving)
        {
            if (timer >= moveTime)
            {
                state = State.Waiting;
                direction *= -1;
                timer = 0f;
            }
            else
            {
                transform.Translate(direction * Time.deltaTime * moveSpeed);
            }
        }
        else
        {
            if (timer >= waitTime)
            {
                state = State.Moving;
                timer = 0f;
            }
        }

    }
}

