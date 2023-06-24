using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private enum State { PLAY, END };
    private State currentState = State.PLAY;

    public float travelSpeed = 20f;
    public float speedIncrease = 0.5f;
    public bool playerCrash = false;

    private void Awake() 
    {
        instance = this;
    }

    void Update()
    {
        switch (currentState)
        {
            case State.PLAY:
                travelSpeed += Time.deltaTime * speedIncrease;
                if (playerCrash) currentState = State.END;
                break;

            case State.END:
                travelSpeed = 0f;
                break;
        }
    }
}
