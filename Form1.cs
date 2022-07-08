using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Resume_Creator_or_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Details
        {
            public string FirstName { get; set; }
            public string MiddleInitial { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string ContactNumber { get; set; }
            public string Birthdate { get; set; }
            public string Age { get; set; }
            public string Sex { get; set; }
            public string Citizenship { get; set; }
            public string Email { get; set; }
            public string Primary { get; set; }
            public string JHS { get; set; }
            public string SHS { get; set; }
            public string Tertiary { get; set; }
            public string CareerObjectives { get; set; }
            public string EmployerCompanyName1 { get; set; }
            public string Details1 { get; set; }
            public string EmployerCompanyName2 { get; set; }
            public string Details2 { get; set; }
            public List<string> Skills { get; set; }

            public override string ToString()
            {
                {
                    return string.Format("RESUME:\n \nName: {0} {1} {2} \nAddress: {3} {4} \nContactNumber: {5} \nBirthdate: {6} \nAge: {7} \nSex: {8} \nCitizenship: {9} \nEmail: {10} \nPrimary: {11} \nJHS: {12} \nSHS: {13} \nTertiary: {14} \n\nCareerObjectives: {15}  \n\nEmployerCompanyName1: {16} \n* {17} \n\nEmployerCompanyName2: {18} \n* {19} \nSkills: {20}",
                                    FirstName, MiddleInitial, LastName, Address, ContactNumber, Birthdate, Age, Sex, Citizenship, Email, Primary, JHS, SHS, Tertiary, CareerObjectives, EmployerCompanyName1, Details1, EmployerCompanyName2, Details2, string.Join(",", Skills.ToArray()));
                }
            }
        }
        private void PDFtxtbox_Click(object sender, EventArgs e)
        {
            string file_name = lastnametxtbox.Text + "_" + firstnametxtbox.Text;
            iTextSharp.text.Document Doc = new iTextSharp.text.Document(PageSize.LETTER);
            PdfWriter.GetInstance(Doc, new FileStream(@"D:\DESKTOP\Ram Ymac\EDUCATION\OOP\JSON file\" + file_name + ".pdf", FileMode.Create));
            Doc.Open();
            System.Drawing.Image img = System.Drawing.Image.FromFile(@"D:\DESKTOP\Ram Ymac\EDUCATION\OOP\JSON JPEG\" + file_name + ".jpeg");
            iTextSharp.text.Image Itextimage = iTextSharp.text.Image.GetInstance(img, System.Drawing.Imaging.ImageFormat.Tiff);
            Itextimage.Alignment = Element.ALIGN_CENTER;
            Itextimage.ScaleToFit(563, 750);
            Doc.Add(Itextimage);
            Doc.Close();

            MessageBox.Show("Your Resume Has Been Successfully Saved!");
        }
        private void JSONtxtbox_Click(object sender, EventArgs e)
        {
            string file_name = lastnametxtbox.Text + "_" + firstnametxtbox.Text;
            try
            {
                Details details = new Details()
                {
                    FirstName = firstnametxtbox.Text,
                    MiddleInitial = mitxtbox.Text,
                    LastName = lastnametxtbox.Text,
                    Address = addresstxtbox.Text,
                    ContactNumber = contactnotxtbox.Text,
                    Birthdate = birthdatetxtbox.Text,
                    Age = agetxtbox.Text,
                    Sex = sextxtbox.Text,
                    Citizenship = citizenshiptxtbox.Text,
                    Email = emailtxtbox.Text,
                    Primary = primarytxtbox.Text,
                    JHS = jhstxtbox.Text,
                    SHS = shstxtbox.Text,
                    Tertiary = tertiarytxtbox.Text,
                    CareerObjectives = careerobjtxtbox.Text,
                    EmployerCompanyName1 = employertxtbox1.Text,
                    Details1 = Details1txtbox.Text,
                    EmployerCompanyName2 = employertxtbox2.Text,
                    Details2 = Details2txtbox.Text,
                    Skills = new List<string>
                    {
                        skill1.Text,
                        skill2.Text,
                        skill3.Text
                    }
                };
                string json = JsonConvert.SerializeObject(details, Formatting.None);
                File.WriteAllText(@"D:\DESKTOP\Ram Ymac\EDUCATION\OOP\JSON file\" + file_name + ".json", json);
                MessageBox.Show("Saved Successfully");

                json = string.Empty;
                json = File.ReadAllText(@"D:\DESKTOP\Ram Ymac\EDUCATION\OOP\JSON file\" + file_name + ".json");
                Details resultDetails = JsonConvert.DeserializeObject<Details>(json);
                resumertbox.Text = resultDetails.ToString();

            }
            catch 
            {
                //MessageBox.Show("Pls fill all sections");
            }
            using (var jpeg = new Bitmap(Resumepanel.Width, Resumepanel.Height))
            {
                Resumepanel.DrawToBitmap(jpeg, new System.Drawing.Rectangle(0, 0, jpeg.Width, jpeg.Height));
                jpeg.Save(@"D:\DESKTOP\Ram Ymac\EDUCATION\OOP\JSON JPEG\" + file_name + ".jpeg");
            }


        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EducPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void resumertbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}