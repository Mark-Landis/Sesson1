#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace Sesson1
{
    [Transaction(TransactionMode.Manual)]
    public class Command01Challenge : IExternalCommand
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

            double offset = 0.05;
            double offsetcalc = offset * doc.ActiveView.Scale;

            XYZ curPoint = new XYZ(20, 0, 0);
            XYZ offsetPoint = new XYZ(0, offsetcalc, 0);

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(TextNoteType));

            Transaction t = new Transaction(doc, "FizzBuzz");
            t.Start();


            for (int i = 1; i <= 100; i++)  //Defines for loop
            {
                if (i % 3 ==0 && i % 5 ==0)
                {
                    TextNote curNote = TextNote.Create(doc, doc.ActiveView.Id, curPoint, "FIZZBUZZ", collector.FirstElementId());
                    curPoint = curPoint.Subtract(offsetPoint);
                }
                else if (i % 3 == 0)
                {
                    TextNote curNote = TextNote.Create(doc, doc.ActiveView.Id, curPoint, "FIZZ", collector.FirstElementId());
                    curPoint = curPoint.Subtract(offsetPoint);
                }
                else
                {
                    TextNote curNote = TextNote.Create(doc, doc.ActiveView.Id, curPoint, i.ToString(), collector.FirstElementId());
                    curPoint = curPoint.Subtract(offsetPoint);
                }

            }


            t.Commit();
            t.Dispose();

            return Result.Succeeded;
        }
    }
}
