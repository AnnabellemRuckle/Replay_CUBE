using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool replay = false;
    public Text replayText;
    public Text skipText;

    bool gameHasEnded = false;                  
    public float restartDelay = 2f;            
    public GameObject completeLevelUI;         
    GameObject player;
    public void Start()
    {
        replayText.text = "";
        skipText.text = "";
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        player = playerMovement.gameObject;

        if ( CommandLog.commands.Count > 0 )
        {
            replay = true;
            restartDelay = Time.timeSinceLevelLoad;
        }

    }

    public void Update()
    {
        if (replay == true)
        {
            InstantReplay();
        }
    }

    public void InstantReplay()
    {
        if (CommandLog.commands.Count == 0) { return; }         

        Command m_Command = CommandLog.commands.Peek();         

        if ( Time.timeSinceLevelLoad >= m_Command.timeStamp)   
        {
            replayText.text = "REPLAY";
            skipText.text = "Press 'S' to skip";
            
            if (Input.GetKey(KeyCode.S))   //s to skip
            {
                CommandLog.commands.Clear();
                Restart();
            }

            if (CommandLog.commands.Count == 0) { return; }

            m_Command = CommandLog.commands.Dequeue();          
            m_Command.m_rb = player.GetComponent<Rigidbody>();  

            Invoker m_Invoker = new Invoker();                  
            m_Invoker.SetCommand(m_Command);                    
            m_Invoker.ExecuteCommandWithoutEnqueue(m_Command);
        }
    }


    public void CompleteLevel ()                
    {
        completeLevelUI.SetActive(true);       
    }
    public void EndGame ()                      
    {
        if (gameHasEnded == false)             
        {
            gameHasEnded = true;   
            //InstantReplay();             
            Invoke("Restart", restartDelay);    
        }
     //   else 
       // {
            //Invoke("Restart", restartDelay); 
      //  }
        
    }
    void Restart ()                             
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
//Cubethon/Library*