using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Warframe_ReBa_Farmer
{
    class Module_Data
    {
        //https://github.com/WFCD/warframe-worldstate-data/tree/master/data
        //https://n8k6e2y6.ssl.hwcdn.net/repos/hnfvc0o3jnfvc873njb03enrf56.html
        //https://tenno.zone/drops


        public static void DataModule_Initialize()
        {
            //GetSolarNodeData();
            //GetRelicDropData();
            Initialize_Translator_SolarNode();
            Initialize_FissureTranslator();
            Initialize_RelicData();
            PrimeItemData_Load();
            GetFissureData();
            GetBaroData();
            //PrimeItemDictionary();
        }


        #region Solar Nodes

        public static void GetSolarNodeData()
        {
            JObject JSONHolder;
            using (WebClient TempWebClient = new WebClient())
            {
                TempWebClient.Encoding = Encoding.UTF8;
                JSONHolder = JObject.Parse(TempWebClient.DownloadString("https://raw.githubusercontent.com/WFCD/warframe-worldstate-data/master/data/solNodes.json"));
            }                       
            foreach (KeyValuePair<string,JToken> SolarNode in JSONHolder)
            {
                string NodeName = SolarNode.Value["value"].Value<string>();//.Replace(")", "");
                //if (NodeName.Contains("(")) { NodeName = NodeName.Substring(NodeName.IndexOf("(") + 1) + " - " + NodeName.Substring(0, NodeName.IndexOf("(") - 1); };
                Debug.Print(string.Format("Translator_SolarNode.Add(\"{0}\", new SolarNodeData( \"{1}\", \"{2}\", \"{3}\" ));", SolarNode.Key, NodeName, SolarNode.Value["enemy"], SolarNode.Value["type"]));
            }

        }

        public static Dictionary<string, SolarNodeData> Translator_SolarNode = new Dictionary<string, SolarNodeData>();

        private static void Initialize_Translator_SolarNode()
        {
            Translator_SolarNode.Add("SolNode0", new SolarNodeData("SolNode0", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode1", new SolarNodeData("Galatea (Neptune)", "Corpus", "Capture"));
            Translator_SolarNode.Add("SolNode2", new SolarNodeData("Aphrodite (Venus)", "Corpus", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode3", new SolarNodeData("Cordelia (Uranus)", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode4", new SolarNodeData("Acheron (Pluto)", "Corpus", "Exterminate"));
            Translator_SolarNode.Add("SolNode5", new SolarNodeData("Perdita (Uranus)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode6", new SolarNodeData("Despina (Neptune)", "Corpus", "Excavation"));
            Translator_SolarNode.Add("SolNode7", new SolarNodeData("Epimetheus (Saturn)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode8", new SolarNodeData("Nix (Pluto)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode9", new SolarNodeData("Rosalind (Uranus)", "Grineer", "Spy"));
            Translator_SolarNode.Add("SolNode10", new SolarNodeData("Thebe (Jupiter)", "Corpus", "Sabotage"));
            Translator_SolarNode.Add("SolNode11", new SolarNodeData("Tharsis (Mars)", "Corpus", "Hijack"));
            Translator_SolarNode.Add("SolNode12", new SolarNodeData("Elion (Mercury)", "Grineer", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode13", new SolarNodeData("Bianca (Uranus)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode14", new SolarNodeData("Ultor (Mars)", "Crossfire", "Exterminate"));
            Translator_SolarNode.Add("SolNode15", new SolarNodeData("Pacific (Earth)", "Grineer", "Rescue"));
            Translator_SolarNode.Add("SolNode16", new SolarNodeData("Augustus (Mars)", "Grineer", "Excavation"));
            Translator_SolarNode.Add("SolNode17", new SolarNodeData("Proteus (Neptune)", "Corpus", "Defense"));
            Translator_SolarNode.Add("SolNode18", new SolarNodeData("Rhea (Saturn)", "Grineer", "Interception"));
            Translator_SolarNode.Add("SolNode19", new SolarNodeData("Enceladus (Saturn)", "Grineer", "Sabotage"));
            Translator_SolarNode.Add("SolNode20", new SolarNodeData("Telesto (Saturn)", "Grineer", "Exterminate"));
            Translator_SolarNode.Add("SolNode21", new SolarNodeData("Narcissus (Pluto)", "Corpus", "Exterminate"));
            Translator_SolarNode.Add("SolNode22", new SolarNodeData("Tessera (Venus)", "Corpus", "Defense"));
            Translator_SolarNode.Add("SolNode23", new SolarNodeData("Cytherean (Venus)", "Corpus", "Interception"));
            Translator_SolarNode.Add("SolNode24", new SolarNodeData("Oro (Earth)", "Grineer", "Assassination"));
            Translator_SolarNode.Add("SolNode25", new SolarNodeData("Callisto (Jupiter)", "Corpus", "Interception"));
            Translator_SolarNode.Add("SolNode26", new SolarNodeData("Lith (Earth)", "Grineer", "Defense"));
            Translator_SolarNode.Add("SolNode27", new SolarNodeData("E Prime (Earth)", "Grineer", "Exterminate"));
            Translator_SolarNode.Add("SolNode28", new SolarNodeData("M Prime (Mercury)", "Crossfire", "Exterminate"));
            Translator_SolarNode.Add("SolNode29", new SolarNodeData("Oberon (Uranus)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode30", new SolarNodeData("Olympus (Mars)", "Grineer", "Disruption"));
            Translator_SolarNode.Add("SolNode31", new SolarNodeData("Anthe (Saturn)", "Grineer", "Rescue"));
            Translator_SolarNode.Add("SolNode32", new SolarNodeData("Tethys (Saturn)", "Grineer", "Assassination"));
            Translator_SolarNode.Add("SolNode33", new SolarNodeData("Ariel (Uranus)", "Grineer", "Sabotage"));
            Translator_SolarNode.Add("SolNode34", new SolarNodeData("Sycorax (Uranus)", "Grineer", "Exterminate"));
            Translator_SolarNode.Add("SolNode35", new SolarNodeData("Arcadia (Mars)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode36", new SolarNodeData("Martialis (Mars)", "Grineer", "Rescue"));
            Translator_SolarNode.Add("SolNode37", new SolarNodeData("Pallene (Saturn)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode38", new SolarNodeData("Minthe (Pluto)", "Corpus", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode39", new SolarNodeData("Everest (Earth)", "Grineer", "Excavation"));
            Translator_SolarNode.Add("SolNode40", new SolarNodeData("Prospero (Uranus)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode41", new SolarNodeData("Arval (Mars)", "Grineer", "Spy"));
            Translator_SolarNode.Add("SolNode42", new SolarNodeData("Helene (Saturn)", "Grineer", "Defense"));
            Translator_SolarNode.Add("SolNode43", new SolarNodeData("Cerberus (Pluto)", "Corpus", "Interception"));
            Translator_SolarNode.Add("SolNode44", new SolarNodeData("Mimas (Saturn)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode45", new SolarNodeData("Ara (Mars)", "Grineer", "Capture"));
            Translator_SolarNode.Add("SolNode46", new SolarNodeData("Spear (Mars)", "Grineer", "Defense"));
            Translator_SolarNode.Add("SolNode47", new SolarNodeData("Janus (Saturn)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode48", new SolarNodeData("Regna (Pluto)", "Corpus", "Rescue"));
            Translator_SolarNode.Add("SolNode49", new SolarNodeData("Larissa (Neptune)", "Corpus", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode50", new SolarNodeData("Numa (Saturn)", "Grineer", "Rescue"));
            Translator_SolarNode.Add("SolNode51", new SolarNodeData("Hades (Pluto)", "Corpus", "Assassination"));
            Translator_SolarNode.Add("SolNode52", new SolarNodeData("Portia (Uranus)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode53", new SolarNodeData("Themisto (Jupiter)", "Corpus", "Assassination"));
            Translator_SolarNode.Add("SolNode54", new SolarNodeData("Silvanus (Mars)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode55", new SolarNodeData("Methone (Saturn)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode56", new SolarNodeData("Cypress (Pluto)", "Corpus", "Sabotage"));
            Translator_SolarNode.Add("SolNode57", new SolarNodeData("Sao (Neptune)", "Corpus", "Sabotage"));
            Translator_SolarNode.Add("SolNode58", new SolarNodeData("Hellas (Mars)", "Grineer", "Exterminate"));
            Translator_SolarNode.Add("SolNode59", new SolarNodeData("Eurasia (Earth)", "Grineer", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode60", new SolarNodeData("Caliban (Uranus)", "Grineer", "Rescue"));
            Translator_SolarNode.Add("SolNode61", new SolarNodeData("Ishtar (Venus)", "Corpus", "Sabotage"));
            Translator_SolarNode.Add("SolNode62", new SolarNodeData("Neso (Neptune)", "Corpus", "Exterminate"));
            Translator_SolarNode.Add("SolNode63", new SolarNodeData("Mantle (Earth)", "Grineer", "Capture"));
            Translator_SolarNode.Add("SolNode64", new SolarNodeData("Umbriel (Uranus)", "Grineer", "Interception"));
            Translator_SolarNode.Add("SolNode65", new SolarNodeData("Gradivus (Mars)", "Corpus", "Sabotage"));
            Translator_SolarNode.Add("SolNode66", new SolarNodeData("Unda (Venus)", "Corpus", "Spy"));
            Translator_SolarNode.Add("SolNode67", new SolarNodeData("Dione (Saturn)", "Grineer", "Spy"));
            Translator_SolarNode.Add("SolNode68", new SolarNodeData("Vallis (Mars)", "Grineer", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode69", new SolarNodeData("Ophelia (Uranus)", "Grineer", "Survival"));
            Translator_SolarNode.Add("SolNode70", new SolarNodeData("Cassini (Saturn)", "Grineer", "Capture"));
            Translator_SolarNode.Add("SolNode71", new SolarNodeData("Vesper (Venus)", "Corpus", "Spy"));
            Translator_SolarNode.Add("SolNode72", new SolarNodeData("Outer Terminus (Pluto)", "Corpus", "Defense"));
            Translator_SolarNode.Add("SolNode73", new SolarNodeData("Ananke (Jupiter)", "Corpus", "Capture"));
            Translator_SolarNode.Add("SolNode74", new SolarNodeData("Carme (Jupiter)", "Corpus", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode75", new SolarNodeData("Cervantes (Earth)", "Grineer", "Sabotage"));
            Translator_SolarNode.Add("SolNode76", new SolarNodeData("Hydra (Pluto)", "Corpus", "Capture"));
            Translator_SolarNode.Add("SolNode77", new SolarNodeData("Cupid (Uranus)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode78", new SolarNodeData("Triton (Neptune)", "Corpus", "Rescue"));
            Translator_SolarNode.Add("SolNode79", new SolarNodeData("Cambria (Earth)", "Grineer", "Spy"));
            Translator_SolarNode.Add("SolNode80", new SolarNodeData("Phoebe (Saturn)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode81", new SolarNodeData("Palus (Pluto)", "Corpus", "Survival"));
            Translator_SolarNode.Add("SolNode82", new SolarNodeData("Calypso (Saturn)", "Grineer", "Sabotage"));
            Translator_SolarNode.Add("SolNode83", new SolarNodeData("Cressida (Uranus)", "Grineer", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode84", new SolarNodeData("Nereid (Neptune)", "Corpus", "Hijack"));
            Translator_SolarNode.Add("SolNode85", new SolarNodeData("Gaia (Earth)", "Grineer", "Interception"));
            Translator_SolarNode.Add("SolNode86", new SolarNodeData("Aegaeon (Saturn)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode87", new SolarNodeData("Ganymede (Jupiter)", "Corpus", "Disruption"));
            Translator_SolarNode.Add("SolNode88", new SolarNodeData("Adrastea (Jupiter)", "Corpus", "Spy"));
            Translator_SolarNode.Add("SolNode89", new SolarNodeData("Mariana (Earth)", "Grineer", "Exterminate"));
            Translator_SolarNode.Add("SolNode90", new SolarNodeData("Miranda", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode91", new SolarNodeData("Iapetus (Saturn)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode92", new SolarNodeData("Charon (Pluto)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode93", new SolarNodeData("Keeler (Saturn)", "Grineer", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode94", new SolarNodeData("Apollodorus (Mercury)", "Infested", "Survival"));
            Translator_SolarNode.Add("SolNode95", new SolarNodeData("Thalassa (Neptune)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode96", new SolarNodeData("Titan (Saturn)", "Grineer", "Survival"));
            Translator_SolarNode.Add("SolNode97", new SolarNodeData("Amalthea (Jupiter)", "Corpus", "Spy"));
            Translator_SolarNode.Add("SolNode98", new SolarNodeData("Desdemona (Uranus)", "Grineer", "Capture"));
            Translator_SolarNode.Add("SolNode99", new SolarNodeData("War (Mars)", "Grineer", "Assassinate"));
            Translator_SolarNode.Add("SolNode100", new SolarNodeData("Elara (Jupiter)", "Corpus", "Survival"));
            Translator_SolarNode.Add("SolNode101", new SolarNodeData("Kiliken (Venus)", "Corpus", "Excavation"));
            Translator_SolarNode.Add("SolNode102", new SolarNodeData("Oceanum (Pluto)", "Corpus", "Spy"));
            Translator_SolarNode.Add("SolNode103", new SolarNodeData("Terminus (Mercury)", "Grineer", "Capture"));
            Translator_SolarNode.Add("SolNode104", new SolarNodeData("Fossa (Venus)", "Corpus", "Assassinate"));
            Translator_SolarNode.Add("SolNode105", new SolarNodeData("Titania (Uranus)", "Grineer", "Assassination"));
            Translator_SolarNode.Add("SolNode106", new SolarNodeData("Alator (Mars)", "Grineer", "Interception"));
            Translator_SolarNode.Add("SolNode107", new SolarNodeData("Venera (Venus)", "Corpus", "Capture"));
            Translator_SolarNode.Add("SolNode108", new SolarNodeData("Tolstoj (Mercury)", "Grineer", "Assassinate"));
            Translator_SolarNode.Add("SolNode109", new SolarNodeData("Linea (Venus)", "Corpus", "Rescue"));
            Translator_SolarNode.Add("SolNode110", new SolarNodeData("Hyperion (Saturn)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode111", new SolarNodeData("Juliet (Uranus)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode112", new SolarNodeData("Setebos (Uranus)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode113", new SolarNodeData("Ares (Mars)", "Grineer", "Sabotage"));
            Translator_SolarNode.Add("SolNode114", new SolarNodeData("Puck (Uranus)", "Grineer", "Exterminate"));
            Translator_SolarNode.Add("SolNode115", new SolarNodeData("Quirinus (Mars)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode116", new SolarNodeData("Mab (Uranus)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode117", new SolarNodeData("Naiad (Neptune)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode118", new SolarNodeData("Laomedeia (Neptune)", "Corpus", "Disruption"));
            Translator_SolarNode.Add("SolNode119", new SolarNodeData("Caloris (Mercury)", "Grineer", "Rescue"));
            Translator_SolarNode.Add("SolNode120", new SolarNodeData("Halimede (Neptune)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode121", new SolarNodeData("Carpo (Jupiter)", "Corpus", "Exterminate"));
            Translator_SolarNode.Add("SolNode122", new SolarNodeData("Stephano (Uranus)", "Grineer", "Defense"));
            Translator_SolarNode.Add("SolNode123", new SolarNodeData("V Prime (Venus)", "Corpus", "Survival"));
            Translator_SolarNode.Add("SolNode124", new SolarNodeData("Trinculo (Uranus)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode125", new SolarNodeData("Io (Jupiter)", "Corpus", "Defense"));
            Translator_SolarNode.Add("SolNode126", new SolarNodeData("Metis (Jupiter)", "Corpus", "Rescue"));
            Translator_SolarNode.Add("SolNode127", new SolarNodeData("Psamathe (Neptune)", "Corpus", "Assassination"));
            Translator_SolarNode.Add("SolNode128", new SolarNodeData("E Gate (Venus)", "Corpus", "Exterminate"));
            Translator_SolarNode.Add("SolNode129", new SolarNodeData("Orb Vallis (Venus)", "Corpus", "Free Roam"));
            Translator_SolarNode.Add("SolNode130", new SolarNodeData("Lares (Mercury)", "Grineer", "Defense"));
            Translator_SolarNode.Add("SolNode131", new SolarNodeData("Pallas (Ceres)", "Grineer", "Exterminate"));
            Translator_SolarNode.Add("SolNode132", new SolarNodeData("Bode (Ceres)", "Grineer", "Spy"));
            Translator_SolarNode.Add("SolNode133", new SolarNodeData("Vedic (Ceres)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode134", new SolarNodeData("Varro (Ceres)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode135", new SolarNodeData("Thon (Ceres)", "Grineer", "Sabotage"));
            Translator_SolarNode.Add("SolNode136", new SolarNodeData("Olla (Ceres)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode137", new SolarNodeData("Nuovo (Ceres)", "Grineer", "Rescue"));
            Translator_SolarNode.Add("SolNode138", new SolarNodeData("Ludi (Ceres)", "Grineer", "Hijack"));
            Translator_SolarNode.Add("SolNode139", new SolarNodeData("Lex (Ceres)", "Grineer", "Capture"));
            Translator_SolarNode.Add("SolNode140", new SolarNodeData("Kiste (Ceres)", "Grineer", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode141", new SolarNodeData("Ker (Ceres)", "Grineer", "Sabotage"));
            Translator_SolarNode.Add("SolNode142", new SolarNodeData("Hapke (Ceres)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode143", new SolarNodeData("Gefion (Ceres)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode144", new SolarNodeData("Exta (Ceres)", "Grineer", "Assassination"));
            Translator_SolarNode.Add("SolNode145", new SolarNodeData("Egeria (Ceres)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode146", new SolarNodeData("Draco (Ceres)", "Grineer", "Survival"));
            Translator_SolarNode.Add("SolNode147", new SolarNodeData("Cinxia (Ceres)", "Grineer", "Interception"));
            Translator_SolarNode.Add("SolNode148", new SolarNodeData("Cerium (Ceres)", "", ""));
            Translator_SolarNode.Add("SolNode149", new SolarNodeData("Casta (Ceres)", "Grineer", "Defense"));
            Translator_SolarNode.Add("SolNode150", new SolarNodeData("Albedo (Ceres)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode151", new SolarNodeData("Acanth (Eris)", "Infested", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode152", new SolarNodeData("Ascar (Eris)", "Infested", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode153", new SolarNodeData("Brugia (Eris)", "Infested", "Rescue"));
            Translator_SolarNode.Add("SolNode154", new SolarNodeData("Candiru (Eris)", "Infested", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode155", new SolarNodeData("Cosis (Eris)", "Infested", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode156", new SolarNodeData("Cyath (Eris)", "Infested", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode157", new SolarNodeData("Giardia (Eris)", "Infested", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode158", new SolarNodeData("Gnathos (Eris)", "Infested", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode159", new SolarNodeData("Lepis (Eris)", "Infested", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode160", new SolarNodeData("Histo (Eris)", "Infested", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode161", new SolarNodeData("Hymeno (Eris)", "Infested", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode162", new SolarNodeData("Isos (Eris)", "Infested", "Capture"));
            Translator_SolarNode.Add("SolNode163", new SolarNodeData("Ixodes (Eris)", "", ""));
            Translator_SolarNode.Add("SolNode164", new SolarNodeData("Kala-azar (Eris)", "Infested", "Defense"));
            Translator_SolarNode.Add("SolNode165", new SolarNodeData("Sporid (Eris)", "Infested", "Hive Sabotage"));
            Translator_SolarNode.Add("SolNode166", new SolarNodeData("Nimus (Eris)", "Infested", "Survival"));
            Translator_SolarNode.Add("SolNode167", new SolarNodeData("Oestrus (Eris)", "Infested", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode168", new SolarNodeData("Phalan (Eris)", "Infested", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode169", new SolarNodeData("Psoro (Eris)", "Infested", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode170", new SolarNodeData("Ranova (Eris)", "Infested", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode171", new SolarNodeData("Saxis (Eris)", "Infested", "Exterminate"));
            Translator_SolarNode.Add("SolNode172", new SolarNodeData("Xini (Eris)", "Infested", "Interception"));
            Translator_SolarNode.Add("SolNode173", new SolarNodeData("Solium (Eris)", "Infested", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode174", new SolarNodeData("Sparga (Eris)", "Infested", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode175", new SolarNodeData("Naeglar (Eris)", "Infested", "Hive"));
            Translator_SolarNode.Add("SolNode176", new SolarNodeData("Viver (Eris)", "Infested", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode177", new SolarNodeData("Kappa (Sedna)", "Grineer", "Spy"));
            Translator_SolarNode.Add("SolNode178", new SolarNodeData("Hyosube (Sedna)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode179", new SolarNodeData("Jengu (Sedna)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode180", new SolarNodeData("Undine (Sedna)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode181", new SolarNodeData("Adaro (Sedna)", "Grineer", "Exterminate"));
            Translator_SolarNode.Add("SolNode182", new SolarNodeData("Camenae (Sedna)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode183", new SolarNodeData("Vodyanoi (Sedna)", "Grineer", "Arena"));
            Translator_SolarNode.Add("SolNode184", new SolarNodeData("Rusalka (Sedna)", "Grineer", "Capture"));
            Translator_SolarNode.Add("SolNode185", new SolarNodeData("Berehynia (Sedna)", "Grineer", "Interception"));
            Translator_SolarNode.Add("SolNode186", new SolarNodeData("Phithale (Sedna)", "Grineer", "Sabotage"));
            Translator_SolarNode.Add("SolNode187", new SolarNodeData("Selkie (Sedna)", "Grineer", "Survival"));
            Translator_SolarNode.Add("SolNode188", new SolarNodeData("Kelpie (Sedna)", "Grineer", "Disruption"));
            Translator_SolarNode.Add("SolNode189", new SolarNodeData("Naga (Sedna)", "Grineer", "Rescue"));
            Translator_SolarNode.Add("SolNode190", new SolarNodeData("Nakki (Sedna)", "Grineer", "Arena"));
            Translator_SolarNode.Add("SolNode191", new SolarNodeData("Marid (Sedna)", "Grineer", "Hijack"));
            Translator_SolarNode.Add("SolNode192", new SolarNodeData("Tikoloshe (Sedna)", "Grineer", "Spy"));
            Translator_SolarNode.Add("SolNode193", new SolarNodeData("Merrow (Sedna)", "Grineer", "Assassination"));
            Translator_SolarNode.Add("SolNode194", new SolarNodeData("Ponaturi (Sedna)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode195", new SolarNodeData("Hydron (Sedna)", "Grineer", "Defense"));
            Translator_SolarNode.Add("SolNode196", new SolarNodeData("Charybdis (Sedna)", "Grineer", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode197", new SolarNodeData("Graeae (Sedna)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode198", new SolarNodeData("Scylla (Sedna)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode199", new SolarNodeData("Yam (Sedna)", "Grineer", "Arena"));
            Translator_SolarNode.Add("SolNode200", new SolarNodeData("Veles (Sedna)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode201", new SolarNodeData("Tiamat (Sedna)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode202", new SolarNodeData("Yemaja (Sedna)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode203", new SolarNodeData("Abaddon (Europa)", "Corpus", "Capture"));
            Translator_SolarNode.Add("SolNode204", new SolarNodeData("Armaros (Europa)", "Corpus", "Exterminate"));
            Translator_SolarNode.Add("SolNode205", new SolarNodeData("Baal (Europa)", "Corpus", "Exterminate"));
            Translator_SolarNode.Add("SolNode206", new SolarNodeData("Eligor (Europa)", "", ""));
            Translator_SolarNode.Add("SolNode207", new SolarNodeData("Gamygyn (Europa)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode208", new SolarNodeData("Lillith (Europa)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode209", new SolarNodeData("Morax (Europa)", "Corpus", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode210", new SolarNodeData("Naamah (Europa)", "Corpus", "Assassination"));
            Translator_SolarNode.Add("SolNode211", new SolarNodeData("Ose (Europa)", "Corpus", "Interception"));
            Translator_SolarNode.Add("SolNode212", new SolarNodeData("Paimon (Europa)", "Corpus", "Defense"));
            Translator_SolarNode.Add("SolNode213", new SolarNodeData("Shax (Europa)", "", ""));
            Translator_SolarNode.Add("SolNode214", new SolarNodeData("Sorath (Europa)", "Corpus", "Hijack"));
            Translator_SolarNode.Add("SolNode215", new SolarNodeData("Valac (Europa)", "Corpus", "Spy"));
            Translator_SolarNode.Add("SolNode216", new SolarNodeData("Valefor (Europa)", "Corpus", "Excavation"));
            Translator_SolarNode.Add("SolNode217", new SolarNodeData("Orias (Europa)", "Corpus", "Rescue"));
            Translator_SolarNode.Add("SolNode218", new SolarNodeData("Zagan (Europa)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode219", new SolarNodeData("Beleth (Europa)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode220", new SolarNodeData("Kokabiel (Europa)", "Corpus", "Sabotage"));
            Translator_SolarNode.Add("SolNode221", new SolarNodeData("Neruda (Mercury)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode222", new SolarNodeData("Eminescu (Mercury)", "Grineer", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode223", new SolarNodeData("Boethius (Mercury)", "Grineer", "Exterminate"));
            Translator_SolarNode.Add("SolNode224", new SolarNodeData("Odin (Mercury)", "Grineer", "Interception"));
            Translator_SolarNode.Add("SolNode225", new SolarNodeData("Suisei (Mercury)", "Grineer", "Spy"));
            Translator_SolarNode.Add("SolNode226", new SolarNodeData("Pantheon (Mercury)", "Grineer", "Exterminate"));
            Translator_SolarNode.Add("SolNode227", new SolarNodeData("Verdi (Mercury)", "", ""));
            Translator_SolarNode.Add("SolNode228", new SolarNodeData("Plains of Eidolon (Earth)", "Grineer", "Free Roam"));
            Translator_SolarNode.Add("SolNode400", new SolarNodeData("Teshub (Void)", "Orokin", "Exterminate"));
            Translator_SolarNode.Add("SolNode401", new SolarNodeData("Hepit (Void)", "Orokin", "Capture"));
            Translator_SolarNode.Add("SolNode402", new SolarNodeData("Taranis (Void)", "Orokin", "Defense"));
            Translator_SolarNode.Add("SolNode403", new SolarNodeData("Tiwaz (Void)", "Orokin", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode404", new SolarNodeData("Stribog (Void)", "Orokin", "Orokin Sabotage"));
            Translator_SolarNode.Add("SolNode405", new SolarNodeData("Ani (Void)", "Orokin", "Survival"));
            Translator_SolarNode.Add("SolNode406", new SolarNodeData("Ukko (Void)", "Orokin", "Capture"));
            Translator_SolarNode.Add("SolNode407", new SolarNodeData("Oxomoco (Void)", "Orokin", "Exterminate"));
            Translator_SolarNode.Add("SolNode408", new SolarNodeData("Belenus (Void)", "Orokin", "Defense"));
            Translator_SolarNode.Add("SolNode409", new SolarNodeData("Mot (Void)", "Orokin", "Survival"));
            Translator_SolarNode.Add("SolNode410", new SolarNodeData("Aten (Void)", "Orokin", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode411", new SolarNodeData("SolNode411 (Void)", "Orokin", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode412", new SolarNodeData("Mithra (Void)", "Orokin", "Interception"));
            Translator_SolarNode.Add("SolNode413", new SolarNodeData("SolNode413 (Void)", "Corrupted", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode740", new SolarNodeData("The Ropalolyst (Jupiter)", "Sentient", "Assassination"));
            Translator_SolarNode.Add("SolNode741", new SolarNodeData("Koro (Kuva Fortress)", "Grineer", "Assault"));
            Translator_SolarNode.Add("SolNode742", new SolarNodeData("Nabuk (Kuva Fortress)", "Grineer", "Capture"));
            Translator_SolarNode.Add("SolNode743", new SolarNodeData("Rotuma (Kuva Fortress)", "Grineer", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode744", new SolarNodeData("Taveuni (Kuva Fortress)", "Grineer", "Survival"));
            Translator_SolarNode.Add("SolNode745", new SolarNodeData("Tamu (Kuva Fortress)", "Grineer", "Disruption"));
            Translator_SolarNode.Add("SolNode746", new SolarNodeData("Dakata (Kuva Fortress)", "Grineer", "Extermination"));
            Translator_SolarNode.Add("SolNode747", new SolarNodeData("Pago (Kuva Fortress)", "Grineer", "Spy"));
            Translator_SolarNode.Add("SolNode748", new SolarNodeData("Garus (Kuva Fortress)", "Grineer", "Rescue"));
            Translator_SolarNode.Add("SolNode901", new SolarNodeData("Caduceus", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("SolNode902", new SolarNodeData("Montes (Venus)", "Corpus", "Exterminate (Archwing)"));
            Translator_SolarNode.Add("SolNode903", new SolarNodeData("Erpo (Earth)", "Grineer", "Mobile Defense (Archwing)"));
            Translator_SolarNode.Add("SolNode904", new SolarNodeData("Syrtis (Mars)", "Grineer", "Exterminate (Archwing)"));
            Translator_SolarNode.Add("SolNode905", new SolarNodeData("Galilea (Jupiter)", "Corpus", "Sabotage (Archwing)"));
            Translator_SolarNode.Add("SolNode906", new SolarNodeData("Pandora (Saturn)", "Grineer", "Pursuit (Archwing)"));
            Translator_SolarNode.Add("SolNode907", new SolarNodeData("Caelus (Uranus)", "Grineer", "Interception (Archwing)"));
            Translator_SolarNode.Add("SolNode908", new SolarNodeData("Salacia (Neptune)", "Corpus", "Mobile Defense (Archwing)"));
            Translator_SolarNode.Add("SolNode300", new SolarNodeData("Plato (Lua)", "Grineer", "Exterminate"));
            Translator_SolarNode.Add("SolNode301", new SolarNodeData("Grimaldi (Lua)", "Grineer", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode302", new SolarNodeData("Tycho (Lua)", "Corpus", "Survival"));
            Translator_SolarNode.Add("SolNode304", new SolarNodeData("Copernicus (Lua)", "Grineer", "Mobile Defense"));
            Translator_SolarNode.Add("SolNode305", new SolarNodeData("Stöfler (Lua)", "Corpus", "Survival"));
            Translator_SolarNode.Add("SolNode306", new SolarNodeData("Pavlov (Lua)", "Corpus", "Spy"));
            Translator_SolarNode.Add("SolNode307", new SolarNodeData("Zeipel (Lua)", "Corpus", "Rescue"));
            Translator_SolarNode.Add("SolNode308", new SolarNodeData("Apollo (Lua)", "Corpus", "Disruption"));
            Translator_SolarNode.Add("SettlementNode1", new SolarNodeData("Roche (Phobos)", "Corpus", "Exterminate"));
            Translator_SolarNode.Add("SettlementNode2", new SolarNodeData("Skyresh (Phobos)", "Corpus", "Capture"));
            Translator_SolarNode.Add("SettlementNode3", new SolarNodeData("Stickney (Phobos)", "Corpus", "Survival"));
            Translator_SolarNode.Add("SettlementNode4", new SolarNodeData("Drunlo (Phobos)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SettlementNode5", new SolarNodeData("Grildrig (Phobos)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SettlementNode6", new SolarNodeData("Limtoc (Phobos)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SettlementNode7", new SolarNodeData("Hall (Phobos)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SettlementNode8", new SolarNodeData("Reldresal (Phobos)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SettlementNode9", new SolarNodeData("Clustril (Phobos)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SettlementNode10", new SolarNodeData("Kepler (Phobos)", "Corpus", "Rush (Archwing)"));
            Translator_SolarNode.Add("SettlementNode11", new SolarNodeData("Gulliver (Phobos)", "Corpus", "Defense"));
            Translator_SolarNode.Add("SettlementNode12", new SolarNodeData("Monolith (Phobos)", "Corpus", "Rescue"));
            Translator_SolarNode.Add("SettlementNode13", new SolarNodeData("D'Arrest (Phobos)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SettlementNode14", new SolarNodeData("Shklovsky (Phobos)", "Corpus", "Spy"));
            Translator_SolarNode.Add("SettlementNode15", new SolarNodeData("Sharpless (Phobos)", "Corpus", "Mobile Defense"));
            Translator_SolarNode.Add("SettlementNode16", new SolarNodeData("Wendell (Phobos)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SettlementNode17", new SolarNodeData("Flimnap (Phobos)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SettlementNode18", new SolarNodeData("Opik (Phobos)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SettlementNode19", new SolarNodeData("Todd (Phobos)", "Corpus", "Ancient Retribution"));
            Translator_SolarNode.Add("SettlementNode20", new SolarNodeData("Iliad (Phobos)", "Corpus", "Assassination"));
            Translator_SolarNode.Add("MercuryHUB", new SolarNodeData("Larunda Relay (Mercury)", "Grineer", "Relay"));
            Translator_SolarNode.Add("VenusHUB", new SolarNodeData("Vesper Relay (Venus)", "Corpus", "Relay"));
            Translator_SolarNode.Add("EarthHUB", new SolarNodeData("Strata Relay (Earth)", "Grineer", "Relay"));
            Translator_SolarNode.Add("SaturnHUB", new SolarNodeData("Kronia Relay (Saturn)", "Grineer", "Relay"));
            Translator_SolarNode.Add("ErisHUB", new SolarNodeData("Kuiper Relay (Eris)", "Infested", "Relay"));
            Translator_SolarNode.Add("EuropaHUB", new SolarNodeData("Leonov Relay (Europa)", "Corpus", "Relay"));
            Translator_SolarNode.Add("PlutoHUB", new SolarNodeData("Orcus Relay (Pluto)", "Corpus", "Relay"));
            Translator_SolarNode.Add("EventNode0", new SolarNodeData("Balor", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("EventNode1", new SolarNodeData("Tethra", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("EventNode2", new SolarNodeData("Operation Gate Crash", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("EventNode3", new SolarNodeData("Elatha", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("EventNode4", new SolarNodeData("Proxy Rebellion", "Corpus", "Survival"));
            Translator_SolarNode.Add("EventNode5", new SolarNodeData("Birog", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("EventNode6", new SolarNodeData("Tyl Reygor Seal Lab", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("EventNode7", new SolarNodeData("Proxy Rebellion", "Corpus", "Interception"));
            Translator_SolarNode.Add("EventNode8", new SolarNodeData("Corb", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("EventNode9", new SolarNodeData("Operation Gate Crash Pt. 2", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("EventNode10", new SolarNodeData("Lugh", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("EventNode11", new SolarNodeData("Nemed", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("EventNode12", new SolarNodeData("Operation Cryotic Front", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("EventNode13", new SolarNodeData("Shifting Sands", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("EventNode14", new SolarNodeData("Gate Crash", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("EventNode15", new SolarNodeData("Operation Cryotic Front", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("EventNode16", new SolarNodeData("Operation Cryotic Front", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("EventNode17", new SolarNodeData("Proxy Rebellion", "Corpus", "Defense"));
            Translator_SolarNode.Add("EventNode18", new SolarNodeData("Proxy Rebellion", "Corpus", "Defense"));
            Translator_SolarNode.Add("EventNode19", new SolarNodeData("Mars", "Grineer", "Defense"));
            Translator_SolarNode.Add("EventNode20", new SolarNodeData("Tyl Regor Sea Lab", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("EventNode22", new SolarNodeData("Tyl Regor Sea Lab", "Sentient", "Ancient Retribution"));
            Translator_SolarNode.Add("EventNode24", new SolarNodeData("Earth", "Grineer", "Arena"));
            Translator_SolarNode.Add("EventNode25", new SolarNodeData("Earth", "Grineer", "Arena"));
            Translator_SolarNode.Add("EventNode26", new SolarNodeData("Earth", "Grineer", "Exterminate"));
            Translator_SolarNode.Add("EventNode27", new SolarNodeData("Void", "Corrupted", "Survival"));
            Translator_SolarNode.Add("EventNode28", new SolarNodeData("Saturn", "Grineer", "Assassination"));
            Translator_SolarNode.Add("EventNode29", new SolarNodeData("Saturn", "Grineer", "Assassination"));
            Translator_SolarNode.Add("EventNode30", new SolarNodeData("Ganymede (Jupiter)", "Corpus", "Disruption"));
            Translator_SolarNode.Add("EventNode31", new SolarNodeData("Ganymede (Jupiter)", "Corpus", "Disruption"));
            Translator_SolarNode.Add("EventNode32", new SolarNodeData("Ganymede (Jupiter)", "Corpus", "Disruption"));
            Translator_SolarNode.Add("EventNode33", new SolarNodeData("Ganymede (Jupiter)", "Corpus", "Disruption"));
            Translator_SolarNode.Add("EventNode34", new SolarNodeData("Earth", "Grineer", "Arena"));
            Translator_SolarNode.Add("EventNode35", new SolarNodeData("Earth", "Grineer", "Arena"));
            Translator_SolarNode.Add("EventNode761", new SolarNodeData("The Index", "Corpus", "Arena"));
            Translator_SolarNode.Add("EventNode762", new SolarNodeData("The Index pt 2", "Corpus", "Arena"));
            Translator_SolarNode.Add("EventNode763", new SolarNodeData("The Index Endurance", "Corpus", "Arena"));
            Translator_SolarNode.Add("PvpNode0", new SolarNodeData("Conclave Capture the Cephalon", "Tenno", "Conclave"));
            Translator_SolarNode.Add("PvpNode1", new SolarNodeData("Conclave", "Tenno", "Conclave"));
            Translator_SolarNode.Add("PvpNode2", new SolarNodeData("Conclave", "Tenno", "Conclave"));
            Translator_SolarNode.Add("PvpNode3", new SolarNodeData("Conclave Capture the Cephalon", "Tenno", "Conclave"));
            Translator_SolarNode.Add("PvpNode4", new SolarNodeData("Conclave", "Tenno", "Conclave"));
            Translator_SolarNode.Add("PvpNode5", new SolarNodeData("Conclave", "Tenno", "Conclave"));
            Translator_SolarNode.Add("PvpNode6", new SolarNodeData("Conclave", "Tenno", "Conclave"));
            Translator_SolarNode.Add("PvpNode7", new SolarNodeData("Conclave", "Tenno", "Conclave"));
            Translator_SolarNode.Add("PvpNode8", new SolarNodeData("Conclave", "Tenno", "Conclave"));
            Translator_SolarNode.Add("PvpNode9", new SolarNodeData("Conclave Team Domination", "Tenno", "Conclave"));
            Translator_SolarNode.Add("PvpNode10", new SolarNodeData("Conclave Domination", "Tenno", "Conclave"));
            Translator_SolarNode.Add("PvpNode11", new SolarNodeData("Conclave Domination", "Tenno", "Conclave"));
            Translator_SolarNode.Add("PvpNode12", new SolarNodeData("Conclave Domination", "Tenno", "Conclave"));
            Translator_SolarNode.Add("PvpNode13", new SolarNodeData("Tactical Alert: Snoball Fight!", "Tenno", "Conclave"));
            Translator_SolarNode.Add("PvpNode14", new SolarNodeData("Conclave: Quick Steel", "Tenno", "Conclave"));
            Translator_SolarNode.Add("ClanNode0", new SolarNodeData("Romula (Venus)", "Infested", "Dark Sector Defense"));
            Translator_SolarNode.Add("ClanNode1", new SolarNodeData("Malva (Venus)", "Infested", "Dark Sector Survival"));
            Translator_SolarNode.Add("ClanNode2", new SolarNodeData("Coba (Earth)", "Infested", "Dark Sector Defense"));
            Translator_SolarNode.Add("ClanNode3", new SolarNodeData("Tikal (Earth)", "Infested", "Dark Sector Excavation"));
            Translator_SolarNode.Add("ClanNode4", new SolarNodeData("Sinai (Jupiter)", "Infested", "Dark Sector Survival"));
            Translator_SolarNode.Add("ClanNode5", new SolarNodeData("Cameria (Jupiter)", "Infested", "Dark Sector Survival"));
            Translator_SolarNode.Add("ClanNode6", new SolarNodeData("Larzac (Europa)", "Infested", "Dark Sector Defense"));
            Translator_SolarNode.Add("ClanNode7", new SolarNodeData("Cholistan (Europa)", "Infested", "Dark Sector Excavation"));
            Translator_SolarNode.Add("ClanNode8", new SolarNodeData("Kadesh (Mars)", "Infested", "Dark Sector Defense"));
            Translator_SolarNode.Add("ClanNode9", new SolarNodeData("Wahiba (Mars)", "Infested", "Dark Sector Survival"));
            Translator_SolarNode.Add("ClanNode10", new SolarNodeData("Memphis (Phobos)", "Infested", "Dark Sector Defection"));
            Translator_SolarNode.Add("ClanNode11", new SolarNodeData("Zeugma (Phobos)", "Infested", "Dark Sector Survival"));
            Translator_SolarNode.Add("ClanNode12", new SolarNodeData("Caracol (Saturn)", "Infested", "Dark Sector Defection"));
            Translator_SolarNode.Add("ClanNode13", new SolarNodeData("Piscinas (Saturn)", "Infested", "Dark Sector Survival"));
            Translator_SolarNode.Add("ClanNode14", new SolarNodeData("Amarna (Sedna)", "Infested", "Dark Sector Survival"));
            Translator_SolarNode.Add("ClanNode15", new SolarNodeData("Sangeru (Sedna)", "Infested", "Dark Sector Defense"));
            Translator_SolarNode.Add("ClanNode16", new SolarNodeData("Ur (Uranus)", "Infested", "Dark Sector Disruption"));
            Translator_SolarNode.Add("ClanNode17", new SolarNodeData("Assur (Uranus)", "Infested", "Dark Sector Survival"));
            Translator_SolarNode.Add("ClanNode18", new SolarNodeData("Akkad (Eris)", "Infested", "Dark Sector Defense"));
            Translator_SolarNode.Add("ClanNode19", new SolarNodeData("Zabala (Eris)", "Infested", "Dark Sector Survival"));
            Translator_SolarNode.Add("ClanNode20", new SolarNodeData("Yursa (Neptune)", "Infested", "Dark Sector Defection"));
            Translator_SolarNode.Add("ClanNode21", new SolarNodeData("Kelashin (Neptune)", "Infested", "Dark Sector Survival"));
            Translator_SolarNode.Add("ClanNode22", new SolarNodeData("Seimeni (Ceres)", "Infested", "Dark Sector Defense"));
            Translator_SolarNode.Add("ClanNode23", new SolarNodeData("Gabii (Ceres)", "Infested", "Dark Sector Survival"));
            Translator_SolarNode.Add("ClanNode24", new SolarNodeData("Sechura (Pluto)", "Infested", "Dark Sector Defense"));
            Translator_SolarNode.Add("ClanNode25", new SolarNodeData("Hieracon (Pluto)", "Infested", "Dark Sector Excavation"));
            Translator_SolarNode.Add("/Lotus/Types/Keys/SortieBossKeyPhorid", new SolarNodeData("Sortie Boss: Phorid", "Infested", "Assassination"));
            Translator_SolarNode.Add("CrewBattleNode505", new SolarNodeData("Ruse War Field (Veil Proxima)", "Grineer", "Skirmish"));
            Translator_SolarNode.Add("CrewBattleNode510", new SolarNodeData("Gian Point (Veil Proxima)", "Grineer", "Skirmish"));
            Translator_SolarNode.Add("CrewBattleNode550", new SolarNodeData("Nsu Grid (Veil Proxima)", "Grineer", "Skirmish"));
            Translator_SolarNode.Add("CrewBattleNode551", new SolarNodeData("Ganalen's Grave (Veil Proxima)", "Grineer", "Skirmish"));
            Translator_SolarNode.Add("CrewBattleNode552", new SolarNodeData("Rya (Veil Proxima)", "Grineer", "Skirmish"));
            Translator_SolarNode.Add("CrewBattleNode553", new SolarNodeData("Flexa (Veil Proxima)", "Grineer", "Skirmish"));
            Translator_SolarNode.Add("CrewBattleNode554", new SolarNodeData("H-2 Cloud (Veil Proxima)", "Grineer", "Skirmish"));
            Translator_SolarNode.Add("CrewBattleNode555", new SolarNodeData("R-9 Cloud (Veil Proxima)", "Grineer", "Skirmish"));
        }

        #endregion



        #region Fissures

        public static Dictionary<string, string> Translator_Fissure2Tier = new Dictionary<string, string>();
        public static Dictionary<string, string> Translator_Tier2Fissure = new Dictionary<string, string>();
        private static void Initialize_FissureTranslator()
        {
            Translator_Fissure2Tier.Add("Lith", "VoidT1");
            Translator_Fissure2Tier.Add("Meso", "VoidT2");
            Translator_Fissure2Tier.Add("Neo", "VoidT3");
            Translator_Fissure2Tier.Add("Axi", "VoidT4");
            Translator_Fissure2Tier.Add("Requiem", "VoidT5");
            Translator_Tier2Fissure.Add("VoidT1", "Lith");
            Translator_Tier2Fissure.Add("VoidT2", "Meso");
            Translator_Tier2Fissure.Add("VoidT3", "Neo");
            Translator_Tier2Fissure.Add("VoidT4", "Axi");
            Translator_Tier2Fissure.Add("VoidT5", "Requiem");
        }

        public static DateTime FissureEndsAt;
        public static Dictionary<string, List<string>> FissureList;
        public static void GetFissureData()
        {
            //http://content.warframe.com/dynamic/worldState.php
            
            FissureList = new Dictionary<string, List<string>>
            {
                { "VoidT1", new List<string>() },
                { "VoidT2", new List<string>() },
                { "VoidT3", new List<string>() },
                { "VoidT4", new List<string>() },
                { "VoidT5", new List<string>() }
            };
            FissureEndsAt = new DateTime(2100, 12, 12);

            string WarframeWorldState_JSON = new WebClient().DownloadString("http://content.warframe.com/dynamic/worldState.php");
            WarframeWorldState_JSON = WarframeWorldState_JSON.Remove(0, WarframeWorldState_JSON.IndexOf("ActiveMissions") + ("ActiveMissions").Length + 2);
            WarframeWorldState_JSON = WarframeWorldState_JSON.Substring(0, WarframeWorldState_JSON.IndexOf("]") + 1);
            JArray Fissure_Data = JArray.Parse(WarframeWorldState_JSON);
            foreach (JObject FissureData in Fissure_Data)
            {
                DateTime ThisFissureEndTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(FissureData["Expiry"]["$date"]["$numberLong"].Value<Int64>());
                if (ThisFissureEndTime < FissureEndsAt) { FissureEndsAt = ThisFissureEndTime; };

                string NodeName = FissureData["Node"].Value<string>();
                if (!RelicData.ContainsKey(Translator_SolarNode[NodeName].Name)) { continue; };
                FissureList[FissureData["Modifier"].Value<string>()].Add(NodeName);
            }
        }

        #endregion



        #region Relic Data

        public static void GetRelicDropData()
        {
            //location - rotation[] - relics[] - relic tier, chance[]
            SortedDictionary<string, SortedDictionary<string, Dictionary<string, Dictionary<string, decimal>>>> RelicDataTemp = new SortedDictionary<string, SortedDictionary<string, Dictionary<string, Dictionary<string, decimal>>>>();

            JArray JSONHolder;
            using (WebClient TempWebClient = new WebClient())
            {
                TempWebClient.Encoding = Encoding.UTF8;
                JSONHolder = JArray.Parse(TempWebClient.DownloadString("https://raw.githubusercontent.com/WFCD/warframe-items/development/data/json/Relics.json"));
            }

            foreach (JObject RelicEntry in JSONHolder)
            {
                string Relic_FullName = RelicEntry["name"].Value<string>();
                if (!Relic_FullName.Contains("Intact")) { continue; } //skip over refined relics
                string Relic_Name = Relic_FullName.Substring(0, Relic_FullName.IndexOf(" "));

                if (RelicEntry.ContainsKey("drops"))
                {
                    JArray DropsHolder = RelicEntry["drops"].Value<JArray>();
                    foreach (JObject DropData in DropsHolder)
                    {
                        string Relic_Location = DropData["location"].Value<string>();
                        //convert from Location - Name to Name (Location)
                        string Relic_Location_Fix = Relic_Location;
                        if (Relic_Location.Contains(" - ")){Relic_Location_Fix = string.Format("{0} ({1})", Relic_Location.Substring(Relic_Location.IndexOf(" - ") + 3), Relic_Location.Substring(0, Relic_Location.IndexOf(" - ")));}
                        if (!RelicDataTemp.ContainsKey(Relic_Location_Fix)) { RelicDataTemp.Add(Relic_Location_Fix, new SortedDictionary<string, Dictionary<string, Dictionary<string, decimal>>>()); }    

                        string Relic_Rotation = DropData.ContainsKey("rotation") ? DropData["rotation"].Value<string>() : "NoRotation";
                        if (!RelicDataTemp[Relic_Location_Fix].ContainsKey(Relic_Rotation)) { RelicDataTemp[Relic_Location_Fix].Add(Relic_Rotation, new Dictionary<string, Dictionary<string, decimal>>()); }
                        if (!RelicDataTemp[Relic_Location_Fix][Relic_Rotation].ContainsKey(Relic_Name)) { RelicDataTemp[Relic_Location_Fix][Relic_Rotation].Add(Relic_Name, new Dictionary<string, decimal>()); }
                        if (!RelicDataTemp[Relic_Location_Fix][Relic_Rotation][Relic_Name].ContainsKey(Relic_FullName)) { RelicDataTemp[Relic_Location_Fix][Relic_Rotation][Relic_Name].Add(Relic_FullName, 0); }

                        decimal Relic_Chance = DropData["chance"].Value<decimal>();
                        RelicDataTemp[Relic_Location_Fix][Relic_Rotation][Relic_Name][Relic_FullName] += Relic_Chance;
                    }
                }
            }

            foreach (KeyValuePair<string, SortedDictionary<string, Dictionary<string, Dictionary<string, decimal>>>> ParseRelic_Location in RelicDataTemp)
            {
                string RelicPaste_Location = ParseRelic_Location.Key;

                SortedDictionary<string, OrderedDictionary> RelicPasteData_Rotation = new SortedDictionary<string, OrderedDictionary>();
                foreach (KeyValuePair<string, Dictionary<string, Dictionary<string, decimal>>> ParseRelic_Rotation in ParseRelic_Location.Value)
                {
                    string RelicPaste_Rotation = ParseRelic_Rotation.Key;
                    if (!RelicPasteData_Rotation.ContainsKey(RelicPaste_Rotation)) { RelicPasteData_Rotation.Add(RelicPaste_Rotation, new OrderedDictionary { { "Lith", 0 }, { "Meso", 0 }, { "Neo", 0 }, { "Axi", 0 }, { "Requiem", 0 } }); }

                    foreach (KeyValuePair<string, Dictionary<string, decimal>> ParseRelic_RelicName in ParseRelic_Rotation.Value)
                    {
                        decimal RelicNameChance = 0;
                        foreach (KeyValuePair<string, decimal> ParseRelic_RelicFullName in ParseRelic_RelicName.Value)
                        {
                            RelicNameChance += ParseRelic_RelicFullName.Value;
                        }
                        RelicPasteData_Rotation[RelicPaste_Rotation][ParseRelic_RelicName.Key] = RelicNameChance;
                    }

                    // Remove 0 valued Relics so it's easier to print
                    List<string> List4Removal = new List<string>(); //can't remove during loop
                    foreach (DictionaryEntry DeleteRelicEntryCheck in RelicPasteData_Rotation[ParseRelic_Rotation.Key])
                    {
                        if (DeleteRelicEntryCheck.Value.ToString().Equals("0")) { List4Removal.Add(DeleteRelicEntryCheck.Key.ToString()); }       
                    }
                    foreach (string DoRemove in List4Removal)
                    {
                        RelicPasteData_Rotation[RelicPaste_Rotation].Remove(DoRemove);
                    }
                }

                //Print Paste Line
                string DebugPrintString = string.Format("RelicData.Add(\"{0}\", new List<string>{{", RelicPaste_Location);
                double TotalChance = 0;

                if (RelicPasteData_Rotation.Count > 1)
                {
                    foreach (KeyValuePair<string, OrderedDictionary> PasteRelic_Location in RelicPasteData_Rotation)
                    {
                        TotalChance = 0;
                        string DebugPrintString_ThisRotation = "";
                        foreach (DictionaryEntry RelicsNChances in PasteRelic_Location.Value)
                        {
                            double RelicNameChance = double.Parse(RelicsNChances.Value.ToString());
                            DebugPrintString_ThisRotation += string.Format(" {0} {1},", RelicsNChances.Key, RelicNameChance.ToString("P0"));
                            TotalChance += RelicNameChance;
                        }
                        if (TotalChance > 1.1) { continue; } //something wrong here

                        DebugPrintString_ThisRotation = DebugPrintString_ThisRotation.Remove(DebugPrintString_ThisRotation.Length - 1);
                        string MidPartCheck = (PasteRelic_Location.Value.Count == 1) ? "" : string.Format("({0}) ", TotalChance.ToString("P0"));
                        DebugPrintString_ThisRotation = string.Format("{0} {1}-{2}", PasteRelic_Location.Key, MidPartCheck, DebugPrintString_ThisRotation);

                        DebugPrintString += string.Format(" \"{0}\",", DebugPrintString_ThisRotation.Trim());
                    }
                }
                else
                {
                    TotalChance = 0;
                    string DebugPrintString_ThisRotation = "";
                    foreach (DictionaryEntry RelicsNChances in RelicPasteData_Rotation.First().Value)
                    {
                        double RelicNameChance = double.Parse(RelicsNChances.Value.ToString());
                        DebugPrintString_ThisRotation += string.Format(" {0} {1},", RelicsNChances.Key, RelicNameChance.ToString("P0"));
                        TotalChance += RelicNameChance;
                    }
                    if (TotalChance > 1.1) { continue; } //something wrong here

                    DebugPrintString_ThisRotation = DebugPrintString_ThisRotation.Remove(DebugPrintString_ThisRotation.Length - 1);
                    DebugPrintString_ThisRotation = string.Format(" ({0}) -{1}", TotalChance.ToString("P0"), DebugPrintString_ThisRotation);
                    if (RelicPasteData_Rotation.First().Value.Count == 1) { DebugPrintString_ThisRotation = DebugPrintString_ThisRotation.Substring(DebugPrintString_ThisRotation.IndexOf(") -") + 4); }

                    DebugPrintString += string.Format(" \"{0}\",", DebugPrintString_ThisRotation.Trim());
                }
                DebugPrintString = DebugPrintString.Remove(DebugPrintString.Length - 1) + " });";

                //Orokin Derelict causes errors, it got a non standard format for some reason. Skip that here and write it manually.
                if (DebugPrintString.Contains("Orokin (Derelict)")) { continue; }

                Debug.Print(DebugPrintString);
            }
        }

        public static Dictionary<string, List<string>> RelicData = new Dictionary<string, List<string>>();

        public static void Initialize_RelicData()
        {
            RelicData.Add("15 Orb Vallis Bounty (Level 5)", new List<string> { "Lith 31%" });
            RelicData.Add("Aegaeon (Saturn)", new List<string> { "Meso 77%" });
            RelicData.Add("Akkad (Eris)", new List<string> { "A - Lith 48%", "B - Meso 11%", "C (66%) - Meso 53%, Neo 13%" });
            RelicData.Add("Alator (Mars)", new List<string> { "A (77%) - Lith 54%, Meso 23%", "B - Meso 41%", "C - Meso 97%" });
            RelicData.Add("Amalthea (Jupiter)", new List<string> { "Meso 77%" });
            RelicData.Add("Amarna (Sedna)", new List<string> { "B - Neo 47%", "C - Axi 77%" });
            RelicData.Add("Ani (Void)", new List<string> { "A (100%) - Lith 77%, Meso 23%", "B (100%) - Meso 77%, Neo 23%", "C (100%) - Meso 50%, Neo 50%" });
            RelicData.Add("Apollo (Lua)", new List<string> { "A - Neo 100%", "B - Axi 100%", "C - Axi 87%" });
            RelicData.Add("Apollodorus (Mercury)", new List<string> { "B - Lith 54%", "C - Lith 77%" });
            RelicData.Add("Arcadia (Mars)", new List<string> { "B - Lith 54%", "C - Lith 77%" });
            RelicData.Add("Arval (Mars)", new List<string> { "Lith 100%" });
            RelicData.Add("Assur (Uranus)", new List<string> { "B - Neo 47%", "C - Axi 77%" });
            RelicData.Add("Aten (Void)", new List<string> { "(100%) - Neo 50%, Axi 50%" });
            RelicData.Add("Augustus (Mars)", new List<string> { "B - Lith 54%", "C - Lith 77%" });
            RelicData.Add("Belenus (Void)", new List<string> { "A (100%) - Meso 50%, Neo 50%", "B - Neo 100%", "C (100%) - Neo 77%, Axi 23%" });
            RelicData.Add("Bendar (Earth)", new List<string> { "Lith 21%" });
            RelicData.Add("Berehynia (Sedna)", new List<string> { "A - Neo 70%", "B - Axi 100%", "C - Axi 100%" });
            RelicData.Add("Bianca (Uranus)", new List<string> { "A - Neo 70%", "B - Axi 47%", "C - Axi 77%" });
            RelicData.Add("Bode (Ceres)", new List<string> { "Meso 77%" });
            RelicData.Add("Caelus (Uranus)", new List<string> { "Axi 68%" });
            RelicData.Add("Callisto (Jupiter)", new List<string> { "A - Meso 70%", "B - Neo 50%", "C - Neo 100%" });
            RelicData.Add("Cambria (Earth)", new List<string> { "Lith 100%" });
            RelicData.Add("Camenae (Sedna)", new List<string> { "A - Meso 100%", "B - Neo 44%", "C - Neo 77%" });
            RelicData.Add("Cameria (Jupiter)", new List<string> { "B - Meso 50%", "C - Neo 77%" });
            RelicData.Add("Caracol (Saturn)", new List<string> { "B - Meso 76%", "C - Neo 77%" });
            RelicData.Add("Casta (Ceres)", new List<string> { "A - Lith 64%", "B - Meso 58%", "C - Meso 58%" });
            RelicData.Add("Cerberus (Pluto)", new List<string> { "A - Neo 70%", "B - Axi 100%", "C - Axi 100%" });
            RelicData.Add("Cholistan (Europa)", new List<string> { "B - Neo 47%", "C - Axi 77%" });
            RelicData.Add("Cinxia (Ceres)", new List<string> { "A (77%) - Lith 54%, Meso 23%", "B - Meso 41%", "C - Meso 97%" });
            RelicData.Add("Coba (Earth)", new List<string> { "A - Lith 48%", "B - Meso 11%", "C (66%) - Meso 53%, Neo 13%" });
            RelicData.Add("Cupid (Uranus)", new List<string> { "B - Neo 47%", "C - Axi 77%" });
            RelicData.Add("Cyath (Eris)", new List<string> { "(100%) - Meso 77%, Neo 23%" });
            RelicData.Add("Cytherean (Venus)", new List<string> { "A (77%) - Lith 54%, Meso 23%", "B - Meso 41%", "C - Meso 97%" });
            RelicData.Add("Despina (Neptune)", new List<string> { "B - Neo 47%", "C - Axi 77%" });
            RelicData.Add("Dione (Saturn)", new List<string> { "Meso 77%" });
            RelicData.Add("Draco (Ceres)", new List<string> { "B - Meso 50%", "C - Neo 77%" });
            RelicData.Add("Drunlo (Phobos)", new List<string> { "A - Lith 64%", "B - Meso 58%", "C - Meso 58%" });
            RelicData.Add("Egeria (Ceres)", new List<string> { "A - Lith 64%", "B - Meso 58%", "C - Meso 58%" });
            RelicData.Add("Elara (Jupiter)", new List<string> { "B - Meso 50%", "C - Neo 77%" });
            RelicData.Add("Everest (Earth)", new List<string> { "B - Lith 54%", "C - Lith 77%" });
            RelicData.Add("Flexa (Veil)", new List<string> { "Neo 14%" });
            RelicData.Add("Flimnap (Phobos)", new List<string> { "B - Lith 54%", "C - Lith 77%" });
            RelicData.Add("Gabii (Ceres)", new List<string> { "B - Lith 54%", "C - Lith 77%" });
            RelicData.Add("Gaia (Earth)", new List<string> { "A (77%) - Lith 54%, Meso 23%", "B - Meso 41%", "C - Meso 97%" });
            RelicData.Add("Ganalen's (Veil)", new List<string> { "Neo 14%" });
            RelicData.Add("Ganymede (Jupiter)", new List<string> { "A - Meso 39%", "B - Neo 39%", "C - Axi 35%" });
            RelicData.Add("Gian (Veil)", new List<string> { "Neo 14%" });
            RelicData.Add("Gnathos (Eris)", new List<string> { "(100%) - Meso 77%, Neo 23%" });
            RelicData.Add("Grildrig (Phobos)", new List<string> { "Lith 100%" });
            RelicData.Add("Gulliver (Phobos)", new List<string> { "A - Lith 64%", "B - Meso 58%", "C - Meso 58%" });
            RelicData.Add("H-2 (Veil)", new List<string> { "Neo 14%" });
            RelicData.Add("Hallowed Flame Endurance Caches", new List<string> { "Lith 7%" });
            RelicData.Add("Hapke (Ceres)", new List<string> { "Lith 100%" });
            RelicData.Add("Helene (Saturn)", new List<string> { "A - Meso 100%", "B - Neo 44%", "C - Neo 77%" });
            RelicData.Add("Hepit (Void)", new List<string> { "Lith 100%" });
            RelicData.Add("Hieracon (Pluto)", new List<string> { "B - Neo 47%", "C - Axi 77%" });
            RelicData.Add("Hydron (Sedna)", new List<string> { "A - Neo 70%", "B - Axi 47%", "C - Axi 77%" });
            RelicData.Add("Hymeno (Eris)", new List<string> { "B - Neo 47%", "C - Axi 77%" });
            RelicData.Add("Iapetus (Saturn)", new List<string> { "A - Meso 70%", "B - Neo 50%", "C - Neo 100%" });
            RelicData.Add("Io (Jupiter)", new List<string> { "A - Meso 100%", "B - Neo 44%", "C - Neo 77%" });
            RelicData.Add("Iota (Earth)", new List<string> { "Lith 21%" });
            RelicData.Add("Ixodes (Eris)", new List<string> { "A - Neo 70%", "B - Axi 47%", "C - Axi 77%" });
            RelicData.Add("Jex (Earth)", new List<string> { "Lith 21%" });
            RelicData.Add("Kadesh (Mars)", new List<string> { "A - Lith 48%", "B - Meso 11%", "C (66%) - Meso 53%, Neo 13%" });
            RelicData.Add("Kala-Azar (Eris)", new List<string> { "A - Neo 70%", "B - Axi 47%", "C - Axi 77%" });
            RelicData.Add("Kappa (Sedna)", new List<string> { "(100%) - Meso 77%, Neo 23%" });
            RelicData.Add("Kasio's (Saturn)", new List<string> { "Meso 14%" });
            RelicData.Add("Kelashin (Neptune)", new List<string> { "B - Neo 47%", "C - Axi 77%" });
            RelicData.Add("Kelpie (Sedna)", new List<string> { "A - Meso 100%", "B - Neo 100%", "C - Axi 71%" });
            RelicData.Add("Kepler (Phobos)", new List<string> { "Lith 68%" });
            RelicData.Add("Kiliken (Venus)", new List<string> { "B - Lith 54%", "C - Lith 77%" });
            RelicData.Add("Korms (Earth)", new List<string> { "Lith 21%" });
            RelicData.Add("Kuva Flood", new List<string> { "Requiem 100%" });
            RelicData.Add("Kuva Siphon", new List<string> { "Requiem 50%" });
            RelicData.Add("Lares (Mercury)", new List<string> { "A - Lith 64%", "B - Meso 58%", "C - Meso 58%" });
            RelicData.Add("Larzac (Europa)", new List<string> { "A - Lith 48%", "B - Meso 11%", "C (66%) - Meso 53%, Neo 13%" });
            RelicData.Add("Lillith (Europa)", new List<string> { "B - Meso 50%", "C - Neo 77%" });
            RelicData.Add("Lith (Earth)", new List<string> { "A - Lith 64%", "B - Meso 58%", "C - Meso 58%" });
            RelicData.Add("Lupal (Saturn)", new List<string> { "Meso 14%" });
            RelicData.Add("Malva (Venus)", new List<string> { "B - Lith 54%", "C - Lith 77%" });
            RelicData.Add("Marduk (Void)", new List<string> { "(100%) - Neo 50%, Axi 50%" });
            RelicData.Add("Memphis (Phobos)", new List<string> { "B - Lith 76%", "C - Lith 77%" });
            RelicData.Add("Minhast (Earth)", new List<string> { "Lith 21%" });
            RelicData.Add("Miranda (Uranus)", new List<string> { "A - Neo 70%", "B - Axi 47%", "C - Axi 77%" });
            RelicData.Add("Mithra (Void)", new List<string> { "A - Neo 100%", "B - Neo 100%", "C - Axi 100%" });
            RelicData.Add("Mordo (Saturn)", new List<string> { "Meso 14%" });
            RelicData.Add("Mot (Void)", new List<string> { "A - Neo 100%", "B - Neo 100%", "C - Axi 100%" });
            RelicData.Add("Nereid (Neptune)", new List<string> { "(100%) - Meso 77%, Neo 23%" });
            RelicData.Add("Nimus (Eris)", new List<string> { "B - Neo 47%", "C - Axi 77%" });
            RelicData.Add("Nodo (Saturn)", new List<string> { "Meso 14%" });
            RelicData.Add("Nsu (Veil)", new List<string> { "Neo 14%" });
            RelicData.Add("Oceanum (Pluto)", new List<string> { "(100%) - Meso 77%, Neo 23%" });
            RelicData.Add("Odin (Mercury)", new List<string> { "A (77%) - Lith 54%, Meso 23%", "B - Meso 41%", "C - Meso 97%" });
            RelicData.Add("Oestrus (Eris)", new List<string> { "A - Neo 70%", "B - Axi 47%" });
            RelicData.Add("Ogal (Earth)", new List<string> { "Lith 21%" });
            RelicData.Add("Olympus (Mars)", new List<string> { "A - Lith 100%", "B - Lith 100%", "C - Meso 100%" });
            RelicData.Add("Ophelia (Uranus)", new List<string> { "B - Neo 47%", "C - Axi 77%" });
            RelicData.Add("Opik (Phobos)", new List<string> { "A - Lith 15%", "B - Meso 11%", "C (73%) - Meso 59%, Neo 14%" });
            RelicData.Add("Ose (Europa)", new List<string> { "A - Meso 70%", "B - Neo 50%", "C - Neo 100%" });
            RelicData.Add("Oxomoco (Void)", new List<string> { "(100%) - Meso 50%, Neo 50%" });
            RelicData.Add("Paimon (Europa)", new List<string> { "A - Meso 100%", "B - Neo 44%", "C - Neo 77%" });
            RelicData.Add("Palus (Pluto)", new List<string> { "B - Neo 47%", "C - Axi 77%" });
            RelicData.Add("Pandora (Saturn)", new List<string> { "(35%) - Meso 30%, Neo 5%" });
            RelicData.Add("Phalan (Eris)", new List<string> { "A - Neo 70%", "B - Axi 100%", "C - Axi 100%" });
            RelicData.Add("Phanghoul (Earth)", new List<string> { "Lith 21%" });
            RelicData.Add("Piscinas (Saturn)", new List<string> { "B - Meso 50%", "C - Neo 77%" });
            RelicData.Add("Posit (Earth)", new List<string> { "Lith 21%" });
            RelicData.Add("Proteus (Neptune)", new List<string> { "A - Neo 70%", "B - Axi 47%", "C - Axi 77%" });
            RelicData.Add("R-9 (Veil)", new List<string> { "Neo 14%" });
            RelicData.Add("Recover The Orokin Archive", new List<string> { "(100%) - Lith 15%, Meso 70%, Neo 14%" });
            RelicData.Add("Rhea (Saturn)", new List<string> { "A - Meso 70%", "B - Neo 50%", "C - Neo 100%" });
            RelicData.Add("Rian (Earth)", new List<string> { "Lith 21%" });
            RelicData.Add("Romula (Venus)", new List<string> { "A - Lith 48%", "B - Meso 11%", "C (66%) - Meso 53%, Neo 13%" });
            RelicData.Add("Rosalind (Uranus)", new List<string> { "(100%) - Meso 77%, Neo 23%" });
            RelicData.Add("Ruse (Veil)", new List<string> { "Neo 14%" });
            RelicData.Add("Rya (Veil)", new List<string> { "Neo 14%" });
            RelicData.Add("Sangeru (Sedna)", new List<string> { "A - Lith 48%", "B - Meso 11%", "C (66%) - Meso 53%, Neo 13%" });
            RelicData.Add("Scylla (Sedna)", new List<string> { "B - Neo 47%", "C - Axi 77%" });
            RelicData.Add("Sechura (Pluto)", new List<string> { "A - Lith 48%", "B - Meso 11%", "C (66%) - Meso 53%, Neo 13%" });
            RelicData.Add("Seimeni (Ceres)", new List<string> { "A - Lith 48%", "B - Meso 11%", "C (66%) - Meso 53%, Neo 13%" });
            RelicData.Add("Selkie (Sedna)", new List<string> { "B - Neo 47%", "C - Axi 77%" });
            RelicData.Add("Shklovsky (Phobos)", new List<string> { "Lith 100%" });
            RelicData.Add("Sinai (Jupiter)", new List<string> { "A - Lith 48%", "B - Meso 11%", "C (66%) - Meso 53%, Neo 13%" });
            RelicData.Add("Sover (Earth)", new List<string> { "Lith 21%" });
            RelicData.Add("Spear (Mars)", new List<string> { "A - Lith 64%", "B - Meso 58%", "C - Meso 58%" });
            RelicData.Add("Spiro (Saturn)", new List<string> { "Meso 14%" });
            RelicData.Add("Sporid (Eris)", new List<string> { "A - Neo 70%", "B - Axi 100%", "C - Axi 100%" });
            RelicData.Add("Stephano (Uranus)", new List<string> { "A - Neo 70%", "B - Axi 47%", "C - Axi 77%" });
            RelicData.Add("Stickney (Phobos)", new List<string> { "B - Lith 54%", "C - Lith 77%" });
            RelicData.Add("StöFler (Lua)", new List<string> { "A - Neo 70%", "B - Axi 47%", "C - Axi 77%" });
            RelicData.Add("Stribog (Void)", new List<string> { "(100%) - Lith 50%, Meso 50%" });
            RelicData.Add("Suisei (Mercury)", new List<string> { "Lith 100%" });
            RelicData.Add("Taranis (Void)", new List<string> { "A - Lith 100%", "B (100%) - Lith 77%, Meso 23%", "C (100%) - Lith 50%, Meso 50%" });
            RelicData.Add("Teshub (Void)", new List<string> { "Lith 100%" });
            RelicData.Add("Tessera (Venus)", new List<string> { "A - Lith 64%", "B - Meso 58%", "C - Meso 58%" });
            RelicData.Add("Tikal (Earth)", new List<string> { "B - Lith 54%", "C - Lith 77%" });
            RelicData.Add("Tikoloshe (Sedna)", new List<string> { "(100%) - Meso 77%, Neo 23%" });
            RelicData.Add("Titan (Saturn)", new List<string> { "B - Meso 50%", "C - Neo 77%" });
            RelicData.Add("Tiwaz (Void)", new List<string> { "(100%) - Lith 50%, Meso 50%" });
            RelicData.Add("Tycho (Lua)", new List<string> { "B - Neo 47%", "C - Axi 77%" });
            RelicData.Add("Ukko (Void)", new List<string> { "(100%) - Meso 50%, Neo 50%" });
            RelicData.Add("Umbriel (Uranus)", new List<string> { "A - Meso 70%", "B - Neo 50%", "C - Neo 100%" });
            RelicData.Add("Unda (Venus)", new List<string> { "Lith 100%" });
            RelicData.Add("Ur (Uranus)", new List<string> { "A - Meso 100%", "B - Neo 100%", "C - Neo 95%" });
            RelicData.Add("Valac (Europa)", new List<string> { "Meso 77%" });
            RelicData.Add("Valefor (Europa)", new List<string> { "B - Meso 50%", "C - Neo 77%" });
            RelicData.Add("Vand (Saturn)", new List<string> { "Meso 14%" });
            RelicData.Add("Varro (Ceres)", new List<string> { "A - Lith 64%", "B - Meso 58%", "C - Meso 58%" });
            RelicData.Add("Vesper (Venus)", new List<string> { "Lith 100%" });
            RelicData.Add("Vila (Saturn)", new List<string> { "Meso 14%" });
            RelicData.Add("Wahiba (Mars)", new List<string> { "B - Meso 50%", "C - Neo 77%" });
            RelicData.Add("Wendell (Phobos)", new List<string> { "B - Lith 54%", "C - Lith 77%" });
            RelicData.Add("Xini (Eris)", new List<string> { "A - Neo 70%", "B - Axi 100%", "C - Axi 100%" });
            RelicData.Add("Yemaja (Sedna)", new List<string> { "B - Neo 47%", "C - Axi 77%" });
            RelicData.Add("Yursa (Neptune)", new List<string> { "B - Neo 76%", "C - Axi 77%" });
            RelicData.Add("Zabala (Eris)", new List<string> { "B - Neo 100%", "C - Axi 88%" });
            RelicData.Add("Zagan (Europa)", new List<string> { "B - Meso 50%", "C - Neo 77%" });
            RelicData.Add("Zeugma (Phobos)", new List<string> { "B - Meso 50%", "C - Neo 77%" });
        }


        #endregion



        #region Baro Data

        public static DateTime BaroStartsAt;
        public static void GetBaroData()
        {
            //http://content.warframe.com/dynamic/worldState.php

            string WarframeWorldState_JSON;
            using (WebClient TempWebClient = new WebClient())
            {
                TempWebClient.Encoding = Encoding.UTF8;
                WarframeWorldState_JSON = TempWebClient.DownloadString("http://content.warframe.com/dynamic/worldState.php");
            }
            WarframeWorldState_JSON = WarframeWorldState_JSON.Remove(0, WarframeWorldState_JSON.IndexOf("VoidTraders") + ("VoidTraders").Length + 3);
            WarframeWorldState_JSON = WarframeWorldState_JSON.Substring(0, WarframeWorldState_JSON.IndexOf("PrimeAccessAvailability") - 3);//Substring(0, WarframeWorldState_JSON.IndexOf("]"));
            JObject BaroJObject = JObject.Parse(WarframeWorldState_JSON);
            BaroStartsAt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(BaroJObject["Activation"]["$date"]["$numberLong"].Value<Int64>());
        }

        #endregion



        #region Prime Data

        public static Dictionary<string, PrimeData> PrimeItemsData = new Dictionary<string, PrimeData>();

        public static void PrimeItemData_Download(object sender, DoWorkEventArgs e)
        {
            //https://tenno.zone/data/ Used for scraping Prime Data, easier than from wiki
            JObject PrimeDataJSON = JObject.Parse(new WebClient().DownloadString("https://tenno.zone/data/"));

            PrimeItemsData.Clear();

            //Get items
            Dictionary<string, string> PartIDsList = new Dictionary<string, string>();
            foreach (JToken PrimePart in PrimeDataJSON["parts"])
            {
                string PartName = PrimePart["name"].Value<string>();
                PartIDsList.Add(PrimePart["id"].Value<string>(), PartName); //Also add Forma to list to avoid error
                if (PartName.Contains("Forma")) { continue; }
                PrimeItemsData.Add(PartName, new PrimeData() { Name = PartName, Ducat_Value = PrimePart["ducats"].Value<string>() });
            }

            //Get vaulted status
            List<string> RelicItems_Vaulted = new List<string>();
            List<string> RelicItems_NonVaulted = new List<string>();
            foreach (JToken Relic in PrimeDataJSON["relics"])
            {
                foreach (JToken ItemInsideRelic in Relic["parts"])
                {
                    var isVaulted = Relic["isVaulted"]; //Aklex Prime Blueprint and Aklex Prime Link have name only
                    if (isVaulted != null)
                    {
                        string PrimePartName = PartIDsList[ItemInsideRelic["partId"].Value<string>()];
                        if (isVaulted.Value<bool>())
                        {
                            RelicItems_Vaulted.Add(PrimePartName);
                        }
                        else
                        {
                            RelicItems_NonVaulted.Add(PrimePartName);
                        }
                    }
                }
            }
            RelicItems_Vaulted = RelicItems_Vaulted.Distinct().ToList();
            RelicItems_Vaulted.Sort();
            RelicItems_NonVaulted = RelicItems_NonVaulted.Distinct().ToList();
            RelicItems_NonVaulted.Sort();
            List<string> VaultedPrimeItems = RelicItems_Vaulted.Except(RelicItems_NonVaulted).ToList();
            VaultedPrimeItems.Sort();
            foreach (string PrimeItem in RelicItems_Vaulted)
            {
                if (PrimeItem.Contains("Forma")) { continue; }
                PrimeItemsData[PrimeItem].isVaulted = true;
            }

            //get market data
            double ProgressCounter = 0;
            foreach (string PrimeItem in PrimeItemsData.Keys)
            {
                string FixName = PrimeItem.Replace(" ", "_").ToLower();
                if (FixName.Contains("&")) { FixName = FixName.Replace("&", "and"); }
                if (FixName.Contains("chassis") || FixName.Contains("neuroptics") || FixName.Contains("systems") || FixName.Contains("harness") || FixName.Contains("wings"))
                {
                    if (FixName.Contains("blueprint")) { FixName = FixName.Replace("_blueprint", ""); }
                }
                else if (FixName.Contains("kavasa"))
                {
                    if (FixName.Contains("blueprint")) { FixName = FixName.Replace("kavasa_prime_collar", "kavasa_prime_kubrow_collar"); }
                    else { FixName = FixName.Replace("kavasa_prime_collar", "kavasa_prime"); }
                }
                JToken ListedItems = JToken.Parse(new WebClient().DownloadString("https://api.warframe.market/v1/items/" + FixName + "/orders"))["payload"]["orders"];
                List<int> PlatList = new List<int>();
                for (int x = 0; x < ListedItems.Count() - 1; x++)
                {
                    if (ListedItems[x]["order_type"].Value<string>().Equals("sell"))
                    {
                        for (int y = 1; y <= ListedItems[x]["quantity"].Value<int>(); y++)
                        {
                            PlatList.Add(ListedItems[x]["platinum"].Value<int>());
                        }
                    }
                }
                PrimeItemsData[PrimeItem].Platinum_Average = Convert.ToInt32(PlatList.Average()).ToString();
                PrimeItemsData[PrimeItem].Platinum_Min = Convert.ToInt32(PlatList.Min()).ToString();
                PrimeItemsData[PrimeItem].Platinum_Max = Convert.ToInt32(PlatList.Max()).ToString();
                PrimeItemsData[PrimeItem].Market_Count = PlatList.Count().ToString();
                ProgressCounter += 1;
                Form_Main._FormReference.BeginInvoke(new Action(() => { Form_Main._FormReference.PrimeData_DL_btn.Text = (ProgressCounter / PrimeItemsData.Count).ToString("P"); }));
            }

            string SerializeAndWrite = JsonConvert.SerializeObject(PrimeItemsData);
            File.WriteAllText("PrimeData.txt", SerializeAndWrite);
        }

        public static void PrimeItemData_DownloadFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Prime Data has been downloaded.", "Warframe Prime Data Download", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form_Main._FormReference.PrimeData_DL_btn.Text = "DL Prime Data";
            Form_Main._FormReference.PrimeData_DL_btn.Enabled = true;
        }

        public static void PrimeItemData_Load()
        {
            JObject JSON_Payload = JObject.Parse(File.ReadAllText("PrimeData.txt"));
            foreach (KeyValuePair<string, JToken> PrimeItem in JSON_Payload)
            {
                JToken TempJToken = PrimeItem.Value;
                PrimeData TempData = new PrimeData()
                {
                    Name = TempJToken["Name"].Value<string>(),
                    Ducat_Value = TempJToken["Ducat_Value"].Value<string>(),
                    Platinum_Average = TempJToken["Platinum_Average"].Value<string>(),
                    Platinum_Min = TempJToken["Platinum_Min"].Value<string>(),
                    Platinum_Max = TempJToken["Platinum_Max"].Value<string>(),
                    Market_Count = TempJToken["Market_Count"].Value<string>(),
                    isVaulted = TempJToken["isVaulted"].Value<bool>(),
                };
                PrimeItemsData.Add(PrimeItem.Key, TempData);
            }
        }

        public static void PrimeItemDictionary()
        {
            List<string> TempList = new List<string>();
            foreach (string PrimeString in PrimeItemsData.Keys)
            {
                TempList.AddRange(PrimeString.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            }
            TempList = TempList.Distinct().ToList();
            TempList.Sort();
            File.WriteAllLines("PrimeDictionary.txt", TempList);
        }

        #endregion

    }

    class SolarNodeData
    {
        public string Name { get; set; }
        public string Enemy { get; set; }
        public string MissionType { get; set; }

        public SolarNodeData() { }
        public SolarNodeData(string NameInit, string EnemyInit, string TypeInit)
        {
            Name = NameInit;
            Enemy = EnemyInit;
            MissionType = TypeInit;
        }
    }

    class PrimeData
    {
        public string Name = "None";
        public string Ducat_Value = "None";
        public string Platinum_Average = "None";
        public string Platinum_Min = "None";
        public string Platinum_Max = "None";
        public string Market_Count = "None";
        public bool isVaulted = false;
    }

}
