using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

    public enum GameStage
    {
        None = 0,
        Start,
        GameOver
    }

    #region Fields

    [SerializeField]
    private float _GameDuration;

    #endregion Fields

    #region Properties

    public float GlobalTimer { get; private set; }
    public int Score { get; private set; }
    public GameStage Stage { get; private set; }

    public float TimeLeft
    {
        get
        {
            if (this.Stage == GameStage.GameOver)
                return 0.0f;

            return Mathf.Clamp(this._GameDuration - this.GlobalTimer,0f,this._GameDuration);
        }
    }

    #endregion Properties

    #region MonoBehaviour

    void Start () {
        //Debug.Log(this.gameObject.name);

        this.GlobalTimer = 0.0f;
        this.Score = 0;
        this.Stage = GameStage.Start;
	}
	
	// Update is called once per frame
	void Update () {
        this.GlobalTimer += Time.deltaTime;
        if (this.GlobalTimer > this._GameDuration)
            this.TimesUp();
            
    }

    #endregion MonoBehaviour

    #region Score

    public void GainScore(int score)
    {
        if (this.Stage == GameStage.GameOver)
            return;

        if (score <= 0)
            throw new System.ArgumentException("Expected score > 0 for GainScore() function");

        this.Score += score;
    }

    public void LoseScore(int score)
    {
        if (this.Stage == GameStage.GameOver)
            return;

        if (score <= 0)
            throw new System.ArgumentException("Expected score > 0 for LoseScore() function");

        //if (score > this.Score)
        //    throw new System.ArgumentException("Expected score < {0} for LoseScore() function", this.Score.ToString());

        this.Score -= score;
    }

    #endregion Score

    private void TimesUp()
    {
        this.Stage = GameStage.GameOver;
        //TODO: Implement here.

        this.GameOver();
    }

    private void GameOver()
    {
        //TODO: Implement here.
    }
}
