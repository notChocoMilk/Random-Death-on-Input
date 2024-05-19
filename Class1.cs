// seein' as you downloaded the source code for a mod this simple, you probably need help explaining what all of this does. i left some comments for help :3

using UnityEngine;
using UnityEngine.SceneManagement;
using MelonLoader;

namespace ExampleModThingy
{
    public class Class1 : MelonMod
    {
        // these are the variables specified at the start of the script. data is assigned to these later.
        private GameObject player;
        private healthsystem healthSystem;

        // runs when the game starts
        public override void OnApplicationStart()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // this looks for the 'Player' object in the scene when loaded, then assigns it to the variable.
            player = GameObject.Find("Player");

            /*
             * if the player turns out to exist,
             * it grabs the health system on the player (manages the player health)
             * & assigns it to the 'healthSystem' variable for later usage.
             * using variables is good practice to save performance, as using gameobject.find every frame isn't a good idea.
            */

            if (player != null)
            {
                healthSystem = player.GetComponent<healthsystem>();
            }
        }

        // this is run every frame.. foreverrrrrrr~
        public override void OnUpdate()
        {
            // checks if the player & health system exist
            if (player != null && healthSystem != null)
            {
                // if it makes it to this point, both exist. it then checks for any input.
                if (Input.anyKeyDown)
                {
                    // grabs a random number & assigns it to a variable
                    int randomNumber = UnityEngine.Random.Range(9, 1001);

                    // if the number is 9 (it can be anything, i just chose it bc it's my favorite :3), it will advance, else it does nothing.
                    if (randomNumber == 9)
                    {
                        // this is the last thing it does! if it makes it to this point, it sets the player health to zero, killing them instantly.
                        healthSystem.Health = -10;
                        /*
                        update here! turns out, there was a bug in the last release. the player wouldn't actually die, as they would just heal back to 5hp instantly!
                        i've modified it to set the health to -10 to make SURE they're dead. i'm too lazy to recompile it, so the bug will still be there in the release dll on github..
                        */
                    }
                }
            }
        }
    }
}