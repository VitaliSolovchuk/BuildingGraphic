﻿using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BusinessModels
{
    class MathematicaBusinessModel
    {
        public int amountOfPoints;
        public float[] ReqestDataX { get; private set; }
        public float[] ResponseDataY { get; private set; }
        public string StrReqestDataX { get; private set; }
        public string StrResponseDataY { get; private set; }
        public UserDataDTO ProcessedObject { get; private set; }

        public MathematicaBusinessModel(UserDataDTO userDataDTO)
        {
            ProcessedObject = userDataDTO;

        }

        public void BuildingVisualisation()
        {
            GetSizeData();
            ResponseDataY = new float[amountOfPoints];
            ReqestDataX = new float[amountOfPoints];
            SetDataForVisualisation();
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
        private float GetValueEquation(float x)
        {
            float y = ProcessedObject.CoefficientSecondDegrees * x * x + ProcessedObject.CoefficientFirstDegrees * x + ProcessedObject.CoefficientZeroDegrees;
            return y;
        }
    }
}
