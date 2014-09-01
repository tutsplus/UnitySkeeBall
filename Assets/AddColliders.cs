/*http://whydoidoit.com/2012/03/22/unity-automatic-meshcollider-generation/
 * *
 * using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;

public class AddColliders : ScriptableWizard
{
    
    [MenuItem("Wizards/Add Mesh Colliders")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<AddColliders>("Add mesh colliders", "Add Colliders");
    }
    
    void OnWizardCreate()
    {
        if (UnityEditor.Selection.activeGameObject != null)
        {
            foreach (var c in UnityEditor.Selection.activeGameObject.GetComponentsInChildren<MeshRenderer>().Cast<MeshRenderer>().
                    Where(mr=>mr.GetComponent<MeshCollider>()==null))
            {
                c.gameObject.AddComponent(typeof(MeshCollider));
            }
        }
    }

    void OnWizardUpdate()
    {
        helpString = "Add mesh colliders to all items that have a mesh renderer";
    }
    
}