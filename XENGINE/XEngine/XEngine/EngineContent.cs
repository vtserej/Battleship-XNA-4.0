using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Xengine
{
    public static class EngineContent
    {
        #region Private Atributes

        //general;
        static string contentRoot;

        //textures
        static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        static List<string> textureNames = new List<string>();
        static string textureDir;

        //models
        static Dictionary<string, Model> models = new Dictionary<string, Model>();
        static List<string> modelNames = new List<string>();
        static string modelDir;

        //effects
        static Dictionary<string, Effect> effects = new Dictionary<string, Effect>();
        static List<string> effectNames = new List<string>();
        static string effectDir;

        //texture cubes
        static Dictionary<string, TextureCube> textureCubes = new Dictionary<string, TextureCube>();
        static List<string> textureCubeNames = new List<string>();
        static string textureCubeDir;


        #endregion

        #region Properties

        public static string ContentRoot
        {
            get { return EngineContent.contentRoot; }
            set { EngineContent.contentRoot = value; }
        }

        #endregion

        #region Texture Functions

        /// <summary>
        /// This method loads all the texture path from a specified folder
        /// </summary>
        static public void SetTextureList(string texDir)
        {
            textureDir = texDir;
            string[] texturePaths = Directory.GetFiles(contentRoot + "\\" + textureDir, "*.xnb");
            foreach (var item in texturePaths)
            {
                textureNames.Add(Helper.GetNameFromPath(item));   
            }

         }

        /// <summary>
        /// This method returns the openGL id for the texture wanted
        /// </summary>
        public static Texture2D GetTextureByName(string name)
        {
            if (textures.ContainsKey(name))
            {
                return textures[name];
            }
            
            return null;
        }

        /// <summary>
        /// This method load all the textures
        /// </summary>
        public static void LoadTextures()
        {
            foreach (var item in textureNames)
            {
                textures.Add(item, DxManager.Game.Content.Load<Texture2D>(textureDir + item));
            }
        }

        #endregion

        #region Model Functions

        /// <summary>
        /// This method loads all the models path from a specified folder
        /// </summary>
        public static void SetModelList(string modDir)
        {
            modelDir = modDir;
            string[] modelPaths = Directory.GetFiles(contentRoot + "\\" + modelDir, "*.xnb");
            List<string> f = new List<string>(modelPaths); 
            foreach (var item in modelPaths)
            {
                modelNames.Add(Helper.GetNameFromPath(item));
            }
        }

        /// <summary>
        /// This method loads a single model
        /// </summary>
        public static Model LoadModel(string file)
        {
            return DxManager.Game.Content.Load<Model>(file);
        }

        /// <summary>
        /// This method loads all the models
        /// </summary>
        public static void LoadModels()
        {
            foreach (var item in modelNames)
            {
             models.Add(item, DxManager.Game.Content.Load<Model>(modelDir + item)); 
            }
        }

        /// <summary>
        /// This method returns the model whoose name has been specified
        /// </summary>
        public static Model GetModelByName(string name)
        {
            name += "_0";
            if (models.ContainsKey(name))
            {
                return models[name];
            }
            return null;
        }

        #endregion

        #region Effect Functions

        /// <summary>
        /// This method loads all the models path from a specified folder
        /// </summary>
        public static void SetEffectList(string effDir)
        {
            effectDir = effDir;
            string[] effectPaths = Directory.GetFiles(contentRoot + "\\" + effectDir, "*.xnb");
            foreach (var item in effectPaths)
            {
                effectNames.Add(Helper.GetNameFromPath(item));
            }
        }

        /// <summary>
        /// This method loads all the models
        /// </summary>
        public static void LoadEffects()
        {
            foreach (var item in effectNames)
            {
                effects.Add(item, DxManager.Game.Content.Load<Effect>(effectDir + item));
            }
        }

        /// <summary>
        /// This method returns the model whoose name has been specified
        /// </summary>
        public static Effect GetEffectByName(string name)
        {
            if (effects.ContainsKey(name))
            {
                return effects[name];
            }
            return null;
        }

        #endregion

        #region Texture Cube Functions

        /// <summary>
        /// This method loads all the texture path from a specified folder
        /// </summary>
        static public void SetTextureCubeList(string texCubeDir)
        {
            textureCubeDir = texCubeDir;
            string[] textureCubePaths = Directory.GetFiles(contentRoot + "\\" + textureCubeDir, "*.xnb");
            foreach (var item in textureCubePaths)
            {
                textureCubeNames.Add(Helper.GetNameFromPath(item));
            }

        }

        /// <summary>
        /// This method returns the openGL id for the texture wanted
        /// </summary>
        public static TextureCube GetTextureCubeByName(string name)
        {
            if (textureCubes.ContainsKey(name))
            {
                return textureCubes[name];
            }

            return null;
        }

        /// <summary>
        /// This method load all the textures
        /// </summary>
        public static void LoadTextureCube()
        {
            foreach (var item in textureCubeNames)
            {
                textureCubes.Add(item, DxManager.Game.Content.Load<TextureCube>(textureCubeDir + item));
            }
        }

        #endregion
    }
}
