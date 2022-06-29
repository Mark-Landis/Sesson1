#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;


#endregion

namespace Sesson1
{
    [Transaction(TransactionMode.Manual)]
    public class Command01 : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;


            int num1 = 1;
            double num2 = 10.5;

            string txt1 = "Revit Add-in Academy";
            string filename = doc.PathName;

            double offset = 0.05;
            double offsetcalc = offset * doc.ActiveView.Scale;

            XYZ curpoint = new XYZ (0, 0, 0);
            XYZ offsetPoint = new XYZ(0,offsetcalc, 0);


            XYZ pnt1 = new XYZ(0,0,0); 
            XYZ pnt2 = new XYZ(1,1,1);

            double num3 = num1 + num2;
            double num4 = 5 + 5;
            double num5 = num4 % 2;

            List<string> lst1 = new List<string>();
            //strings.Add("item 1");
            //strings.Add("item 2");

            List<XYZ> points = new List<XYZ>();
            points.Add(pnt1);
            points.Add(pnt2);

            int range = 100;
            for(int i = 1;i<=100;i++)  //Defines for loop
            {
                num1 = num1 + 1;
            }

            string newString = "";
            foreach(string s in strings)
            {
                if(s == "item1")
                {
                    newString = "got to 1";
                }
                else if (s == "item2")
                {
                    newString = "got to 2";
                }
                else
                {
                    newString = "got somewhere else";
                }

                newString = newString + s;
            }

            double num6 = Method01(100, 100);

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(TextNoteType));

            Transaction t = new Transaction(doc, "Create Text Note");
            t.Start();
            TextNote myText = new TextNote.Create(doc, doc.ActiveView.Id, pnt1, "This is my text note", collector.FirstElementId);
            t.Commit();
            t.Dispose();


            return Result.Succeeded;
        }

        internal double Method01( double a, double b)
        {
            double c = a + b;
            Debug.Print("Got here: " + c.ToString());

            return c;   
        }
    }
}
