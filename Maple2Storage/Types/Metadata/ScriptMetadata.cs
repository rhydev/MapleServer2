﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Maple2Storage.Types.Metadata
{
    [XmlType]
    public class ScriptMetadata
    {
        [XmlElement(Order = 1)]
        public bool IsQuestScript;
        [XmlElement(Order = 2)]
        public int Id;
        [XmlElement(Order = 3)]
        public Dictionary<int, Script> Scripts = new Dictionary<int, Script>();
        [XmlElement(Order = 4)]
        public Dictionary<int, Monologue> Monologues = new Dictionary<int, Monologue>();
        [XmlElement(Order = 5)]
        public Dictionary<int, Select> Selects = new Dictionary<int, Select>();

        public ScriptMetadata() { }

        public override string ToString()
        {
            string text = "";
            foreach (KeyValuePair<int, Script> kvp in Scripts)
            {
                text += ("\r\n" + kvp.Key + " = " + kvp.Value.ToString());
            }
            string text2 = "";
            foreach (KeyValuePair<int, Monologue> kvp in Monologues)
            {
                text2 += ("\r\n" + kvp.Key + " = " + kvp.Value.ToString());
            }
            string text3 = "";
            foreach (KeyValuePair<int, Select> kvp in Selects)
            {
                text3 += ("\r\n" + kvp.Key + " = " + kvp.Value.ToString());
            }

            return $"IsQuestScript: {IsQuestScript}, Id: {Id}, Scripts: ({text}), Monologues: ({text2}), Selects: ({text3})";
        }
    }

    [XmlType]
    public class Script
    {
        [XmlElement(Order = 1)]
        public int Id;
        [XmlElement(Order = 2)]
        public string Feature;
        [XmlElement(Order = 3)]
        public int RandomPick;
        [XmlElement(Order = 4)]
        public List<int> GoToConditionTalkID = new List<int>();
        [XmlElement(Order = 5)]
        public List<Content> Content = new List<Content>();

        public Script() { }

        public Script(int id, string feature, int randomPick, List<int> goToConditionTalkID, List<Content> content)
        {
            this.Id = id;
            this.Feature = feature;
            this.RandomPick = randomPick;
            this.GoToConditionTalkID = goToConditionTalkID;
            this.Content = content;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Feature: {Feature}, RandomPick: {RandomPick}, GoToConditionTalkID: ({string.Join(",", GoToConditionTalkID)}), Content: ({string.Join(",", Content)})\r\n";
        }
    }

    [XmlType]
    public class Select
    {
        [XmlElement(Order = 1)]
        public int Id;
        [XmlElement(Order = 2)]
        public List<Content> Content = new List<Content>();

        public Select() { }

        public Select(int id, List<Content> content)
        {
            this.Id = id;
            this.Content = content;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Content: ({string.Join(",", Content)})\r\n";
        }
    }

    [XmlType]
    public class Monologue
    {
        [XmlElement(Order = 1)]
        public int Id;
        [XmlElement(Order = 2)]
        public int PopupState;
        [XmlElement(Order = 3)]
        public int PopupProp;
        [XmlElement(Order = 4)]
        public List<Content> Content = new List<Content>();

        public Monologue() { }

        public Monologue(int id, int popupState, int popupProp, List<Content> content)
        {
            this.Id = id;
            this.PopupState = popupState;
            this.PopupProp = popupProp;
            this.Content = content;
        }

        public override string ToString()
        {
            return $"Id: {Id}, PopupState: {PopupState}, PopupProp: {PopupProp}, Content: ({string.Join(",", Content)})\r\n";
        }
    }

    [XmlType]
    public class Content
    {
        [XmlElement(Order = 1)]
        public long Script;
        [XmlElement(Order = 2)]
        public string VoiceId;
        [XmlElement(Order = 3)]
        public byte FunctionId;
        [XmlElement(Order = 4)]
        public string LeftIllust;
        [XmlElement(Order = 5)]
        public string SpeakerIllust;
        [XmlElement(Order = 6)]
        public int OtherNpcTalk;
        [XmlElement(Order = 7)]
        public bool MyTalk;
        [XmlElement(Order = 8)]
        public string Illust;
        [XmlElement(Order = 9)]
        public List<Distractor> Distractor = new List<Distractor>();

        public Content() { }

        public Content(long script, string voiceId, byte functionId, string leftIllust, string speakerIllust, int otherNpcTalk, bool myTalk, string illust, List<Distractor> distractor)
        {
            this.Script = script;
            this.VoiceId = voiceId;
            this.FunctionId = functionId;
            this.LeftIllust = leftIllust;
            this.SpeakerIllust = speakerIllust;
            this.OtherNpcTalk = otherNpcTalk;
            this.MyTalk = myTalk;
            this.Illust = illust;
            this.Distractor = distractor;
        }

        public override string ToString()
        {
            return $"Script: {Script}, VoiceId: {VoiceId}, FunctionId: {FunctionId}, LeftIllust: {LeftIllust}, SpeakerIllust: {SpeakerIllust}, " +
            $"OtherNpcTalk: {OtherNpcTalk}, MyTalk: {MyTalk}, Illust: {Illust}, Distractor: ({string.Join(",", Distractor)})\r\n";
        }
    }

    [XmlType]
    public class Distractor
    {
        [XmlElement(Order = 1)]
        public long Script;
        [XmlElement(Order = 2)]
        public List<int> GoTo = new List<int>();
        [XmlElement(Order = 3)]
        public List<int> GoToFail = new List<int>();

        public Distractor() { }

        public Distractor(long script, List<int> goTo, List<int> goToFail)
        {
            this.Script = script;
            this.GoTo = goTo;
            this.GoToFail = goToFail;
        }

        public override string ToString()
        {
            return $"Script: {Script}, GoTo: ({string.Join(",", GoTo)}), GoToFail: ({string.Join(",", GoToFail)})\r\n";
        }
    }

    [XmlType]
    public class Event
    {
        [XmlElement(Order = 1)]
        public int ID;
        [XmlElement(Order = 2)]
        public List<Content> Content = new List<Content>();

        public Event() { }

        public Event(int id, List<Content> content)
        {
            this.ID = id;
            this.Content = content;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Content: ({string.Join(",", Content)})\r\n";
        }
    }

}
