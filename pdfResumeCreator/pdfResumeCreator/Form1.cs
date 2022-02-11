using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.IO;

namespace pdfResumeCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Createbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please Wait");
            string jsonpathfile = @"C:\Users\Computer\source\repos\pdfResumeCreator\pdfResumeCreator\pdfresumecreator.json";
            string openfile = File.ReadAllText(jsonpathfile);
            jsonreader jsonoutput = JsonConvert.DeserializeObject<jsonreader>(openfile);
            Document resume = new Document();
            PdfWriter.GetInstance(resume, new FileStream(@"C:\Users\Computer\source\repos\pdfResumeCreator\pdfResumeCreator\NATIVIDAD_MARYANN.pdf",FileMode.Create));
            LineSeparator separate = new LineSeparator(3f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, 1);
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(jsonoutput.image);
            image.ScalePercent(14f);
            image.Alignment = 6;
        


            Paragraph myname = new Paragraph(jsonoutput.Full_name+"\n");
            Paragraph add = new Paragraph(jsonoutput.Address);
            Paragraph Phnum = new Paragraph(jsonoutput.Phone_number);
            Paragraph telnum = new Paragraph(jsonoutput.Tel_number);
            Paragraph emailadd = new Paragraph(jsonoutput.email_address+"\n\n");
            Paragraph educattain = new Paragraph("Educational Attainment:\n\n"+jsonoutput.Tertiary+"\n\n"+jsonoutput.Secondary+"\n\n"+jsonoutput.Elementary+"\n\n");
            Paragraph workexp = new Paragraph("Work Experience:\n\n" + jsonoutput.Position +jsonoutput.Company_Name + "\n\n"+jsonoutput.Position1 + jsonoutput.Company_Name1+"\n\n");
            Paragraph prsnldata = new Paragraph("Personal Data:\n\n" + jsonoutput.nick_name + "\n\n" + jsonoutput.height + "\n\n" + jsonoutput.citizenship + "\n\n" + jsonoutput.date_of_birth + "\n\n" +
                jsonoutput.religion + "\n\n" + jsonoutput.Language);

            resume.Open();
            resume.Add(image);
            resume.Add(myname);
            resume.Add(add);
            resume.Add(Phnum);
            resume.Add(telnum);
            resume.Add(emailadd);
            resume.Add(separate);
            resume.Add(educattain);
            resume.Add(separate);
            resume.Add(workexp);
            resume.Add(separate);
            resume.Add(prsnldata);
            resume.Close();

        }
        public class jsonreader
        {
            public string Full_name
            {
                get; set;
            }
           public string image
            {
                get; set;
            }
            public string Phone_number
            {
                get; set;
            }
            public string Address
            {
                get; set;
            }
            public string Tel_number
            {
                get; set;
            }
            public string email_address
            {
                get; set;
            }
            public string Secondary
            {
                get; set; 
            }
            public string Tertiary
            {
                get; set;
            }
            public string Elementary
            {
                get; set;
            }
            public string Position
            {
                get; set;
            }
            public string Company_Name
            {
                get; set;
            }
            public string Position1
            {
                get; set;
            }
            public string Company_Name1
            {
                get; set;
            }
            public string nick_name
            {
                get; set;
            }
            public string height
            {
                get; set;
            }
            public string citizenship
            {
                get; set;
            }
            public string date_of_birth
            {
                get; set;
            }
            public string religion
            {
                get; set;
            }
            public string Language
            {
                get; set;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
