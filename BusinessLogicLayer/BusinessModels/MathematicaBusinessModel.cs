using BusinessLogicLayer.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.BusinessModels
{
    class MathematicaBusinessModel
    {
        public int amountOfPoints;
        public int[] ReqestDataX { get; private set; }
        public int[] ResponseDataY { get; private set; }
        public UserDataDTO ProcessedObject { get; private set; }

        public MathematicaBusinessModel(UserDataDTO userDataDTO)
        {
            ProcessedObject = userDataDTO;

        }
        public bool GetValid()
        {
            if (ProcessedObject.RangeFrom < ProcessedObject.RangeTo)
            {
                return true;
            }
            return false;
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

        private void GetSizeData()
        {
            int size;
            size = (ProcessedObject.RangeTo - ProcessedObject.RangeFrom) / ProcessedObject.Step;
            amountOfPoints = size + 1;
        }
        private void UpdateUserData()
        {
            IList<PointDTO> points = new List<PointDTO>();
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
                ReqestDataX[i + 1] = ReqestDataX[i] + ProcessedObject.Step;
                i++;
            } while (i < amountOfPoints - 1);

            ReqestDataX[i] = ProcessedObject.RangeTo;
            ResponseDataY[i] = GetValueEquation(ProcessedObject.RangeTo);
           
        }
        private int GetValueEquation(int x)
        {
            int y = ProcessedObject.CoefficientSecondDegrees * x * x + ProcessedObject.CoefficientFirstDegrees * x + ProcessedObject.CoefficientZeroDegrees;
            return y;
        }
    }
}
