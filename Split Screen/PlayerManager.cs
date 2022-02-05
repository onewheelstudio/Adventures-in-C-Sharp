    using System.Collections.Generic;
    using UnityEngine;
    using Cinemachine;
    using UnityEngine.InputSystem;

    public class PlayerManager : MonoBehaviour
    {
        [SerializeField]
        private List<PlayerInput> players;
        [SerializeField]
        private List<Transform> startingPoints;
        [SerializeField]
        private List<LayerMask> playerLayers;

        private PlayerInputManager playerInputManager;

        private void Awake()
        {
            playerInputManager = FindObjectOfType<PlayerInputManager>();
        }

        private void OnEnable()
        {
            playerInputManager.onPlayerJoined += AddPlayer;
        }

        private void OnDisable()
        {
            playerInputManager.onPlayerJoined -= AddPlayer;
        }

        public void AddPlayer(PlayerInput player)
        {
            players.Add(player);

            //need to use the parent due to the structure of the prefab
            Transform playerParent = player.transform.parent;
            playerParent.position = startingPoints[players.Count - 1].position;

            //convert layer mask (bit) to an integer 
            int layerToAdd = (int)Mathf.Log(playerLayers[players.Count - 1].value, 2);

            //set the layer
            playerParent.GetComponentInChildren<CinemachineFreeLook>().gameObject.layer = layerToAdd;
            //add the layer
            playerParent.GetComponentInChildren<Camera>().cullingMask |= 1 << layerToAdd;

            playerParent.GetComponentInChildren<CinemachineInputHandler>().look = player.actions.FindAction("Look");

        }
    }


