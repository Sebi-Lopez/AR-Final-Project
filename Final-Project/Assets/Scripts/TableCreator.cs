using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCreator : MonoBehaviour 
{
    public GameObject table;

    public float lengthFactor = 0.15f; 

    public bool activeEnd = false;
    public bool activeBegin = false;

    public void CreateTable()
    {
        Debug.Log("Trying to create Table");

        // If any target is not found, bye
        if (!activeEnd || !activeBegin)
        {
            Debug.Log("Abort: Not both target actives right now");
            return;
        }

        // If table already created, bye
        if (table.active)
        {
            Debug.Log("Abort: Table already created");
            return;
        }

        Transform tableBegin = GameObject.Find("Table_Begin").transform;
        Transform tableEnd = GameObject.Find("Table_End").transform;

        Vector3 tableVector = tableEnd.position - tableBegin.position;
        float length = tableVector.magnitude;
        Debug.Log("Table Size = " + length);

        table.transform.position = tableBegin.position + tableVector.normalized * length * 0.5f;
        table.transform.LookAt(tableEnd);

        length *= lengthFactor;
        table.transform.localScale = new Vector3(length * 0.5f, 1, length);
        table.SetActive(true);

        // Cups rotation

        GameObject cups = GameObject.FindGameObjectWithTag("Cups");

        cups.transform.LookAt(tableBegin);

        Debug.Log("Creating Table");
    }

    public void DestroyTable()
    {
        table.SetActive(false);
        Debug.Log("Destroying Tableeee");
    }

    // Target Setters 

    public void SetCupActive()
    {
        activeEnd = true;
    }

    public void SetCupUnactive()
    {
        activeEnd = false;
    }

    public void SetBeginActive()
    {
        activeBegin = true;
    }

    public void SetBeginUnactive()
    {
        activeBegin = false;
    }
}
