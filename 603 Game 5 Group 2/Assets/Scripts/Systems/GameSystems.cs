using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems {
    static class SystemVariables {
        private static string[] Names = new[] { "Jessie", "Cleo", "Madison", "Angel", "Sam", "Jamie", "Franke", "Dakota", "Alexis", "Chris", "Charlie" };
        /// <summary>
        /// Returns a random name
        /// </summary>
        /// <returns></returns>
        public static string GetName() {
            // Get random int
            int index = Random.Range(0, Names.Length);

            // Return the name
            return Names[index];
        }

        /// <summary>
        /// Returns a title based off the given stat block
        /// </summary>
        /// <param name="statBlock"></param>
        /// <returns></returns>
        public static string GetTitle(int[] stats) {
            // Set stat threshold
            int threshold = 5;
            if(stats[0] >= threshold && stats[1] >= threshold && stats[2] >= threshold) {
                // +STR +DEX +INT
                return "Prodigy";
            } else if(stats[0] >= threshold && stats[1] >= threshold && stats[2] < threshold) {
                // +STR +DEX
                return "Gymnist";
            } else if(stats[0] >= threshold && stats[1] < threshold && stats[2] >= threshold) {
                // +STR +INT
                return "Scholar Athelete";
            } else if(stats[0] < threshold && stats[1] >= threshold && stats[2] >= threshold) {
                // +DEX +INT
                return "Gamer";
            } else if(stats[0] >= threshold && stats[1] < threshold && stats[2] < threshold) {
                // +STR
                return "Meathead";
            } else if(stats[0] < threshold && stats[1] >= threshold && stats[2] < threshold) {
                // +DEX
                return "Pickpocket";
            } else if(stats[0] < threshold && stats[1] < threshold && stats[2] >= threshold) {
                // +INT
                return "Librarian";
            } else {
                // +NONE
                return "Citizen";
            }
        }
    }

    public class Party {
        // Variables & Properties
        private List<Person> people;
        public List<Person> People {
            get { return people; }
        }

        private List<Equipment> unequippedEquipment;
        public List<Equipment> UnequippedEquipment {
            get { return unequippedEquipment; }
        }

        // Constructors
        public Party() {
            // Init variables
            people = new List<Person>();
            unequippedEquipment = new List<Equipment>();
        }

        // Methods
        /// <summary>
        /// Adds the given Person to the party
        /// </summary>
        /// <param name="p"></param>
        public void Hire(Person p) {
            people.Add(p);
        }
    }

    public class Person {
        // Variables & Properties
        private string name;
        /// <summary>
        /// Name of the Person
        /// </summary>
        public string Name {
            get { return name; }
        }

        private string title;
        /// <summary>
        /// Job title / description. Indicative of stats
        /// </summary>
        public string Title {
            get { return title; }
        }

        private int[] stats;
        /// <summary>
        /// Person stats. [Strength, Dexterity, Intelligence]
        /// </summary>
        public int[] Stats {
            get { return stats; } }
        public int Strength {
            get { return stats[0]; } }
        public int Dexterity {
            get { return stats[1]; } }
        public int Intelligence {
            get { return stats[2]; }
        }

        private Equipment heldEquipment = null;
        /// <summary>
        /// The currently held piece of Equipment
        /// </summary>
        public Equipment HeldEquipment {
            get { return heldEquipment; }
        }

        private Sprite image = null;
        /// <summary>
        /// The image used to display what this is
        /// </summary>
        public Sprite Image {
            get { return image; }
            set { image = value; }
        }

        // Constructors
        public Person() {
            // Get name
            name = SystemVariables.GetName();

            // Build stat block
            stats = new int[3];
            for(int i = 0; i < stats.Length; i++) { stats[i] = 0; }
            int pointBuys = Random.Range(10, 19);
            while(pointBuys > 0) {
                // Allocate stat
                int statToIncrease = Random.Range(0, stats.Length);
                stats[statToIncrease]++;

                // Decrement pointBuys
                pointBuys--;
            }

            // Get title
            title = SystemVariables.GetTitle(stats);

            // Get image
            int imageIndex = Random.Range(0, GameManager.Instance.PlayerSprites.Count);
            image = GameManager.Instance.PlayerSprites[imageIndex];
        }

        // Methods
        /// <summary>
        /// Roll all the stats randomly to see if they pass a challenge threshold. Affected by randomness, stats, and Equipment. [Strength, Dexterity, Intelligence]
        /// </summary>
        /// <returns></returns>
        public int[] RollStats() {
            // Build the score array
            int[] statScores = new int[stats.Length];

            // Build each score
            for(int i = 0; i < statScores.Length; i++) {
                if(heldEquipment == null) {
                    // No Equipment equipped
                    statScores[i] = stats[i] + Random.Range(1, 7);
                } else {
                    // Equipment equipped
                    statScores[i] = stats[i] + Random.Range(1, 7) + heldEquipment.StatImprovements[i];
                }
            }

            // Return the scores
            return statScores;
        }

        /// <summary>
        /// Requips the person with the given equipment
        /// </summary>
        /// <param name="e"></param>
        /// <returns>If the equipment was successfully equipped</returns>
        public bool Equip(Equipment e) {
            if(heldEquipment == null) {
                heldEquipment = e;
                return true;
            } else {
                return false;
            }
        }
    }

    public class Equipment {
        // Variables & Properties
        private string name;
        /// <summary>
        /// Name of the Equipment
        /// </summary>
        public string Name {
            get { return name; }
        }

        private int[] statImprovements;
        /// <summary>
        /// The way that this Equipment affects Person stats. [Strength, Dexterity, Intelligence]
        /// </summary>
        public int[] StatImprovements {
            get { return statImprovements; }
        }

        private Sprite image = null;
        /// <summary>
        /// The image used to display what this is
        /// </summary>
        public Sprite Image {
            get { return image; }
            set { image = value; }
        }

        // Constructors
        public Equipment(string name, int[] statImprovements) {
            this.name = name;
            this.statImprovements = statImprovements;
        }

        public Equipment(string name, int[] statImprovements, Sprite image) {
            this.name = name;
            this.statImprovements = statImprovements;
            this.image = image;
        }
    }
}


