using System;
using System.Windows.Forms;

namespace LA1400
{
    public partial class LA1400 : Form
    {

        string selectionShape = "";
        string selectionCalculation = "";

        public LA1400()
        {
            InitializeComponent();
        }

        private void LA1400_Load(object sender, EventArgs e)
        {
            buttonRectangle.Checked = false;
            buttonArea.Checked = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            pictureShape.ImageLocation = "";
        }
        private void buttonShape_CheckedChanged(object sender, EventArgs e)
        {
            if (buttonRectangle.Checked)
            {
                selectionShape = "rectangle";
                pictureShape.ImageLocation = "..\\..\\..\\images\\" + selectionShape + ".gif";
                ShowBoxes();
            }
            if (buttonSquare.Checked)
            {
                selectionShape = "square";
                pictureShape.ImageLocation = "..\\..\\..\\images\\" + selectionShape + ".gif";
                ShowBoxes();
            }
            if (buttonTriangle.Checked)
            {
                selectionShape = "triangle";
                pictureShape.ImageLocation = "..\\..\\..\\images\\" + selectionShape + ".gif";
                ShowBoxes();
            }
            if (buttonCircle.Checked)
            {
                selectionShape = "circle";
                pictureShape.ImageLocation = "..\\..\\..\\images\\" + selectionShape + ".gif";
                ShowBoxes();
            }
        }
        private void buttonPerimeter_CheckedChanged(object sender, EventArgs e)
        {
            selectionCalculation = "perimeter";
        }
        private void buttonArea_CheckedChanged(object sender, EventArgs e)
        {
            selectionCalculation = "area";
        }
        private void buttonAreaPerimeter_CheckedChanged(object sender, EventArgs e)
        {
            selectionCalculation = "areaperimeter";
        }
        private void calculatorButton_Click(object sender, EventArgs e)
        {
            if (!(selectionShape == "" || selectionCalculation == ""))
            {
                Calculate(selectionShape, selectionCalculation);
            }
            else
            {
                ClearSettings();
                Console.Beep();
                MessageBox.Show("Bitte wählen Sie erst eine Form und eine Rechnung aus");
            }
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearSettings();
        }
        private void Calculate(string shape, string calc)
        {
            try
            {
                if (calc == "area")
                {
                    labelResult.Text = CalculateArea(shape);
                }
                else if (calc == "perimeter")
                {
                    labelResult.Text = CalculatePerimeter(shape);
                }
                else if (calc == "areaperimeter")
                {
                    labelResult.Text = CalculateArea(shape) + "\n" + CalculatePerimeter(shape);
                }
            }
            catch
            {
                ClearSettings();
                Console.Beep();
                MessageBox.Show("Ein Fehler ist aufgetreten.");
            }
        }
        private string CalculateArea(string shape)
        {
            double result = 0;
            switch (shape)
            {
                case "rectangle":
                    {
                        double height = double.Parse(textBox1.Text);
                        double width = double.Parse(textBox2.Text);
                        double area = width * height;
                        result = area;
                        break;
                    }
                case "square":
                    {
                        double site = double.Parse(textBox1.Text);
                        double area = site * site;
                        result = area;
                        break;
                    }
                case "triangle":
                    {
                        double y = double.Parse(textBox1.Text);
                        double x = double.Parse(textBox4.Text);
                        double area = (y * x) / 2;
                        result = area;
                        break;
                    }
                case "circle":
                    {
                        double radius = double.Parse(textBox1.Text);
                        double area = Math.PI * (radius * radius);
                        result = area;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return "Fläche: " + result;
        }
        private string CalculatePerimeter(string shape)
        {
            string result = "";
            switch (shape)
            {
                case "rectangle":
                    {

                        double height = double.Parse(textBox1.Text);
                        double width = double.Parse(textBox2.Text);
                        double perimeter = 2 * (height + width);
                        result = "Umfang: " + perimeter;
                        break;
                    }
                case "square":
                    {
                        double site = double.Parse(textBox1.Text);
                        double perimeter = 4 * site;
                        result = "Umfang: " + perimeter;
                        break;
                    }
                case "triangle":
                    {
                        double b = double.Parse(textBox1.Text);
                        double a = double.Parse(textBox2.Text);
                        double c = double.Parse(textBox3.Text);
                        double perimeter = a + b + c;
                        result = "Umfang: " + perimeter;
                        break;
                    }
                case "circle":
                    {
                        double radius = double.Parse(textBox1.Text);
                        double perimeter = Math.PI * (radius * 2);
                        result = "Umfang: " + perimeter;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return result;
        }
        private void ClearSettings()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            pictureShape.ImageLocation = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            buttonRectangle.Checked = false;
            buttonSquare.Checked = false;
            buttonCircle.Checked = false;
            buttonTriangle.Checked = false;
            buttonArea.Checked = false;
            buttonPerimeter.Checked = false;
            buttonAreaPerimeter.Checked = false;
            labelResult.Text = "";
        }
        private void ShowBoxes()
        {
            if (selectionCalculation != null)
            {
                switch (selectionShape)
                {
                    case "rectangle":
                        {
                            ClearBoxes();
                            label1.Visible = true;
                            label1.Text = "Länge";
                            label2.Visible = true;
                            label2.Text = "Breite";
                            textBox1.Visible = true;
                            textBox2.Visible = true;
                            break;
                        }
                    case "square":
                        {
                            ClearBoxes();
                            label1.Visible = true;
                            label1.Text = "Länge";
                            textBox1.Visible = true;
                            break;
                        }
                    case "triangle":
                        {
                            ClearBoxes();
                            textBox1.Visible = true;
                            textBox2.Visible = true;
                            textBox3.Visible = true;
                            textBox4.Visible = true;
                            label1.Visible = true;
                            label1.Text = "Längste Seite";
                            label2.Visible = true;
                            label2.Text = "Seite A";
                            label3.Visible = true;
                            label3.Text = "Seite B";
                            label4.Visible = true;
                            label4.Text = "Höhe";
                            break;
                        }
                    case "circle":
                        {
                            ClearBoxes();
                            label1.Visible = true;
                            label1.Text = "Radius";
                            textBox1.Visible = true;
                            break;
                        }
                }
            }
        }
        public void ClearBoxes()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
        }
        //"animate" pictues when entering & leaving the textbox
        private void textBox1_Enter(object sender, EventArgs e)
        {
            pictureShape.ImageLocation = "..\\..\\..\\images\\" + selectionShape + "_textBox1.gif";
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            pictureShape.ImageLocation = "..\\..\\..\\images\\" + selectionShape + ".gif";
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            pictureShape.ImageLocation = "..\\..\\..\\images\\" + selectionShape + "_textBox2.gif";
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            pictureShape.ImageLocation = "..\\..\\..\\images\\" + selectionShape + ".gif";
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            pictureShape.ImageLocation = "..\\..\\..\\images\\" + selectionShape + "_textBox3.gif";
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            pictureShape.ImageLocation = "..\\..\\..\\images\\" + selectionShape + ".gif";
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
            pictureShape.ImageLocation = "..\\..\\..\\images\\" + selectionShape + "_textBox4.gif";
        }
        private void textBox4_Leave(object sender, EventArgs e)
        {
            pictureShape.ImageLocation = "..\\..\\..\\images\\" + selectionShape + ".gif";
        }
    }
}