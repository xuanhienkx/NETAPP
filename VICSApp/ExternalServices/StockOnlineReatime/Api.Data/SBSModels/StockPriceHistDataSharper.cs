using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Api.Data.SBSModels
{
    public sealed class StockPriceHistDataSharper : DataShaper<StockPriceHist>
    {
        public StockPriceHistDataSharper()
            : base(rd =>
            {
                var sph = new StockPriceHist
                {
                    AveragePrice = Convert.ToDecimal(rd.GetValue(rd.GetOrdinal("AveragePrice")).ToString().Trim() == "" ? "0" : rd.GetValue(rd.GetOrdinal("AveragePrice")).ToString().Trim()),
                    BasicPrice = Convert.ToDecimal(rd.GetValue(rd.GetOrdinal("BasicPrice")).ToString().Trim() == "" ? "0" : rd.GetValue(rd.GetOrdinal("BasicPrice")).ToString().Trim()),
                    Benefit = rd.GetValue(rd.GetOrdinal("Benefit")).ToString().Trim(),
                    BoardType = rd.GetValue(rd.GetOrdinal("BoardType")).ToString().Trim(),
                    CeilingPrice = Convert.ToDecimal(rd.GetValue(rd.GetOrdinal("CeilingPrice")).ToString().Trim() == "" ? "0" : rd.GetValue(rd.GetOrdinal("CeilingPrice")).ToString().Trim()),
                    ClosePrice = Convert.ToDecimal(rd.GetValue(rd.GetOrdinal("ClosePrice")).ToString().Trim() == "" ? "0" : rd.GetValue(rd.GetOrdinal("ClosePrice")).ToString().Trim()),
                    CoveredWarrantType = rd.GetValue(rd.GetOrdinal("CoveredWarrantType")).ToString().Trim(),
                    CurrentRoom = Convert.ToDecimal(rd.GetValue(rd.GetOrdinal("CurrentRoom")).ToString().Trim() == "" ? "0" : rd.GetValue(rd.GetOrdinal("CurrentRoom")).ToString().Trim()),
                    Delisted = rd.GetValue(rd.GetOrdinal("Delisted")).ToString().Trim(),
                    ExercisePrice = Convert.ToDecimal(rd.GetValue(rd.GetOrdinal("ExercisePrice")).ToString().Trim() == "" ? "0" : rd.GetValue(rd.GetOrdinal("ExercisePrice")).ToString().Trim()),
                    ExerciseRatio = rd.GetValue(rd.GetOrdinal("ExerciseRatio")).ToString().Trim(),
                    FloorPrice = Convert.ToDecimal(rd.GetValue(rd.GetOrdinal("FloorPrice")).ToString().Trim() == "" ? "0" : rd.GetValue(rd.GetOrdinal("FloorPrice")).ToString().Trim()),
                    Halted = rd.GetValue(rd.GetOrdinal("Halted")).ToString().Trim(),
                    IssuerName = rd.GetValue(rd.GetOrdinal("IssuerName")).ToString().Trim(),
                    LastTradingDate = rd.GetValue(rd.GetOrdinal("LastTradingDate")).ToString().Trim(),
                    ListedShare = Convert.ToDecimal(rd.GetValue(rd.GetOrdinal("ListedShare")).ToString().Trim() == "" ? "0" : rd.GetValue(rd.GetOrdinal("ListedShare")).ToString().Trim()),
                    MaturityDate = rd.GetValue(rd.GetOrdinal("MaturityDate")).ToString().Trim(),
                    Meeting = rd.GetValue(rd.GetOrdinal("Meeting")).ToString().Trim(),
                    Notice = rd.GetValue(rd.GetOrdinal("Notice")).ToString().Trim(),
                    OpenPrice = Convert.ToDecimal(rd.GetValue(rd.GetOrdinal("OpenPrice")).ToString().Trim() == "" ? "0" : rd.GetValue(rd.GetOrdinal("OpenPrice")).ToString().Trim()),
                    Split = rd.GetValue(rd.GetOrdinal("Split")).ToString().Trim(),
                    StockCode = rd.GetValue(rd.GetOrdinal("StockCode")).ToString().Trim(),
                    StockNo = Convert.ToInt32(rd.GetValue(rd.GetOrdinal("StockNo")).ToString().Trim() == "" ? "0" : rd.GetValue(rd.GetOrdinal("StockNo")).ToString().Trim()),
                    StockType = rd.GetValue(rd.GetOrdinal("StockType")).ToString().Trim(),
                    Suspension = rd.GetValue(rd.GetOrdinal("Suspension")).ToString().Trim(),
                    TotalRoom = Convert.ToDecimal(rd.GetValue(rd.GetOrdinal("TotalRoom")).ToString().Trim() == "" ? "0" : rd.GetValue(rd.GetOrdinal("TotalRoom")).ToString().Trim()),
                    TradingDate = rd.GetValue(rd.GetOrdinal("TradingDate")).ToString().Trim(),
                    TransactionDate = rd.GetDateTime(rd.GetOrdinal("TransactionDate")),
                    UnderlyingSymbol = rd.GetValue(rd.GetOrdinal("UnderlyingSymbol")).ToString().Trim()
                };
                return sph;
            })
        {
        }
    }
}
