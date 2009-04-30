using System;
using System.Collections;
using Castle.Services.Transaction;
using EzPos.DataAccess;
using EzPos.Model;
using EzPos.Utility;

namespace EzPos.Service
{
    /// <summary>
    /// Summary description for BarCodeService.
    /// </summary>
    [Transactional]
    public class BarCodeService
    {
        private readonly BarCodeDataAccess _BarCodeDataAccess;

        public BarCodeService(BarCodeDataAccess barCodeDataAccess)
        {
            _BarCodeDataAccess = barCodeDataAccess;
        }

        public IList GetBarCodes()
        {
            try
            {
                return _BarCodeDataAccess.GetBarCodes();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public BarCode AddBarCode()
        {
            try
            {
                IList barCodeList = _BarCodeDataAccess.GetBarCodes();
                BarCode barCode;
                if (barCodeList.Count == 0)
                {
                    barCode = new BarCode();
                    barCode.BarCodeValue = "RS00000001";
                }
                else
                {
                    barCode = (BarCode) barCodeList[barCodeList.Count - 1];
                    barCode.BarCodeValue = (Int32.Parse(barCode.BarCodeValue.Substring(2)) + 1).ToString();
                    barCode.BarCodeValue = "00000000" + barCode.BarCodeValue;
                    barCode.BarCodeValue = "RS" + StringHelper.Right(barCode.BarCodeValue, 8);
                }
                barCode.BarCodeDate = DateTime.Now;
                _BarCodeDataAccess.InsertBarCode(barCode);

                return barCode;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}