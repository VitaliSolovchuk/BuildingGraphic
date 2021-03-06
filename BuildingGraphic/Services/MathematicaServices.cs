﻿using System;
using BuildingGraphic.Models;


namespace BuildingGraphic.Services
{
    public class MathematicaServices
    {
        public int amountOfPoints;
        public float[] ReqestDataX { get; private set; }
        public float[] ResponseDataY { get; private set; }
        public string StrReqestDataX { get; private set; }
        public string StrResponseDataY { get; private set; }
        public EquationDTO ProcessedObject { get; private set; }

        public MathematicaServices(EquationDTO equationDTO)
        {
            ProcessedObject = equationDTO;
           
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
            ReqestDataX[i] = ProcessedObject.StartPosition;
           
            do {
                ResponseDataY[i] = GetValueEquation(ReqestDataX[i]);

                //Это обязательно прибрать
                StrReqestDataX = StrReqestDataX + ReqestDataX[i] + ", ";
                StrResponseDataY = StrResponseDataY + ResponseDataY[i] + ", ";


                i++;
                ReqestDataX[i] = ReqestDataX[i - 1] + ProcessedObject.Step;

            } while (i < amountOfPoints - 1);

            ResponseDataY[i] = GetValueEquation(ProcessedObject.StopPosition);

            //Это обязательно прибрать
            StrReqestDataX = StrReqestDataX + ReqestDataX[i];
            StrResponseDataY = StrResponseDataY + ResponseDataY[i];
        }
        public bool GetValid()
        {
            if (ProcessedObject.StartPosition < ProcessedObject.StopPosition)
            {
                return true;
            }
            return false;
        }
        private void GetSizeData()
        {
            int size;
            size = (int)Math.Ceiling((ProcessedObject.StopPosition - ProcessedObject.StartPosition) / ProcessedObject.Step);
            amountOfPoints = size + 1;
        }
        private float GetValueEquation(float x)
        {
            float y = ProcessedObject.CoefficientSecondDegrees * x * x + ProcessedObject.CoefficientFirstDegrees * x + ProcessedObject.CoefficientZeroDegrees;
            return y;
        }
    }
}