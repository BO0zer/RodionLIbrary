using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Correlation
{
    public abstract class PirsonCor
    {
        public static PirsonCorAnswer GetCor(double meanX, double meanY, double meanXY, double meanX2, double meanY2)
        {
            double sdX = Math.Sqrt(meanX2 - Math.Pow(meanX, 2));
            double sdY = Math.Sqrt(meanY2 - Math.Pow(meanY, 2));
            double cov = meanXY - meanX * meanY;
            double cor = cov / (sdX * sdY);

            string formula = "Sx = √(X^2 - (X\x0305)^2); Sy = √(Y^2 - (Y\x0305)^2); K*(X,Y) = XY - X*Y; r*(X,Y) = K*(X,Y) / (Sx * Sy)";
            string calculation = $"Sx = √({meanX2} - {meanX}^2) = {sdX}; Sy = √({meanY2} - {meanY}^2) = {sdY}; K*(X,Y) = {meanXY} - {meanX}*{meanY} = {cov}; r*(X,Y) = {cov} / ({sdX} * {sdY}) = {cor}";

            return new PirsonCorAnswer(cor, formula, calculation);
        }
    }
}
