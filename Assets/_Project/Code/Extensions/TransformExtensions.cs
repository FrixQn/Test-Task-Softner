using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject.Extensions
{
    public static class TransformExtensions
    {
        private static readonly System.Random Random = new();

        public static void ShuffleChildrens(this Transform parent)
        {
            List<Transform> children = new();
            foreach (Transform child in parent)
            {
                children.Add(child);
            }

            int n = children.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);

                int siblingIndex1 = children[k].GetSiblingIndex();
                int siblingIndex2 = children[n].GetSiblingIndex();

                children[k].SetSiblingIndex(siblingIndex2);
                children[n].SetSiblingIndex(siblingIndex1);

                (children[k], children[n]) = (children[n], children[k]);
            }
        }
    }
}
