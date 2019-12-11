using System;
using BuildingGraphic.Models;

namespace BuildingGraphic.Services
{
    public class MathematicaServices
    {
        public EquationDTO ProcessedObject { get; private set; }
        public MathematicaServices(EquationDTO equationDTO)
        {
            ProcessedObject = equationDTO;
        }

        public float[] GetDataForVisualisation()
        {
            int amountOfPoints = GetSizeData();
            float[] responseData = new float[amountOfPoints];
            
            int i = 0;
            float x = ProcessedObject.StartPosition;
            do {
                responseData[i] = GetValueEquation(x);
                x += ProcessedObject.Step;
                i++;
            } while (i < amountOfPoints);

            responseData[i] = GetValueEquation(ProcessedObject.StopPosition);

            return responseData;
        }

        private int GetSizeData()
        {
            int size;
            size = (int)Math.Ceiling((ProcessedObject.StopPosition - ProcessedObject.StartPosition) / ProcessedObject.Step);
            return size;
        }

        private float GetValueEquation(float x)
        {
            float y = ProcessedObject.CoefficientSecondDegrees * x * x + ProcessedObject.CoefficientFirstDegrees * x + ProcessedObject.CoefficientZeroDegrees;
            return y;
        }
    }
}