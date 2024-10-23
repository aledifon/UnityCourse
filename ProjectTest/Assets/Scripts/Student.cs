using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    // Fields
    // Notas que ha introducido el profe
    public float studentNoteTheory,
                studentNotePractices;

    // Student name
    public string studentName;

    // Start is called before the first frame update
    void Start()
    {
        CheckGrades();
    }

    // Update is called once per frame
    private void StudentGrades()
    {
        // Local vars.
        float theory = 0.7f,
                practices = 0.3f,
                finalGrade;
        // Calculo
        finalGrade = studentNoteTheory*theory + studentNotePractices*practices;

        // Show the result
        Debug.Log("The final mark of the student called " + studentName + " es " + finalGrade);
    }

    private void CheckGrades()
    {
        if (studentNoteTheory<0 || studentNoteTheory>10 ||
            studentNotePractices < 0 || studentNotePractices > 10)
        {
            Debug.Log("The inserted value should be between 0 and 10.");
        }
        else
        {
            StudentGrades();
        }
    }
}
