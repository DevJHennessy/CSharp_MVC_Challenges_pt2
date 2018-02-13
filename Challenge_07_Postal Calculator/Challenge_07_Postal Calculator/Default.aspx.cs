using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Challenge_07_Postal_Calculator
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void groundRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //Ground multiplies by .15
            calculateVolume(0.15);

        }

        protected void airRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //Air multiplies by .25
            calculateVolume(0.25);
        }

        protected void nextDayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //Next Day multiplies by .45
            calculateVolume(0.45);
        }


        private void calculateVolume(double shippingMethodMultiplier)
        {
            if (widthTextBox.Text.Trim().Length == 0)
                return;
            if (heightTextBox.Text.Trim().Length == 0)
                return;

            double width = 0.0;
            double height = 0.0;
            double length = 0.0;
            if (!Double.TryParse(widthTextBox.Text, out width))
                return;
            if (!Double.TryParse(heightTextBox.Text, out height))
                return;
            if (!Double.TryParse(lengthTextBox.Text, out length))
                length = 1;


            double volume = width * height * length;

            double parcelCost = volume * shippingMethodMultiplier;

            resultLabel.Text = String.Format("Your pacel will cost {0:C} to ship.", parcelCost);

        }

    }
}