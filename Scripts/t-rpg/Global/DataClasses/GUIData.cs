using UnityEngine;

namespace TRPG.Global.DataClasses.GuiClasses
{
    public static class GUIData
    {
        public static int maxShownPlayerOrder = 9;

        // Other
        public static Sprite parameterButtonSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Other/Parameter");
        public static Sprite characterButtonSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Other/Character");

        // StatsData
        public static Sprite actionBarSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Action");
        public static Sprite movementBarSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Movement");
        public static Sprite lifeBarSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Life");

        // SkillData
        public static Sprite skillBarSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Skill/Skills");
        public static Sprite emptySkillSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Skill/EmptySkill");
        public static Sprite increaseSkillLineSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Skill/upButton");
        public static Sprite decreaseSkillLineSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Skill/downButton");
        public static Sprite showSkillLineSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Skill/centerButton");

        // SpiritData
        public static Sprite spiritBarSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Spirit/Spirits");
        public static Sprite emptySpiritSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Spirit/EmptySpirit");

        // CreatureData
        public static Sprite creatureBarSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Creature/Creatures");
        public static Sprite emptyCreatureSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Creature/EmptyCreature");

        // CharacterOrderData
        public static Sprite actualFighterCasingSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/CharacterOrder/ActualFighterCasing");
        public static Sprite separatorSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/CharacterOrder/Separator");

        // GroundGUIData
        public static Sprite freeCellSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Ground/FreeCell");
        public static Sprite obstacleCellSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Ground/ObstacleCell");
        public static Sprite actionCellSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Ground/FreeCellAction");
        public static Sprite actionHoverCellSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Ground/FreeCellActionHover");
        public static Sprite movementCellSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Ground/FreeCellMovement");
        public static Sprite movementHoverCellSprite = Resources.Load<Sprite>("Sprites/GUI/FightGUI/Ground/FreeCellMovementHover");

        // SkillEffects
        public static Sprite AOECircleSprite = Resources.Load<Sprite>("Sprites/GUI/FightConstructorGUI/DATA/Skill/Effects/AOECircle");
        public static Sprite AOECenterLineSprite = Resources.Load<Sprite>("Sprites/GUI/FightConstructorGUI/DATA/Skill/Effects/AOECenterLine");
        public static Sprite AOECrossSprite = Resources.Load<Sprite>("Sprites/GUI/FightConstructorGUI/DATA/Skill/Effects/AOECross");
        public static Sprite AOELineSprite = Resources.Load<Sprite>("Sprites/GUI/FightConstructorGUI/DATA/Skill/Effects/AOELine");
        public static Sprite AOESingleSprite = Resources.Load<Sprite>("Sprites/GUI/FightConstructorGUI/DATA/Skill/Effects/AOESingle");
        public static Sprite AOESquareSprite = Resources.Load<Sprite>("Sprites/GUI/FightConstructorGUI/DATA/Skill/Effects/AOESquare");
        public static Sprite targetEnemyFSprite = Resources.Load<Sprite>("Sprites/GUI/FightConstructorGUI/DATA/Skill/Effects/enemyFireF");
        public static Sprite targetEnemyTSprite = Resources.Load<Sprite>("Sprites/GUI/FightConstructorGUI/DATA/Skill/Effects/enemyFireT");
        public static Sprite targetFriendFSprite = Resources.Load<Sprite>("Sprites/GUI/FightConstructorGUI/DATA/Skill/Effects/FriendFireF");
        public static Sprite targetFriendTSprite = Resources.Load<Sprite>("Sprites/GUI/FightConstructorGUI/DATA/Skill/Effects/FriendFireT");
        public static Sprite LosFSprite = Resources.Load<Sprite>("Sprites/GUI/FightConstructorGUI/DATA/Skill/Effects/LosF");
        public static Sprite LosTSprite = Resources.Load<Sprite>("Sprites/GUI/FightConstructorGUI/DATA/Skill/Effects/LosT");
    }


}
