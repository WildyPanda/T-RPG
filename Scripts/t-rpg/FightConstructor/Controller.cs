using System.Collections.Generic;
using UnityEngine;
using TRPG.Global.PlayerClasses.Util;
using TRPG.Global.PlayerClasses;
using TRPG.FightConstructor.CatalogClasses;
using TRPG.Global.CreatureClasses;
using TRPG.Global.SpiritClasses;
using TRPG.Global.SkillClasses;
using TRPG.Global.DataClasses;
using TRPG.Global.BuffClasses;
using TRPG.Global.StatsClasses;
using TRPG.Global.SkillClasses.SkillEffects;
using System;
using TRPG.Global.SkillClasses.SkillTrees;
using UnityEngine.UI;
using TRPG.Global.SkillClasses.SkillPotentials;
using TRPG.Global.CreatureClasses.Creatures;
using TRPG.Global.SpiritClasses.Spirits;
using System.Reflection;
using TMPro;

namespace TRPG.FightConstructor
{
    public class Controller : MonoBehaviour
    {
        private List<PlayerController> team1;
        private List<PlayerController> team2;

        private PlayerController actPlayerController;
        private bool isNewPlayerController = true;

        private Canvas canvas;

        private GameObject CreatureSpiritEditor;
        private GameObject CreatureSpiritInventory;
        private GameObject PlayerEditor;
        private GameObject PlayerControllerInformation;

        private GameObject CreatureCatalogObject;
        private Catalog<Creature> CreatureCatalog;
        private GameObject SpiritCatalogObject;
        private Catalog<Spirit> SpiritCatalog;
        private int actCatalog;

        public static Element[] elements2;

        public void Start()
        {
            /// BEFORE EVERYTHINGS
            this.setUp();
            ClassesIdVerifier.AllIdentifiableVerifier(false);
            /// BEFORE EVERYTHINGS


            Creature c1 = new Fox();
            Creature c2 = new Eagle();
            Spirit s1 = new FoxSpirit();
            Spirit s2 = new RacoonSpirit();

            this.actPlayerController.AddCreature(c1);
            this.actPlayerController.AddCreature(c2);
            this.actPlayerController.AddSpirit(s1);
            this.actPlayerController.AddSpirit(s2);

            this.updateCreatureInventory();
            this.updateSpiritInventory();
            this.updatePlayerControllerInformation();

            CatalogChange(0);
        }

        private void setUp()
        {
            this.canvas = this.transform.GetChild(0).GetComponent<Canvas>();
            this.CreatureSpiritEditor = this.transform.GetChild(0).GetChild(2).gameObject;
            this.CreatureSpiritInventory = this.CreatureSpiritEditor.transform.GetChild(1).gameObject;
            this.PlayerEditor = this.transform.GetChild(0).GetChild(3).gameObject;
            this.PlayerControllerInformation = this.transform.GetChild(0).GetChild(1).gameObject;

            CreatureCatalogObject = CreatureSpiritEditor.transform.GetChild(2).GetChild(0).gameObject;
            SpiritCatalogObject = CreatureSpiritEditor.transform.GetChild(2).GetChild(1).gameObject;
            CreatureCatalog = new Catalog<Creature>(CreatureCatalogObject.transform.GetChild(0));
            SpiritCatalog = new Catalog<Spirit>(SpiritCatalogObject.transform.GetChild(0));
        }

        public void CatalogNext()
        {
            switch (actCatalog)
            {
                case 0:
                    CreatureCatalog.Next(); break;
                case 1:
                    SpiritCatalog.Next(); break;
            }
        }

        public void CatalogPrev()
        {
            switch (actCatalog)
            {
                case 0:
                    CreatureCatalog.Prev(); break;
                case 1:
                    SpiritCatalog.Prev(); break;
            }
        }

        public void CatalogChange(int catalogType)
        {
            switch (catalogType)
            {
                case 0:
                    CreatureCatalogObject.SetActive(true);
                    SpiritCatalogObject.SetActive(false);
                    actCatalog = 0;
                    break;
                case 1:
                    CreatureCatalogObject.SetActive(false);
                    SpiritCatalogObject.SetActive(true);
                    actCatalog = 1;
                    break;
            }
        }

        public void showSkillPotential(SkillPotential sp)
        {
            sp.showGUI(this.canvas.transform);
        }

        public void updateInventory()
        {
            this.updateCreatureInventory();
            this.updateSpiritInventory();
        }

        public void updateCreatureInventory()
        {
            for (int i = 0; i < Data.maxCreatures; i++)
            {
                for(int o = 0; o < CreatureSpiritInventory.transform.GetChild(0).GetChild(i).childCount; o++)
                {
                    Destroy(CreatureSpiritInventory.transform.GetChild(0).GetChild(i).GetChild(o).gameObject);
                }
                if (i < this.actPlayerController.getNbCreatures())
                    this.actPlayerController.getCreature(i).toInventoryCell(CreatureSpiritInventory, i);
            }
        }

        public void updateSpiritInventory()
        {
            for (int i = 0; i < Data.maxSpirits; i++)
            {
                for (int o = 0; o < CreatureSpiritInventory.transform.GetChild(1).GetChild(i).childCount; o++)
                {
                    Destroy(CreatureSpiritInventory.transform.GetChild(1).GetChild(i).GetChild(o).gameObject);
                }
                if (i < this.actPlayerController.getNbSpirits())
                {
                    this.actPlayerController.getSpirit(i).toInventoryCell(CreatureSpiritInventory, i);
                }
            }
        }

        public void addSpirit()
        {
            Spirit spirit = SpiritCatalog.current();
            if(!this.actPlayerController.spiritIdExist(spirit.Id))
                this.actPlayerController.AddSpirit(spirit);
            this.updateSpiritInventory();
            this.updatePlayerControllerInformation();
        }

        public void removeSpirit(int index)
        {
            this.actPlayerController.removeSpirit(index);
            this.updateSpiritInventory();
            this.updatePlayerControllerInformation();
        }

        public void addCreature()
        {
            Creature creature = CreatureCatalog.current();
            if(!this.actPlayerController.creatureIdExist(creature.Id))
                this.actPlayerController.AddCreature(creature);
            this.updateCreatureInventory();
            this.updatePlayerControllerInformation();
        }

        public void removeCreature(int index)
        {
            this.actPlayerController.removeCreature(index);
            this.updateCreatureInventory();
            this.updatePlayerControllerInformation();
        }

        public void updatePlayerControllerInformation()
        {
            if (this.isNewPlayerController)
            {
                this.PlayerControllerInformation.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                this.PlayerControllerInformation.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                this.PlayerControllerInformation.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                this.PlayerControllerInformation.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            }
            this.PlayerControllerInformation.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.actPlayerController.getNbCreatures() + " / " + Data.maxCreatures;
            this.PlayerControllerInformation.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = this.actPlayerController.getNbSpirits() + " / " + Data.maxSpirits;
        }

        public void newPlayerController()
        {
            Player p = new Player("tempName", 0, new Stats(), new FighterSprites(true, "tempName"));
            this.actPlayerController = new PlayerController(p);
        }

        public void addToTeam(int team)
        {
            if(team == 1)
            {
                this.team1.Add(this.actPlayerController);
            }
            else
            {
                this.team2.Add(this.actPlayerController);
            }
            newPlayerController();
        }
    }
}

