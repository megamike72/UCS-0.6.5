﻿using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ucssceditor
{
    internal class ScObject
    {
        public ScObject()
        {
        }

        public virtual Bitmap GetBitmap()
        {
            return null;
        }

        public virtual List<ScObject> GetChildren()
        {
            return new List<ScObject>();
        }

        public virtual int GetDataType()
        {
            return -1;
        }

        public virtual string GetDataTypeName()
        {
            return null;
        }

        public virtual short GetId()
        {
            return -1;
        }

        public virtual string GetInfo()
        {
            return string.Empty;
        }

        public virtual string GetName()
        {
            return GetId().ToString();
        }

        public virtual bool IsImage()
        {
            return false;
        }

        public virtual void ParseData(BinaryReader br)
        {
        }

        public virtual Bitmap Render(RenderingOptions options)
        {
            return null;
        }

        public virtual void Save(FileStream input)
        {
        }
    }
}