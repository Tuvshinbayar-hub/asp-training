﻿using DesignAPI_DotNet8.Models.BaseModels;
using DesignAPI_DotNet8.Models.GobiColor;
using Org.BouncyCastle.Asn1.Mozilla;

namespace DesignAPI_DotNet8.Models.Colors
{
    public class ColorRecipe: BaseWithModified
    {
        public string Name { get; set; }
        public string? ColorComposition { get; set; }

        public float NaturalColorI { get; set; } = 0f;
        public float NaturalColorII { get; set; } = 0f;
        public float NaturalColorIII { get; set; } = 0f;
        public float NaturalColorIV { get; set; } = 0f;
        public float CamelWool { get; set; } = 0f;
        public float SheepWool { get; set; } = 0f;
        public float Cotton {  get; set; } = 0f;
        public float Silk { get; set; } = 0f;
        public bool IsDefault { get; set; } = true;

        public List<int>? PaintTypeIds { get; set; }
        public List<PaintType>? PaintTypes { get; set; }
    }
}
