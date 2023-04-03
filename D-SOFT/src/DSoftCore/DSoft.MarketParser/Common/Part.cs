﻿using DSoft.Common.Shared.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace DSoft.MarketParser.Common;

public class Part 
{
    [DataMember(Name = "name")]
    public string Name { get; set; }
    [DataMember(Name = "type")]
    [DefaultValue(CSValueType.String)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
    public CSValueType Type { get; set; }
    [DataMember(Name = "Format")]
    public string Format { get; set; }
    [DataMember(Name = "Desc")]
    public string Desc { get; set; }
    [DataMember(Name = "optional")]
    public bool IsOptional { get; set; }
    [DataMember(Name = "length")]
    public int Length { get; set; }
    [DataMember(Name = "tag")]
    [DefaultValue(0)]
    public int Tag { get; set; }
}    

