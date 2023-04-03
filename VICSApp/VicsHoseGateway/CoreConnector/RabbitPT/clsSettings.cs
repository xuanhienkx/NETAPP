using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace HOGW_PT_Dealer
{
    [Serializable]
    public class clsSettings
    {
        #region private Fields

        private clsApplication appRelated = new clsApplication();
        private Paths paths = new Paths();

        #endregion

        #region Constructors

        public clsSettings()
        {
        }

        #endregion

        #region Public properties

        public Paths Paths
        {
            get
            {
                return paths;
            }
            set
            {
                paths = value;
            }
        }

        public clsApplication AppRelated
        {
            get
            {
                return appRelated;
            }
            set
            {
                appRelated = value;
            }
        }

        #endregion

        #region Methods: Save, Load

        /// <summary>
        /// Saves this settings object to desired location
        /// </summary>
        /// <param name="fileName"></param>
        public void Save(string fileName)
        {
            // Insert code to set properties and fields of the object.
            XmlSerializer mySerializer = new XmlSerializer(typeof(clsSettings));
            // To write to a file, create a StreamWriter object.
            StreamWriter myWriter = new StreamWriter(fileName);
            mySerializer.Serialize(myWriter, this);
            myWriter.Close();
        }

        /// <summary>
        /// Returns a clsSettings object, loaded from a specific location
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static clsSettings Load(string fileName)
        {
            // Constructs an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer = new XmlSerializer(typeof(clsSettings));
            // To read the file, creates a FileStream.
            FileStream myFileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            // Calls the Deserialize method and casts to the object type.
            clsSettings pos = (clsSettings)mySerializer.Deserialize(myFileStream);
            myFileStream.Close();
            //appRelated = pos.AppRelated;
            //paths = pos.Paths;
            return pos;
        }

        #endregion
    }
    [Serializable]
    public class clsApplication
    {
        /*<add key="PriceMultipleOperand" value="1" />
        <add key="AdminMobiles" value="84912591416;84912327166;84912848673" />
        <add key="FirmID" value="69" />
        <add key="ContactAddress" value="SHS069,162ThaiHa,Tel:04.5373838" />
        <add key="PTOrderInterval" value="10000" />
        <add key="MatchingOrderInterval" value="5000" />
        <add key="AppName" value="HOGW_PT_Dealer" />
        <add key="Board" value="B" />
        <add key="BoardOdd" value="O" />
        <add key="MaxNumThread" value="3" />
        <add key="SBSGatewayUsername" value="pm" />
        <add key="SBSGatewayPassword" value="pm" />*/

        #region fields
        private int priceMultipleOperand = 0;

        public int PriceMultipleOperand
        {
            get { return priceMultipleOperand; }
            set { priceMultipleOperand = value; }
        }
        private string adminMobiles = "";

        public string AdminMobiles
        {
            get { return adminMobiles; }
            set { adminMobiles = value; }
        }
        private int firmID = 0;

        public int FirmID
        {
            get { return firmID; }
            set { firmID = value; }
        }
        private string contactAddress = "";

        public string ContactAddress
        {
            get { return contactAddress; }
            set { contactAddress = value; }
        }
        private int ptOrderInterval = 0;

        public int PtOrderInterval
        {
            get { return ptOrderInterval; }
            set { ptOrderInterval = value; }
        }
        private int matchingOrderInterval = 0;

        public int MatchingOrderInterval
        {
            get { return matchingOrderInterval; }
            set { matchingOrderInterval = value; }
        }
        private string appName = "";

        public string AppName
        {
            get { return appName; }
            set { appName = value; }
        }
        private string board = "";

        public string Board
        {
            get { return board; }
            set { board = value; }
        }
        private string boardOdd = "";

        public string BoardOdd
        {
            get { return boardOdd; }
            set { boardOdd = value; }
        }
        private int maxNumThread = 0;

        public int MaxNumThread
        {
            get { return maxNumThread; }
            set { maxNumThread = value; }
        }
        private string sbsGatewayUsername = "";

        public string SbsGatewayUsername
        {
            get { return sbsGatewayUsername; }
            set { sbsGatewayUsername = value; }
        }
        private string sbsGatewayPassword = "";

        public string SbsGatewayPassword
        {
            get { return sbsGatewayPassword; }
            set { sbsGatewayPassword = value; }
        }
        #endregion       

        #region Constructors
        public clsApplication()
        {
        }

        #endregion
    }
    [Serializable]
    public class Paths
    {
        #region private fields

        private string initialPath = "";
        private string dBPath = "";
        private string[] webServices = null;

        #endregion

        #region Constructors

        public Paths()
        {
        }

        #endregion

        #region Public properties

        [XmlElement("WebService")]
        public string[] WebServices
        {
            get
            {
                return webServices;
            }
            set
            {
                webServices = value;
            }
        }

        public string DBPath
        {
            get { return dBPath; }
            set { dBPath = value; }
        }


        public string InitialPath
        {
            get
            {
                return initialPath;
            }
            set
            {
                initialPath = value;
            }
        }

        #endregion
    }
}
