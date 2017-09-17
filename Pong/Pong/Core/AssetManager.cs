﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Pong.Core
{
    public static class AssetManager
    {
        private static GenericDatabase database;
        public static ContentManager content;

        static AssetManager()
        {
            database = new GenericDatabase();
        }

        public static T GetResource<T>(string name)
        {
            if (content == null) return default(T);
            T res;
            if (database.GetData<T>(name, out res))
                return res;
            res = content.Load<T>(name);
            database.SetData<T>(name, res);
            return res;
        }
    }
}