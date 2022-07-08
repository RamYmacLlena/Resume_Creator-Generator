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
            public string Name { get; set; }
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
                                    Name, Address, ContactNumber, Birthdate, Age, Sex, Citizenship, Email, Primary, JHS, SHS, Tertiary, CareerObjectives, EmployerCompanyName1, Details1, EmployerCompanyName2, Details2, string.Join(",", Skills.ToArray()));
                }
            }
        }
        private void PDFtxtbox_Click(object sender, EventArgs e)
        {
            string file_name = nametxtbox.Text;
            using (SaveFileDialog save = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true, FileName = file_name })
            {
                if (save.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.LETTER);
                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));
                        doc.Open();
                        doc.Add(new iTextSharp.text.Paragraph(resumertbox.Text));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        doc.Close();
                        MessageBox.Show("File has been saved successfully");
                    }
                }
            }
        }
        private void JSONtxtbox_Click(object sender, EventArgs e)
        {

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
    }
}