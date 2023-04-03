using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace InterStock
{
    public class CommonSettings
    {
        //GIAO DICH THONG THUONG
        /// <summary>
        /// P
        /// </summary>
        public const string PENDING = "P"; //LENH CHO DUYET TAI CONG TY CHUNG KHOAN
        /// <summary>
        /// S
        /// </summary>
        public const string APPROVED = "S"; //LENH DA DUOC DUYET TAI CONG TY CHUNG KHOAN
        /// <summary>
        /// E
        /// </summary>
        public const string ENTERED = "E"; //LENH DA VAO SAN
        /// <summary>
        /// M
        /// </summary>
        public const string MATCHED = "M"; //LENH DA KHOP 
        /// <summary>
        /// O
        /// </summary>
        public const string PARTLY_MATCHED = "O"; //LENH DA KHOP MOT PHAN; CHO KHOP
        /// <summary>
        /// C
        /// </summary>
        public const string CANCELLED = "C"; //LENH DA HUY TAI SAN
        /// <summary>
        /// W
        /// </summary>
        public const string CANCEL_WAITING = "W"; //LENH CHO HUY (CHO DE GUI LENH HUY VAO SAN)
        /// <summary>
        /// D
        /// </summary>
        public const string CANCELLED_BY_GATEWAY = "D"; //LENH CHO HUY (CHO DE GUI LENH HUY VAO SAN)
        /// <summary>
        /// X
        /// </summary>
        public const string LOCAL_CANCELLED = "X"; //LENH DA HUY TAI CONG TY CHUNG KHOAN
        /// <summary>
        /// ERR
        /// </summary>
        public const string ERROR = "L"; //Lenh loi do khong pass duoc validation

        //GIAO DICH THOA THUAN
        /// <summary>
        /// P
        /// </summary>
        public const string PT_PENDING = "P"; //LENH CHO DUYET TAI CONG TY CHUNG KHOAN        
        /// <summary>
        /// S
        /// </summary>
        public const string PT_APPROVED = "S"; //LENH DA DUOC DUYET TAI CONG TY CHUNG KHOAN
        /// <summary>
        /// E
        /// </summary>
        public const string PT_ENTERED = "E"; //LENH DA VAO SAN
        /// <summary>
        /// NS
        /// </summary>
        public const string PT_DISAPPROVED_BY_HOSE = "NS"; //SAN DISAPPROVE
        /// <summary>
        /// NC
        /// </summary>
        public const string PT_DISAPPROVED_BY_CONTRA = "NC"; //CONTRA_FIRM DISAPPROVE       
        /// <summary>
        /// M
        /// </summary>
        public const string PT_MATCHED = "M"; //LENH DA KHOP 
        /// <summary>
        /// X
        /// </summary>
        public const string PT_CANCELLED = "X"; //LENH HUY TAI CONG TY CHUNG KHOAN/KHONG DUOC DUYET 
        /// <summary>
        /// MXP
        /// </summary>
        public const string PT_PENDING_CANCEL = "MXP"; //CHO DUYET LENH HUY
        /// <summary>
        /// MXS
        /// </summary>
        public const string PT_CANCEL_WAITING = "MXS"; //CHO DE LENH HUY DUOC GUI VAO SAN
        /// <summary>
        /// MXE
        /// </summary>
        public const string PT_CANCEL_ENTERED = "MXE"; //DA GUI LENH HUY VAO SAN
        /// <summary>
        /// MS
        /// </summary>
        public const string PT_CANCEL_UNCONFIRMED_BY_HOSE = "MS"; //SAN CONFIRM KHONG HUY
        /// <summary>
        /// MC
        /// </summary>
        public const string PT_CANCEL_UNCONFIRMED_BY_CONTRA = "MC"; //SAN CONFIRM KHONG HUY
        /// <summary>
        /// SP
        /// </summary>
        public const string PT_BUYER_APPROVED = "SP"; //BUYER DUYET DEAL TU 2F TRA VE
        /// <summary>
        /// C
        /// </summary>
        public const string PT_BUYER_DEAL_DISAPPROVE_PENDING = "C"; //khong chap nhan deal tu seller (BROKER vua duyet, CHO KIEM SOAT DUYET)
        /// <summary>
        /// SC
        /// </summary>
        public const string PT_BUYER_DEAL_DISAPPROVE = "SC"; //khong chap nhan deal tu seller (kiem soat vua duyet)
        /// <summary>
        /// MX
        /// </summary>
        public const string PT_BUYER_CANCEL_WAITING = "MX"; //LENH HUY CUA SELLER CHO BUYER HUY
        /// <summary>
        /// MXCS
        /// </summary>
        public const string PT_BUYER_CANCEL_DISAPPROVE = "MXCS"; //kiem soat TU CHOI LENH HUY CUA SELLER
        /// <summary>
        /// MXS
        /// </summary>
        public const string PT_BUYER_CANCEL_APPROVE = "MXS"; //kiem soat CHAP NHAN LENH HUY CUA SELLER        
        /// <summary>
        /// MXCP
        /// </summary>
        public const string PT_BUYER_CANCEL_DISAPPROVE_PENDING = "MXCP"; //broker TU CHOI LENH HUY CUA SELLER
        /// <summary>
        /// MXP
        /// </summary>
        public const string PT_BUYER_CANCEL_APPROVE_PENDING = "MXP"; //broker CHAP NHAN LENH HUY CUA SELLER     
        /// <summary>
        /// RP
        /// </summary>
        public const string PT_BUYER_BEFORE_PENDING = "RP"; //TRUOC KHI DUYET LENH HUY CUA SELLER 
        /// <summary>
        /// XD
        /// </summary>
        public const string PT_BUYER_CANCELLED = "XD"; //DA HUY
        /// <summary>
        /// D
        /// </summary>
        public const string PT_CONFIRMED = "D"; //SAN CONFIRM GUI LENH MOI
        /// <summary>
        /// MXD
        /// </summary>
        public const string PT_CANCEL_CONFIRMED = "MXD"; //SAN CONFIRM HUY
        /// <summary>
        /// ERR
        /// </summary>
        public const string PT_ERROR = "ERR"; //Lenh loi do khong pass duoc validation
                
        //gateway messages status
        /// <summary>
        /// N
        /// </summary>
        public const string GW_NEW = "N"; //Message moi
        /// <summary>
        /// R
        /// </summary>
        public const string GW_RECEIVED = "R"; //Vua nhan duoc tu Protocol Handle
        /// <summary>
        /// S
        /// </summary>
        public const string GW_SENT_TO_PROTOCOL = "S"; //Da gui cho Protocol Handle
        /// <summary>
        /// Q
        /// </summary>
        public const string GW_QUEUED = "Q"; //Dang duoc queued
        /// <summary>
        /// W
        /// </summary>
        public const string GW_WRITTEN_TO_FILE = "W"; //Da ghi vao file (PRS, CTCI file)
        /// <summary>
        /// D
        /// </summary>
        public const string GW_READ = "D"; //Da duoc xu ly xong, da doc        

        //----- loai lenh -----
        public const string ORT_NEW = "N"; //tao moi
        public const string ORT_CANCEL = "X"; //Huy
        public const string ORT_CHANGE = "C"; //Sua

        //-------- MA LOI -----------
        /// <summary>
        /// OK
        /// </summary>
        public const int VALERCODE_OK = 0;
        /// <summary>
        /// KHONG LOAD DUOC THONG TIN VE CHUNG KHOAN TU CSDL
        /// </summary>
        public const int VALERCODE_NO_INFO_LOAD = 10;
        /// <summary>
        /// KHONG CO THONG TIN VE CP NAY
        /// </summary>
        public const int VALERCODE_NO_STOCK_INFO = 11;
        /// <summary>
        /// HALT
        /// </summary>
        public const int VALERCODE_HALT = 1211;
        /// <summary>
        /// HALT AOM
        /// </summary>
        public const int VALERCODE_HALT_A = 12111;
        /// <summary>
        /// HALT PT
        /// </summary>
        public const int VALERCODE_HALT_P = 12112;
        /// <summary>
        /// SUSPENSION
        /// </summary>
        public const int VALERCODE_SUSPEND = 1212;
        /// <summary>
        /// DELIST
        /// </summary>
        public const int VALERCODE_DELIST = 1213;
        /// <summary>
        /// SAI BUOC GIA
        /// </summary>
        public const int VALERCODE_PRICE_STEP = 13;
        /// <summary>
        /// SAI BOARD LOT
        /// </summary>
        public const int VALERCODE_BOARDLOT = 14;
        /// <summary>
        /// VOL # PUBLISH VOL
        /// </summary>
        public const int VALERCODE_VOL_PUBVOL = 15;
        /// <summary>
        /// KHONG GUI LENH LO (1I) CHO TRAI PHIEU
        /// </summary>
        public const int VALERCODE_MATCHING_BONDS = 111;
        /// <summary>
        /// LON HON GIA TRAN
        /// </summary>
        public const int VALERCODE_ABOVE_CEILING = 121;
        /// <summary>
        /// NHO HON GIA SAN
        /// </summary>
        public const int VALERCODE_BELOW_FLOOR = 122;
        /// <summary>
        /// ATO KHONG DAT DUNG PHIEN -> HUY ATO
        /// </summary>
        public const int VALERCODE_ATO_SESSION_CANCEL = 2211;
        /// <summary>
        /// ATO DAT CHUA DEN PHIEN -> wait for correct session
        /// </summary>
        public const int VALERCODE_ATO_SESSION_WAIT = 2212;
        /// <summary>
        /// ATC KHONG DAT DUNG PHIEN -> huy ATC
        /// </summary>
        public const int VALERCODE_ATC_SESSION_CANCEL = 2221;
        /// <summary>
        /// ATC dat khong dung phien -> Wait for correct session
        /// </summary>
        public const int VALERCODE_ATC_SESSION_WAIT = 2222;
        /// <summary>
        /// MP KHONG DAT DUNG PHIEN HOAC BI CAM
        /// </summary>
        public const int VALERCODE_MP_SESSION_CANCEL = 2230;
        /// MP DAT CHUA DEN PHIEN -> wait for correct session
        /// </summary>
        public const int VALERCODE_MP_SESSION_WAIT = 2231;
        /// <summary>
        /// THI TRUONG CHUA SAN SAN DE DAT LENH MATCHING
        /// </summary>
        public const int VALERCODE_MATCHING_SESSION = 231;
        /// <summary>
        /// Khong huy lenh ATO
        /// </summary>
        public const int VALERCODE_CANCEL_ATO_INCORRECT = 241;
        /// <summary>
        /// Khong huy lenh ATC
        /// </summary>
        public const int VALERCODE_CANCEL_ATC_INCORRECT = 242;
        /// <summary>
        /// Khong duoc huy lenh trong phien P
        /// </summary>
        public const int VALERCODE_CANCEL_LO_PREOPEN_INCORRECT = 243;
        /// <summary>
        /// Khong duoc huy lenh LO trong cung phien dinh ky
        /// </summary>
        public const int VALERCODE_CANCEL_LO_SAME_SESSION_INCORRECT = 244;
        /// <summary>
        /// CP MOI NIEM YET KHONG DUOC GD THOA THUAN NGAY DAU TIEN
        /// </summary>
        public const int VALERCODE_NEWLIST_NOT_PT = 31;
        /// <summary>
        /// LON HON GIA TRAN (GD THOA THUAN)
        /// </summary>
        public const int VALERCODE_ABOVE_CEILING_PT = 32;
        /// <summary>
        /// NHO HON GIA SAN (GD THOA THUAN)
        /// </summary>
        public const int VALERCODE_BELOW_FLOOR_PT = 33;
        /// <summary>
        /// GD THOA THUAN CHO STOCK # PHIEN C -> KHONG DUOC PHEP
        /// </summary>
        public const int VALERCODE_STOCK_PT_SESSION = 34;
        /// <summary>
        /// gd thoa thuan cho CP volume phai >= 20000
        /// </summary>
        public const int VALERCODE_STOCK_PT_VOLUME = 35;
        /// <summary>
        /// KHONG CON ROOM CHO NDTNN
        /// </summary>
        public const int VALERCODE_ABOVE_ROOM = 41;
        /// <summary>
        /// KHACH HANG MUA, BAN CUNG LOAI CO PHIEU
        /// </summary>
        public const int VALERCODE_BUYSELL_ONE_STOCK = 42;

        static public bool ValidateOrderSession
        {
            get
            {
                int r;
                if (int.TryParse(ConfigurationManager.AppSettings["ValidateOrderSession"], out r))
                {
                    return (r == 1 ? true : false);
                }
                else
                    return true; //mac dinh la co'
            }
        }
        static public int FirmID
        {
            get
            {
                //return Program.sets.AppRelated.FirmID;

                int r;
                if (int.TryParse(ConfigurationManager.AppSettings["FirmID"], out r))
                    return r;
                else
                    return -1;
            }
        }
        static public int MatchingOrderInterval
        {
            get
            {
                int r;
                if (int.TryParse(ConfigurationManager.AppSettings["MatchingOrderInterval"], out r))
                    return r;
                else
                    return 3000; //default = 3s
            }
        }
        static public bool HasApprove
        {
            get
            {
                //return Program.sets.AppRelated.FirmID;

                int r;
                if (int.TryParse(ConfigurationManager.AppSettings["HasApprove"], out r))
                    return (r == 0 ? false : true);
                else
                    return true; //mac dinh la co duyet
            }
        }
        static public bool CheckPriceFromCore
        {
            get
            {
                //return Program.sets.AppRelated.FirmID;

                int r;
                if (int.TryParse(ConfigurationManager.AppSettings["CheckPriceFromCore"], out r))
                    return (r == 0 ? false : true);
                else
                    return true; //mac dinh la co duyet
            }
        }
        static public bool IsTest
        {
            get
            {
                //return Program.sets.AppRelated.FirmID;

                int r;
                if (int.TryParse(ConfigurationManager.AppSettings["IsTest"], out r))
                    return (r == 0 ? false : true);
                else
                    return true; //mac dinh la test
            }
        }
        static public int PTDealInterval
        {
            get
            {
                //return Program.sets.AppRelated.PtOrderInterval;

                int r;
                if (int.TryParse(ConfigurationManager.AppSettings["PTOrderInterval"], out r))
                    return r;
                else
                    return 3000; //default = 3s

            }
        }
        static public int MaxNumThread
        {
            get
            {
                //return Program.sets.AppRelated.MaxNumThread;

                int r;
                if (int.TryParse(ConfigurationManager.AppSettings["MaxNumThread"], out r))
                    return r;
                else
                    return 1;
            }
        }
        static public int PriceMultipleOperand
        {
            get
            {
                //return Program.sets.AppRelated.PriceMultipleOperand;

                int r;
                if (int.TryParse(ConfigurationManager.AppSettings["PriceMultipleOperand"], out r))
                    return r;
                else
                    return 1;
            }
        }
        static public int PriceMultipleOperandPT
        {
            get
            {
                //return Program.sets.AppRelated.PriceMultipleOperand;

                int r;
                if (int.TryParse(ConfigurationManager.AppSettings["PriceMultipleOperandPT"], out r))
                    return r;
                else
                    return 1000; //mac dinh la gap 1000 lan (vi don vi la 1tr, thong thuong don vi la 1000)
            }
        }
        static public int BasicOrderNumber
        {
            get
            {
                //return Program.sets.AppRelated.PriceMultipleOperand;

                int r;
                if (int.TryParse(ConfigurationManager.AppSettings["BasicOrderNumber"], out r))
                    return r;
                else
                    return 80000000; //mac dinh la 80.000.000 vi so OrderNumber se la 8000000x (8 chu so, nhu kieu cua san)
            }
        }
        static public string[] AdminMobiles
        {
            get
            {
                string mobiles = ConfigurationManager.AppSettings["AdminMobiles"];
                //string mobiles = Program.sets.AppRelated.AdminMobiles;
                return mobiles.Split(';');
            }
        }
        static public string ContactAddress
        {
            get
            {
                //return Program.sets.AppRelated.ContactAddress;
                return ConfigurationManager.AppSettings["ContactAddress"];
            }
        }
        static public string AppName
        {
            get
            {
                //return Program.sets.AppRelated.AppName;
                return ConfigurationManager.AppSettings["AppName"];
            }
        }
        static public string Board
        {
            get
            {
                return ConfigurationManager.AppSettings["Board"];
            }
        }
        static public string BoardPT
        {
            get
            {
                return ConfigurationManager.AppSettings["BoardPT"];
            }
        }
        static public string BoardOdd
        {
            get
            {
                //return Program.sets.AppRelated.BoardOdd;
                return ConfigurationManager.AppSettings["BoardOdd"];
            }
        }
        static public string CoreOnlineTradeCode
        {
            get
            {
                //return Program.sets.AppRelated.BoardOdd;
                return ConfigurationManager.AppSettings["CoreOnlineTradeCode"];
            }
        }
        static public string CoreOnlineBranchCode
        {
            get
            {
                //return Program.sets.AppRelated.BoardOdd;
                return ConfigurationManager.AppSettings["CoreOnlineBranchCode"];
            }
        }
        static public string CoreOnlineUser
        {
            get
            {
                //return Program.sets.AppRelated.BoardOdd;
                return ConfigurationManager.AppSettings["CoreOnlineUser"];
            }
        }
        //----
        static public string SBSGatewayUsername
        {
            get
            {
                //return Program.sets.AppRelated.BoardOdd;
                return ConfigurationManager.AppSettings["SBSGatewayUsername"];
            }
        }
        static public string SBSGatewayPassword
        {
            get
            {
                //return Program.sets.AppRelated.BoardOdd;
                return ConfigurationManager.AppSettings["SBSGatewayPassword"];
            }
        }
    }
}
