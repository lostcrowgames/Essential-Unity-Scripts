using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour

{
    [SerializeField] private string[] sceneNames;
    private Dictionary<string, List<string>> alternativeScenes;

    [SerializeField] private GameObject doorPrefab;
    [SerializeField] private GameObject sceneLoadObject;

    private int totalEnemies;

    private void Awake()
    {
        InitializeAlternativeScenes();
    }

    private void InitializeAlternativeScenes()
    {
        alternativeScenes = new Dictionary<string, List<string>>();

        foreach (string sceneName in sceneNames)
        {
            string baseSceneName = sceneName.Split('-')[0];

            if (!alternativeScenes.ContainsKey(baseSceneName))
            {
                alternativeScenes[baseSceneName] = new List<string>();
            }

            alternativeScenes[baseSceneName].Add(sceneName);
        }
    }

    private void Start()
    {
        // Get the number of enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        totalEnemies = enemies.Length;

        // Print the number of enemies in the scene
        Debug.Log("Number of enemies in the scene: " + totalEnemies);

        // Disable the SceneLoad game object
        sceneLoadObject.SetActive(false);
    }

    public void EnemyKilled()
    {
        totalEnemies--;

        // Print the number of enemies left
        Debug.Log("Number of enemies left: " + totalEnemies);

        if (totalEnemies <= 0)
        {
            // Deactivate the door prefab
            doorPrefab.SetActive(false);

            // Enable the SceneLoad game object
            sceneLoadObject.SetActive(true);
        }
    }

    public void LoadSceneByName(string sceneName)
    {
        if (sceneNames.Contains(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene not found in the array: " + sceneName);
        }
    }

    public void LoadRandomAlternativeScene(string baseSceneName)
    {
        if (alternativeScenes.ContainsKey(baseSceneName))
        {
            List<string> scenes = alternativeScenes[baseSceneName];
            int randomIndex = Random.Range(0, scenes.Count);
            SceneManager.LoadScene(scenes[randomIndex]);
        }
        else
        {
            Debug.LogError("No alternative scenes found for: " + baseSceneName);
        }
    }
}    