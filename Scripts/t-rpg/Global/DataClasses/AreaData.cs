using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPG.Global.DataClasses.GuiClasses;
using UnityEngine;

namespace TRPG.Global.DataClasses
{
    public static class AreaData
    {
        public static Func<Vector2, int, Vector2, int, int, int, int, List<Vector2>> getAreaTypeFunc(AreaType type)
        {
            switch (type)
            {
                case AreaType.Circle:
                    return AreaData.getCircleArea;
                case AreaType.Cross:
                    return AreaData.getCrossArea;
                case AreaType.Line: 
                    return AreaData.getLineArea;
                case AreaType.CenterLine: 
                    return AreaData.getCenterLineArea;
                case AreaType.Single:
                    return AreaData.getSingleArea;
                case AreaType.Square: 
                    return AreaData.getSquareArea;
                default: 
                    return null;
            }
        }

        public static List<Vector2> getCircleArea(Vector2 center, int range, Vector2 direction, int xMin, int xMax, int yMin, int yMax)
        {
            List<Vector2> result = new List<Vector2>();
            for(int y = -range; y <= range; y++)
            {
                for(int x = -range + (int)MathF.Abs(y); x <= range - (int)MathF.Abs(y); x++)
                {
                    Vector2 res = new Vector2(center.x + x, center.y + y);
                    if (res.x <= xMax && res.x >= xMin && res.y <= yMax && res.y >= yMin)
                        result.Add(res);
                }
            }
            return result;
        }

        public static List<Vector2> getCrossArea(Vector2 center, int range, Vector2 direction, int xMin, int xMax, int yMin, int yMax)
        {
            List<Vector2> result = new List<Vector2>();
            for (int i = -range; i <= range; i++)
            {
                if(center.x + i <= xMax && center.x + i >= xMin)
                    result.Add(new Vector2(center.x + i, center.y));
                if(center.y + i <= yMax && center.y + i >= yMin)
                    result.Add(new Vector2(center.x, center.y + i));
            }
            return result;
        }

        public static List<Vector2> getLineArea(Vector2 center, int range, Vector2 direction, int xMin, int xMax, int yMin, int yMax)
        {
            List<Vector2> result = new List<Vector2>();
            for(int i = 1; i <= range; i++)
            {
                Vector2 res = center + i * direction;
                if (res.x <= xMax && res.x >= xMin && res.y <= yMax && res.y >= yMin)
                    result.Add(res);
            }
            return result;
        }

        public static List<Vector2> getCenterLineArea(Vector2 center, int range, Vector2 direction, int xMin, int xMax, int yMin, int yMax)
        {
            List<Vector2> result = new List<Vector2>();
            for (int i = -range; i <= range; i++)
            {
                Vector2 res = center + i * direction;
                if (res.x <= xMax && res.x >= xMin && res.y <= yMax && res.y >= yMin)
                    result.Add(res);
            }
            return result;
        }

        public static List<Vector2> getSingleArea(Vector2 center, int range, Vector2 direction, int xMin, int xMax, int yMin, int yMax)
        {
            return new List<Vector2> { center };
        }

        public static List<Vector2> getSquareArea(Vector2 center, int range, Vector2 direction, int xMin, int xMax, int yMin, int yMax)
        {
            List<Vector2> result = new List<Vector2>();
            for(int y = -range; y <= range; y++)
            {
                for(int x = -range; x <= range; x++)
                {
                    Vector2 res = new Vector2(center.x + x, center.y + y);
                    if (res.x <= xMax && res.x >= xMin && res.y <= yMax && res.y >= yMin)
                        result.Add(res);
                }
            }
            return result;
        }

        public static Sprite getAreaGUISprite(AreaType type)
        {
            switch(type)
            {
                case AreaType.Circle:
                    return GUIData.AOECircleSprite;
                case AreaType.Cross:
                    return GUIData.AOECrossSprite;
                case AreaType.Line:
                    return GUIData.AOELineSprite;
                case AreaType.CenterLine:
                    return GUIData.AOECenterLineSprite;
                case AreaType.Single:
                    return GUIData.AOESingleSprite;
                case AreaType.Square:
                    return GUIData.AOESquareSprite;
                default:
                    return SpritesData.noTexture;
            }
        }
    }

    public enum AreaType
    {
        Circle = 0,
        Cross = 1,
        Line = 2,
        CenterLine = 3,
        Single = 4,
        Square = 5,
        Triangle = 6,
        CrossDiagonal = 7
    }
}
