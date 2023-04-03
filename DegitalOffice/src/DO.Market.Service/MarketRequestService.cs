using BO.Core.DataCommon.Entities;
using DO.Common.Contract.Models;
using DO.Common.Domain;
using DO.Common.Domain.Interfaces;
using DO.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO.Market.Service;

public class CustodyRequestService : CommonServiceBase<long, MarketInfoRequestModel, MarketInfoRequest>
{
    public CustodyRequestService(IDataFactory dataFactory, ICacheService cacheService)
        : base(dataFactory, cacheService)
    {
    }

    protected override bool ValidateDelete(MarketInfoRequest custodyRequest)
    {
        return true;
    }

    protected override bool UseCache => false;

    protected override bool ValidateInsert(MarketInfoRequestModel model)
    {
        return true;
    }

    protected override bool ValidateUpdate(MarketInfoRequestModel model)
    {
        return true;
    }
}