using BusinessLogicLayer.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.BusinessModels
{
    class MathematicaBusinessModel
    {
        public int amountOfPoints;
        public int[] ReqestDataX { get; private set; }
        public int[] ResponseDataY { get; private set; }
        public string StrReqestDataX { get; private set; }
        public string StrResponseDataY { get; private set; }
        public UserDataDTO ProcessedObject { get; private set; }

        public MathematicaBusinessModel(UserDataDTO userDataDTO)
        {
            ProcessedObject = userDataDTO;

        }
        public UserDataDTO BuildingVisualisation()
        {
            GetSizeData();
            ResponseDataY = new int[amountOfPoints];
            ReqestDataX = new int[amountOfPoints];
            SetDataForVisualisation();
            UpdateUserData();

            return ProcessedObject;
        }
        private void UpdateUserData()
        {
            ICollection<PointDTO> points = new List<PointDTO>();
            for (int k = 0; k < ReqestDataX.Length; k++)
            {
                points.Add(new PointDTO()
                {
                    PointX = ReqestDataX[k],
                    PointY = ResponseDataY[k]
                });
            }
            ProcessedObject.PointList = points;
        }
        private void SetDataForVisualisation()
        {
            int i = 0;
            ReqestDataX[i] = ProcessedObject.RangeFrom;
            do
            {
                ResponseDataY[i] = GetValueEquation(ReqestDataX[i]);
                //Это обязательно прибрать
                StrReqestDataX = StrReqestDataX + ReqestDataX[i] + ", ";
                StrResponseDataY = StrResponseDataY + ResponseDataY[i] + ", ";
                
                i++;
                ReqestDataX[i] = ReqestDataX[i - 1] + ProcessedObject.Step;
            } while (i < amountOfPoints - 1);
            
            ResponseDataY[i] = GetValueEquation(ProcessedObject.RangeTo);
           
            //Это обязательно прибрать
            StrReqestDataX = StrReqestDataX + ReqestDataX[i];
            StrResponseDataY = StrResponseDataY + ResponseDataY[i];
        }
        public bool GetValid()
        {
            if (ProcessedObject.RangeFrom < ProcessedObject.RangeTo)
            {
                return true;
            }
            return false;
        }
        private void GetSizeData()
        {
            int size;
            size = (ProcessedObject.RangeTo - ProcessedObject.RangeFrom) / ProcessedObject.Step;
            amountOfPoints = size + 1;
        }
        private int GetValueEquation(int x)
        {
            int y = ProcessedObject.CoefficientSecondDegrees * x * x + ProcessedObject.CoefficientFirstDegrees * x + ProcessedObject.CoefficientZeroDegrees;
            return y;
        }
    }
}
