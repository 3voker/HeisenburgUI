using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ZTargeting : MonoBehaviour
{
    private Simple3rdPersonCamera simpleCamera;

    public KeyCode kbZTargetKey = KeyCode.Z;
    public GamepadButtons gpZTargetKey = GamepadButtons.LBumper;

    [SerializeField]
    Sprite blueCursor;

    [SerializeField]
    Sprite greenCursor;

    Animation anim;

    private Player player;
    //Enemy targeting variables
    private Enemy targetedEnemy;
    public float[] enemyDistances = new float[1];
    public List<Enemy> enemiesInView = new List<Enemy>();

    //NPC targeting variables
    private NPC targetedNPC;
    public float[] npcDistances = new float[1];
    public List<NPC>npcInView = new List<NPC>();
    private Color originalColor;

    void Awake()
    {
        simpleCamera = GameObject.FindObjectOfType<Simple3rdPersonCamera>();
        anim = GameObject.FindGameObjectWithTag("Cursor").GetComponent<Animation>();
      
        originalColor = Color.blue;

        if (!transform.parent.gameObject.GetComponent<Player>())
        {
            Debug.LogError("Player didn't exist on parent -- adding player now");
            player = this.transform.parent.gameObject.AddComponent<Player>();
        }
        else
        {
            player = transform.parent.gameObject.GetComponent<Player>();
        }
    }

    void Update()
    {
        ZTargetCamera();
        //Set distances and color
        manageEnemyTargets();
    }

    private void manageEnemyTargets()
    {
        for (int x = 0; x < enemiesInView.Count; x++)
        {
            if (enemyDistances.Length != enemiesInView.Count)
            { enemyDistances = new float[enemiesInView.Count]; }

            if (enemiesInView[x] != null)
            {
                enemiesInView[x].GetComponent<Renderer>().material.color = originalColor;
                enemyDistances[x] = (Vector3.Distance(player.transform.position, enemiesInView[x].transform.position));
            }
        }

        //Set actual player target
        if (enemiesInView.Count > 0 && enemyDistances.Length > 0)
        {
            int indexOfMinDistance = System.Array.IndexOf(enemyDistances, enemyDistances.Min());
            if (enemiesInView[indexOfMinDistance] != null)
            {
                targetedEnemy = enemiesInView[indexOfMinDistance];
                targetedEnemy.GetComponent<Renderer>().material.color = Color.yellow;
                player.SetTarget(targetedEnemy);
            }
        }

        //Reset color -- for testing purposes 
        foreach (var enemy in enemiesInView)
        {
            if (targetedEnemy != enemy)
            {
                enemy.GetComponent<Renderer>().material.color = originalColor;
            }
        }
    }
    private void manageNPCTargets()
    {
        for (int x = 0; x < npcInView.Count; x++)
        {
            if (npcDistances.Length != npcInView.Count)
            { npcDistances = new float[npcInView.Count]; }

            if (npcInView[x] != null)
            {
                npcInView[x].GetComponent<Renderer>().material.color = originalColor;
                npcDistances[x] = (Vector3.Distance(player.transform.position, npcInView[x].transform.position));
            }
        }

        //Set actual player target
        if (npcInView.Count > 0 && npcDistances.Length > 0)
        {
            int indexOfMinDistance = System.Array.IndexOf(npcDistances, npcDistances.Min());
            if (npcInView[indexOfMinDistance] != null)
            {
                targetedNPC = npcInView[indexOfMinDistance];
                targetedNPC.GetComponent<Renderer>().material.color = Color.yellow;
                player.SetTarget(targetedNPC);
            }
        }

        //Reset color -- for testing purposes 
        foreach (var npc in npcInView)
        {
            if (targetedNPC != npc)
            {
                npc.GetComponent<Renderer>().material.color = originalColor;
            }
        }
    }
    private void ZTargetCamera()
    {
        if (Input.GetKey(kbZTargetKey) || (player.controller.gamepadInput && player.controller.myGamepad.GetButton(gpZTargetKey)))
        {   simpleCamera.canMoveCamera = false;  }
        else { simpleCamera.canMoveCamera = true; }
    }
    //UI section done
    void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Enemy>() != null)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemiesInView.Add(enemy);
            Instantiate(blueCursor, enemy.transform.position, enemy.transform.rotation);
            anim.Play("targetCursor");
        }
        if (collider.GetComponent<NPC>() != null)
        {
            NPC npc = collider.GetComponent<NPC>();
            npcInView.Add(npc);
            Instantiate(greenCursor, npc.transform.position, npc.transform.rotation);
            anim.Play("targetCursor");
        }
    }
    //UI section done
    void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Enemy>() != null)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.GetComponent<Renderer>().material.color = originalColor;
            enemiesInView.Remove(enemy);
            Destroy(blueCursor);
        }
        if (collider.GetComponent<NPC>() != null)
        {
            NPC npc = collider.GetComponent<NPC>();
            npc.GetComponent<Renderer>().material.color = originalColor;
            npcInView.Remove(npc);
            Destroy(greenCursor);
        }
    }
}
