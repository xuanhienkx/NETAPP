namespace HoseContinentialGT.Messaages
{  using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    internal struct Securities
    {
        [MarshalAs(UnmanagedType.U2)]
        internal ushort StockNo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
        internal char[] stockSymbol;
        [MarshalAs(UnmanagedType.U1)]
        internal char StockType;
        internal int Ceiling;
        internal int Floor;
        internal double BigLotValue;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x19)]
        internal char[] stockName;
        [MarshalAs(UnmanagedType.U1)]
        internal char SectorNo;
        [MarshalAs(UnmanagedType.U1)]
        internal char Designated;
        [MarshalAs(UnmanagedType.U1)]
        internal char Suspension;
        [MarshalAs(UnmanagedType.U1)]
        internal char Delist;
        [MarshalAs(UnmanagedType.U1)]
        internal char HaltResumeFlag;
        [MarshalAs(UnmanagedType.U1)]
        internal char Split;
        [MarshalAs(UnmanagedType.U1)]
        internal char Benefit;
        [MarshalAs(UnmanagedType.U1)]
        internal char Meeting;
        [MarshalAs(UnmanagedType.U1)]
        internal char Notice;
        [MarshalAs(UnmanagedType.U1)]
        internal char ClientIDRequired;
        internal short CouponRate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
        internal char[] issueDate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
        internal char[] matureDate;
        internal int AveragePrice;
        internal short ParValue;
        [MarshalAs(UnmanagedType.U1)]
        internal char SDCFlag;
        internal int PriorClosePrice;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=6)]
        internal char[] priorCloseDate;
        internal int ProjectOpen;
        internal int OpenPrice;
        internal int LastPrice;
        internal int LastVolume;
        internal double LastValue;
        internal int Highest;
        internal int Lowest;
        internal double TotalShares;
        internal double TotalValue;
        internal short AccumulateDeal;
        internal short BigDeal;
        internal int BigVolume;
        internal double BigValue;
        internal short OddDeal;
        internal int OddVolume;
        internal double OddValue;
        internal int Best1Bid;
        internal int Best1BidVolume;
        internal int Best2Bid;
        internal int Best2BidVolume;
        internal int Best3Bid;
        internal int Best3BidVolume;
        internal int Best1Offer;
        internal int Best1OfferVolume;
        internal int Best2Offer;
        internal int Best2OfferVolume;
        internal int Best3Offer;
        internal int Best3OfferVolume;
        internal short BoardLot;
        // CoveredWarrant
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        internal char[] underlyingSymbol;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)]
        internal char[] issuerName;
        [MarshalAs(UnmanagedType.U1)]
        internal char CoveredWarrantType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        internal char[] maturityDate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        internal char[] lastTradingDate;
        internal int ExercisePrice;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
        internal char[] exerciseRatio;
        internal double ListedShare;
        internal string StockSymbol
        {
            get
            {
                return new string(this.stockSymbol).Trim();
            }
        }
        internal string StockName
        {
            get
            {
                return new string(this.stockName).Trim();
            }
        }
        internal string IssueDate
        {
            get
            {
                return new string(this.issueDate).Trim();
            }
        }
        internal string MatureDate
        {
            get
            {
                return new string(this.matureDate).Trim();
            }
        }
        internal string PriorCloseDate
        {
            get
            {
                return new string(this.priorCloseDate).Trim();
            }
        }
        //CoveredWarrant
        internal string UnderlyingSymbol
        {
            get
            {
                return new string(this.underlyingSymbol).Trim();
            }
        }
        internal string IssuerName
        {
            get
            {
                return new string(this.issuerName).Trim();
            }
        }
        internal string MaturityDate
        {
            get
            {
                return new string(this.maturityDate).Trim();
            }
        }
        internal string LastTradingDate
        {
            get
            {
                return new string(this.lastTradingDate).Trim();
            }
        }
        internal string ExerciseRatio
        {
            get
            {
                return new string(this.exerciseRatio).Trim();
            }
        } 
    }
}
