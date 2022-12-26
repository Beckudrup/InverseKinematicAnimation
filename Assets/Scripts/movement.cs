using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Library som lader visual studio kende commands til Unities nye "l�kkre" input system

public class movement : MonoBehaviour
{
    private Vector2 bevaegelse; //En vector2 som gemmer movement'en fra vores gut
    private Rigidbody2D myBody; //En rigid body vi kan kode til at flytte
    private Animator myAnimator; //Laver en plads i koden til vores animator

    [SerializeField] private int speed = 5; //S�tter en speed som unity kan se pga [SerializeField]

    private void Awake() //k�re en gang n�r noget specielt sker i det her tilf�lde er det bare n�r programmet starter
    {
        myBody = GetComponent<Rigidbody2D>(); //Vi giver vores myBody Rigidbody2D componentet fra unity s� vi kan �ndre dens v�rdiger i koden s� hvad end det her script sider p� kan bev�ge sig
        myAnimator = GetComponent<Animator>(); //Vi giver vores myAnimator Animator componentet fra unity s� vi kan �ndre dens v�rdiger i koden s� hvad end det her script sider p� kan bev�ge sig

    }
    private void OnMovement(InputValue value) //En private void der modtager et parameter som er baseret p� Unities Input system og bruger den value som den sender til at f� gutten til at bev�ge sig
    {
        bevaegelse = value.Get<Vector2>();
        //^^Vores vector tal som vi f�r af at bev�ge os med inputsystemet som beskriver movement'en af vores gut bliver nu sat lig movement'en s� vi kan g�re klar til at rykke vores gut

        //Tjekker om gutten bev�ger sig og s�tter walking tril true hvis den g�r og s�tter walking til false hvis den ikke g�r, dette har betydning for vores animator og dens skifts fra idle og moving
        if (bevaegelse.x != 0 || bevaegelse.y != 0)
        {

            myAnimator.SetBool("walking", true);
        }
        else
        {
            myAnimator.SetBool("walking", false);
        }

        //Tjekker om Input enten er w elle spacebar og s� k�re den animationen hop, ved at bruge trigger k�re den kun �n gang hvor i mod hvis jeg havde brugt bool havde den k�rt for evigt
        if (Input.GetKeyDown(KeyCode.W) == true || Input.GetKeyDown(KeyCode.Space) == true)
        {
            myAnimator.SetTrigger("hop");
        }

    }
    private void FixedUpdate() //Det er update men det k�re p� et bedre interval n�r det kommer til animationer og rigidbody
    {
        myBody.velocity = bevaegelse * speed; //Vores guts movement bliver sat lig den movement vi f�r fra inputsystemet ganget med den speed vi definerede i starten
    }
}
