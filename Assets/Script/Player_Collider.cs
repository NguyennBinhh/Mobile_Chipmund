using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Player_Collider : MonoBehaviour
{
    public GameObject Message;

    public TextMeshProUGUI Message_Text;

    public TextMeshProUGUI Score_Text;

    private int Acorn = 0;

    private int Heart = 3;

    public TextMeshProUGUI Acorn_Text;

    public TextMeshProUGUI Heart_Text;

    public Animator Player_Anim;

    void Start()
    {
        Acorn_Text.text = Acorn.ToString();
        Heart_Text.text = Heart.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Acorn"))
        {
            Acorn++;
            Destroy(collision.gameObject);
            Acorn_Text.text = Acorn.ToString();
            Audio_Manage.Instance.Play_SFX("Acorn");
        }
        if (collision.CompareTag("Monster") && Heart >= 0)
        {
            Heart--;
            Heart_Text.text = Heart.ToString();
            if (Heart >= 1)
            {
                Player_Anim.SetTrigger("Hurt");
                Audio_Manage.Instance.Play_SFX("Death");
            }
            if (Heart == 0)
            {
                Player_Anim.SetTrigger("Player_Die");
                StartCoroutine(Disable_Player());
                Audio_Manage.Instance.Play_SFX("Game_Over");
                Message.SetActive(true);
                Score_Text.SetText(Score() + "");
                Message_Text.SetText("Game Over");
                Audio_Manage.Instance.Music_Source.Stop();
            }
        }
        if(collision.CompareTag("Door"))
        {
            Message.SetActive(true);
            Score_Text.SetText(Score() + "");
            Message_Text.SetText("Level Complete");
            Audio_Manage.Instance.Play_SFX("Victory");
            Audio_Manage.Instance.Music_Source.Stop();
            gameObject.SetActive(false);
        }    
    }

    public float Score()
    {
        return 100 * Acorn;
    }

    IEnumerator Disable_Player()
    {
        AnimatorStateInfo stateInfo = Player_Anim.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);
        gameObject.SetActive(false);
    }
}
