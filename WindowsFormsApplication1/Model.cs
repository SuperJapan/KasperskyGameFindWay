using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Model
    {
        ViewModel vModel;
        public Model(ViewModel vModel)
        {
            this.vModel = vModel;
        }

        public bool isCorrectData(string wayBlock1, string wayBlock2)
        {
            bool isCorrect = true;
            if (wayBlock1.Length != wayBlock2.Length) isCorrect = false;
            if (wayBlock1.Length < 2) isCorrect = false;

            return isCorrect;
        }
        
        public void startGame(string wayBlock1, string wayBlock2)
        {
            this.vModel.clearTextBox();
            this.vModel.addLine("START GAME");
       
            bool isExistWay = testWays(wayBlock1, wayBlock2);
            vModel.setScreenColor((isExistWay ? Color.Green : Color.Red));
            
            this.vModel.addLine("WAY IS" + (isExistWay ? " EXIST":" NOT EXIST"));
            
            if (isExistWay)
            {
                this.vModel.addLine(" ");
                this.vModel.addLine("RIGHT WAY SCHEME:");
                
                string w1 = "", w2 = "";
                List<string> wList = getRightWay(wayBlock1, wayBlock2);
                w1 = wList[0];
                w2 = wList[1];
                this.vModel.addLine(w1);
                this.vModel.addLine(w2);                
            }

            this.vModel.addLine(" ");
            this.vModel.addLine(" ..PRESS BUTTON FOR NEW GAME");
        }

        private bool testWays(string wayBlock1, string wayBlock2)
        {
            bool isExistWay = true;

            if (wayBlock2.Substring(wayBlock2.Length - 1, 1) != ".")
                return false;
            
            for (int w = 0; w < wayBlock1.Length; w++)
            {
                string b1 = wayBlock1.Substring(w, 1);
                string b2 = wayBlock2.Substring(w, 1);
                if (b1 != "." && b1 == b2) { isExistWay = false; break; }
            }
            return isExistWay;
        }

        private List<string> getRightWay(string wayBlock1, string wayBlock2)
        {
            List<string> resList = new List<string>();
            string way1 = "", way2 = "", w1 = "", w2 = "";
            int yPrev = 0;
            for (int w = 0; w < wayBlock1.Length; w++)
            {
                string b1 = w1 = wayBlock1.Substring(w, 1);
                string b2 = w2 = wayBlock2.Substring(w, 1);
                
                if (b1 == "." && b2 != ".") w1 = "=";
                if (b2 == "." && b1 != ".") w2 = "=";
                if (b1 == "." && b2 == ".") if (yPrev == 0) w1 = "="; else w2 = "=";
                if (w == wayBlock1.Length - 1) w2 = "=";
                
                yPrev = (w1 == "=" ? 0 : 1);
                
                way1 += w1 + (w1 == "." ? " " : "");
                way2 += w2 + (w2 == "." ? " " : "");
            }

            resList.Add(way1);
            resList.Add(way2);
            return resList;
        }
    }
}
