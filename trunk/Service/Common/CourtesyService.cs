using System;
using System.Collections;
using EzPos.DataAccess;
using EzPos.Model;

namespace EzPos.Service
{
    public class CourtesyService
    {
        private readonly CourtesyDataAccess _CourtesyDataAccess;

        public CourtesyService(CourtesyDataAccess CourtesyDataAccess)
        {
            _CourtesyDataAccess = CourtesyDataAccess;
        }

        public virtual IList GetCourtesies()
        {
            try
            {
                return _CourtesyDataAccess.GetCourtesies();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void InsertCourtesy(Courtesy Courtesy)
        {
            if (Courtesy == null)
                throw new ArgumentNullException("Courtesy", "Courtesy");

            try
            {
                _CourtesyDataAccess.InsertCourtesy(Courtesy);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}